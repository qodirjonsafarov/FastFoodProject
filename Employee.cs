using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood
{
    internal class Employee
    {
        private static object lastRequest;
        private static int requestCounter;

        public Employee()
        {

        }
        public object NewRequest(int quantity, string menuItem)
        {
            requestCounter++;
            if (requestCounter % 3 == 0)
            {
                if (menuItem == "Chicken")
                {
                    menuItem = "Egg";
                }
                else
                {
                    menuItem = "Chicken";
                }
            }

            if (menuItem == "Egg")
            {
                EggOrder MyOrder = new EggOrder(quantity);
                lastRequest = MyOrder;
                return MyOrder;
            }

            else if (menuItem == "Chicken")
            {
                ChickenOrder MyOrder = new ChickenOrder(quantity);
                lastRequest = MyOrder;
                return MyOrder;
            }
            else
            {
                throw new ArgumentException();
            }

        }
        public object CopyRequest()
        {
            if (lastRequest != null)
            {
                return lastRequest;
            }

            else
            {
                throw new Exception("No any order");
            }
        }
        public string Inspect(object request)
        {
            string result = "";
            switch (request)
            {
                case EggOrder order:
                    result = order.GetQuality().ToString();
                    break;

                case ChickenOrder order:
                    result = "Verification is not required";
                    break;
                default:
                    throw new ArgumentException();
            }
            return result;
        }
        public string PrepareFood(object request)
        {
            string result = "";

            switch (request)
            {
                case ChickenOrder order:
                    int counter;
                    counter = order.GetQuantity();
                    for (int i = 1; i <= counter; i++)
                    {
                        order.CutUp();
                    }
                    order.Coock();
                    result = $"Oreder-Chicken is ready";
                    break;
                case EggOrder order:
                    int eggQuantity;
                    int countRotten = 0;
                    eggQuantity = order.GetQuantity();
                    for (int i = 1; i <= eggQuantity; i++)
                    {
                        try
                        {
                            order.Crack();
                        }
                        catch (Exception)
                        {
                            countRotten++;
                        }
                        finally
                        {
                            order.DiscardShell();
                        }


                    }
                    order.Coock();
                    result = $"Order-Egg is ready";
                    break;
                default:
                    throw new ArgumentException();
            }
            return result;

        }
    }
}
