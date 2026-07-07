using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Refrigeracion.Entities.MicrosoftIdentity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.DataAccess.MicrosoftIdentity
{
    public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.ToTable(nameof(UserToken));
        }
    }
}
