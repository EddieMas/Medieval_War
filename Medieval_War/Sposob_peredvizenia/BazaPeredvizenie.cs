namespace Medieval_War.Sposob_peredvizenia
{
    abstract class SposobPeredvizenia
    {
        private float skorost;

        public float Skorost
        {
            get { return skorost; }
            set { skorost = value; }
        }

        private SposobPeredvizenia() { }
        protected SposobPeredvizenia(float skorost)
        {
            Skorost = skorost;
        }
    }
}