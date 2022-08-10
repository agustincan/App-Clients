using Client.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Persistence.Database.Configuration
{
    internal class ClientConfiguration
    {
        public ClientConfiguration(EntityTypeBuilder<ClientTbl> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.Id);
            entityBuilder.Property(x => x.Names).IsRequired().HasMaxLength(200);
            entityBuilder.Property(x => x.LastNames).IsRequired().HasMaxLength(200);
            entityBuilder.Property(x => x.CelularPhone).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.Email).IsRequired().HasMaxLength(50);
        }
    }
}
