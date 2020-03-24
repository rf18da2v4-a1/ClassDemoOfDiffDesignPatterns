using System;
using System.Collections.Generic;
using System.Text;

namespace ClassDemoOfDiffDesignPatterns.pattern.template
{
    class MySubTemplate:AbstractTemplateClass
    {
        protected override string MakeString(string s)
        {
            return s.ToLower();
        }
    }
}
