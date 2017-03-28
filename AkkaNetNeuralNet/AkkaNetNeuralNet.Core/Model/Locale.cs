namespace AkkaNetNeuralNet.Core.Model
{
    public class Locale
    {
        public LocaleName Name { get; private set; }
        public (decimal, decimal) Encoding { get; private set; }

        private Locale() { }

        private Locale(LocaleName name, (decimal, decimal) encoding)
        {
            Name = name;
            Encoding = encoding;
        }

        public static Locale Rural = new Locale(LocaleName.Rural, (1m, 0m));
        public static Locale Suburban = new Locale(LocaleName.Suburban, (0m, 1m));
        public static Locale Urban = new Locale(LocaleName.Urban, (-1m, 1m));

        public enum LocaleName
        {
            Rural,
            Suburban,
            Urban
        }
    }
}