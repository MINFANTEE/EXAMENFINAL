﻿using FINANZASAPP2022INFANTE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FINANZASAPP2022INFANTE.DB.Mapping;

public class CuentaMapping: IEntityTypeConfiguration<Cuenta>
{
    public void Configure(EntityTypeBuilder<Cuenta> builder)
    {
        builder.ToTable("Cuenta", "dbo");
        builder.HasKey(o => o.Id);

        builder.HasOne(o => o.TipoCuenta)
            .WithMany()
            .HasForeignKey(o => o.TipoCuentaId);    }
}