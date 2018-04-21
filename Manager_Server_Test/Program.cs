﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manager_Server_Test.Manager_Server;
using System.Timers;
namespace Manager_Server_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageSvcClient client = new MessageSvcClient();

            Console.WriteLine(client.GetServerDebugVersion());
            //client.PushString("test","Hello,World");
            //Console.ReadLine();
            
            Timer timer = new Timer() { Interval = 1000, Enabled = true };
            timer.Elapsed += (s, e) =>
            {
                var i = client.GetUTasks();
                foreach (var item in i)
                {
                    Console.WriteLine("TASK:"+item.Id);
                }
            };
            Console.ReadLine();

        }
    }
}
