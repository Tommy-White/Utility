using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{

    public class Logger
    {
        private FileStream fStream;
        private StreamWriter sWriter;

        private static readonly Logger _instance = new Logger();

        public static Logger Instance
        {
            get { return _instance; }
        }

        private Logger()
        {
            fStream = File.OpenWrite(@"c:\logs\log.txt");
            sWriter =new StreamWriter(fStream);
        }

        public void LogMessage(string msg)
        {
            
            sWriter.WriteLine(" logged at " + DateTime.UtcNow + msg );
            sWriter.Flush();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string logMsg = "testing";
            Console.WriteLine("log message :{0}", logMsg);
            Logger.Instance.LogMessage(logMsg);
            Console.WriteLine("Message logged successfully");
            Console.ReadKey();

        }
    }

    //Some reference:
    //https://www.codeproject.com/Articles/1178694/Singleton-and-Multiton-Pattern
    //
}
