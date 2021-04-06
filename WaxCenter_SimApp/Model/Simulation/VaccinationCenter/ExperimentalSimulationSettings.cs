using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Core;

namespace WaxCenter_SimApp.Model.Simulation.VaccinationCenter
{
    class ExperimentalSimulationSettings
    {
        /**
         * Trieda obsahuje nastavenia pre experimentalnu simulaciu na ulohe vakcinacneho centra.
         */
        public int RepPerExperiment { get; set; } = 10;
        public int CurrentExperimentalReplications { get; set; } = 0;
        public int MaxReplications { get => _maxReplications; }
        public int CurrentReplication { get; set; } = 0;
        public SimulationStatus ExperimentalSimulationStatus { get; set; } = SimulationStatus.FINISHED;
        public int MinAdmin { get; set; } = 1;
        public int MaxAdmin { get; set; } = 1;
        public int ActualAdmin { get; set; } = 1;
        public int MinDoctor { get; set; } = 1;
        public int MaxDoctor { get; set; } = 1;
        public int ActualDoctor { get; set; } = 1;
        public int MinNurse { get; set; } = 1;
        public int MaxNurse { get; set; } = 1;
        public int ActualNurse { get; set; } = 1;
        public double ArrivalInterval { get; set; } = 60;
        public int NumberOfPatients { get; set; } = 540;
        public string AdminPrefillText { get => $"{MinAdmin}-{MaxAdmin}"; }
        public string DoctorPrefillText { get => $"{MinDoctor}-{MaxDoctor}"; }
        public string NursePrefillText { get => $"{MinNurse}-{MaxNurse}"; }
        private int _maxReplications = 0;

        public void ResetActual()
        {
            ActualAdmin = MinAdmin;
            ActualDoctor = MinDoctor;
            ActualNurse = MinNurse;
        }
        
        public void CalculateMaxReplications()
        {
            short zeroCount = 0;
            int tmp = 0;
            _maxReplications = 1;
            tmp = (MaxAdmin - MinAdmin)+1;
            if (tmp == 1)
                ++zeroCount;
            else
                _maxReplications *= tmp;

            tmp = (MaxDoctor - MinDoctor)+1;
            if (tmp == 1)
                ++zeroCount;
            else
                _maxReplications *= tmp;

            tmp = (MaxNurse - MinNurse)+1;
            if (tmp == 1)
                ++zeroCount;
            else
                _maxReplications *= tmp;

            if (zeroCount == 3)
                _maxReplications = RepPerExperiment;
            else
                _maxReplications *= RepPerExperiment;

        }
    }
}
