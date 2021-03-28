using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents.AdditionalServiceComponents;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents.AdditionServiceComponents
{
    public class ResourcePool
    {
        private ServiceComponent _service;
        private ServiceStaff[] _staff;
        private Random[] _staffSelectGenerators;
        public int MaxStaff { get; private set; }
        private Random _selectSeedGenerator;
        private List<ServiceStaff> _availableStaff;
        private double _totalTimeOccupied;
        public double Utilization { get => _service.Simulation.CurrentTime == 0 ? 0 : _totalTimeOccupied / (MaxStaff * _service.Simulation.CurrentTime); }
        public ResourcePool(ServiceComponent service, int maxStaff)
        {
            _service = service;
            _selectSeedGenerator = new Random();
            SetMaxStaff(maxStaff);
        }

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
        }

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

        public void ReturnStaff(ServiceStaff staff)
        {
            staff.Occupied = false;
            staff.TimeOccupied += staff.CurrentServiceDuration;
            _totalTimeOccupied += staff.CurrentServiceDuration;
        }

        public void Reset()
        {
            _availableStaff.Clear();
            for (int i = 0; i < MaxStaff; ++i)
                _staff[i].Reset();
            _totalTimeOccupied = 0;
        }

        public void SetSeed(int seed)
        {
            _selectSeedGenerator = new Random(seed);
            SetSelectSeed();
        }
        public void SetSeed()
        {
            _selectSeedGenerator = new Random();
            SetSelectSeed();
        }
        private void SetSelectSeed()
        {
            for (int i = 0; i < MaxStaff - 1; ++i)
                _staffSelectGenerators[i] = new Random(_selectSeedGenerator.Next());
        }
    }
}
