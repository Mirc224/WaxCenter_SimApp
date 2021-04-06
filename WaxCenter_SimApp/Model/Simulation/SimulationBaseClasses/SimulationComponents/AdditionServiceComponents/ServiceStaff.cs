using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents.AdditionalServiceComponents
{
    public class ServiceStaff
    {
        /**
         * Predstavuje pracovnika resource poolu. Zaznamenava jeho zakladne statistiky a sucasny stav.
         */
        // Celkovy cas, ktory bol obsluhujuci pracovne vyrazeny.
        public double TimeOccupied { get; set; } = 0;
        // Vrati vytazenie zamestnanca v zavislosti od aktualneho casu simulacie.
        public double Utilization { get => _service.Simulation.CurrentTime == 0 ? 0 : TimeOccupied / _service.Simulation.CurrentTime; }
        // Pomocny atribut pre zaznemnavanie, dlzky travania aktualnej obsluhy.
        public double CurrentServiceDuration { get; set; } = 0;
        public bool Occupied { get; set; } = false;
        // Referencia service komponent, ku ktoremu obsluhujuci prislucha
        private ServiceComponent _service;

        public ServiceStaff(ServiceComponent service)
        {
            _service = service;
        }

        public void ReturnToResourcePool()
        {
            _service.ResourcePool.ReturnStaff(this);
        }

        public void Reset()
        {
            CurrentServiceDuration = 0;
            TimeOccupied = 0;
            Occupied = false;
        }
    }
}
