using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood
{
    internal class ChickenOrder
    {

        private int quantity;

        public ChickenOrder(int quantity)
        {
            this.quantity = quantity;
        }
        public int GetQuantity()
        {
            return quantity;
        }
        public void CutUp()
        {
        }
        public void Coock()
        {
        }
    }
}
