using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Manager
{
    public class Sync
    {
        /// <summary>
        /// 序列化
        /// </summary>
        public static void Save(List<Sync> list)
        {

        }
        public Sync(string dir_Source, string dir_Dest)
        {
            Dir_Source = dir_Source;
            Dir_Dest = dir_Dest;
        }

        public string Dir_Source { get; set; }
        public string Dir_Dest { get; set; }
        public override string ToString()
        {
            DirectoryInfo info1;
            DirectoryInfo info2;
            try
            {
                info1 = new DirectoryInfo(Dir_Source);
                info2 = new DirectoryInfo(Dir_Dest);
                return $"{info1.Name}-->{info2.Name}";
            }
            catch (Exception)
            {
                return $"Error";
            }

        }
    }
}
