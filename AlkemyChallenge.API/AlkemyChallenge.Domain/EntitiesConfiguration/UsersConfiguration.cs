using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AlkemyChallenge.Domain.Entities;

namespace AlkemyChallenge.Domain.EntitiesConfiguration
{
    
    public class UsersConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(c => c.UsersId);
            builder.Property(c => c.UsersId)
                .ValueGeneratedOnAdd()
                .IsRequired(true);

            builder.Property(u => u.Username)
               .IsRequired(true)
               .HasMaxLength(50);

            builder.Property(p => p.Password)
               .IsRequired(true)
               .HasMaxLength(50);

            builder.Property(m => m.Mail)
               .IsRequired(true)
               .HasMaxLength(50);
        }
        
    }

}