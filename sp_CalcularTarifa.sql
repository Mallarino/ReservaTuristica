CREATE PROCEDURE sp_CalcularTarifa
(
    @TarifaId INT,
    @NumeroPersonas INT,
    @NumeroHabitaciones INT
)
AS
BEGIN

    DECLARE @MontoBase DECIMAL(18,2)
    DECLARE @CapacidadBase INT
    DECLARE @ValorPersonaAdicional DECIMAL(18,2)

    DECLARE @PersonasAdicionales INT
    DECLARE @Total DECIMAL(18,2)

    -- Obtener tarifa
    SELECT
        @MontoBase = Monto,
        @CapacidadBase = CapacidadBase,
        @ValorPersonaAdicional = ValorPersonaAdicional
    FROM Tarifas
    WHERE Id = @TarifaId

    -- Calcular personas adicionales
    IF @NumeroPersonas > @CapacidadBase
    BEGIN
        SET @PersonasAdicionales =
            @NumeroPersonas - @CapacidadBase
    END
    ELSE
    BEGIN
        SET @PersonasAdicionales = 0
    END

    -- Calcular total
    SET @Total =
        (
            @MontoBase
            +
            (@PersonasAdicionales * @ValorPersonaAdicional)
        )
        *
        @NumeroHabitaciones

    -- Resultado
    SELECT
        @MontoBase AS MontoBase,
        @CapacidadBase AS CapacidadBase,
        @PersonasAdicionales AS PersonasAdicionales,
        @ValorPersonaAdicional AS ValorPersonaAdicional,
        @NumeroHabitaciones AS NumeroHabitaciones,
        @Total AS Total

END
GO