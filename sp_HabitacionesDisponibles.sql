CREATE PROCEDURE sp_HabitacionesDisponibles
(
    @FechaInicio DATETIME,
    @FechaFin DATETIME
)
AS
BEGIN

    SELECT
        a.Id,
        a.Nombre,
        a.Descripcion,
        a.Capacidad,
        a.CantidadHabitaciones,
        s.Nombre AS Sede
    FROM Alojamientos a
    INNER JOIN Sedes s
        ON a.SedeId = s.Id
    WHERE NOT EXISTS
    (
        SELECT 1
        FROM Reservas r
        WHERE r.AlojamientoId = a.Id
        AND (
            @FechaInicio <= r.FechaFin
            AND @FechaFin >= r.FechaInicio
        )
    )

END
GO