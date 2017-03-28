using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;

namespace AkkaNetNeuralNet.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("AkkaNetNeuralNet");
            // var topLevel = system.ActorOf()
        }
    }
}
