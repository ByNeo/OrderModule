using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Infrastructure
{
    public class API
    {
        public static class Order
        {
            public static string CreateOrder(string baseUri)
            {
                return $"{baseUri}/createorder ";
            }
        }
    }
}
