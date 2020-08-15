﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MLOps.NET.Entities.Impl;

namespace MLOps.NET.Storage.EntityMaps
{
    internal sealed class DeploymentTargetMap : IEntityTypeConfiguration<DeploymentTarget>
    {
        public void Configure(EntityTypeBuilder<DeploymentTarget> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.IsProduction).IsRequired();

            builder
                .HasMany(x => x.Deployments)
                .WithOne(x => x.DeploymentTarget)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
