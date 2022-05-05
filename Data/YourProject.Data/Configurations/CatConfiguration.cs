﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace YourProject.Data.Configurations;
public class CatConfiguration : IEntityTypeConfiguration<Cat>
{
    public void Configure(EntityTypeBuilder<Cat> cat)
    {
        cat
            .HasOne(x => x.User)
            .WithMany(u => u.Cats)
            .HasForeignKey(x => x.UserId);
    }

}

