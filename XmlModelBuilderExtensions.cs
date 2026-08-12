using Microsoft.EntityFrameworkCore;

namespace Nieffed.EntityFramworkCore.Xml;

public static class XmlModelBuilderExtensions
{
    public static ModelBuilder ApplyXmlModel(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<XmlAttributeEntity>(entity =>
        {
            entity.HasOne(x => x.ParentNode)
                .WithMany(x => x.Attributes)
                .HasForeignKey(x => x.ParentNodeId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<XmlNodeEntity>(entity =>
        {
            entity.HasOne(x => x.ParentNode)
                .WithMany(x => x.Children)
                .HasForeignKey(x => x.ParentNodeId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<XmlCommentEntity>();
        modelBuilder.Entity<XmlDocumentTypeEntity>();
        modelBuilder.Entity<XmlProcessingInstructionEntity>();
        modelBuilder.Entity<XmlTextEntity>();
        modelBuilder.Entity<XmlCDataEntity>();
        modelBuilder.Entity<XmlContainerEntity>();
        modelBuilder.Entity<XmlDocumentEntity>();
        modelBuilder.Entity<XmlElementEntity>();
        
        return modelBuilder;
    }
}
