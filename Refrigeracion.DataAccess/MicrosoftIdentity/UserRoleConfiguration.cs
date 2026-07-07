using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Refrigeracion.Entities.MicrosoftIdentity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.DataAccess.MicrosoftIdentity
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable(nameof(UserRole));
        }
    }
}
