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
        private readonly decimal _alpha;

        private decimal _massWeight;
        private decimal _incomeWeight;
        private decimal _bias;


        public AgeMassIncomePerceptronActor(int randomSeed, IActorRef outputTarget, decimal trainingAlpha)
        {
            _rnd = new Random(randomSeed);
            _outputTarget = outputTarget;
            _alpha = trainingAlpha;

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
            decimal output = Output(m);

        }

        public static Props CreateProps(int randomSeed, IActorRef outputTarget, decimal trainingAlpha)
        {
            return Props.Create(() => new AgeMassIncomePerceptronActor(randomSeed, outputTarget, trainingAlpha));
        }

        private decimal Output(IIndependentVariable m)
        {
            return (_massWeight * m.AdultBodymass) + (_incomeWeight * m.HouseholdIncome) + _bias;
        }

        private void InitialiseWeights()
        {
            const decimal high = 0.01m;
            const decimal low = -0.01m;

            decimal GenWeight()
            {
                return (high - low) * (decimal)_rnd.NextDouble() + low;
            }

            _massWeight = GenWeight();
            _incomeWeight = GenWeight();
            _bias = GenWeight();
        }
    }
}
