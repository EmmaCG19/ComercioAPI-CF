﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ComercioAPI.DAL
{
    public class EcommerceDbContextInitializer : DropCreateDatabaseAlways<EcommerceDbContext>
    {
        protected override void Seed(EcommerceDbContext context)
        {
            //Seed database before executing

            context.Categorias.Add(new Categoria() { Descripcion = "Indumentaria" });
            context.SaveChanges();

            var productos = new List<Producto>()
                {
                    new Producto(){Descripcion="botines nike", Precio=4500, Stock=20, Categoria = context.Categorias.Where(c => c.Descripcion.Equals("Indumentaria")).FirstOrDefault<Categoria>() },
                    new Producto(){Descripcion="pantalones de jean", Precio=1300, Stock=100, Categoria = context.Categorias.Where(c => c.Descripcion.Equals("Indumentaria")).FirstOrDefault<Categoria>()},
                    new Producto(){Descripcion="saco de cuero", Precio=9000, Stock=10},
                    new Producto(){Descripcion="zapatillas adidas", Precio=2500, Stock=50},
                    new Producto(){Descripcion="camisa lisa negra", Precio=1500, Stock=20, Categoria = context.Categorias.Where(c => c.Descripcion.Equals("Indumentaria")).FirstOrDefault<Categoria>()},

                };


            var vendedores = new List<Vendedor>()
                {
                    new Vendedor(){Nombre="Emmanuel", Apellido="Fernandez", DNI=38396359, FechaDeNacimiento= new DateTime(1994,6,15)},
                    new Vendedor(){Nombre="Juan", Apellido="Martinez", DNI=10300123 /*FechaDeNacimiento= new DateTime(1995,7,31)*/}

                };


            productos.ForEach(p => 
                                    {
                                      context.Productos.Add(p);
                                      context.SaveChanges();
                                    });

            vendedores.ForEach(v =>
            {
                context.Vendedores.Add(v);
                context.SaveChanges();
            });


            base.Seed(context);
        }

    }
}