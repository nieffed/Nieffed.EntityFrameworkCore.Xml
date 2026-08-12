using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Nieffed.EntityFramworkCore.Xml;

[Table("XmlComments")]
public class XmlCommentEntity : XmlNodeEntity
{
    public required string Value { get; set; }

    public static XmlCommentEntity FromXComment(XComment xComment)
    {
        return new XmlCommentEntity
        {
            Value = xComment.Value
        };
    }
}
