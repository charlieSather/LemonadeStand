using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemondeStandProject
{
    class Weather
    {
        public string condition { get; set; }
        public int temperature { get; set; }
        List<string> weatherConditions;
        public string predictedForecast { get; set; }

        public Weather(string condition, int temperature, List<string> weatherConditions, string predictedForecast)
        {
            this.condition = condition;
            this.temperature = temperature;
            this.weatherConditions = weatherConditions;
            this.predictedForecast = predictedForecast;
        }




    }
}
