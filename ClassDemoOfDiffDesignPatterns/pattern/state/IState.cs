using System;
using System.Collections.Generic;
using System.Text;

namespace ClassDemoOfDiffDesignPatterns.pattern.state
{
    interface IState
    {
        int HandleCalculate(int priceExTax);
    }
}
