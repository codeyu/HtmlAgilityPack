using System.Linq;
using System.IO;
using Xunit;
using HtmlAgilityPack.CssSelector;
namespace HtmlAgilityPackTests
{
    public class CssSelectorTest
    {
        private HtmlAgilityPack.HtmlDocument doc;
        public CssSelectorTest()
        {
            var path = Path.GetFullPath("../HtmlAgilityPack/src/HtmlAgilityPackTests/files/");
            doc = new HtmlAgilityPack.HtmlDocument();
            doc.Load(path + "Test1.html");

        }
        [Fact]
        public void IdSelectorMustReturnOnlyFirstElement()
        {
            var elements = doc.QuerySelectorAll("#myDiv");

            Assert.True(elements.Count == 1);
            Assert.True(elements[0].Id == "myDiv");
            Assert.True(elements[0].Attributes["first"].Value == "1");
        }

        [Fact]
        public void GetElementsByAttribute()
        {
            var elements = doc.QuerySelectorAll("*[id=myDiv]");

            Assert.True(elements.Distinct().Count() == 2 && elements.Count == 2);
            for (int i = 0; i < elements.Count; i++)
                Assert.True(elements[i].Id == "myDiv");
        }

        [Fact]
        public void GetElementsByClassName1()
        {
            var elements1 = doc.QuerySelectorAll(".cls-a");
            var elements2 = doc.QuerySelectorAll(".clsb");

            Assert.True(elements1.Count == 1);
            for (int i = 0; i < elements1.Count; i++)
                Assert.True(elements1[i] == elements2[i]);
        }

		[Fact]
        public void GetElementsByClassName_MultiClasses()
        {
            var elements = doc.QuerySelectorAll(".cls-a, .cls-b");

            Assert.True(elements.Count == 2);
            Assert.True(elements[0].Id == "spanA");
            Assert.True(elements[1].Id == "spanB");
        }

		[Fact]
        public void GetElementsByClassName_WithUnderscore()
        {
            var elements = doc.QuerySelectorAll(".underscore_class");

            Assert.True(elements.Count == 1);
            Assert.True(elements[0].Id == "spanB");
        }



        

    }
}
