namespace Exercise2_04;

public class InvalidTemperatureConverterException : Exception
{
    public InvalidTemperatureConverterException(TemperatureUnit unit)
        : base($"Duplicate converter for {unit}.")
    {
        
    }
    public InvalidTemperatureConverterException(string message): base(message)
    {
        
    }
}