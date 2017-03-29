using System;
using System.Threading.Tasks;
using Akka.Actor;
using AkkaNetNeuralNet.Core.Model;

namespace AkkaNetNeuralNet.Core.Actors
{
    public class AgeMassIncomePerceptronActor : ReceiveActor
    {
        private readonly Random _rnd;
        private readonly IActorRef _outputTarget;

        private decimal _massWeight;
        private decimal _incomeWeight;
        private decimal _bias;


        public AgeMassIncomePerceptronActor(int randomSeed, IActorRef outputTarget)
        {
            _rnd = new Random(randomSeed);
            _outputTarget = outputTarget;

            InitialiseWeights();

            Receive<IIndependentVariable>(x => Trigger(x));
            Receive<IDogProfile>(x => Train(x));
        }

        private void Trigger(IIndependentVariable m)
        {
            _outputTarget.Tell(Output(m));
        }

        private void Train(IDogProfile m)
        {
            throw new NotImplementedException();
        }

        public static Props CreateProps(int randomSeed, IActorRef outputTarget)
        {
            return Props.Create(() => new AgeMassIncomePerceptronActor(randomSeed, outputTarget));
        }

        private decimal Output(IIndependentVariable m)
        {
            return (_massWeight * m.AdultBodymass) + (_incomeWeight * m.HouseholdIncome) + _bias;
        }

        private void InitialiseWeights()
        {
            decimal high = 0.01m;
            decimal low = -0.01m;

            decimal genWeight()
            {
                return (high - low) * (decimal)_rnd.NextDouble() + low;
            }

            _massWeight = genWeight();
            _incomeWeight = genWeight();
            _bias = genWeight();
        }
    }
}
