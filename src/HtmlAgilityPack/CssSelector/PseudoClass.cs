﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
namespace HtmlAgilityPack.CssSelector
{
    public abstract class PseudoClass
    {
        private static Dictionary<string, PseudoClass> s_Classes = LoadPseudoClasses();

        public virtual IEnumerable<HtmlNode> Filter(IEnumerable<HtmlNode> nodes, string parameter)
        {
            return nodes.Where(i => CheckNode(i, parameter));
        }

        protected abstract bool CheckNode(HtmlAgilityPack.HtmlNode node, string parameter);

        
        
        public static PseudoClass GetPseudoClass(string pseudoClass)
        {
            if (!s_Classes.ContainsKey(pseudoClass))
                throw new NotSupportedException("Pseudo classe não suportada: " + pseudoClass);

            return s_Classes[pseudoClass];
        }

        private static Dictionary<string, PseudoClass> LoadPseudoClasses()
        {
            var rt = new Dictionary<string, PseudoClass>(StringComparer.OrdinalIgnoreCase);
            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(asm => asm.GetTypes().Where(i => !i.GetTypeInfo().IsAbstract && i.GetTypeInfo().IsSubclassOf(typeof(PseudoClass))));
            types = types.OrderBy(i => i.GetTypeInfo().Assembly == typeof(PseudoClass).GetTypeInfo().Assembly ? 0 : 1).ToList();
            foreach (var type in types)
            {
                var attr = type.GetTypeInfo().GetCustomAttributes(typeof(PseudoClassNameAttribute), false).Cast<PseudoClassNameAttribute>().FirstOrDefault();
                rt.Add(attr.FunctionName, (PseudoClass)Activator.CreateInstance(type));
            }

            return rt;
        }
    }
}