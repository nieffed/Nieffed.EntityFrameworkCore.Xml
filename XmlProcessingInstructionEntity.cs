using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Nieffed.EntityFramworkCore.Xml;

[Table("XmlProcessingInstructions")]
public class XmlProcessingInstructionEntity : XmlNodeEntity
{
    public required string Target { get; set; }
    public required string Data { get; set; }

    public static XmlProcessingInstructionEntity FromXProcessingInstruction(
        XProcessingInstruction xProcessingInstruction)
    {
        return new XmlProcessingInstructionEntity
        {
            Target = xProcessingInstruction.Target,
            Data = xProcessingInstruction.Data
        };
    }
}
