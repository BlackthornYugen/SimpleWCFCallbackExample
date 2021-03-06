﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCFCallbackConsole.GameService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="GameService.IGameService")]
    public interface IGameService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/GuessNumber", ReplyAction="http://tempuri.org/IGameService/GuessNumberResponse")]
        string GuessNumber(string clientName, int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/GuessNumber", ReplyAction="http://tempuri.org/IGameService/GuessNumberResponse")]
        System.Threading.Tasks.Task<string> GuessNumberAsync(string clientName, int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/GuessTheNumber", ReplyAction="http://tempuri.org/IGameService/GuessTheNumberResponse")]
        void GuessTheNumber();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/GuessTheNumber", ReplyAction="http://tempuri.org/IGameService/GuessTheNumberResponse")]
        System.Threading.Tasks.Task GuessTheNumberAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGameServiceChannel : WCFCallbackConsole.GameService.IGameService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GameServiceClient : System.ServiceModel.ClientBase<WCFCallbackConsole.GameService.IGameService>, WCFCallbackConsole.GameService.IGameService {
        
        public GameServiceClient() {
        }
        
        public GameServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GameServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GameServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GameServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GuessNumber(string clientName, int value) {
            return base.Channel.GuessNumber(clientName, value);
        }
        
        public System.Threading.Tasks.Task<string> GuessNumberAsync(string clientName, int value) {
            return base.Channel.GuessNumberAsync(clientName, value);
        }
        
        public void GuessTheNumber() {
            base.Channel.GuessTheNumber();
        }
        
        public System.Threading.Tasks.Task GuessTheNumberAsync() {
            return base.Channel.GuessTheNumberAsync();
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="GameService.IGameCallbacks", CallbackContract=typeof(WCFCallbackConsole.GameService.IGameCallbacksCallback))]
    public interface IGameCallbacks {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameCallbacks/RegisterClient")]
        void RegisterClient(string clientName);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameCallbacks/RegisterClient")]
        System.Threading.Tasks.Task RegisterClientAsync(string clientName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGameCallbacksCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameCallbacks/BroadcastToClient")]
        void BroadcastToClient(string message);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGameCallbacksChannel : WCFCallbackConsole.GameService.IGameCallbacks, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GameCallbacksClient : System.ServiceModel.DuplexClientBase<WCFCallbackConsole.GameService.IGameCallbacks>, WCFCallbackConsole.GameService.IGameCallbacks {
        
        public GameCallbacksClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public GameCallbacksClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public GameCallbacksClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public GameCallbacksClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public GameCallbacksClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void RegisterClient(string clientName) {
            base.Channel.RegisterClient(clientName);
        }
        
        public System.Threading.Tasks.Task RegisterClientAsync(string clientName) {
            return base.Channel.RegisterClientAsync(clientName);
        }
    }
}
