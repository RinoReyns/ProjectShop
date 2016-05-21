using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectShop
{
    interface ICount
    {
        double Count(int quantity, double price, bool? checkbox);
    }
}
