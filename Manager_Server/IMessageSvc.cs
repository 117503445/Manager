using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Manager_Server
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract]
    public interface IMessageSvc
    {
        [OperationContract]
        void PushInfo(string clientName, string s);

        [OperationContract]
        string GetServerDebugVersion();

        [OperationContract]
        void PushUTask(UTask uTask);

        [OperationContract]
        List<UTask> GetUTasks();
    }

    // 使用下面示例中说明的数据约定将复合类型添加到服务操作。
    // 可以将 XSD 文件添加到项目中。在生成项目后，可以通过命名空间“WCF.ContractType”直接使用其中定义的数据类型。


    [DataContract]
    public class UTask
    {
        [XmlSerializerFormat]
        private string id;
        [DataMember]
        public string Id { get => id; set => id = value; }
        [DataMember]
        public string MethodName { get => methodName; set => methodName = value; }
        [DataMember]
        public string[] MethodParameters { get => methodParameters; set => methodParameters = value; }
        [DataMember]
        public string ExtraInfo { get => extraInfo; set => extraInfo = value; }
        [DataMember]
        public string Sender { get => sender; set => sender = value; }
        [DataMember]
        public bool IsHandled { get => isHandled; set => isHandled = value; }
        [DataMember]
        public string Receiver { get => receiver; set => receiver = value; }

        private string methodName;

        private string[] methodParameters;

        private string extraInfo;

        private bool isHandled;

        private string sender;

        private string receiver;
        public UTask(string id, string sender, string re, string extraInfo = "")
        {
            Id = id;
            ExtraInfo = extraInfo;
            Sender = sender;
        }

        public static void ToXML() { }
        public static UTask FromXML(string receiver, string xml)
        {
            //return new UTask();
            return null;
        }
    }
}
