using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood
{
    internal class EggOrder
    {
        private int quantity;
        private int? quality;
        private static int countOrder;

        public EggOrder(int quantity)
        {
            this.quantity = quantity;
            countOrder++;
        }
        public int GetQuantity()
        {
            return quantity;
        }

        public int? GetQuality()
        {
            int? quality;

            if (countOrder % 2 == 0)
            {
                quality = null;
                this.quality = quality;
            }

            else
            {
                Random rand = new Random();
                quality = rand.Next(1, 100);
                this.quality = quality;
            }
            return quality;

        }
        public void Crack()
        {
            int? eggQuality = quality;
            if (eggQuality != null && quality < 25)
            {
                throw new Exception("This egg is rotten!");
            }
        }
        public void DiscardShell()
        {
        }
        public void Coock()
        {
        }
    }
}
