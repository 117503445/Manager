using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Manager_Server
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Data;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// Xml序列化与反序列化
    /// </summary>
    public class XmlUtil
    {
        #region 反序列化
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="xml">XML字符串</param>
        /// <returns></returns>
        public static object Deserialize(Type type, string xml)
        {
            try
            {
                using (StringReader sr = new StringReader(xml))
                {
                    XmlSerializer xmldes = new XmlSerializer(type);
                    return xmldes.Deserialize(sr);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type"></param>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static object Deserialize(Type type, Stream stream)
        {
            XmlSerializer xmldes = new XmlSerializer(type);
            return xmldes.Deserialize(stream);
        }
        #endregion

        #region 序列化
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static string Serializer(Type type, object obj)
        {
            MemoryStream Stream = new MemoryStream();
            XmlSerializer xml = new XmlSerializer(type);
            try
            {
                //序列化对象
                xml.Serialize(Stream, obj);
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            Stream.Position = 0;
            StreamReader sr = new StreamReader(Stream);
            string str = sr.ReadToEnd();

            sr.Dispose();
            Stream.Dispose();

            return str;
        }

        #endregion
    }
    public class MessageSvc : IMessageSvc
    {
        /// <summary>
        /// 根目录
        /// </summary>
        string rootDir = AppDomain.CurrentDomain.BaseDirectory;

        public string GetServerDebugVersion()
        {
            return "0423_2140";
        }

        public void PushInfo(string clientName, string s)
        {
            string p = rootDir + "/Strs";
            Directory.CreateDirectory(p);
            var t = DateTime.Now;
            File.WriteAllText(p + $"/{t.Minute}_{t.Second}_{clientName}.txt", s);
        }

        public void PushUTask(UTask uTask)
        {
            string dir = "";
            if (uTask.IsHandled)
            {
                dir = $"{rootDir}/HandledUTasks";
            }
            else
            {
                dir = $"{rootDir}/UnHandledTasks";
            }
            XmlSerializer serializer = new XmlSerializer(typeof(UTask));
            Directory.CreateDirectory(dir);
            using (Stream fs = new FileStream($"{dir}/{uTask.Id}-{uTask.Receiver}.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                serializer.Serialize(fs, uTask);
            }
        }
        public List<UTask> GetUTasks(string receiver)
        {
            string dir  = $"{rootDir}/UnHandledTasks";
            Directory.CreateDirectory(dir);
            var uTaskPaths = Directory.GetFiles(dir);
            var receivedUTasks = (from x in uTaskPaths where x.Contains(receiver) select x).ToList();
            List<UTask> uTasks = new List<UTask>();
            foreach (var item in receivedUTasks)
            {
                string xml = File.ReadAllText(item);
                UTask task = XmlUtil.Deserialize(typeof(UTask), xml) as UTask;
                uTasks.Add(task);
                File.Delete(item);
            }
            return uTasks;
        }

        public string GetTimeStamp()
        {
            var t = DateTime.Now;
            return $"{t.Year}_{t.Month}_{t.Day}_{t.Hour}_{t.Minute}_{t.Second}_{t.Millisecond}";
        }

    }
}
