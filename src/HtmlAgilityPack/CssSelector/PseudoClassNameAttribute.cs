using System;

namespace HtmlAgilityPack.CssSelector
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PseudoClassNameAttribute : Attribute
    {
        public string FunctionName { get; private set; }

        public PseudoClassNameAttribute(string name)
        {
            this.FunctionName = name;
        }
    }
}
