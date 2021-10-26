using System;

namespace Hw9
{
    class Dairy : Product
    {
        int expiration_days;
        string expiration_date;
        DateTime today = DateTime.Today;
        
        public Dairy(string name, double price, int experation_days) : base(name, price)
        {
            
            this.expiration_days = experation_days;
            expiration_date = Convert.ToString(today.AddDays(expiration_days));
        }
        public Dairy () :base()
        {
            this.expiration_days = 1000;
            expiration_date = Convert.ToString(today.AddDays(this.expiration_days));
        }

        public override string Expi()
        {
            return this.expiration_date;
        }
        public override string ToString()
        {
          return "Name " + this.name + " Price " + price + " Expiration Date "+ expiration_date+"\n";
        }
        public int SetterDay
        {
            set
            {
                expiration_days = value;
                expiration_date = Convert.ToString(today.AddDays(expiration_days));
            }
        }
    }
}
