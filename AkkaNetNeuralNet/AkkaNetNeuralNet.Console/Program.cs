using Akka.Actor;
using Akka.Util.Internal;
using AkkaNetNeuralNet.Core.Normalisation;
using C = System.Console;

namespace AkkaNetNeuralNet.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var trainingData = DummySource.GetTrainingData();

            ConsoleHelper.PrintDogProfileHeader();
            trainingData.ForEach(ConsoleHelper.Print);

            C.WriteLine("Normalising...");
            var normalisedTrainingData = trainingData.Normalise();
            ConsoleHelper.PrintDogProfileHeader();
            normalisedTrainingData.ForEach(ConsoleHelper.Print);

            var system = ActorSystem.Create("AkkaNetNeuralNet");
            // var topLevel = system.ActorOf()
            system.Terminate();

            C.ReadLine();
        }
    }
}
