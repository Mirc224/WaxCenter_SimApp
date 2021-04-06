using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Results;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents.AdditionalServiceComponents;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents.AdditionServiceComponents
{
    public class ResourcePool
    {
        /**
         * Predtavuje simulacny komponent resource pool. Obsahuje udaje o dostupnosti obsluhy ako aj jej vytazeni. Taktiez obsahuje pole obsluhujucich. Umoznuje ziskat udaje o vytazeni jednotlivych obsluhujucich.
         * Vztahuje sa vzdy k nejakemu serice komponentu.
         */

        // Maximalny pocet moznych obsluhujucich.
        public int MaxStaff { get; private set; }
        // Vrati priemernu hodnotu vyuzitia resoruce poolu.
        public double Utilization { get => _service.Simulation.CurrentTime == 0 ? 0 : _totalTimeOccupied / (MaxStaff * _service.Simulation.CurrentTime); }
        // Pole obsluhujucich entit.
        public ServiceStaff[] Staff { get => _staff; }
        // Obsahuje vysledky ziskane pocas vykonavanych replikacii na danej instancii triedy ResourcePool.
        public ResourcePoolResults ReplicationResults { get; set;}
        // List dostupnych obsluhujucich.
        private List<ServiceStaff> _availableStaff;
        // Pole generatorov pre ziskavanie volneho obsluhujuceho
        private Random[] _staffSelectGenerators;
        // Referenica na prisluchajuci service komponent.
        private ServiceComponent _service;
        // Pole referencii na obsluhujucich.
        private ServiceStaff[] _staff;
        // Suma celkoveho casu, ktory boli jendotlivi zamesntanci obsadeni.
        private double _totalTimeOccupied;
        // Generator nasad pre generatory vyberu z volnych obsluhujucich
        private Random _selectSeedGenerator;
        public ResourcePool(ServiceComponent service, int maxStaff)
        {
            _service = service;
            _selectSeedGenerator = new Random();
            SetMaxStaff(maxStaff);
            ReplicationResults = new ResourcePoolResults(this);
        }

        /**
         * Nastavi hodnotu max staff a spolu s tym vytvori aj nove pole obsluhujucich ako a generatorov pre vyber.
         * Taktiez sa postara po prebudovanie pripadnych replikacnych vysledkov, ktore k instancii prisluchaju
         */
        public void SetMaxStaff(int maxStaff)
        {
            MaxStaff = maxStaff;
            _staff = new ServiceStaff[MaxStaff];
            _staffSelectGenerators = new Random[MaxStaff - 1];
            for (int i = 0; i < MaxStaff; ++i)
            {
                _staff[i] = new ServiceStaff(_service);
            }
            _availableStaff = new List<ServiceStaff>(MaxStaff);
            SetSelectSeed();
            if (ReplicationResults != null)
                ReplicationResults.Rebuild();
        }

        /**
         * Nahodne vrati volneho obsluhujuceho, v pripade ak je mozne vyberat z viacerych volnych.
         */
        public ServiceStaff GetFreeStaff()
        {
            _availableStaff.Clear();
            for(int i = 0; i < MaxStaff; ++i)
            {
                if (!_staff[i].Occupied)
                    _availableStaff.Add(_staff[i]);
            }
            if (_availableStaff.Count == 0)
                return null;

            if (_availableStaff.Count == 1)
            {
                _availableStaff[0].Occupied = true;
                return _availableStaff[0];
            }
                
            
            var generator = _staffSelectGenerators[_availableStaff.Count - 2];

            var staff = _availableStaff[generator.Next(_availableStaff.Count)];
            staff.Occupied = true;
            
            return staff;
        }
        /**
         * Navrati pouzivaneho obsluhujuceho a aktualizuje statistiky.
         */
        public void ReturnStaff(ServiceStaff staff)
        {
            staff.Occupied = false;
            staff.TimeOccupied += staff.CurrentServiceDuration;
            _totalTimeOccupied += staff.CurrentServiceDuration;
        }
        /**
         * Vykona reset komponentu. Sledovane statistiky vynuluje a taktiez restartuje aj instancie obsluhujucich.
         */
        public void Reset()
        {
            _availableStaff.Clear();
            for (int i = 0; i < MaxStaff; ++i)
                _staff[i].Reset();
            _totalTimeOccupied = 0;
        }
        /**
         * Nastavi seed pre generatory.
         */
        public void SetSeed(int seed)
        {
            _selectSeedGenerator = new Random(seed);
            SetSelectSeed();
        }
        /**
         * Nastavi nahodny seed pre generator a nastavi aj dalsie generatory.
         */
        public void SetSeed()
        {
            _selectSeedGenerator = new Random();
            SetSelectSeed();
        }
        /**
         * Nastavi seedy generatorom, ktore sluzia pri vybere volneho pracovnika.
         */
        private void SetSelectSeed()
        {
            for (int i = 0; i < MaxStaff - 1; ++i)
                _staffSelectGenerators[i] = new Random(_selectSeedGenerator.Next());
        }
    }
}
