using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservaTuristica.Domain.Entities;
using ReservaTuristica.Domain.Enums;

namespace ReservaTuristica.Infrastructure.Data;

public static class SeedData
{
	public static async Task Initialize(AppDbContext context)
	{
		await SeedTemporada(context);
		await SeedSedes(context);
		await SeedAlojamientos(context);
        await SeedTarifas(context);
    }

	public static async Task SeedTemporada(AppDbContext context)
	{
		if (context.Temporadas.Any())
		{
			return; // DB has been seeded
		}

		var temporadas = new List<Temporada>
		{
			new Temporada
			{
				Nombre = "Baja",
				Tipo = TipoTemporada.Baja,
				FechaInicio = new DateTime(2026, 2, 1),
				FechaFin = new DateTime(2026, 11, 1)
			},
			new Temporada
			{
				Nombre = "Alta",
				Tipo = TipoTemporada.Alta,
				FechaInicio = new DateTime(2026, 11, 2),
				FechaFin = new DateTime(2027, 1, 31)
			}
		};

		context.Temporadas.AddRange(temporadas);
		await context.SaveChangesAsync();
	}

	public static async Task SeedSedes(AppDbContext context)
	{
		if (context.Sedes.Any())
		{
			return; // DB has been seeded
		}

		var sedes = new List<Sede>
		{
			//APTOS
            new Sede
            {
                Nombre = "Medellin",
                Ciudad = "Medellin",
                CapacidadTotal = 9,
                Tipo = TipoSede.Apartamento
            },
            new Sede
            {
                Nombre = "Santa Marta",
                Ciudad = "Santa Marta",
                CapacidadTotal = 20,
                Tipo = TipoSede.Apartamento
            },

			//SEDES RECREATIVAS

            new Sede
			{
				Nombre = "El placer",
				Ciudad = "Fusagasugá",
				CapacidadTotal = 34,
				Tipo = TipoSede.SedeRecreativa
			},
			new Sede
			{
				Nombre = "Villeta",
				Ciudad = "Villeta",
				Descripcion = string.Empty,
				CapacidadTotal = 32,
				Tipo = TipoSede.SedeRecreativa
			},
			new Sede
			{
				Nombre = "Gonzalo Morante",
				Ciudad = "Chinchina",
				CapacidadTotal = 30,
				Tipo = TipoSede.SedeRecreativa
			},
			new Sede
			{
				Nombre = "Tablones",
				Ciudad = "Palmira",
				CapacidadTotal = 24,
				Tipo = TipoSede.SedeRecreativa
			},
			new Sede
			{
				Nombre = "Manguruma",
				Ciudad = "Santa fe de Antioquia",
				CapacidadTotal = 46,
				Tipo = TipoSede.SedeRecreativa
			},
			new Sede
			{
				Nombre = "Federman",
				Ciudad = "Bogotá",
				CapacidadTotal = 8,
				Tipo = TipoSede.SedeRecreativa
			}
		};

		context.Sedes.AddRange(sedes);
		await context.SaveChangesAsync();
	}

