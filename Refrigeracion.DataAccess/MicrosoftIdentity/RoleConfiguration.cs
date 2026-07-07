using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Refrigeracion.Entities.MicrosoftIdentity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.DataAccess.MicrosoftIdentity
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable(nameof(Role));
        }
    }
}
