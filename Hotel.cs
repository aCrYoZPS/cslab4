namespace Lab4
{

    public class Hotel
    {
        private static Hotel? hotelInstance = null;
        private string hotelName;
        private uint capacity;
        private uint currentGuests;
        private Tarif tarif;

        public double CurrentRate
        {
            get { return this.tarif.Rate; }
        }
        public uint CurrentGuests
        {
            get { return this.currentGuests; }
        }
        public string HotelName
        {
            get { return this.hotelName; }
            set { this.hotelName = value; }
        }

        private Hotel(string name, double startingCost, uint maxCustomers)
        {
            this.hotelName = name;
            this.tarif = new Tarif(startingCost);
            if (maxCustomers >= 0)
            {
                this.capacity = maxCustomers;
            }
            else
            {
                this.capacity = 0;
            }
        }

        public static Hotel GetHotelInstance(string name, double startingCost, uint maxCustomers)
        {
            if (hotelInstance == null)
            {
                hotelInstance = new Hotel(name, startingCost, maxCustomers);
            }
            else
            {
                hotelInstance.hotelName = name;
                hotelInstance.tarif.Rate = startingCost;
                hotelInstance.capacity = maxCustomers;
            }
            return hotelInstance;

        }

        public void CheckIn(uint newGuests)
        {
            if (this.currentGuests + newGuests <= this.capacity)
            {
                this.currentGuests = newGuests;
            }
            else
            {
                this.currentGuests = this.capacity;
            }
        }

        public void CheckOut(uint guestsLeft)
        {
            if (this.currentGuests <= guestsLeft)
            {
                this.currentGuests = 0;
            }
            else
            {
                this.currentGuests -= guestsLeft;
            }
        }

        public void RateUp(double delta = 10)
        {
            if (delta > 0)
            {
                this.tarif.CostUp(delta);
            }
        }

        public void RateDown(double delta = 10)
        {
            if (delta > 0)
            {
                this.tarif.CostDown(delta);
            }

        }

        public double Revenue()
        {
            return this.tarif.Rate * this.currentGuests;
        }

    }
}
