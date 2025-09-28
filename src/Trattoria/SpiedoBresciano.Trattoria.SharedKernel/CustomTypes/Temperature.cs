namespace SpiedoBresciano.Trattoria.SharedKernel.CustomTypes;

public record Temperature
{
    public double Celsius { get; }
    public double Fahrenheit => (Celsius * 9 / 5) + 32;

    public Temperature(double celsius)
    {
        if (celsius < -273.15)
            throw new ArgumentException("Temperature cannot be below absolute zero");
        
        Celsius = celsius;
    }

    public static Temperature FromCelsius(double celsius) => new(celsius);
    public static Temperature FromFahrenheit(double fahrenheit) => new((fahrenheit - 32) * 5 / 9);

    public override string ToString() => $"{Celsius:F1}°C";

    public static implicit operator double(Temperature temperature) => temperature.Celsius;
}