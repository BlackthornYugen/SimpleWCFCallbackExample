using System.ServiceModel;

namespace SimpleWCFCallbackExample
{
    [ServiceContract]
    public interface IGameService
    {
        [OperationContract]
        string GuessNumber(string clientName, int value);

        [OperationContract]
        void GuessTheNumber();
    }

    [ServiceContract(CallbackContract = typeof(IBroadcastorCallback))]
    public interface IGameCallbacks
    {
        [OperationContract(IsOneWay = true)]
        void RegisterClient(string clientName);
    }

    public interface IBroadcastorCallback
    {
        [OperationContract(IsOneWay = true)]
        void BroadcastToClient(string message);
    }
}
