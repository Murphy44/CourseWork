using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWork
{
    class Program 
    {
        static void Main(string[] args)
        {
            List<Galaxy> galaxies = new List<Galaxy>();
            List<Stars> stars = new List<Stars>();
            List<Planet> planets = new List<Planet>();
            List<Moons> moons = new List<Moons>();

            string input = Console.ReadLine().Trim();
            string[] data = input.Split(' ');

            while(!"exit".Equals(input))
            {
                if ("add".Equals(data[0]))
                {
                    switch (data[1])
                    {
                        case "galaxy":
                            string[] typesOfGalaxies =
                                {
                                    "elliptical",
                                    "lenticular",
                                    "spiral",
                                    "irregular"
                                };
                            string galaxyName = input.Split('[')[1].Split(']')[0];
                            Galaxy galaxy = new Galaxy();
                            galaxy.name = galaxyName;

                            if (Array.Exists(typesOfGalaxies, element => element == input.Split(']')[1].Split()[1]))
                            {
                                galaxy.type = input.Split(']')[1].Split(' ')[1];
                            }
                            else
                            {
                                throw new ArgumentException("Uknown type of galaxy! Pease eneter a valid type!");
                            }
                            galaxy.age = input.Split(']')[1].Split(' ')[2];
                            galaxies.Add(galaxy);
                            break;

                        case "star":
                            Stars star = new Stars
                            {
                                ParentName = input.Split('[')[1].Split(']')[0],
                                name = input.Split('[')[2].Split(']')[0],
                                StarType = input.Split(']')[2].Trim()
                            };
                            stars.Add(star);
                            break;

                        case "planet":
                            Planet planet = new Planet();
                            string[] planetTypes =
                                {
                                    "terrestrial",
                                    "giant planet",
                                    "ice giant",
                                    "mesoplanet",
                                    "mini-neptune",
                                    "planetar",
                                    "super-earth",
                                    "super-jupiter",
                                    "sub-earth"
                                };
                            Planet newPlanet = new Planet
                            {
                                ParentName = input.Split('[')[1].Split(']')[0],
                                name = input.Split('[')[2].Split(']')[0]
                            };
                            string planetData = input.Split(']')[2].Trim();
                            if (Array.Exists(planetTypes, value => value == planetData.Remove(planetData.Length - 3).Trim()))
                            {
                                newPlanet.Data = planetData;
                            }
                            else
                            {
                                throw new ArgumentException("Invalid planet!" + planetData.Split(' ')[^1]);
                            }
                            planets.Add(newPlanet);
                            break;
                        case "moon":
                            Moons moon = new Moons
                            {
                                ParentName = input.Split('[')[1].Split(']')[0],
                                name = input.Split('[')[2].Split(']')[0]
                            };
                            moons.Add(moon);
                            break;
                    }
                }
                else if ("stats".Equals(data[0]))
                {
                    Console.WriteLine("--- Stats ---");
                    Console.WriteLine($"Galaxies: {galaxies.Count}");
                    Console.WriteLine($"Stars: {stars.Count}");
                    Console.WriteLine($"Planets: {planets.Count}");
                    Console.WriteLine($"Moons: {moons.Count}");
                    Console.WriteLine("--- End of stats ---");
                }
                else if ("list".Equals(data[0]))
                {
                    string allObjectsFromType = "";
                    switch (data[1])
                    {
                        case "galaxies":
                            Console.WriteLine("--- List of all researched galaxies ---");
                            foreach (var galaxy in galaxies)
                            {
                                allObjectsFromType += galaxy.name + ", ";
                            }
                            Console.WriteLine(allObjectsFromType.Remove(allObjectsFromType.Length - 2, 2));
                            Console.WriteLine("--- End of galaxies list ---");
                            break;
                        case "stars":
                            Console.WriteLine("--- List of all researched stars ---");
                            foreach (var star in stars)
                            {
                                allObjectsFromType += star.name + ", ";
                            }
                            Console.WriteLine(allObjectsFromType.Remove(allObjectsFromType.Length - 2, 2));
                            Console.WriteLine("--- End of stars list ---");
                            break;
                        case "planets":
                            Console.WriteLine("--- List of all researched planets ---");
                            foreach (var planet in planets)
                            {
                                allObjectsFromType += planet.name + ", ";
                            }
                            Console.WriteLine(allObjectsFromType.Remove(allObjectsFromType.Length - 2, 2));
                            Console.WriteLine("--- End of planets list ---");
                            break;
                        case "moons":
                            Console.WriteLine("--- List of all researched moons ---");
                            foreach (var moon in moons)
                            {
                                allObjectsFromType += moon.name + ", ";
                            }
                            Console.WriteLine(allObjectsFromType.Remove(allObjectsFromType.Length - 2, 2));
                            Console.WriteLine("--- End of moons list ---");
                            break;
                        default:
                            Console.WriteLine("none");
                            break;
                    }
                }
                else if ("print".Equals(data[0]))
                {
                    string print = input.Split('[')[1].Split(']')[0];
                    Galaxy foundGalaxy = galaxies.Find(currentGalaxy => currentGalaxy.name == print);
                    if (foundGalaxy != null)
                    {
                        Console.WriteLine($"--- Data for {foundGalaxy.name} galaxy ---");
                        Console.WriteLine("Type: " + foundGalaxy.type);
                        Console.WriteLine("Age: " + foundGalaxy.age);
                        Console.WriteLine("Stars: ");
                    }
                    else
                    {
                        Console.WriteLine("none");
                    }
                    if (stars.Exists(star => star.ParentName == print))
                    {
                        foreach (Stars star in stars)
                        {
                            if (star.ParentName == print)
                            {
                                Console.WriteLine("Name: " + star.name);
                                Console.WriteLine("Class: " + star.StarType);
                                Console.WriteLine("Planets: ");

                                if (planets.Exists(planet => planet.ParentName == star.name))
                                {
                                    foreach (Planet planet in planets)
                                    {
                                        if (planet.ParentName == star.name)
                                        {
                                            Console.WriteLine("Name: " + planet.name);
                                            Console.WriteLine("Type: " + planet.Data.Remove(planet.Data.Length - 3).Trim());
                                            Console.WriteLine("Support life: " + planet.Data.Split(' ')[^1]);
                                            Console.WriteLine("Moons: ");

                                            if (moons.Exists(moon => moon.ParentName == planet.name))
                                            {
                                                foreach (Moons moon in moons)
                                                {
                                                    if (moon.ParentName == planet.name)
                                                    {
                                                        Console.WriteLine(" " + moon.name);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("none");
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("none");
                                    Console.WriteLine("Moons: ");
                                    Console.WriteLine("none");
                                }
                            }
                        }
                        Console.WriteLine($"--- End of data for {print} galaxy ---");
                    }
                    else
                    {
                        Console.WriteLine("none");
                        Console.WriteLine("Planets: ");
                        Console.WriteLine("none");
                        Console.WriteLine("Moons: ");
                        Console.WriteLine("none");
                    }
                }
                input = Console.ReadLine().Trim();
                data = input.Split(' ');
            }
        }
    }
}
