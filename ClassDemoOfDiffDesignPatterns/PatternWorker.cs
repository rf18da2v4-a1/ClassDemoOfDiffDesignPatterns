using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Schema;
using ClassDemoOfDiffDesignPatterns.pattern.abstractFactory;
using ClassDemoOfDiffDesignPatterns.pattern.adaptor;
using ClassDemoOfDiffDesignPatterns.pattern.decorator;
using ClassDemoOfDiffDesignPatterns.pattern.facade;
using ClassDemoOfDiffDesignPatterns.pattern.factory;
using ClassDemoOfDiffDesignPatterns.pattern.observer;
using ClassDemoOfDiffDesignPatterns.pattern.proxy;
using ClassDemoOfDiffDesignPatterns.pattern.singleton;
using ClassDemoOfDiffDesignPatterns.pattern.state;
using ClassDemoOfDiffDesignPatterns.pattern.strategy;
using ClassDemoOfDiffDesignPatterns.pattern.template;
using FactoryType = ClassDemoOfDiffDesignPatterns.pattern.factory.FactoryType;
using IComponent = ClassDemoOfDiffDesignPatterns.pattern.decorator.IComponent;
using IDemoObject = ClassDemoOfDiffDesignPatterns.pattern.factory.IDemoObject;

namespace ClassDemoOfDiffDesignPatterns
{
    class PatternWorker
    {
        public void Start()
        {
            /*
             DemoFactoryMethod();
             
            
            DemoSingleton();
            

            DemoAbstractFactory();
            
            
            DemoAdaptor();
          

            DemoFacade();
              
            
            DemoProxy();
            
            DemoDecorator();
            
            
            DemoObserver();
           */
            //DemoTemplate();

            //DemoStrategy();

            DemoState();
            
        }

        private void DemoFactoryMethod()
        {
            IDemoObject obj = DemoFactory.GetClass(FactoryType.Polite);
            obj.Print("Peter");

            IDemoObject obj2 = DemoFactory.GetClass(FactoryType.Friendly);
            obj2.Print("Peter");

        }

        private void DemoSingleton()
        {
            /*
            NoteCatalogue c1 = new NoteCatalogue();
            c1.Add("New note");
            Console.WriteLine(c1);

            NoteCatalogue c2 = new NoteCatalogue();
            c2.Add("yet another note");
            Console.WriteLine(c2);
            */

            NoteCatalogue c1 = NoteCatalogue.Instance;
            c1.Add("New note");
            Console.WriteLine(c1);

            NoteCatalogue c2 =  NoteCatalogue.Instance;
            c2.Add("yet another note");
            Console.WriteLine(c2);

        }

        private void DemoAbstractFactory()
        {
            IFactory factory = AbstractFactory.GetFactory(AbstractFactoryType.Uk);
            pattern.abstractFactory.IDemoObject obj = factory.GetClass(pattern.abstractFactory.FactoryType.Polite);
            obj.Print("Peter");

            IFactory factory2 = AbstractFactory.GetFactory(AbstractFactoryType.Dk);
            pattern.abstractFactory.IDemoObject obj2 = factory2.GetClass(pattern.abstractFactory.FactoryType.Friendly);
            obj2.Print("Peter");

        }

        private void DemoAdaptor()
        {
            IAdaptor adap = new Adaptor1();
            string newstr = adap.Request("anders");
            Console.WriteLine(newstr);

            IAdaptor adap2 = new Adaptor2();
            string newstr2 = adap2.Request("anders");
            Console.WriteLine(newstr2);

        }

        private void DemoFacade()
        {
            Facade facade = new Facade();

            facade.InsertNote("Remember to Shop on the way home");
            facade.NewShopItem("Milk");

            Console.WriteLine("My shoping list \n" + string.Join("\n", facade.GetShoppingList()));


        }

        private void DemoProxy()
        {
            IDemoProxy proxy = new RealProxy();

            proxy.InsertString("Peter");
            proxy.InsertString("Anders");
            proxy.InsertString("Vibeke");
            proxy.InsertString("Michael C");

            foreach (string s in proxy.GetAll())
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("    AFTER PROXY ");
            IDemoProxy proxy2 = new ProxyClass("SWC");

            proxy2.InsertString("Peter");
            proxy2.InsertString("Anders");
            
            foreach (string s in proxy2.GetAll())
            {
                Console.WriteLine(s);
            }

        }

        private void DemoDecorator()
        {
            // Concrete
            IComponent component = new ConcreteComponent();
            Console.WriteLine(component.DoSomething("peter"));

            IComponent comp2 = new Decorator1(component);
            Console.WriteLine(comp2.DoSomething("peter"));

            IComponent comp3 = new Decorator1(comp2);
            Console.WriteLine(comp3.DoSomething("peter"));

        }

        private void DemoObserver()
        {
            // I am observer
            ObservableObject obj = new ObservableObject(3, "text");
            obj.Text = "Peter"; // nothing happen


            // attach to be observer
            obj.PropertyChanged += (s, args) =>
            {
                Console.WriteLine($"the changed property is {args.PropertyName}");
                Console.WriteLine($"New values is \n{s}");
            };

            // alternative
            obj.PropertyChanged += Update;

            obj.Text = "Anders";

        }

        /*
         * Help to Observer
         */
        protected void Update(object obj, PropertyChangedEventArgs args)
        {
            Console.WriteLine($"the changed property is {args.PropertyName}");
            Console.WriteLine($"New values is \n{obj}");
        }



        private void DemoTemplate()
        {
            List<String> data = new List<string>()
            {
                "Peter",
                "Anders",
                "Vibeke",
                "Michael C"
            };

            AbstractTemplateClass temp = new MySubTemplate();
            temp.InsertTemplateMethod(data);

            Console.WriteLine(temp);

        }

        private void DemoStrategy()
        {
            List<String> data = new List<string>()
            {
                "Peter",
                "Anders",
                "Vibeke",
                "Michael C"
            };

            ContextClass context = new ContextClass();
            context.InsertStrategyMethod(data, new ConcreteStrategy());
            Console.WriteLine(context);


            ContextClassMoreCSharpLike context2 = new ContextClassMoreCSharpLike();
            context2.StrategyMethod = (s) => { return s.Substring(1); };
            context2.InsertStrategyMethod(data);
            Console.WriteLine(context2);

        }

        private void DemoState()
        {
            // low tax
            IState calc = new DemoStateLow();
            int price = calc.HandleCalculate(10000);
            Console.WriteLine($"Price with low tax is {price}");

            // high tax
            calc = new DemoStateHigh();
            price = calc.HandleCalculate(10000);
            Console.WriteLine($"Price with high tax is {price}");
        }
    }
}