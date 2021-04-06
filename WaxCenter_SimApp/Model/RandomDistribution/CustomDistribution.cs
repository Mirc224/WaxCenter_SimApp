using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaxCenter_SimApp.Model.RandomDistribution
{
    /*
     * Trieda generatora, ktora produkuje hodnoty na zakalde poskytnutej funkcie CustomDistributionFunction.
     * Implementuje v sebe interface IDistribution.
     */
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
