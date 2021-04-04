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
            /*            var gen = new UniformBoundedDistribution(5, 25);
                        using (var file = new StreamWriter("uniform.txt"))
                             {
                                 for (int i = 0; i < 1000000; ++i)
                                 {
                                     file.WriteLine(gen.Sample().ToString().Replace(",", "."));
                                 }
                             }*/

            //Console.WriteLine(list.Average());
            //var simulation = new EventSimCoreNewsPapers(null);
            /*            var simulation = new EventSimCoreVaccinationCenter(null);
                        //simulation.BeforeReplicationInit();
                        simulation.AutoSeed = true;
                        simulation.ContinueAfterMaxTime = true;
                        //simulation.Seed = 3010;
                        //simulation.MaxTime = 54000 * 60;
                        //simulation.DoReplication();
                        var cont = new Controller.Controller(simulation);
                        cont.Test();
                        cont.Test();*/
            //cont.RunReplications();


            /*            simulation.BeforeReplicationInit();
                        simulation.AutoSeed = true;
                        simulation.Seed = 3010;
                        simulation.MaxTime = 54000 * 60;
                        simulation.DoReplication();
            */
        }
    }
}
