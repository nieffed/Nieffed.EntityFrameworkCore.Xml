using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Nieffed.EntityFramworkCore.Xml;

[Table("XmlContainers")]
public abstract class XmlContainerEntity : XmlNodeEntity
{
    public ICollection<XmlNodeEntity> Children { get; set; } = [];

    protected static List<XmlNodeEntity> GenerateChildren(
        XContainer xContainer)
    {
        List<XmlNodeEntity> children = [.. xContainer.Nodes()
            .Select(XmlNodeEntity.FromXNode)];
        int position = 0;
        foreach (var child in children)
        {
            child.Position = position++;
        }
        return children;
    }

    public static XmlContainerEntity FromXContainer(XContainer xContainer)
    {
        return xContainer switch
        {
            XElement x => XmlElementEntity.FromXElement(x),
            XDocument x => XmlDocumentEntity.FromXDocument(x),
            _ => throw new NotSupportedException(
                $"Unsupported XContainer type: {xContainer.GetType().Name}")
        };
    }
}
