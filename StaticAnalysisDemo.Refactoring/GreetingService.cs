using StaticAnalysisDemo.Refactoring.models;

namespace StaticAnalysisDemo.Refactoring
{
    public class GreetingService
    {
        public string SayHello(string name)
        {
            return $"Hello there {name}, greetings from {GetDefaultSender()}";
        }
        
        private string GetDefaultSender()
        {
            return "Maarten";
        }

        public static GreetingConfiguration BuildConfiguration(string receiver, string message)
        {
            return new GreetingConfiguration
            {
                Receiver = receiver,
                Sender = "Maarten",
                Message = message
            };
        }
    }
}