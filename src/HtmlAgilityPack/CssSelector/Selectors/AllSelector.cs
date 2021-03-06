﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlAgilityPack.CssSelector.Selectors
{
    internal class AllSelector : CssSelector
    {
        public override string Token
        {
            get { return "*"; }
        }

        protected internal override IEnumerable<HtmlAgilityPack.HtmlNode> FilterCore(IEnumerable<HtmlAgilityPack.HtmlNode> currentNodes)
        {
            return currentNodes;
        }
    }
}