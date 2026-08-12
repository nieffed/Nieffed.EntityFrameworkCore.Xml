using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Nieffed.EntityFramworkCore.Xml;

[Table("XmlElements")]
public class XmlElementEntity : XmlContainerEntity
{
    public required string Name { get; set; }
    public List<XmlAttributeEntity> Attributes { get; set; } = [];

    public static XmlElementEntity FromXElement(XElement xElement)
    {
        return new XmlElementEntity
        {
            Name = xElement.Name.LocalName,
            Attributes = [.. xElement.Attributes()
                .Select(XmlAttributeEntity.FromXAttribute)],
            Children = GenerateChildren(xElement)
        };
    }
}
