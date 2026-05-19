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
				FechaInicio = new DateTime(2026, 1, 15),
				FechaFin = new DateTime(2026, 6, 15)
			},
			new Temporada
			{
				Nombre = "Alta",
				Tipo = TipoTemporada.Alta,
				FechaInicio = new DateTime(2026, 6, 16),
				FechaFin = new DateTime(2026, 8, 31)
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

		var elPlacer = context.Sedes.First(s => s.Nombre == "El placer");
		var villeta = context.Sedes.First(s => s.Nombre == "Villeta");
		var gonzaloMorante = context.Sedes.First(s => s.Nombre == "Gonzalo Morante");
		var tablones = context.Sedes.First(s => s.Nombre == "Tablones");
		var manguruma = context.Sedes.First(s => s.Nombre == "Manguruma");
		var federman = context.Sedes.First(s => s.Nombre == "Federman");

		var alojamientos = new List<Alojamiento>
		{
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
				Descripcion = "Sala de estar con sofá cama y Televisor, baño, habitación con cama doble y una cama sencilla, cocineta equipada y neverra, terraza comedor.",
				Capacidad = 4,
				CantidadHabitaciones = 1,
				Tipo = TipoAlojamiento.Cabana,
				SedeId = elPlacer.Id
			},
			new Alojamiento
			{
				Nombre = "Alojamiento 7",
				Descripcion = "Sala de estar con sofá cama y Televisor, baño, habitación con cama doble y una cama sencilla, cocineta equipada y neverra, terraza comedor.",
				Capacidad = 4,
				CantidadHabitaciones = 1,
				Tipo = TipoAlojamiento.Cabana,
				SedeId = elPlacer.Id
			},
			new Alojamiento
			{
				Nombre = "Alojamiento 8",
				Descripcion = "Sala de estar con sofá cama y Televisor, baño, habitación con cama doble y una cama sencilla, cocineta equipada y neverra, terraza comedor.",
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
				Descripcion = "Una habitación con cama doble y un camarote. Televisor, baño, cocineta con neverra y comedor.",
				Capacidad = 4,
				CantidadHabitaciones = 1,
				Tipo = TipoAlojamiento.Habitacion,
				SedeId = tablones.Id
			},

			new Alojamiento
			{
				Nombre = "Alojamiento 2",
				Descripcion = "Una habitación con cama doble y un camarote. Televisor, baño, cocineta con neverra y comedor.",
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
}
