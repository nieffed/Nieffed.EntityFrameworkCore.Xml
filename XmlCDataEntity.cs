using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Nieffed.EntityFramworkCore.Xml;

[Table("XmlCData")]
public class XmlCDataEntity : XmlTextEntity
{
    public static XmlCDataEntity FromXCData(XCData xCData)
    {
        return new XmlCDataEntity
        {
            Value = xCData.Value
        };
    }
}
