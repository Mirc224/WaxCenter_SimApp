using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WaxCenter_SimApp.DataStructures;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Events.BaseEvents;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Results;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Settings;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents.SimulationComponentsWrapper;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Core
{
    // Enum symbolizujuci stavy simulacie
    public enum SimulationStatus
    {
        FINISHED,
        CANCELED,
        PAUSED,
        RUNNING,
        INTERRUPTED
    }
    // Struktura obsahujuca parameter CurrentTime. Pouziva sa pri update real time simulacie. Konstruktor sa stara o prevod poskytnuteho casu v sekundach na ludsky citatelny format.
    public struct ClockUpdateData
    {
        public string CurrentTime;
        public ClockUpdateData(double currTime)
        {
            TimeSpan t = TimeSpan.FromSeconds(currTime);
            CurrentTime = t.ToString(@"hh\:mm\:ss");
        }
    }
    public abstract class EventSimulationCore : ISimulation
    {
        /**
         * Trieda, ktora predsavuje simulacne jadro udaloste orientovanej simulacie
         */

        // Enum obsahujuci casove jednotky a ich prevody na sekundy
        public enum TimeUnits
        {
            SECONDS = 1,
            MINUTES = 60,
            HOURS = 3600
        }

        // Pociatocny cas v sekundach. Pouziva sa pri formatovani casoveho vystupu hodin.
        public double StartTimeInSeconds { get; set; } = 0; 
        // Aktualny status simulacie
        public SimulationStatus Status { get; set; } = SimulationStatus.FINISHED;
        // Parovacia halda predstavujuca kalendar udalosti. Su do nej vkladane udalosti s casom ich vyskytu.
        public PairingHeap<double, SimEvent> EventCalendar { get; protected set; } = new PairingHeap<double, SimEvent>();
        // Trieda, ktora obsahuje vysledky vykonanych replikacii. V pripade ak nebude restovana, bude pokracovat v zbere statistik aj v dalsich replikaciach.
        public ReplicationsResults ReplicationResults { get; protected set; }
        // Referencia na kontroler, ktory tvori spojovaciu cast medzi logiou a grafickou castou
        public Controller.Controller Controller { get; set; }
        // Generator seedov pre generatory v simulacii
        public Random SeedGenerator { get; protected set; }
        // Sucasny simulacny cas
        public double CurrentTime { get; protected set; } = 0;
        // Manazer simulacnych komponentov. Obsahuje simulacne komponenty a umoznuje ich lahke resetovanie alebo updatovanie
        public SimulationComponentsManager SimulationComponentsManager { get; protected set; } = new SimulationComponentsManager();
        // Zakladne nastavenia simulacie
        public BaseEventSimulationSettings SimulationSettings { get; protected set; } = new BaseEventSimulationSettings();
        // Rychlost vykonavania simulacie
        public int Speed { get => SimulationSettings.Speed; set => SimulationSettings.Speed = value; }
        public double MaxTime { get => SimulationSettings.MaxTime *(int)SimulationSettings.Units ; set => SimulationSettings.MaxTime = value; }
        // Maximalny cas simulacie v sekundach
        private double _realMaxTimeInSec { get => SimulationSettings.MaxTime; }
        // Informacia o tom, ci ma simulacia pokracovat aj po dovrseni MaxTime
        public bool ContinueAfterMaxTime { get=> SimulationSettings.ContinueAfterMaxTime; set => SimulationSettings.ContinueAfterMaxTime = value; }
        // Pocet sekund od 00:00:00 po sucasny simulacny cas
        public double ClockTimeInSeconds { get => CurrentTime + StartTimeInSeconds; }
        // Propertie na nastavenie a ziskavanie Seedu. 
        public int Seed { 
            get => SimulationSettings.LastUsedSeed; 
            set 
            {
                SimulationSettings.LastUsedSeed = value;
                SetSeed(SimulationSettings.LastUsedSeed);
            } 
        }
        // Informacia o tom, ci ma byt v simulacii pouzity AutoSeed alebo pouzivatelom nastaveny seed.
        public bool AutoSeed 
        { 
            get => SimulationSettings.AutoSeed;
            set
            {
                SimulationSettings.AutoSeed = value;
                if (value)
                    SetSeed();
                else
                    SetSeed(SimulationSettings.LastUsedSeed);
            } 
        }
        
        public EventSimulationCore(Controller.Controller controller, double maxTime = 0)
        {
            Controller = controller;
            MaxTime = maxTime;
        }
        public void AfterReplication()
        {
            // Po kazdej replikacii sa updatuju hodnoty v triede ReplicationsResults
            UpdateReplicationResults();
        }

        public void AfterSimulation()
        {
            throw new NotImplementedException();
        }

        public virtual void BeforeReplication()
        {
            // Pred kazdou replikaciou dojde k resetovaniu simulacie
            ResetSimulation();
        }

        public void BeforeSimulation()
        {
            // Pred kazdou simulaciou sa nastavi seed v zavislosti od toho, ci je zvoleny auto seed, alebo vlastny seed
            if (SimulationSettings.AutoSeed)
                SetSeed();
            else
                SetSeed(SimulationSettings.LastUsedSeed);
            if (ReplicationResults != null)
                ReplicationResults.Reset();
        }
        protected void UpdateReplicationResults()
        {
            // Po konci replikacie dojde k aktualizacii vysledkov. Pocet vykonanych replikacii sa zvysi o 1. V pripade, ak sa pokracuje po MaxTime, pripocita sa aj nadcas pre tuto replikaciu
            ++ReplicationResults.CurrentReplications;
            if(ContinueAfterMaxTime)
                ReplicationResults.OverTime += CurrentTime - _realMaxTimeInSec;

            ReplicationResults.AfterReplicationUpdate();
        }

        
        public void ResetSimulation()
        {
            // Resetovanie simulacie spociva v nastaveni jej statusu na ukonceny, aktualny cas je nastaveny na 0. Kalendar udalosti je vynulovany a aj hodnoty jednotlivych komponentov su vyresetovane.
            Status = SimulationStatus.FINISHED;
            CurrentTime = 0;
            EventCalendar.Reset();
            ResetComponents();
            ResetStatistics();
        }
        protected virtual void ResetComponents()
        {
            // Pomocou manazera komponentov resetuje hodnoty vsetkych komponentov simulacie
            SimulationComponentsManager.ResetAllComponents();
        }
        protected virtual void ResetStatistics()
        {
            // Resetuje statistiky simulacie.
            if (SimulationComponentsManager.Statistics != null)
                for (int i = 0; i < SimulationComponentsManager.Statistics.Length; ++i)
                    SimulationComponentsManager.Statistics[i].Reset();
        }
        protected void SetSeed()
        {
            // Setter automatickeho seedu.
            SeedGenerator = new Random();
            SeedIt();
        }
        protected void SetSeed(int seed)
        {
            // Setter pozadovaneho seedu.
            SimulationSettings.LastUsedSeed = seed;
            SeedGenerator = new Random(seed);
            SeedIt();
        }
        protected virtual void SeedIt()
        {
            SimulationComponentsManager.SetComponetsSeed(SeedGenerator);
        }
        // Metoda, ktora sa stara o ukoncenie vsetkych spojitych statistik. 
        protected abstract void FinishContinuousStatistics();
        public virtual void DoReplication()
        {
            // Hlavna simulacna slucka.
            SimEvent currentEvent = null;
            if (EventCalendar.Count == 0)
            {
                // V pripade ak je kalendar prazdny, naplanuje sa prvy event.
                PlanFirstEvent();
            }
            // Simulacny cas sa nastavi na hodnotu 0
            CurrentTime = 0;
            // Slucka sa vykonava dovtedy, kym kalendar udalosti nie je prazdny alebo kym nie je dosiahnuty maximalny simulacny cas. V pripade ze je nastavene pokracovanie po MaxTime
            // je podmienka posledna podmienka ignorovana.
            while (EventCalendar.Count != 0 && (CurrentTime <= _realMaxTimeInSec || ContinueAfterMaxTime))
            {
                // Z kalendara sa vyberie udalost s najmensim casom vyskytu udalosti.
                currentEvent = EventCalendar.GetMin();
                // Simulacny cas sa nastavi na cas vyskytu danej udalosti.
                CurrentTime = currentEvent.OccurrenceTime;
                // Udalost sa vykona
                currentEvent.Execute();
            }
        }
        public void ResetGenerators()
        {
            // Metoda strarajuca sa o resetovanie generatorov
            if (AutoSeed)
                SetSeed();
            else
                SetSeed(Seed);
        }

        // V ramci tejto metody je naplanovay prvy event.
        protected abstract void PlanFirstEvent();
        // Metoda v ktorej bezi RealTime simulacia. Je podobna metode DoReplication avsak obsahuje v sebe aj cakanie pre simulovanie plynutia casu
        public virtual SimulationStatus RunRealTimeSimulation()
        {
            SimEvent currentEvent = null;
            // V pripade ak bola simulacia ukoncena alebo zrusena, tak je naplanovany prvy event.
            if (EventCalendar.Count == 0 && (Status == SimulationStatus.CANCELED || Status == SimulationStatus.FINISHED))
            {
                PlanFirstEvent();
            }
            // Status simulacie sa nastavi na Running
            Status = SimulationStatus.RUNNING;
            double nextEventTime;
            while (EventCalendar.Count != 0 && (CurrentTime <= _realMaxTimeInSec || ContinueAfterMaxTime))
            {
                // Z kalendara sa ziska s najmensi caso vyskytu udalosti
                nextEventTime = EventCalendar.Peek;
                while (CurrentTime < nextEventTime)
                {
                    // V pripade ak je cas vyskytu udalosti vacsi ako sucasny cas vyskytu, tak su spustene hodiny, ktre simuluju plynutie casu.
                    CurrentTime += RunClock(nextEventTime - CurrentTime);
                    if (nextEventTime < CurrentTime)
                        CurrentTime = nextEventTime;
                    // Po behu hodin je v kontorlery zavolana metoda pre aktualizaiu casu na GUI.
                    Controller.ClockUpdate();
                    // Kontroluje sa, ze ci nahodou simulacia cakanim neprekrocila MaxTime.
                    if (CurrentTime > _realMaxTimeInSec && !ContinueAfterMaxTime)
                    {
                        Status = SimulationStatus.FINISHED;
                        return Status;
                    }
                    // Kontorla, ci nebola zaznamenana ziadost o pozastavenie alebo zrusenie behu simulacie
                    if (Controller.RealTimeCancellation)
                    {
                        Status = SimulationStatus.CANCELED;
                        return Status;
                    }
                }
                // Simulacny cas sa nastvi na cas eventu a je vykonany
                CurrentTime = nextEventTime;
                currentEvent = EventCalendar.GetMin();
                CurrentTime = currentEvent.OccurrenceTime;
                currentEvent.Execute();
                // Po vykonani eventu je pomocou kontorlera zaslana informacia u potrebe aktualizacie grafickeho rozhrania
                Controller.AfterEventUpdate();
            }
            Status = SimulationStatus.FINISHED;
            return Status;
        }

        public double RunClock(double timeDifference)
        {
            // Metoda hodin, ktora robi iluziu plynutia casu.
            // Podla aktualne nastavenej rychlosti su navratene hodnoty.
            int actualSpeed = Speed;
            // Ak je rychlost vacsia ako 1000, tak je vracana hodnota vacsia ako 1, co vlastne predstavuje ze za 1 milisekundu uplynie viac ako 1 sekunda simulacneho casu.
            if(Speed > 1000)
            {
                // Ak je rychlost nastavena na maximum, je navratena obrovska hodnota a simulacia je takmer okamzite ukoncena.
                if (Speed == 500000000)
                    return 500000000;
                Thread.Sleep(1);
                return actualSpeed / 10;
            }
            // Ak je rychlost mensia ako 1000 dochadza k vypoctu, kolko casu sa pocka, aby doslo k zmene o 1 sekundu simulacneho casu
            int time = timeDifference - 1 >= 0 ? 1000 / actualSpeed : (int)((timeDifference * 1000) / actualSpeed);
            Thread.Sleep(time);
            if (timeDifference < 1)
                return timeDifference;
            return 1;
        }
    }
}
