CREATE PROCEDURE sp_CalcularTarifa
(
    @SedeId INT,
    @TemporadaId INT,
    @NumeroPersonas INT,
    @NumeroHabitaciones INT
)
AS
BEGIN

    DECLARE @MontoBase DECIMAL(18,2)
    DECLARE @CapacidadBase INT
    DECLARE @ValorPersonaAdicional DECIMAL(18,2)

    DECLARE @PersonasAdicionales INT = 0
    DECLARE @Total DECIMAL(18,2)

    -- Obtener tarifa correcta
    SELECT TOP 1
        @MontoBase = t.Monto,
        @CapacidadBase = t.CapacidadBase,
        @ValorPersonaAdicional = t.ValorPersonaAdicional
    FROM Tarifas t

    INNER JOIN Alojamientos a
        ON t.AlojamientoId = a.Id

    INNER JOIN Sedes s
        ON a.SedeId = s.Id

    WHERE
        s.Id = @SedeId
        AND t.TemporadaId = @TemporadaId
        AND a.CantidadHabitaciones = @NumeroHabitaciones
        AND 
        (
        -- es apartamento Y tiene capacidad suficiente
        (s.Tipo = 1 AND a.Capacidad >= @NumeroPersonas)
        
        OR 

        s.Tipo = 2 

        )
        AND
        (
            -- tarifa fija Y capacidad suficiente
            (
                t.ValorPersonaAdicional = 0
                AND t.CapacidadBase >= @NumeroPersonas
            )

            OR

            -- Tarifa con adicinales
            (
                t.ValorPersonaAdicional > 0
             
            )
        )


    -- Validar si encontró tarifa
    IF @MontoBase IS NULL
    BEGIN
        RAISERROR(
            'No encontramos alojamiento para tus necesidades',
            16,
            1
        )

        RETURN
    END

    -- Solo calcular adicionales si aplica
    IF @ValorPersonaAdicional > 0
    BEGIN

        IF @NumeroPersonas > @CapacidadBase
        BEGIN
            SET @PersonasAdicionales =
                @NumeroPersonas - @CapacidadBase
        END

    END

    -- Calcular total
    SET @Total =
        @MontoBase
        +
        (@PersonasAdicionales * @ValorPersonaAdicional)

    -- Resultado
    SELECT
        @MontoBase AS MontoBase,
        @CapacidadBase AS CapacidadBase,
        @PersonasAdicionales AS PersonasAdicionales,
        @ValorPersonaAdicional AS ValorPersonaAdicional,
        @Total AS Total

END
GO
