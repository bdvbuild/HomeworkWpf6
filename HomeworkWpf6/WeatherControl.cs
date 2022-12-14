using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HomeworkWpf6
{
    enum Precipitation
    { 
            Sunny = 0, 
            Cloudy = 1, 
            Rain = 2, 
            Snow = 3
    }

    internal class WeatherControl : DependencyObject
    {

        public WeatherControl(int temp, string windDirection, int windSpeed, Precipitation precipitation)
        {
            Temp = temp;
            WindDirection = windDirection;
            WindSpeed = windSpeed;
            this.precipitation = precipitation;
        }

        public int Temp
        {
            get => (int)GetValue(TempProperty);
            set => SetValue(TempProperty, value);
        }
        public string WindDirection { get; set; }
        public int WindSpeed { get; set; }

        public readonly Precipitation precipitation;

        public static readonly DependencyProperty TempProperty;

        static WeatherControl()
        {
            TempProperty = DependencyProperty.Register(
            nameof(Temp),
            typeof(int),
            typeof(WeatherControl),
            new FrameworkPropertyMetadata(
                0,
                FrameworkPropertyMetadataOptions.AffectsMeasure |
                FrameworkPropertyMetadataOptions.AffectsArrange,
                null,
                new CoerceValueCallback(CoerceTemp)),
            new ValidateValueCallback(ValidateTemp));
        }

        private static bool ValidateTemp(object value)
        {
            int t = (int)value;
            if (t > 50 || t< -50) 
            {
                return false;
            }
            return true;
        }

        private static object CoerceTemp(DependencyObject d, object baseValue)
        {
            int t = (int)baseValue;
            if (t > 50 || t < -50)
            {
                return null;
            }
            return t;
        }
    }
}
