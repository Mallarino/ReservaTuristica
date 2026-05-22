CREATE PROCEDURE sp_HabitacionesDisponiblesPorPersonas
(
    @FechaInicio DATETIME,
    @FechaFin DATETIME,
    @NumeroPersonas INT
)
AS
BEGIN

    SELECT
        a.Id,
        a.Nombre,
        a.Descripcion,
        a.Capacidad,
        a.CantidadHabitaciones,
        s.Nombre AS Sede,
        CONVERT(DECIMAL(18,2), 0) AS Precio
    FROM Alojamientos a
    INNER JOIN Sedes s
        ON a.SedeId = s.Id
    WHERE a.Capacidad >= @NumeroPersonas
    AND NOT EXISTS
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