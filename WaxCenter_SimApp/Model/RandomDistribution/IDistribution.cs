using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaxCenter_SimApp.Model.RandomDistribution
{
    public interface IDistribution
    {
        double Sample();
        void SetSeed(int seed);
    }
}
