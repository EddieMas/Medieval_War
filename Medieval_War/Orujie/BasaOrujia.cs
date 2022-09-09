namespace Medieval_War.Orujie
{
    abstract class BasaOrujia
    {
        private float dalnost;
        private int uron;

        public int Uron
        {
            get { return uron; }
            set { uron = value; }
        }
        public float Dalnost
        {
            get { return dalnost; }
            set { dalnost = value; }
        }
        private BasaOrujia()
        {

        }
        protected BasaOrujia(float dalnost, int uron)
        {
            Uron = uron;
            Dalnost = dalnost;
        }
    }
}