using System;
using System.Collections.Generic;

// Клас для представлення погодних даних
public class WeatherData
{
    public DateTime Date { get; set; }
    public float Temperature { get; set; }
    public float Humidity { get; set; }
    public float WindSpeed { get; set; }

    public WeatherData(DateTime date, float temperature, float humidity, float windSpeed)
    {
        Date = date;
        Temperature = temperature;
        Humidity = humidity;
        WindSpeed = windSpeed;
    }

    public override string ToString()
    {
        return $"Date: {Date}, Temperature: {Temperature} C, Humidity: {Humidity} %, Wind Speed: {WindSpeed} km/h";
    }
}

// Клас для представлення метеорологічної станції
public class WeatherStation
{
    public string Name { get; set; }
    private List<WeatherData> data;

    public WeatherStation(string name)
    {
        Name = name;
        data = new List<WeatherData>();
    }

    public void AddWeatherData(WeatherData weatherData)
    {
        data.Add(weatherData);
    }

    public void DisplayAllData()
    {
        Console.WriteLine($"Weather Data for {Name}:");
        foreach (var item in data)
        {
            Console.WriteLine(item);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        WeatherStation station = new WeatherStation("Kyiv Weather Station");

        // Додавання даних
        station.AddWeatherData(new WeatherData(DateTime.Now, 25.3f, 60.0f, 5.0f));
        station.AddWeatherData(new WeatherData(DateTime.Now.AddDays(-1), 22.1f, 65.0f, 15.2f));

        // Відображення даних
        station.DisplayAllData();
    }
}
