using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Nieffed.EntityFramworkCore.Xml;

[Table("XmlTexts")]
public class XmlTextEntity : XmlNodeEntity
{
    public required string Value { get; set; }

    public static XmlTextEntity FromXText(XText xText)
    {
        return xText switch
        {
            XCData x => XmlCDataEntity.FromXCData(x),
            _ => new XmlTextEntity { Value = xText.Value }
        };
    }
}