	public static async Task SeedAlojamientos(AppDbContext context)
	{
		if (context.Alojamientos.Any())
		{
			return; // DB has been seeded
		}

		//APTOS
        var medellin = context.Sedes.First(s => s.Nombre == "Medellin");
        var santaMarta = context.Sedes.First(s => s.Nombre == "Santa Marta");

        //SEDES RECREATIVAS
        var elPlacer = context.Sedes.First(s => s.Nombre == "El placer");
		var villeta = context.Sedes.First(s => s.Nombre == "Villeta");
		var gonzaloMorante = context.Sedes.First(s => s.Nombre == "Gonzalo Morante");
		var tablones = context.Sedes.First(s => s.Nombre == "Tablones");
		var manguruma = context.Sedes.First(s => s.Nombre == "Manguruma");
		var federman = context.Sedes.First(s => s.Nombre == "Federman");


		var alojamientos = new List<Alojamiento>
		{
			// APTOS
			// MEDELLIN
			new Alojamiento
            {
                Nombre = "Habitacion 1",
                Descripcion = "2 camas sencillas y baño privado",
                Capacidad = 2,
                CantidadHabitaciones = 1,
                Tipo = TipoAlojamiento.Apartamento,
                SedeId = medellin.Id
            },
            new Alojamiento
            {
                Nombre = "Habitacion 2",
                Descripcion = "2 camas sencillas",
                Capacidad = 2,
                CantidadHabitaciones = 1,
                Tipo = TipoAlojamiento.Apartamento,
                SedeId = medellin.Id
            },
            new Alojamiento
            {
                Nombre = "Habitacion 3",
                Descripcion = "2 camas sencillas",
                Capacidad = 2,
                CantidadHabitaciones = 1,
                Tipo = TipoAlojamiento.Apartamento,
                SedeId = medellin.Id
            },
            new Alojamiento
            {
                Nombre = "Habitacion 4",
                Descripcion = "2 camas sencillas",
                Capacidad = 2,
                CantidadHabitaciones = 1,
                Tipo = TipoAlojamiento.Apartamento,
                SedeId = medellin.Id
            },
            new Alojamiento
            {
                Nombre = "Habitacion 5",
                Descripcion = "1 cama sencilla y baño privado",
                Capacidad = 1,
                CantidadHabitaciones = 1,
                Tipo = TipoAlojamiento.Apartamento,
                SedeId = medellin.Id
            },

			//SANTA MARTA
			new Alojamiento
            {
                Nombre = "Apartamento 202",
                Descripcion = "sala comedor, cocina, 2 baños, tres habitaciones y un sitio para parqueo",
                Capacidad = 8,
                CantidadHabitaciones = 3,
                Tipo = TipoAlojamiento.Apartamento,
                SedeId = santaMarta.Id
            },
            new Alojamiento
            {
                Nombre = "Apartamento 301",
                Descripcion = "Sala comedor, cocina, 1 baño, dos habitaciones y un sitio para parqueo",
                Capacidad = 6,
                CantidadHabitaciones = 2,
                Tipo = TipoAlojamiento.Apartamento,
                SedeId = santaMarta.Id
            },
            new Alojamiento
            {
                Nombre = "Apartamento 401",
                Descripcion = "Sala comedor, cocina, 1 baño, dos habitaciones y un sitio para parqueo",
                Capacidad = 6,
                CantidadHabitaciones = 2,
                Tipo = TipoAlojamiento.Apartamento,
                SedeId = santaMarta.Id
            },

			//SEDES RECREATIVAS
			// VILLETA
			new Alojamiento
			{
				Nombre = "Alojamiento 1",
				Descripcion = "Ocho habitaciones cada una con cama doble y camarote, baño, nevera, televisor y terraza cubierta.",
				Capacidad = 32,
				CantidadHabitaciones = 8,
				Tipo = TipoAlojamiento.Habitacion,
				SedeId = villeta.Id
			},

			// EL PLACER
			new Alojamiento
			{
				Nombre = "Alojamiento 1",
				Descripcion = "Dos habitaciones, baño y Televisor, una con cama doble y una sencilla, la otra con una cama sencilla.",
				Capacidad = 4,
				CantidadHabitaciones = 2,
				Tipo = TipoAlojamiento.Habitacion,
				SedeId = elPlacer.Id
			},
			new Alojamiento
			{
				Nombre = "Alojamiento 2",
				Descripcion = "Dos habitaciones, baño y Televisor, una con cama doble, la otra con 4 camas sencillas.",
				Capacidad = 6,
				CantidadHabitaciones = 2,
				Tipo = TipoAlojamiento.Habitacion,
				SedeId = elPlacer.Id
			},
			new Alojamiento
			{
				Nombre = "Alojamiento 3",
				Descripcion = "Una habitación con cama doble y 2 camas sencillas, baño y Televisor.",
				Capacidad = 4,
				CantidadHabitaciones = 1,
				Tipo = TipoAlojamiento.Habitacion,
				SedeId = elPlacer.Id
			},
			new Alojamiento
			{
				Nombre = "Alojamiento 4",
				Descripcion = "Dos habitaciones, baño y Televisor, una con cama doble y una sencilla, la otra con una cama sencilla.",
				Capacidad = 4,
				CantidadHabitaciones = 2,
				Tipo = TipoAlojamiento.Habitacion,
				SedeId = elPlacer.Id
			},

			// CABAÑAS EL PLACER
			new Alojamiento
			{
				Nombre = "Alojamiento 5",
				Descripcion = "Sala de estar con sofá cama y Televisor, baño, habitación con cama doble y una cama sencilla, cocineta equipada y nevera, terraza comedor.",
				Capacidad = 4,
				CantidadHabitaciones = 1,
				Tipo = TipoAlojamiento.Cabana,
				SedeId = elPlacer.Id
			},
			new Alojamiento
			{
				Nombre = "Alojamiento 6",
				Descripcion = "Sala de estar con sofá cama y Televisor, baño, habitación con cama doble y una cama sencilla, cocineta equipada y nevera, terraza comedor.",
				Capacidad = 4,
				CantidadHabitaciones = 1,
				Tipo = TipoAlojamiento.Cabana,
				SedeId = elPlacer.Id
			},
			new Alojamiento
			{
				Nombre = "Alojamiento 7",
				Descripcion = "Sala de estar con sofá cama y Televisor, baño, habitación con cama doble y una cama sencilla, cocineta equipada y nevera, terraza comedor.",
				Capacidad = 4,
				CantidadHabitaciones = 1,
				Tipo = TipoAlojamiento.Cabana,
				SedeId = elPlacer.Id
			},
			new Alojamiento
			{
				Nombre = "Alojamiento 8",
				Descripcion = "Sala de estar con sofá cama y Televisor, baño, habitación con cama doble y una cama sencilla, cocineta equipada y nevera, terraza comedor.",
				Capacidad = 4,
				CantidadHabitaciones = 1,
				Tipo = TipoAlojamiento.Cabana,
				SedeId = elPlacer.Id
			},

			// GONZALO MORANTE
			new Alojamiento
			{
				Nombre = "Alojamiento 1",
				Descripcion = "Cocineta, baño, televisor y 2 habitaciones. La primera con dos camas sencillas más dos adicionales. La segunda con una cama doble y una sencilla.",
				Capacidad = 7,
				CantidadHabitaciones = 2,
				Tipo = TipoAlojamiento.Habitacion,
				SedeId = gonzaloMorante.Id
			},
			new Alojamiento
			{
				Nombre = "Alojamiento 2",
				Descripcion = "Cocineta, baño, televisor y 2 habitaciones. La primera con una cama doble más una auxiliar doble. La segunda con dos camas sencillas más dos auxiliares.",
				Capacidad = 8,
				CantidadHabitaciones = 2,
				Tipo = TipoAlojamiento.Habitacion,
				SedeId = gonzaloMorante.Id
			},
			new Alojamiento
			{
				Nombre = "Alojamiento 3",
				Descripcion = "Cocineta, baño, televisor y una habitación con cama doble y una cama sencilla.",
				Capacidad = 3,
				CantidadHabitaciones = 1,
				Tipo = TipoAlojamiento.Habitacion,
				SedeId = gonzaloMorante.Id
			},

			// CABAÑA TIPO A
			new Alojamiento
			{
				Nombre = "Alojamiento 4 Tipo A",
				Descripcion = "Cocineta, dos baños, sala comedor, televisor y dos habitaciones. Una con cama doble y otra con dos camas sencillas más dos auxiliares.",
				Capacidad = 6,
				CantidadHabitaciones = 2,
				Tipo = TipoAlojamiento.Cabana,
				SedeId = gonzaloMorante.Id
			},

			// CABAÑAS TIPO B
			new Alojamiento
			{
				Nombre = "Alojamiento 5 Tipo B",
				Descripcion = "Cocineta, baño, sala con sofá, televisor y habitación con cama doble y una cama sencilla.",
				Capacidad = 3,
				CantidadHabitaciones = 1,
				Tipo = TipoAlojamiento.Cabana,
				SedeId = gonzaloMorante.Id
			},
			new Alojamiento
			{
				Nombre = "Alojamiento 6 Tipo B",
				Descripcion = "Cocineta, baño, sala con sofá, televisor y habitación con cama doble y una cama sencilla.",
				Capacidad = 3,
				CantidadHabitaciones = 1,
				Tipo = TipoAlojamiento.Cabana,
				SedeId = gonzaloMorante.Id
			},

			// TABLONES

			new Alojamiento
			{
				Nombre = "Alojamiento 1",
				Descripcion = "Una habitación con cama doble y un camarote. Televisor, baño, cocineta con nevera y comedor.",
				Capacidad = 4,
				CantidadHabitaciones = 1,
				Tipo = TipoAlojamiento.Habitacion,
				SedeId = tablones.Id
			},

			new Alojamiento
			{
				Nombre = "Alojamiento 2",
				Descripcion = "Una habitación con cama doble y un camarote. Televisor, baño, cocineta con nevera y comedor.",
				Capacidad = 4,
				CantidadHabitaciones = 1,
				Tipo = TipoAlojamiento.Habitacion,
				SedeId = tablones.Id
			},

			new Alojamiento
			{
				Nombre = "Alojamiento 3",
				Descripcion = "Dos habitaciones. La primera con cama doble y un camarote. La segunda con dos camarotes. Sala de estar con televisor, baño y cocineta.",
				Capacidad = 8,
				CantidadHabitaciones = 2,
				Tipo = TipoAlojamiento.Habitacion,
				SedeId = tablones.Id
			},

			new Alojamiento
			{
				Nombre = "Alojamiento 4",
				Descripcion = "Dos habitaciones. La primera con cama doble y un camarote. La segunda con dos camarotes. Sala de estar con televisor, baño y cocineta.",
				Capacidad = 8,
				CantidadHabitaciones = 2,
				Tipo = TipoAlojamiento.Habitacion,
				SedeId = tablones.Id
			},

			// MANGURUMA - SANTA FE DE ANTIOQUIA

			new Alojamiento
			{
				Nombre = "Alojamiento 1",
				Descripcion = "Una cama doble y un camarote. Baño, terraza y televisor.",
				Capacidad = 4,
				CantidadHabitaciones = 1,
				Tipo = TipoAlojamiento.Habitacion,
				SedeId = manguruma.Id
			},

			new Alojamiento
			{
				Nombre = "Alojamiento 2",
				Descripcion = "Una cama doble, un camarote y un sofá cama. Baño, terraza y televisor.",
				Capacidad = 5,
				CantidadHabitaciones = 1,
				Tipo = TipoAlojamiento.Habitacion,
				SedeId = manguruma.Id
			},

			new Alojamiento
			{
				Nombre = "Alojamiento 3",
				Descripcion = "Una cama doble, un camarote y un sofá cama. Baño, terraza y televisor.",
				Capacidad = 5,
				CantidadHabitaciones = 1,
				Tipo = TipoAlojamiento.Habitacion,
				SedeId = manguruma.Id
			},

			// BLOQUE NUEVO

			new Alojamiento
			{
				Nombre = "Bloque Nuevo 1",
				Descripcion = "Habitación con dos camas gemelas y un camarote; baño, terraza comedor y cocina. Nevera y televisor.",
				Capacidad = 4,
				CantidadHabitaciones = 1,
				Tipo = TipoAlojamiento.Habitacion,
				SedeId = manguruma.Id
			},

			new Alojamiento
			{
				Nombre = "Bloque Nuevo 2",
				Descripcion = "Habitación con dos camas gemelas y un camarote; baño, terraza comedor y cocina. Nevera y televisor.",
				Capacidad = 4,
				CantidadHabitaciones = 1,
				Tipo = TipoAlojamiento.Habitacion,
				SedeId = manguruma.Id
			},

			new Alojamiento
			{
				Nombre = "Bloque Nuevo 3",
				Descripcion = "Habitación con dos camas gemelas y un camarote; baño, terraza comedor y cocina. Nevera y televisor.",
				Capacidad = 4,
				CantidadHabitaciones = 1,
				Tipo = TipoAlojamiento.Habitacion,
				SedeId = manguruma.Id
			},

			new Alojamiento
			{
				Nombre = "Bloque Nuevo 4",
				Descripcion = "Habitación con dos camas gemelas y un camarote; baño, terraza comedor y cocina. Nevera y televisor.",
				Capacidad = 4,
				CantidadHabitaciones = 1,
				Tipo = TipoAlojamiento.Habitacion,
				SedeId = manguruma.Id
			},

			new Alojamiento
			{
				Nombre = "Bloque Nuevo 5",
				Descripcion = "Habitación con dos camas gemelas y un camarote; baño, terraza comedor y cocina. Nevera y televisor.",
				Capacidad = 4,
				CantidadHabitaciones = 1,
				Tipo = TipoAlojamiento.Habitacion,
				SedeId = manguruma.Id
			},

			new Alojamiento
			{
				Nombre = "Bloque Nuevo 6",
				Descripcion = "Habitación con dos camas gemelas y un camarote; baño, terraza comedor y cocina. Nevera y televisor.",
				Capacidad = 4,
				CantidadHabitaciones = 1,
				Tipo = TipoAlojamiento.Habitacion,
				SedeId = manguruma.Id
			},

			new Alojamiento
			{
				Nombre = "Bloque Nuevo 7",
				Descripcion = "Habitación con dos camas gemelas y un camarote; baño, terraza comedor y cocina. Nevera y televisor.",
				Capacidad = 4,
				CantidadHabitaciones = 1,
				Tipo = TipoAlojamiento.Habitacion,
				SedeId = manguruma.Id
			},

			new Alojamiento
			{
				Nombre = "Bloque Nuevo 8",
				Descripcion = "Habitación con dos camas gemelas y un camarote; baño, terraza comedor y cocina. Nevera y televisor.",
				Capacidad = 4,
				CantidadHabitaciones = 1,
				Tipo = TipoAlojamiento.Habitacion,
				SedeId = manguruma.Id
			},

			// FEDERMAN - BOGOTÁ

			new Alojamiento
			{
				Nombre = "Habitación 1",
				Descripcion = "Habitación de alojamiento para asociados en la sede Federman.",
				Capacidad = 2,
				CantidadHabitaciones = 1,
				Tipo = TipoAlojamiento.Habitacion,
				SedeId = federman.Id
			},

			new Alojamiento
			{
				Nombre = "Habitación 2",
				Descripcion = "Habitación de alojamiento para asociados en la sede Federman.",
				Capacidad = 2,
				CantidadHabitaciones = 1,
				Tipo = TipoAlojamiento.Habitacion,
				SedeId = federman.Id
			},

			new Alojamiento
			{
				Nombre = "Habitación 3",
				Descripcion = "Habitación de alojamiento para asociados en la sede Federman.",
				Capacidad = 2,
				CantidadHabitaciones = 1,
				Tipo = TipoAlojamiento.Habitacion,
				SedeId = federman.Id
			},

			new Alojamiento
			{
				Nombre = "Habitación 4",
				Descripcion = "Habitación de alojamiento para asociados en la sede Federman.",
				Capacidad = 2,
				CantidadHabitaciones = 1,
				Tipo = TipoAlojamiento.Habitacion,
				SedeId = federman.Id
			}

		};

		context.Alojamientos.AddRange(alojamientos);
		await context.SaveChangesAsync();
	}

