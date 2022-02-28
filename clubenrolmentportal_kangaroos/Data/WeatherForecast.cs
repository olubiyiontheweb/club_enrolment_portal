using System;

namespace clubenrolmentportal_kangaroos.Data
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}

// will use this later
// https://github.com/dotnet-presentations/blazor-workshop/blob/master/docs/06-authentication-and-authorization.md