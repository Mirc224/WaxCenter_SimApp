using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaxCenter_SimApp.Model.Simulation.TrafikaSimulation;

namespace WaxCenter_SimApp.Model.Simulation.GUIData
{
    public class GUIDataValues
    {
        public int SourceOutput { get => _simulation.CustomerSource.NumberOfGenerated; }
        public int ServiceQueueActualLength { get => _simulation.NewsPaperService.QueueSize; }
        public int ServiceInput { get => _simulation.NewsPaperService.AgentsEntered; }
        public int ServiceOutput { get => _simulation.NewsPaperService.AgentsLeaved; }
        public int SinkInput { get => _simulation.CustomerSink.AgentsSinked; }
        public double AverageWaitingTime { get => _simulation.NewsPaperWaitingTime.Mean; }
        public double MinWaitingTime { get => _simulation.NewsPaperWaitingTime.Min; }
        public double MaxWaitingTime { get => _simulation.NewsPaperWaitingTime.Max; }
        public double AverageQLength { get => _simulation.NewsPaperQLength.Mean; }
        public double MinQLength { get => _simulation.NewsPaperQLength.Min; }
        public double MaxQLength { get => _simulation.NewsPaperQLength.Max; }
        public double CurrentTime { get => _simulation.CurrentTime; }
        public int MaxService { get => _simulation.NewsPaperService.MaxService; }
        public int CurrentlyUsedService { get => _simulation.NewsPaperService.CurrentlyUsed; }
        public int CurretlyUsedDelay { get => _simulation.ReadDelay.CurrentlyUsed; }
        public int DelayInput { get => _simulation.ReadDelay.AgentsEntered; }
        public int DelayOutput { get => _simulation.ReadDelay.AgentsLeaved; }
        public double DelayMinSize { get => _simulation.DelaySize.Min; }
        public double DelayMaxSize { get => _simulation.DelaySize.Max; }
        public double DelayMeanSize { get => _simulation.DelaySize.Mean; }


        private EventSimCoreNewsPapers _simulation;

        public GUIDataValues(EventSimCoreNewsPapers simulation)
        {
            _simulation = simulation;
        }
    }
}
