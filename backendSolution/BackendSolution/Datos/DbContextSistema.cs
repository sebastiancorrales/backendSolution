using Datos.Mapping.Almacén;
using Entidades.Almacén;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos
{
    //Hacemos una combinacion entre el proyecto actual y el repositorio
    public class DbContextSistema :DbContext
    {
        //Creamos una instancia de todas las entidades creadas
        public DbSet<Categoria> Categorias { get; set; }

        public DbContextSistema(DbContextOptions<DbContextSistema> options): base(options)
        {
        }

        //void quiere decir que el metodo no retorna ningun resultado
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoriaMap());
        }
    }
}
