using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manager_Server_Test.Server_File;
using Manager_Server_Test.Server_Message;
using System.Timers;
using System.IO;

namespace Manager_Server_Test
{
    class Program
    {
        static void Main(string[] args)
        {

            MessageSvcClient client = new MessageSvcClient();
            Console.WriteLine(client.GetServerDebugVersion());


            //client.PushUTask(new UTask { Id = client.GetTimeStamp(), Sender = "admin",Receiver="test" });

            Timer timer = new Timer() { Interval = 1000, Enabled = true };
            timer.Elapsed += (s, e) =>
            {
                var i = client.GetUTasks("test");
                foreach (var item in i)
                {
                    HandleTask(item);
                }
            };

            FileSvcClient fileSvcClient = new FileSvcClient();
            Console.ReadLine();

        }
        static bool UpLoad(FileSvcClient client, string filePath)
        {
            using (Stream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                bool result = client.UpLoadFile(filePath, fs.Length, fs, out string message);
                return result;
            }
        }
        static bool DownLoad(FileSvcClient client, string serverFilePath, string localPath)
        {
            Stream filestream = new MemoryStream();
            long filesize = client.DownLoadFile(serverFilePath, out bool issuccess, out string message, out filestream);
            using (FileStream fs = new FileStream(localPath, FileMode.Create, FileAccess.Write))
            {
                int count = 0;
                byte[] buffer = new byte[filesize];
                while ((count = filestream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fs.Write(buffer, 0, count);
                }
            }
            return issuccess;
        }
        static void HandleTask(UTask task)
        {

        }
    }
}
