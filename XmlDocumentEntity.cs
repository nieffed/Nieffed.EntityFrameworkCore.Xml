using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Nieffed.EntityFramworkCore.Xml;

[Table("XmlDocuments")]
public class XmlDocumentEntity : XmlContainerEntity
{
    public XmlElementEntity? RootElement =>
        Children.OfType<XmlElementEntity>().FirstOrDefault();

    public static XmlDocumentEntity FromXDocument(XDocument xDocument)
    {
        return new XmlDocumentEntity
        {
            Children = GenerateChildren(xDocument)
        };
    }
}
