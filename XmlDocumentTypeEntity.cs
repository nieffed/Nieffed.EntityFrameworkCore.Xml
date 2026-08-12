using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Nieffed.EntityFramworkCore.Xml;

[Table("XmlDocumentTypes")]
public class XmlDocumentTypeEntity : XmlNodeEntity
{
    public required string Name { get; set; }
    public string? PublicId { get; set; }
    public string? SystemId { get; set; }
    public string? InternalSubset { get; set; }

    public static XmlDocumentTypeEntity FromXDocumentType(XDocumentType xDocumentType)
    {
        return new XmlDocumentTypeEntity
        {
            Name = xDocumentType.Name,
            PublicId = xDocumentType.PublicId,
            SystemId = xDocumentType.SystemId,
            InternalSubset = xDocumentType.InternalSubset
        };
    }
}