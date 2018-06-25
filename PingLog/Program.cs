using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingLog
{
    public class AppGo
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        public void Run(string p_app, string p_target)
        {
            using (System.Diagnostics.Process oProcess = new System.Diagnostics.Process())
            {
                oProcess.StartInfo = new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = p_app,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    Arguments = p_target
                };
                //啟動程序
                oProcess.Start();
                //取得輸出字串
                string cTemp = oProcess.StandardOutput.ReadToEnd();

                //等候程序結束
                oProcess.WaitForExit();
                Log.Debug($"Paping => \n{cTemp}\n");
                //列印字串
                Console.WriteLine(cTemp);
            }
            //Console.ReadLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string app = ConfigurationManager.AppSettings["App"];
            string target1 = ConfigurationManager.AppSettings["Target1"];
            //string target2 = ConfigurationManager.AppSettings["Target2"];
            AppGo Paping = new AppGo();
            while (true)
            {
                Paping.Run(app, target1);
            }
            
        }
    }
}
