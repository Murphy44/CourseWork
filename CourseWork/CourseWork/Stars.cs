using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWork
{
     public class Stars : Galaxy
    {
        public string ParentName { get; set; }
        public string starType;
        public string StarType
        {
            get { return this.starType; }
            set
            {
                int temperature;
                double luminosity;
                double mass;
                double size;
                string[] starStats = value.Split(' ');

                if (double.TryParse(starStats[0], out mass)
                    && double.TryParse(starStats[1], out size)
                    && int.TryParse(starStats[2], out temperature)
                    && double.TryParse(starStats[3], out luminosity))
                    {
                        string starsStatsOutput = $"{mass:0.00}, {size:0.00}, {temperature}, {luminosity:0.00}";
                        if (temperature >= 30000 
                        && luminosity >= 30000
                        && mass >= 16
                        && size >= 6.6)
                        {
                            this.starType = "O";
                        }
                        else if (temperature < 30000 && temperature >= 10000
                            && luminosity < 30000 && luminosity >= 25
                            && mass < 16 && mass >= 2.1
                            && size < 6.6 && mass >= 1.8)
                        {
                            this.starType = "B";
                        }
                        else if (temperature >= 7500 && temperature < 10000
                            && luminosity >= 5 && luminosity < 25
                            && mass >= 1.4 && mass < 2.1
                            && size >= 1.4 && size < 1.8)
                        {
                            this.starType = "A";
                        }
                        else if (temperature >= 6000 && temperature < 7500
                            && luminosity >= 1.5 && luminosity < 5
                            && mass >= 1.04 && mass < 1.4
                            && size >= 1.15 && size < 1.4)
                        {
                            this.starType = "F";
                        }
                        else if (temperature >= 5200 && temperature < 6000
                            && luminosity >= 0.6 && luminosity < 1.5
                            && mass >= 0.8 && mass < 1.04
                            && size >= 0.96 && size < 1.15)
                        {
                        Console.WriteLine("heheheehe");
                        this.starType = "G";
                        }
                        else if (temperature >= 3700 && temperature < 5200
                            && luminosity >= 0.08 && luminosity < 0.6
                            && mass >= 0.45 && mass < 0.8
                            && size >= 0.7 && mass < 0.96)
                        {
                            this.starType = "K";
                        }
                        else if (temperature >= 2400 && temperature < 3700
                            && luminosity < 0.08
                            && mass >= 0.08 && mass < 0.45
                            && size < 0.7)
                        {
                            this.starType = "M";
                        }
                        else
                        {
                        throw new ArgumentException("There is no such type!");
                        }
                        this.starType += starsStatsOutput;
                }
                this.starType = value;
            }
        }

        public Stars()
        {

        }
    }
}
