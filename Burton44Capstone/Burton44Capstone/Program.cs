using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Burton44Capstone
{
    // *************************************************************
    // Title: Capstone Project
    // Application type: .NET Core
    // Description: A program that retreives the user's birthdate and provides them with some interesting factoids
    // Class: CIT 110 with John Velis
    // Date: 11-28-2018
    // Author: Richard Burton
    // Last Modified: 
    // *************************************************************

    class Program
    {
        static void Main(string[] args)
        {
            DateTime bday;
            int differenceInDays = 0;

            DisplayOpeningScreen();
            bday = DisplayGetBirthdate();
            DisplayMainMenu(bday, differenceInDays);
            DisplayClosingScreen();
        }
        static void DisplayOpeningScreen()
        {
            DisplayHeader("Richard Burton's CIT 110 Capstone Project");
            Console.WriteLine();
            Console.WriteLine("In this program you will be able to see a myriad of interesting things");
            Console.WriteLine("about yourself that pertain to your date of birth.");
            Console.WriteLine();
            Console.WriteLine("Press any key to begin");
            Console.ReadKey();
        }
        static DateTime DisplayGetBirthdate()
        {
            string birthday;
            bool validate;
            DateTime bday;

            DisplayHeader("What is your date of birth?");
            Console.WriteLine();
            Console.WriteLine("To access the myriad of interesting things about your");
            Console.WriteLine("birthdate, you will need to enter it now.");
            Console.WriteLine("Use the following format: MM/dd/yyyy");
            birthday = Console.ReadLine();
            validate = DateTime.TryParseExact(birthday, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out bday);
            while (!validate)
            {
                Console.WriteLine("Your birthday was not entered in the correct format, please try again:");
                Console.WriteLine("Correct format: MM/dd/yyyy");
                birthday = Console.ReadLine();
                validate = validate = DateTime.TryParseExact(birthday, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out bday);
            }

            return bday;
        }
        static void DisplayMainMenu(DateTime bday, int differenceInDays)
        {
            string menuChoice;
            bool loopRunning = true;

            DisplayHeader("Interesting factoids you may have never known.");
            Console.WriteLine();
            Console.WriteLine("Choose from the following options:");
            Console.WriteLine("A) Time you have been alive");
            Console.WriteLine("B) Number of breaths you are likely to have exhaled");
            Console.WriteLine("C) Number of moon cycles you have lived through");
            Console.WriteLine("D) Your Western zodiac sign and some info");
            Console.WriteLine("E) Your Chinese zodiac sign and some info");
            Console.WriteLine("F) Re-enter birth date");
            Console.WriteLine("Q) Exit program.");

            while (loopRunning)
            {
                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "a":
                    case "A":
                        DisplayDaysAlive(bday);
                        DisplayMainMenu(bday, differenceInDays);
                        loopRunning = false;
                        break;
                    case "b":
                    case "B":
                        DisplayBreaths(bday);
                        DisplayMainMenu(bday, differenceInDays);
                        loopRunning = false;
                        break;
                    case "c":
                    case "C":
                        DisplayMoonCycles(bday);
                        DisplayMainMenu(bday, differenceInDays);
                        loopRunning = false;
                        break;
                    case "d":
                    case "D":
                        DisplayWesternZodiac(bday);
                        DisplayMainMenu(bday, differenceInDays);
                        loopRunning = false;
                        break;
                    case "e":
                    case "E":
                        DisplayEasternZodiac(bday);
                        DisplayMainMenu(bday, differenceInDays);
                        loopRunning = false;
                        break;
                    case "f":
                    case "F":
                        bday = DisplayGetBirthdate();
                        DisplayMainMenu(bday, differenceInDays);
                        loopRunning = false;
                        break;
                    case "q":
                    case "Q":
                        loopRunning = false;
                        break;
                    default:
                        Console.WriteLine("Sorry, invalid entry, please try again.");
                        break;
                }
            }

        }
        static int DisplayDaysAlive(DateTime bday)
        {
            DateTime now = DateTime.Now;
            TimeSpan ts = now - bday;
            int differenceInDays = ts.Days;
            int hoursAlive = differenceInDays * 24;
            int secondsAlive = hoursAlive * 60;

            DisplayHeader("Time you have lived.");
            Console.WriteLine();
            Console.WriteLine($"You have lived {differenceInDays:n} days.");
            Console.WriteLine();
            Console.WriteLine($"You have lived {hoursAlive:n} hours.");
            Console.WriteLine();
            Console.WriteLine($"You have lived {secondsAlive:n} seconds.");
            Console.WriteLine();
            Console.WriteLine("Press any key to return to main menu");
            Console.ReadKey();

            return differenceInDays;
        }

        static void DisplayBreaths(DateTime bday)
        {
            DateTime now = DateTime.Now;
            TimeSpan ts = now - bday;
            int differenceInDays = ts.Days;
            int breaths = (differenceInDays * 23040);

            DisplayHeader("Number of breaths you've taken.");
            Console.WriteLine();
            Console.WriteLine("The average human takes 23,040 breaths a day.");
            Console.WriteLine("Source: https://www.heraldtribune.com/news/20100112/every-breath-you-take");
            Console.WriteLine();
            Console.WriteLine($"By this average, you have taken {breaths:n} breaths in your lifetime.");
            Console.WriteLine();
            Console.WriteLine("Press any key to return to main menu");
            Console.ReadKey();

        }
        static void DisplayMoonCycles(DateTime bday)
        {
            DateTime now = DateTime.Now;
            TimeSpan ts = now - bday;
            double differenceInDays = ts.Days;
            double moonCycles = (differenceInDays / 27.3);

            DisplayHeader("Number of moon cycles you have lived through");
            Console.WriteLine();
            Console.WriteLine("The moon cycle is 27.3 days long");
            Console.WriteLine();
            Console.WriteLine($"You have lived through {moonCycles:n} in your lifetime");
            Console.WriteLine();
            Console.WriteLine("Press any key to return to main menu");
            Console.ReadKey();

        }
        static void DisplayWesternZodiac(DateTime bday)
        {
            int BMonth = bday.DayOfYear;

            DisplayHeader("Your Western Zodiac");
            Console.WriteLine();
            Console.WriteLine("Sources:");
            Console.WriteLine("https://astrostyle.com/zodiac-signs/");
            Console.WriteLine("https://en.wikipedia.org/wiki/Astrological_sign");
            Console.WriteLine();


            if (BMonth >= 0 && BMonth <= 19)
            {
                Console.WriteLine("\tYour Zodiac symbol is Capricorn - The Goat");
                Console.WriteLine();
                Console.WriteLine("Ruling celestial body: Saturn");
                Console.WriteLine();
                Console.WriteLine("Info: The measured master planner of the horoscope family, \nCapricorn energy teaches us the power of \nstructure and long-term goals.");
            }
            if (BMonth >= 20 && BMonth <= 49)
            {
                Console.WriteLine("\tYour Zodiac symbol is Aquarius - The Water Bearer");
                Console.WriteLine();
                Console.WriteLine("Ruling celestial body: Saturn");
                Console.WriteLine();
                Console.WriteLine("Info: The mad scientist and humanitarian of the horoscope wheel, futuristic Aquarius energy helps us \ninnovate and unite for social justice.");
            }
            if (BMonth >= 50 && BMonth <= 79)
            {
                Console.WriteLine("\tYour Zodiac symbol is Pisces - The Fish");
                Console.WriteLine();
                Console.WriteLine("Ruling celestial body: Jupiter");
                Console.WriteLine();
                Console.WriteLine("Info: The dreamer and healer of the horoscope family, Pisces energy awakens compassion, \nimagination and artistry, uniting us as one.");
            }
            if (BMonth >= 80 && BMonth <= 109)
            {
                Console.WriteLine("\tYour Zodiac symbol is Aries - The Ram");
                Console.WriteLine();
                Console.WriteLine("Ruling celestial body: Mars");
                Console.WriteLine();
                Console.WriteLine("Info:The pioneer and trailblazer of the horoscope wheel, Aries energy helps us initiate, \nfight for our beliefs and fearlessly put ourselves out there.");
            }
            if (BMonth >= 110 && BMonth <= 140)
            {
                Console.WriteLine("\tYour Zodiac symbol is Taurus - The Bull");
                Console.WriteLine();
                Console.WriteLine("Ruling celestial body: Venus and Earth");
                Console.WriteLine();
                Console.WriteLine("Info: The persistent provider of the horoscope family, \nTaurus energy helps us seek security, \nenjoy earthly pleasures and get the job done.");
            }
            if (BMonth >= 141 && BMonth <= 171)
            {
                Console.WriteLine("\tYour Zodiac symbol is Gemini - The Twins");
                Console.WriteLine();
                Console.WriteLine("Ruling celestial body: Mercury");
                Console.WriteLine();
                Console.WriteLine("Info: The most versatile and vibrant horoscope sign, Gemini energy helps us communicate, \ncollaborate and fly our freak flags at full mast.");
            }
            if (BMonth >= 172 && BMonth <= 203)
            {
                Console.WriteLine("\tYour Zodiac symbol is Cancer - The Crab");
                Console.WriteLine();
                Console.WriteLine("Ruling celestial body: Moon");
                Console.WriteLine();
                Console.WriteLine("Info: The natural nurturer of the horoscope wheel, Cancer energy helps us connect with our feelings, \nplant deep roots and feather our family nests.");
            }
            if (BMonth >= 204 && BMonth <= 234)
            {
                Console.WriteLine("\tYour Zodiac symbol is Leo - The Lion");
                Console.WriteLine();
                Console.WriteLine("Ruling celestial body: Sun");
                Console.WriteLine();
                Console.WriteLine("Info: The drama queen and regal ruler of the horoscope clan, Leo energy helps us shine, express ourselves boldly \nand wear our hearts on our sleeves.");
            }
            if (BMonth >= 235 && BMonth <= 265)
            {
                Console.WriteLine("\tYour Zodiac symbol is Virgo - The Virgin");
                Console.WriteLine();
                Console.WriteLine("Ruling celestial body: Mercury and Ceres");
                Console.WriteLine();
                Console.WriteLine("Info: The masterful helper of the horoscope wheel, Virgo energy teaches us to serve, do impeccable work \nand prioritize wellbeing—of ourselves, our loved ones and the planet.");
            }
            if (BMonth >= 266 && BMonth <= 295)
            {
                Console.WriteLine("\tYour Zodiac symbol is Libra - The Scales");
                Console.WriteLine();
                Console.WriteLine("Ruling celestial body: Venus");
                Console.WriteLine();
                Console.WriteLine("Info: The balanced beautifier of the horoscope family, Libra energy inspires us to seek peace, \nharmony and cooperation—and to do it with style and grace.");
            }
            if (BMonth >= 296 && BMonth <= 325)
            {
                Console.WriteLine("\tYour Zodiac symbol is Scorpio - The Scorpion");
                Console.WriteLine();
                Console.WriteLine("Ruling celestial body: Mars");
                Console.WriteLine();
                Console.WriteLine("Info: The most intense and focused of the horoscope signs, Scorpio energy helps us dive deep, \nmerge our superpowers and form bonds that are built to last.");
            }
            if (BMonth >= 326 && BMonth <= 355)
            {
                Console.WriteLine("\tYour Zodiac symbol is Sagittarius - The Archer");
                Console.WriteLine();
                Console.WriteLine("Ruling celestial body: Jupiter");
                Console.WriteLine();
                Console.WriteLine("Info: The worldly adventurer of the horoscope wheel, Sagittarius energy inspires us to dream big, \nchase the impossible and take fearless risks.");
            }
            if (BMonth >= 356 && BMonth <= 366)
            {
                Console.WriteLine("\tYour Zodiac symbol is Capricorn - The Goat");
                Console.WriteLine();
                Console.WriteLine("Ruling celestial body: Saturn");
                Console.WriteLine();
                Console.WriteLine("Info: The measured master planner of the horoscope family, Capricorn energy teaches us the power of \nstructure and long-term goals.");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to return to main menu");
            Console.ReadKey();

        }
        static void DisplayEasternZodiac(DateTime bday)
        {
            int BYear = bday.Year;

            DisplayHeader("Your Eastern Zodiac");
            Console.WriteLine();
            Console.WriteLine("Sources:");
            Console.WriteLine("https://astrostyle.com/zodiac-signs/");
            Console.WriteLine("https://www.chinahighlights.com/travelguide/chinese-zodiac/");
            Console.WriteLine();

            if (new int[] { 1900, 1912, 1924, 1936, 1948, 1960, 1972, 1984, 1996, 2008, 2020, 2032 }.Contains(BYear))
            {
                Console.WriteLine("\tYour sign is the Rat");
                Console.WriteLine();
                Console.WriteLine("With strong intuition and quick responses, Rats always easily");
                Console.WriteLine("adapt themselves to a new environment.");
                Console.WriteLine("With rich imaginations and sharp observations, they can take");
                Console.WriteLine("advantage of various opportunities well.");
                Console.WriteLine("Rats have strong curiosity, so they tend to try their hands at anything,");
                Console.WriteLine("and they can deal with tasks skillfully.");
            }
            if (new int[] { 1901, 1913, 1925, 1937, 1949, 1961, 1973, 1985, 1997, 2009, 2021, 2033 }.Contains(BYear))
            {
                Console.WriteLine("\tYour sign is the Ox");
                Console.WriteLine();
                Console.WriteLine("Oxes are known for diligence, dependability, strength and determination.");
                Console.WriteLine("Having an honest nature, Oxes have a strong patriotism for their country,");
                Console.WriteLine("have ideals and ambitions for life, and attach importance to family and work.");
            }
            if (new int[] { 1902, 1914, 1926, 1938, 1950, 1962, 1974, 1986, 1998, 2010, 2022, 2034 }.Contains(BYear))
            {
                Console.WriteLine("\tYour sign is the Tiger");
                Console.WriteLine();
                Console.WriteLine("Tigers enjoy good health. They are active so they like to do various sports.");
                Console.WriteLine("Small illnesses, such as colds, coughs, and fever, are rarely experienced by Tigers.");
            }
            if (new int[] { 1903, 1915, 1927, 1939, 1951, 1963, 1975, 1987, 1999, 2011, 2023, 2035 }.Contains(BYear))
            {
                Console.WriteLine("\tYour sign is the Rabbit");
                Console.WriteLine();
                Console.WriteLine("Rabbits tend to be gentle, quiet, elegant, and alert; quick, skillful, kind,");
                Console.WriteLine("and patient; and particularly responsible.");
                Console.WriteLine("However, they might be superficial, stubborn, melancholy, and overly-discreet.");
                Console.WriteLine("Generally speaking, people who belong to the Rabbit zodiac sign have");
                Console.WriteLine("likable characters.");
            }
            if (new int[] { 1904, 1916, 1928, 1940, 1952, 1964, 1976, 1988, 2000, 2012, 2024, 2036 }.Contains(BYear))
            {
                Console.WriteLine("\tYour sign is the Dragon");
                Console.WriteLine();
                Console.WriteLine("Among Chinese zodiac animals, the Dragon is the sole imaginary animal.");
                Console.WriteLine("The Dragon is the most vital and powerful beast in the Chinese zodiac,");
                Console.WriteLine("although with an infamous reputation for being a hothead and");
                Console.WriteLine("possessing a sharp tongue.");
                Console.WriteLine("In ancient times, people thought that Dragons could control everything in the");
                Console.WriteLine("world with their character traits of dominance and ambition.");
            }
            if (new int[] { 1905, 1917, 1929, 1941, 1953, 1965, 1977, 1989, 2001, 2013, 2025, 2037 }.Contains(BYear))
            {
                Console.WriteLine("\tYour sign is the Snake");
                Console.WriteLine();
                Console.WriteLine("In Chinese culture, the Snake is the most enigmatic animal among the");
                Console.WriteLine("twelve zodiac animals. People born in a year of the Snake are supposed");
                Console.WriteLine("to be the most intuitive.");
            }
            if (new int[] { 1906, 1918, 1930, 1942, 1954, 1966, 1978, 1990, 2002, 2014, 2026, 2038 }.Contains(BYear))
            {
                Console.WriteLine("\tYour sign is the Horse");
                Console.WriteLine();
                Console.WriteLine("People born in a year of the Horse are extremely animated, active and energetic.");
                Console.WriteLine("Horses love to be in a crowd, and they can usually");
                Console.WriteLine("be seen on such occasions as concerts,");
                Console.WriteLine("theater performances, meetings, sporting events, and parties.");
            }
            if (new int[] { 1907, 1919, 1931, 1943, 1955, 1967, 1979, 1991, 2003, 2015, 2027, 2039 }.Contains(BYear))
            {
                Console.WriteLine("\tYour sign is the Goat");
                Console.WriteLine();
                Console.WriteLine("People born in a year of the Goat are generally believed to be gentle mild-mannered,");
                Console.WriteLine("shy, stable, sympathetic, amicable, and brimming with a strong sense");
                Console.WriteLine("of kindheartedness and justice.");
            }
            if (new int[] { 1908, 1920, 1932, 1944, 1956, 1968, 1980, 1992, 2004, 2016, 2028, 2040 }.Contains(BYear))
            {
                Console.WriteLine("\tYour sign is the Monkey");
                Console.WriteLine();
                Console.WriteLine("People born in a year of the Monkey have magnetic personalities and are witty and intelligent.");
                Console.WriteLine("They have personality traits like mischievousness, curiosity, and cleverness");
            }
            if (new int[] { 1909, 1921, 1933, 1945, 1957, 1969, 1981, 1993, 2005, 2017, 2029, 2041 }.Contains(BYear))
            {
                Console.WriteLine("\tYour sign is the Rooster");
                Console.WriteLine();
                Console.WriteLine("People born in a year of the Rooster are very observant. Hardworking, resourceful,");
                Console.WriteLine("courageous, and talented, Roosters are very confident in themselves.");
            }
            if (new int[] { 1910, 1922, 1934, 1946, 1958, 1970, 1982, 1994, 2006, 2018, 2030, 2042 }.Contains(BYear))
            {
                Console.WriteLine("\tYour sign is the Dog");
                Console.WriteLine();
                Console.WriteLine("Dogs are loyal and honest, amiable and kind, cautious and prudent.");
            }
            if (new int[] { 1911, 1923, 1935, 1947, 1959, 1971, 1983, 1995, 2007, 2019, 2031, 2043 }.Contains(BYear))
            {
                Console.WriteLine("\tYour sign is the Boar");
                Console.WriteLine();
                Console.WriteLine("Pigs are diligent, compassionate, and generous.");
                Console.WriteLine("They have great concentration: once they set a goal,");
                Console.WriteLine("they will devote all their energy to achieving it.");
                Console.WriteLine("Though Pigs rarely seek help from others, they will not refuse to give others a hand.");
                Console.WriteLine("Pigs never suspect trickery, so they are easily fooled.");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to return to main menu");
            Console.ReadKey();
        }
        #region HELPER METHODS

        static void DisplayHeader(string header)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + header);
            Console.WriteLine();
        }
        static void DisplayClosingScreen()
        {
            DisplayHeader("Exit Screen");
            Console.WriteLine("Thanks for enjoying!");
            Console.WriteLine();
            Console.WriteLine("Press any key to exit program.");
            Console.ReadKey();
        }

        #endregion
    }
}


