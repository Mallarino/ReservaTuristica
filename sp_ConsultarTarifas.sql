CREATE PROCEDURE sp_ConsultarTarifas
(
    @SedeId INT,
    @TemporadaId INT,
    @NumeroPersonas INT
)
AS
BEGIN

    SELECT
        t.Id,
        t.Nombre,
        t.Monto,
        t.CapacidadBase,
        t.ValorPersonaAdicional,

        a.Nombre AS Alojamiento,
        a.Capacidad,

        s.Nombre AS Sede,

        tp.Nombre AS Temporada

    FROM Tarifas t

    INNER JOIN Alojamientos a
        ON t.AlojamientoId = a.Id

    INNER JOIN Sedes s
        ON a.SedeId = s.Id

    INNER JOIN Temporadas tp
        ON t.TemporadaId = tp.Id

    WHERE
        s.Id = @SedeId
        AND tp.Id = @TemporadaId
        AND a.Capacidad >= @NumeroPersonas

END
