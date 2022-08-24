using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoAplication.Models;

namespace ToDoAplication.Database
{
    public class ToDoMapping : IEntityTypeConfiguration<ToDo>
    {
        public void Configure(EntityTypeBuilder<ToDo> builder)
        {
            builder.ToTable("ToDo");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.Property(x => x.Todo).HasColumnType("nvarchar").HasMaxLength(50);
            builder.Property(x => x.status).HasDefaultValue(false);
            builder.Property(x => x.Date).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Comment).HasColumnType("nvarchar(max)");
        }
    }
}
