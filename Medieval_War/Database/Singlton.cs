namespace Medieval_War.Database
{
    internal sealed class Singleton
    {
        private string podkluchenie;
        private static Singleton obraz;

        public string Podkluchenie
        {
            get { return podkluchenie; }
            set { podkluchenie = value; }
        }

        private Singleton(string podkluchenie) { this.podkluchenie = podkluchenie; }

        public static Singleton GetInstance(string podkluchenie)
        {
            if (obraz == null)
            {
                obraz = new Singleton(podkluchenie);
            }
            return obraz;
        }
    }
}