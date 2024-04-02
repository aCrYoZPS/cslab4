namespace Lab4
{
    public class Tarif
    {
        private double rate;
        public double Rate
        {
            get { return this.rate; }
            set { this.rate = value; }
        }
        public Tarif(double rate)
        {
            if (rate >= 0)
            {
                this.rate = rate;
            }
            else
            {
                this.rate = 0;
            }
        }
        public void CostUp(double delta)
        {
            this.rate += delta;
        }
        public void CostDown(double delta)
        {
            if (this.rate <= delta)
            {
                this.rate = 0;
            }
            else
            {
                this.rate -= delta;
            }
        }
    }
}
