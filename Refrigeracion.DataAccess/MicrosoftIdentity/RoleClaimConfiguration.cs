using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Refrigeracion.Entities.MicrosoftIdentity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.DataAccess.MicrosoftIdentity
{
    public class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaim>
    {
        public void Configure(EntityTypeBuilder<RoleClaim> builder)
        {
            builder.ToTable(nameof(RoleClaim));
        }
    }
}
