namespace Exercise2_04;

public class InvalidTemperatureConversionException : Exception {
    public InvalidTemperatureConversionException(TemperatureUnit unitTo)
        : base($"No supported convertion to {unitTo}") {}
}