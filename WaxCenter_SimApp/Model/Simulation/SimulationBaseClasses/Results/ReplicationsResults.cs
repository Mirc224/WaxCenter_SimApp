 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Results
{
    public class ReplicationsResults
    {
        /**
         * Obalova trieda pre vysledky z replikacii pre urcitu simulaciu.
         * 
         */
        // Udava cislo aktualnej replikacie.
        public int CurrentReplications { get; set; } = 0;
        // Priemerny nadcas - t.j. cas trvania simulacie po dosaihnuti hodnoty MaxTime
        public double MeanOvertime { get => CurrentReplications == 0 ? 0 : OverTime / CurrentReplications; }
        // Suma nadcasov za vseky vykonane replikacie
        public double OverTime { get; set; } = 0;
        // Indexer umoznujuci zoslat skupinu vysledkov na zaklade string kluca
        public ResultGroup this[string key] { get => _dicionaryGroup[key]; set => _dicionaryGroup[key] = value; }
        // Pole skupin vysledkov - najcasejsie ide o vysledky suvisiace s jednym komponentom
        public ResultGroup[] ResultGroups { 
            get=> _resultGroups; 
            set
            {
                _resultGroups = value;
                foreach (var group in _resultGroups)
                    group.ReplicationsResult = this;
            }
        }
        // Slovnik, v ktorom su ulozene skupiny vysledkov podla string kluca
        private Dictionary<string, ResultGroup> _dicionaryGroup = new Dictionary<string, ResultGroup>();
        // Pole skupin vysledkov
        private ResultGroup[] _resultGroups;

        // Metoda, ktora po jej zavolani zabezpeci, ze vsetky vysledky sa aktualizuju.
        public void AfterReplicationUpdate()
        {
            if (ResultGroups != null)
            {
                foreach (var resultGroup in ResultGroups)
                {
                    resultGroup.AfterReplicationUpdate();
                }
            }
        }
        // Metoda zaruci prebudovanie vsetkych vysledkov, pretoze tie sa mozu menit v zavisloti od nastaveni
        public void Rebuild()
        {
            if (ResultGroups != null)
            {
                foreach (var resultGroup in ResultGroups)
                {
                    resultGroup.Rebuild();
                }
            }
        }
        // Vykona reset vsetkych sledovanych vysledkov replikacii
        public void Reset()
        {
            CurrentReplications = 0;
            OverTime = 0;
            
            if(ResultGroups != null)
            {
                foreach(var resultGroup in ResultGroups)
                {
                    resultGroup.Reset();
                }

            }

        }
    }
}
