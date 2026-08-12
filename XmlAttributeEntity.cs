using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

namespace Nieffed.EntityFramworkCore.Xml;

[Table("XmlAttributes")]
[PrimaryKey(nameof(AttributeId))]
[Index(nameof(ParentNodeId))]
public class XmlAttributeEntity
{
    public int AttributeId { get; set; }
    public int? ParentNodeId { get; set; }
    public XmlElementEntity? ParentNode { get; set; }
    public required string Name { get; set; }
    public required string Value { get; set; }

    public static XmlAttributeEntity FromXAttribute(XAttribute xAttribute)
    {
        return new XmlAttributeEntity
        {
            Name = xAttribute.Name.LocalName,
            Value = xAttribute.Value
        };
    }
}
