using System;

namespace AkkaNetNeuralNet.Core.Model
{
    public class Locale
    {
        private const string _rural = "Rural";
        private const string _suburban = "Suburban";
        private const string _urban = "Urban";

        public string Name { get; private set; }
        public (decimal, decimal) Encoding { get; private set; }

        private Locale() { }

        private Locale(string name, (decimal, decimal) encoding)
        {
            Name = name;
            Encoding = encoding;
        }

        public static Locale Rural = new Locale(_rural, (1m, 0m));
        public static Locale Suburban = new Locale(_suburban, (0m, 1m));
        public static Locale Urban = new Locale(_urban, (-1m, 1m));

        public static Locale FromName(string name)
        {
            if (name == _rural) return Rural;
            if (name == _suburban) return Suburban;
            if (name == _urban) return Urban;

            throw new ArgumentOutOfRangeException(nameof(name));
        }
    }
}