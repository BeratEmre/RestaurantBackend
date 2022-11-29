using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Enums
{
    public class Enums
    {
        public enum OrderDetailStatus
        {
            basket = 10,
            onOrder = 20
        }
        public enum OrderStatus
        {
            gettingReady = 10,
            completed = 20,
            paid = 30
        }
        public enum ProductType
        {
            food = 1,
            drink = 2,
            sweet = 3,
            menu = 4
        }
    }
}
