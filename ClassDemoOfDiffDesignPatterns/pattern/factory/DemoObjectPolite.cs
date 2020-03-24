using System;
using System.Collections.Generic;
using System.Text;

namespace ClassDemoOfDiffDesignPatterns.pattern.factory
{
    class DemoObjectPolite:IDemoObject
    {
        public void Print(string name)
        {
            Console.WriteLine($"Dear {name}");
        }
    }
}
