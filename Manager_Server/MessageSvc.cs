using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Manager_Server
{
    public class MessageSvc : IMessageSvc
    {
        public string GetServerDebugVersion()
        {
            return "0420_1627";
        }

        public void PushString(string clientName,string s)
        {
            string p = AppDomain.CurrentDomain.BaseDirectory + "/Strs";
            Directory.CreateDirectory(p)
            if (!Directory.Exists(p))
            {

            }
        }

        public UTask PushUTask()
        {
            return new UTask();
        }

        public void WriteFile()
        {
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory + "1.txt");
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "1.txt", DateTime.Now.ToString());
        }
    }
}
