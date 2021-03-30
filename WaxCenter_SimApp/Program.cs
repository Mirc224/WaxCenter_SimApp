using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaxCenter_SimApp.Model.RandomDistribution;
using WaxCenter_SimApp.Model.Simulation.TrafikaSimulation;
using WaxCenter_SimApp.Model.Simulation.VaccinationCenter;

namespace WaxCenter_SimApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*double cislo = 2.5522;
            Console.WriteLine((int)cislo);
            Console.WriteLine((int)((cislo%1)* 100));*/
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AppGUI());
            //Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            //var gen = new TriangularDistribution(20, 100, 75);
            //var gen = new ExponentialDistribution(260);
            /*using (var file = new StreamWriter("triangular.txt"))
            {
                for (int i = 0; i < 1000000; ++i)
                {
                    file.WriteLine(gen.Sample().ToString().Replace(",", "."));
                }
            }*/

            /*            var evSimCore = new EventSimCoreNewsPapers();
                        evSimCore.MaxTime = 2000;
                        evSimCore.ResetSimulation();
                        evSimCore.DoReplication();*/

            /*            var gen = new ExponentialDistribution(5);
                        var list = new List<double>();
                        for (int i = 0; i < 100000; ++i)
                        {
                            list.Add(gen.Sample());
                        }

                        Console.WriteLine(list.Average());*/
            //var simulation = new EventSimCoreNewsPapers(null);
            /*            var simulation = new EventSimCoreVaccinationCenter(null);
                        simulation.BeforeReplicationInit();
                        simulation.AutoSeed = true;
                        simulation.Seed = 3010;
                        simulation.MaxTime = 54000 * 60;
                        simulation.DoReplication();


                        simulation.BeforeReplicationInit();
                        simulation.AutoSeed = true;
                        simulation.Seed = 3010;
                        simulation.MaxTime = 54000 * 60;
                        simulation.DoReplication();
            */
        }
    }
}
