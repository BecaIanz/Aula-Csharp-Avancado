using System.Data;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

var connBuilder = new SqlConnectionStringBuilder {
    DataSource = "localhost",
    InitialCatalog = "AulaHoje",
    IntegratedSecurity = true,
    TrustServerCertificate = true
};
var stringConnection = connBuilder.ToString();

var optsBuilder = new DbContextOptionsBuilder();
optsBuilder.UseSqlServer(stringConnection);
var options = optsBuilder.Options;

var db = new ExampleDbContext(options);
// await db.Database.EnsureDeletedAsync();
await db.Database.EnsureCreatedAsync();

// INSERT
// var usuario = new Usuario {
//     Nome = "Cristian",
//     NascimentoData = DateTime.Now,
//     Salario = 1.5m
// };
// db.Add(usuario);
// await db.SaveChangesAsync();

// // db.Add(new Compra {
// //     Produto = "figurinha",
// //     Valor = 1m,
// //     UsuarioID = usuario.ID
// // });
// // await db.SaveChangesAsync();

// DELETE
// var cristian = await db.Usuarios
//     .FirstOrDefaultAsync(u => u.Nome == "Cristian");
// db.Remove(cristian);
// await db.SaveChangesAsync();

// UPDATE
// var cristian = await db.Usuarios
//     .FirstOrDefaultAsync(u => u.Nome == "Cristian");
// cristian.Salario = 1000m;
// await db.SaveChangesAsync();

// JOIN AUTOMATICO
// var cristian = await db.Usuarios
//     .Include(u => u.Compras)
//     .FirstOrDefaultAsync(u => u.Nome == "Cristian");
// foreach (var compra in cristian.Compras)
//     Console.WriteLine(compra.Produto);

// JOIN MANUAL
// var query =
//     from u in db.Usuarios
//     join c in db.Compras
//     on u.ID equals c.UsuarioID
//     select new { Usuario = u.Nome, c.Produto };
// var data = await query.ToListAsync();
// foreach (var item in data)
//     Console.WriteLine($"{item.Usuario} comprou {item.Produto}");

// QUERY
// var query = 
//     from u in db.Usuarios
//     where u.NascimentoData.Year == 2025
//     where u.Salario > 1
//     select new { u.Nome, u.Salario };
// var names = await query.ToListAsync();
// foreach (var name in names)
//     Console.WriteLine(name);

// CREATE
// db.Add(new Usuario {
//     Nome = "Cristian",
//     Salario = 2.50m,
//     NascimentoData = DateTime.Now
// });
// await db.SaveChangesAsync();

public class ExampleDbContext(DbContextOptions opts) : DbContext(opts)
{
    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Compra> Compras => Set<Compra>();

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Usuario>();

        model.Entity<Compra>()
            .HasOne(c => c.Usuario)
            .WithMany(u => u.Compras)
            .HasForeignKey(c => c.UsuarioID)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public class Usuario
{
    public int ID { get; set; }
    public string Nome { get; set; }
    public decimal Salario { get; set; }
    public DateTime NascimentoData { get; set; }

    public ICollection<Compra> Compras { get; set; } = [];
}

public class Compra
{
    public int ID { get; set; }
    public string Produto { get; set; }
    public decimal Valor { get; set; }
    public int UsuarioID { get; set; }

    public Usuario Usuario { get; set; }
}