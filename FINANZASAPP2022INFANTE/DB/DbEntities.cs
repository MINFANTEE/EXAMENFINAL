using FINANZASAPP2022INFANTE.DB.Mapping;
using FINANZASAPP2022INFANTE.Models;
using Microsoft.EntityFrameworkCore;

namespace FINANZASAPP2022INFANTE.DB;

public class DbEntities: DbContext
{
    public virtual DbSet<Cuenta> Cuentas { get; set; }
    public virtual DbSet<TipoCuenta> TipoCuentas { get; set; }

    public DbEntities(){}
    public DbEntities(DbContextOptions<DbEntities> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CuentaMapping());
        modelBuilder.ApplyConfiguration(new TipoCuentaMapping());
    }
    
    public static List<Transaccion> Transacciones = new();
    
    
    
}