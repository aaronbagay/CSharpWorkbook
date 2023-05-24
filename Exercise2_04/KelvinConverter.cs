namespace Exercise2_04;

public class KelvinConverter : ITemperatureConverter
{
    public const double AbsoluteZero = -273.15;
    
    public TemperatureUnit Unit => TemperatureUnit.K;

    public Temperature ToC(Temperature temperature)
    {
        return new (temperature.degrees + AbsoluteZero, TemperatureUnit.C);
    }

    public Temperature FromC(Temperature temperature)
    {
        return new (temperature.degrees - AbsoluteZero, Unit);
    }
}