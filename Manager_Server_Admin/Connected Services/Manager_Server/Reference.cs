﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Manager_Server_Admin.Manager_Server {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UTask", Namespace="http://schemas.datacontract.org/2004/07/Manager_Server")]
    [System.SerializableAttribute()]
    public partial class UTask : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ExtraInfoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsHandledField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MethodNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] MethodParametersField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SenderField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ExtraInfo {
            get {
                return this.ExtraInfoField;
            }
            set {
                if ((object.ReferenceEquals(this.ExtraInfoField, value) != true)) {
                    this.ExtraInfoField = value;
                    this.RaisePropertyChanged("ExtraInfo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Id {
            get {
                return this.IdField;
            }
            set {
                if ((object.ReferenceEquals(this.IdField, value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsHandled {
            get {
                return this.IsHandledField;
            }
            set {
                if ((this.IsHandledField.Equals(value) != true)) {
                    this.IsHandledField = value;
                    this.RaisePropertyChanged("IsHandled");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MethodName {
            get {
                return this.MethodNameField;
            }
            set {
                if ((object.ReferenceEquals(this.MethodNameField, value) != true)) {
                    this.MethodNameField = value;
                    this.RaisePropertyChanged("MethodName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] MethodParameters {
            get {
                return this.MethodParametersField;
            }
            set {
                if ((object.ReferenceEquals(this.MethodParametersField, value) != true)) {
                    this.MethodParametersField = value;
                    this.RaisePropertyChanged("MethodParameters");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Sender {
            get {
                return this.SenderField;
            }
            set {
                if ((object.ReferenceEquals(this.SenderField, value) != true)) {
                    this.SenderField = value;
                    this.RaisePropertyChanged("Sender");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Manager_Server.IMessageSvc")]
    public interface IMessageSvc {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessageSvc/PushInfo", ReplyAction="http://tempuri.org/IMessageSvc/PushInfoResponse")]
        void PushInfo(string clientName, string s);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessageSvc/PushInfo", ReplyAction="http://tempuri.org/IMessageSvc/PushInfoResponse")]
        System.Threading.Tasks.Task PushInfoAsync(string clientName, string s);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessageSvc/GetServerDebugVersion", ReplyAction="http://tempuri.org/IMessageSvc/GetServerDebugVersionResponse")]
        string GetServerDebugVersion();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessageSvc/GetServerDebugVersion", ReplyAction="http://tempuri.org/IMessageSvc/GetServerDebugVersionResponse")]
        System.Threading.Tasks.Task<string> GetServerDebugVersionAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessageSvc/PushUTask", ReplyAction="http://tempuri.org/IMessageSvc/PushUTaskResponse")]
        void PushUTask(Manager_Server_Admin.Manager_Server.UTask uTask);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessageSvc/PushUTask", ReplyAction="http://tempuri.org/IMessageSvc/PushUTaskResponse")]
        System.Threading.Tasks.Task PushUTaskAsync(Manager_Server_Admin.Manager_Server.UTask uTask);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessageSvc/GetUTasks", ReplyAction="http://tempuri.org/IMessageSvc/GetUTasksResponse")]
        Manager_Server_Admin.Manager_Server.UTask[] GetUTasks();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessageSvc/GetUTasks", ReplyAction="http://tempuri.org/IMessageSvc/GetUTasksResponse")]
        System.Threading.Tasks.Task<Manager_Server_Admin.Manager_Server.UTask[]> GetUTasksAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMessageSvcChannel : Manager_Server_Admin.Manager_Server.IMessageSvc, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MessageSvcClient : System.ServiceModel.ClientBase<Manager_Server_Admin.Manager_Server.IMessageSvc>, Manager_Server_Admin.Manager_Server.IMessageSvc {
        
        public MessageSvcClient() {
        }
        
        public MessageSvcClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MessageSvcClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MessageSvcClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MessageSvcClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void PushInfo(string clientName, string s) {
            base.Channel.PushInfo(clientName, s);
        }
        
        public System.Threading.Tasks.Task PushInfoAsync(string clientName, string s) {
            return base.Channel.PushInfoAsync(clientName, s);
        }
        
        public string GetServerDebugVersion() {
            return base.Channel.GetServerDebugVersion();
        }
        
        public System.Threading.Tasks.Task<string> GetServerDebugVersionAsync() {
            return base.Channel.GetServerDebugVersionAsync();
        }
        
        public void PushUTask(Manager_Server_Admin.Manager_Server.UTask uTask) {
            base.Channel.PushUTask(uTask);
        }
        
        public System.Threading.Tasks.Task PushUTaskAsync(Manager_Server_Admin.Manager_Server.UTask uTask) {
            return base.Channel.PushUTaskAsync(uTask);
        }
        
        public Manager_Server_Admin.Manager_Server.UTask[] GetUTasks() {
            return base.Channel.GetUTasks();
        }
        
        public System.Threading.Tasks.Task<Manager_Server_Admin.Manager_Server.UTask[]> GetUTasksAsync() {
            return base.Channel.GetUTasksAsync();
        }
    }
}
