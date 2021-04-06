using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaxCenter_SimApp.Model.RandomDistribution
{
    /*
     * Interface, ktory musi implementovat kazdy generator rozdelenia.
     */
    public interface IDistribution
    {
        // Vrati vygenerovanu hodnotu z rozdelenia
        double Sample();
        // Nastavi seed generatoru, ktory sa v danom rozdeleni stara o nahodnost
        void SetSeed(int seed);
    }
}
