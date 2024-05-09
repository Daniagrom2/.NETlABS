using System;
using System.Collections.Generic;
using System.Linq;

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

    // Метод для видалення даних погоди
    public void RemoveWeatherData(DateTime date)
    {
        data.RemoveAll(d => d.Date.Date == date.Date);
    }

    // Метод для оновлення даних погоди
    public void UpdateWeatherData(DateTime date, WeatherData newData)
    {
        var existingData = data.FirstOrDefault(d => d.Date.Date == date.Date);
        if (existingData != null)
        {
            existingData.Temperature = newData.Temperature;
            existingData.Humidity = newData.Humidity;
            existingData.WindSpeed = newData.WindSpeed;
        }
        else
        {
            Console.WriteLine("No data found for this date!");
        }
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

        // Видалення даних
        station.RemoveWeatherData(DateTime.Now.AddDays(-1));

        // Оновлення даних
        station.UpdateWeatherData(DateTime.Now, new WeatherData(DateTime.Now, 26.0f, 55.0f, 10.0f));

        // Відображення даних
        station.DisplayAllData();
    }
}