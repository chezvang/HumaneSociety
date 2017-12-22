using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class HumaneSocietyWallet
    {
        private int wallet;

        public int HumaneSocietWallet()
        {
            wallet = 0;
            return wallet;
        }

        public int AddToWallet(int number)
        {
            wallet = wallet += number;
            return wallet;
        }
    }
}
