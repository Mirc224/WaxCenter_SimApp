using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaxCenter_SimApp.Model.RandomDistribution
{
    public class CustomDistribution : IDistribution
    {
        public Func<double> CustomDistributionFunction { get; set; }
        public double Sample()
        {
            return CustomDistributionFunction();
        }

        public void SetSeed(int seed)
        {
            
        }
    }
}
