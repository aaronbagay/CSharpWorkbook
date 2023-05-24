namespace Exercise2_04;

public class FarenheitConverter : ITemperatureConverter
{
    public TemperatureUnit Unit => TemperatureUnit.F;

    public Temperature ToC(Temperature temperature)
    {
        return new (5.0 / 9 * (temperature.degrees - 32), TemperatureUnit.C);
    }

    public Temperature FromC(Temperature temperature)
    {
        return new (9.0 / 5 * temperature.degrees + 32, Unit);
    }
}