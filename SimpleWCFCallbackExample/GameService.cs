using System.ServiceModel;

namespace SimpleWCFCallbackExample
{
    [ServiceBehavior]
    public class GameService : IGameService
    {
        public string GuessNumber(int value)
        {
            return string.Format("You guessed: {0}\nWaiting for other players to guess...", value);
        }
    }
}
