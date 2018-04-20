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
        public static List<UTask> uTasks = new List<UTask>();

        public string GetServerDebugVersion()
        {
            return "0421_0704";
        }

        public void PushInfo(string clientName, string s)
        {
            string p = AppDomain.CurrentDomain.BaseDirectory + "/Strs";
            Directory.CreateDirectory(p);
            var t = DateTime.Now;
            File.WriteAllText(p + $"/{t.Minute}_{t.Second}_{clientName}.txt", s);
        }

        public void PushUTask(UTask uTask)
        {
            uTasks.Add(uTask);
        }
        public List<UTask> GetUTasks()
        {
            return uTasks;
        }
    }
}
