using System;

namespace AkkaNetNeuralNet.Core.Model
{
    public class Breed
    {
        private const string StBernardName = "StBernard";
        private const string LabradorName = "Labrador";
        private const string BulldogName = "Bulldog";

        public string Name { get; private set; }
        public (decimal, decimal) Encoding { get; private set; }

        private Breed() { }

        private Breed(string name, (decimal, decimal) encoding)
        {
            Name = name;
            Encoding = encoding;
        }

        public static Breed StBernard = new Breed(StBernardName, (1m, 0m));
        public static Breed Labrador = new Breed(LabradorName, (0m, 1m));
        public static Breed Bulldog = new Breed(BulldogName, (-1m, 1m));

        public static Breed FromName(string name)
        {
            if (name == StBernardName) return StBernard;
            if (name == LabradorName) return Labrador;
            if (name == BulldogName) return Bulldog;

            throw new ArgumentOutOfRangeException(nameof(name));
        }
    }
}