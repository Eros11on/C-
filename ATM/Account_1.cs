using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class Account
    {
        private int accid;
        public int Accid
        {
            get { return accid; }
            set { accid = value; }
        }

        private string accBank;
        public string Accbank
        {
            get { return accBank; }
            set { accBank = value; }
        }

        private string acctype;
        public string Acctype
        {
            get { return acctype; }
            set { acctype = value; }
        }

        private float balance;
        public float Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        private string username;
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        private float limit;
        public float Limit
        {
            get { return limit; }
            set { limit = value; }
        }
    }
}
