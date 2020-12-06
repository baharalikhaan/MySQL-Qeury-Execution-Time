using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mysql
{
    class Program
    {
        static void Main(string[] args)
        {
          //    Console.WriteLine(args[0]);
           var rr = "select * from bahar.value;";
            //open the file
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = @"C:\wamp64\bin\mysql\mysql5.7.31\bin\mysql"; //not the full application path
            myProcess.StartInfo.Arguments = "-u root -e \" set profiling=1; "+ args[0] + "; SELECT query_id, SUM(duration) FROM information_schema.profiling GROUP BY query_id ORDER BY query_id DESC LIMIT 1;\"";

            myProcess.StartInfo.RedirectStandardInput = true;
            myProcess.StartInfo.RedirectStandardOutput = true;
            myProcess.StartInfo.CreateNoWindow = true;
            myProcess.StartInfo.UseShellExecute = false;


            myProcess.Start();
            myProcess.StandardInput.Flush();
            myProcess.StandardInput.Close();
           //  myProcess.WaitForExit();


            string a = myProcess.StandardOutput.ReadToEnd();

           
            string[] bb = a.Split(new string[] { "query_id" }, StringSplitOptions.None);

            Console.Write(bb[1]);
          //  Console.WriteLine("Press any key tou continue");
          //  Console.Read();
        }
    }
}
