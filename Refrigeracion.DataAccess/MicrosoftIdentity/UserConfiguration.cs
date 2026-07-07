using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Refrigeracion.Entities.MicrosoftIdentity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.DataAccess.MicrosoftIdentity
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));
        }
    }
}
