using System.IO;
using System.Linq;
using Xunit;
using HtmlAgilityPack;
namespace HtmlAgilityPackTests
{
	public class HtmlNode
	{
		[Fact]
		public void EnsureAttributeOriginalCaseIsPreserved()
		{
			var html = "<html><body><div AttributeIsThis=\"val\"></div></body></html>";
			var doc = new HtmlDocument
				          {
					          OptionOutputOriginalCase = true
				          };
			doc.LoadHtml(html);
			var div = doc.DocumentNode.Descendants("div").FirstOrDefault();
			var writer = new StringWriter();
			div.WriteTo(writer);
			var result = writer.GetStringBuilder().ToString();
			Assert.Equal("<div AttributeIsThis=\"val\"></div>", result);
		}
	}
}
