using System;
using System.Collections.Generic;
using System.Text;

namespace ClassDemoOfDiffDesignPatterns.pattern.decorator
{
    class Decorator1:IComponent
    {
        private IComponent _component;

        public Decorator1(IComponent component)
        {
            _component = component;
        }

        public string DoSomething(string str)
        {
            return "Mr " + _component.DoSomething(str);
        }
    }
}
