using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

namespace Nieffed.EntityFramworkCore.Xml;

[Table("XmlNodes")]
[PrimaryKey(nameof(NodeId))]
[Index(nameof(ParentNodeId))]
[Index(nameof(Position))]
public class XmlNodeEntity
{
    public int NodeId { get; set; }
    public int? ParentNodeId { get; set; }
    public XmlContainerEntity? ParentNode { get; set; }
    public int Position { get; set; }

    public static XmlNodeEntity FromXNode(XNode xNode)
    {
        return xNode switch
        {
            XContainer x => XmlContainerEntity.FromXContainer(x),
            XCData x => XmlCDataEntity.FromXCData(x),
            XText x => XmlTextEntity.FromXText(x),
            XComment x => XmlCommentEntity.FromXComment(x),
            XDocumentType x => XmlDocumentTypeEntity.FromXDocumentType(x),
            XProcessingInstruction x => XmlProcessingInstructionEntity
                .FromXProcessingInstruction(x),
            _ => throw new NotSupportedException(
                $"Unsupported XNode type: {xNode.GetType().Name}")
        };
    }
}
