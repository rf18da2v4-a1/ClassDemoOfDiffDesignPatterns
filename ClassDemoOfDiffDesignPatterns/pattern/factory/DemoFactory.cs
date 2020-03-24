using System;
using System.Collections.Generic;
using System.Text;

namespace ClassDemoOfDiffDesignPatterns.pattern.factory
{
    class DemoFactory
    {
        public static IDemoObject GetClass(FactoryType typeOfClass)
        {
            switch (typeOfClass)
            {
                case FactoryType.Friendly: return  new DemoObjectFriendly();
                case FactoryType.Polite: return new DemoObjectPolite();
            }

            return new DemoObjectPolite();
        }
    }
}