	public static async Task SeedTarifas(AppDbContext context)
	{
        if (context.Tarifas.Any())
        {
            return;
        }

		//TEMPORADA
        var baja = context.Temporadas
			.First(t => t.Nombre == "Baja");

        var alta = context.Temporadas
            .First(t => t.Nombre == "Alta");

        //SEDES
        var medellin = context.Sedes
			.First(s => s.Nombre == "Medellin");

        var santaMarta = context.Sedes
			.First(s => s.Nombre == "Santa Marta");

        var villeta = context.Sedes
			.First(s => s.Nombre == "Villeta");

        var elPlacer = context.Sedes
            .First(s => s.Nombre == "El placer");

        var manguruma = context.Sedes
            .First(s => s.Nombre == "Manguruma");

        var tablones = context.Sedes
            .First(s => s.Nombre == "Tablones");

        var gonzaloMorante = context.Sedes
            .First(s => s.Nombre == "Gonzalo Morante");

        //ALOJAMIENTOS

        //MEDELLIN
        var habitacionMedellin = context.Alojamientos
			.First(a =>
				a.Nombre == "Habitacion 1" &&
				a.SedeId == medellin.Id);

        var habitacion2 = context.Alojamientos
            .First(a =>
                a.Nombre == "Habitacion 2" &&
                a.SedeId == medellin.Id);

        var habitacion3 = context.Alojamientos
            .First(a =>
                a.Nombre == "Habitacion 3" &&
                a.SedeId == medellin.Id);

        var habitacion4 = context.Alojamientos
            .First(a =>
                a.Nombre == "Habitacion 4" &&
                a.SedeId == medellin.Id);

        var habitacion5 = context.Alojamientos
            .First(a =>
                a.Nombre == "Habitacion 5" &&
                a.SedeId == medellin.Id);

        //SANTA MARTA
        var apartamento202 = context.Alojamientos
			.First(a =>
				a.Nombre == "Apartamento 202" &&
				a.SedeId == santaMarta.Id);

        var apartamento301 = context.Alojamientos
            .First(a =>
                a.Nombre == "Apartamento 301" &&
                a.SedeId == santaMarta.Id);

        var apartamento401 = context.Alojamientos
            .First(a =>
                a.Nombre == "Apartamento 401" &&
                a.SedeId == santaMarta.Id);

        // ALOJAMIENTOS SEDES RECREATIVAS

        var villetaAlojamiento = context.Alojamientos
			.First(a =>
				a.Nombre == "Alojamiento 1" &&
				a.SedeId == villeta.Id);

        var elPlacer1Habitacion = context.Alojamientos
            .First(a =>
                a.Nombre == "Alojamiento 3" &&
                a.SedeId == elPlacer.Id);

        var elPlacer2Habitaciones = context.Alojamientos
            .First(a =>
                a.Nombre == "Alojamiento 1" &&
                a.SedeId == elPlacer.Id);

        var mangurumaAlojamiento = context.Alojamientos
            .First(a =>
                a.Nombre == "Bloque Nuevo 1" &&
                a.SedeId == manguruma.Id);

        var tablones2Habitaciones = context.Alojamientos
            .First(a =>
                a.Nombre == "Alojamiento 3" &&
                a.SedeId == tablones.Id);

        var gonzalo1Habitacion = context.Alojamientos
            .First(a =>
                a.Nombre == "Alojamiento 5 Tipo B" &&
                a.SedeId == gonzaloMorante.Id);

        var gonzalo2Habitacion = context.Alojamientos
            .First(a =>
                a.Nombre == "Alojamiento 4 Tipo A" &&
                a.SedeId == gonzaloMorante.Id);


        var tarifas = new List<Tarifa>
		{
			//MEDELLIN
			new Tarifa
			{
				Nombre = "Habitacion 1 - 1 persona - Medellin",

				Monto = 63000,

				CapacidadBase = 1,

				ValorPersonaAdicional = 0,

				TemporadaId = baja.Id,

				AlojamientoId = habitacionMedellin.Id
			},
            new Tarifa
            {
                Nombre = "Habitacion 1 - 2 persona - Medellin",

                Monto = 75000,

                CapacidadBase = 2,

                ValorPersonaAdicional = 0,

                TemporadaId = baja.Id,

                AlojamientoId = habitacionMedellin.Id
            },
            new Tarifa
            {
                Nombre = "Habitacion 2 - 1 persona - Medellin",

                Monto = 63000,

                CapacidadBase = 1,

                ValorPersonaAdicional = 0,

                TemporadaId = baja.Id,

                AlojamientoId = habitacion2.Id
            },
            new Tarifa
            {
                Nombre = "Habitacion 2 - 2 persona - Medellin",

                Monto = 75000,

                CapacidadBase = 2,

                ValorPersonaAdicional = 0,

                TemporadaId = baja.Id,

                AlojamientoId = habitacion2.Id
            },
            new Tarifa
            {
                Nombre = "Habitacion 3 - 1 persona - Medellin",

                Monto = 63000,

                CapacidadBase = 1,

                ValorPersonaAdicional = 0,

                TemporadaId = baja.Id,

                AlojamientoId = habitacion3.Id
            },
            new Tarifa
            {
                Nombre = "Habitacion 3 - 2 persona - Medellin",

                Monto = 75000,

                CapacidadBase = 2,

                ValorPersonaAdicional = 0,

                TemporadaId = baja.Id,

                AlojamientoId = habitacion3.Id
            },
            new Tarifa
            {
                Nombre = "Habitacion 4 - 1 persona - Medellin",

                Monto = 63000,

                CapacidadBase = 1,

                ValorPersonaAdicional = 0,

                TemporadaId = baja.Id,

                AlojamientoId = habitacion4.Id
            },
            new Tarifa
            {
                Nombre = "Habitacion 4 - 2 persona - Medellin",

                Monto = 75000,

                CapacidadBase = 2,

                ValorPersonaAdicional = 0,

                TemporadaId = baja.Id,

                AlojamientoId = habitacion4.Id
            },
            new Tarifa
            {
                Nombre = "Habitacion 5 - 1 persona - Medellin",

                Monto = 63000,

                CapacidadBase = 1,

                ValorPersonaAdicional = 0,

                TemporadaId = baja.Id,

                AlojamientoId = habitacion5.Id
            },

			//SANTA MARTA - TEMPORADA BAJA
			new Tarifa
			{
				Nombre = "Apartamento 301 - Baja",

				Monto = 89000,

				CapacidadBase = 6,

				ValorPersonaAdicional = 0,

				TemporadaId = baja.Id,

				AlojamientoId = apartamento301.Id
			},

			new Tarifa
			{
				Nombre = "Apartamento 401 - Baja",

				Monto = 89000,

				CapacidadBase = 6,

				ValorPersonaAdicional = 0,

				TemporadaId = baja.Id,

				AlojamientoId = apartamento401.Id
			},

			new Tarifa
			{
				Nombre = "Apartamento 202 - Baja",

				Monto = 103000,

				CapacidadBase = 8,

				ValorPersonaAdicional = 0,

				TemporadaId = baja.Id,

				AlojamientoId = apartamento202.Id
			},

			//SANTA MARTA - TEMPORADA ALTA
			 new Tarifa
			{
				Nombre = "Apartamento 301 - Alta",

				Monto = 124000,

				CapacidadBase = 6,
		
				ValorPersonaAdicional = 0,

				TemporadaId = alta.Id,

				AlojamientoId = apartamento301.Id
			},

			new Tarifa
			{
				Nombre = "Apartamento 401 - Alta",

				Monto = 124000,

				CapacidadBase = 6,

				ValorPersonaAdicional = 0,

				TemporadaId = alta.Id,

				AlojamientoId = apartamento401.Id
			},

			new Tarifa
			{
				Nombre = "Apartamento 202 - Alta",

				Monto = 143000,

				CapacidadBase = 8,

				ValorPersonaAdicional = 0,

				TemporadaId = alta.Id,
		
				AlojamientoId = apartamento202.Id
			},

			// TARIFAS SEDES RECREATIVAS
			// 1 HABITACION

			new Tarifa
			{
				Nombre = "Villeta 1 Habitacion",

				Monto = 70000,

				CapacidadBase = 4,

				ValorPersonaAdicional = 16000,

				TemporadaId = baja.Id,

				AlojamientoId = villetaAlojamiento.Id
			},

			new Tarifa
			{
				Nombre = "El Placer 1 Habitacion",

				Monto = 70000,

				CapacidadBase = 4,

				ValorPersonaAdicional = 16000,

				TemporadaId = baja.Id,

				AlojamientoId = elPlacer1Habitacion.Id
			},

			new Tarifa
			{
				Nombre = "Gonzalo Morante 1 Habitacion",

				Monto = 70000,

				CapacidadBase = 4,

				ValorPersonaAdicional = 16000,

				TemporadaId = baja.Id,

				AlojamientoId = gonzalo1Habitacion.Id
			},

            new Tarifa
            {
                Nombre = "Manguruma 1 Habitacion",

                Monto = 70000,

                CapacidadBase = 4,

                ValorPersonaAdicional = 16000,

                TemporadaId = baja.Id,

                AlojamientoId = mangurumaAlojamiento.Id
            },

			// 2 HABITACIONES

			new Tarifa
			{
				Nombre = "El Placer 2 Habitaciones",

				Monto = 90000,

				CapacidadBase = 4,

				ValorPersonaAdicional = 16000,

				TemporadaId = baja.Id,

				AlojamientoId = elPlacer2Habitaciones.Id
			},

            new Tarifa
            {
                Nombre = "Gonzalo Morante 2 Habitaciones",

                Monto = 90000,

                CapacidadBase = 4,

                ValorPersonaAdicional = 16000,

                TemporadaId = baja.Id,

                AlojamientoId = gonzalo2Habitacion.Id
            },

            new Tarifa
			{
				Nombre = "Tablones 2 Habitaciones",

				Monto = 90000,

				CapacidadBase = 4,

				ValorPersonaAdicional = 16000,

				TemporadaId = baja.Id,

				AlojamientoId = tablones2Habitaciones.Id
			},


		};

        context.Tarifas.AddRange(tarifas);
		await context.SaveChangesAsync();

    }
}
