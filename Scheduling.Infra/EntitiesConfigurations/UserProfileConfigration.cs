using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModuleName.Domain.Entity;
using Scheduling.Domain.Entity;

namespace Scheduling.Infra.ProvidersConfigurations
{
    internal class UserProfileConfigration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.ToTable("UserProfiles");

            builder.HasKey(e => e.Id).UseIdentityColumn();
        }
    }
}