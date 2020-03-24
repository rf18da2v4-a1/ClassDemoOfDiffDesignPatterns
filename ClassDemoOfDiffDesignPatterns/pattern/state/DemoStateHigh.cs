using System;
using System.Collections.Generic;
using System.Text;

namespace ClassDemoOfDiffDesignPatterns.pattern.state
{
    class DemoStateHigh : IState
    {
        public int HandleCalculate(int priceExTax)
        {
            return (int)(priceExTax * 1.25);
        }
    }
}
