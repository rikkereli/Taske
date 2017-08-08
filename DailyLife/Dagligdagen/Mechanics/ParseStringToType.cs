using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dagligdagen
{
    /// <summary>
    /// Parses a given string to type
    /// </summary>
    static public class ParseStringToType
    {
        /// <summary>
        /// Parses string to type of product
        /// </summary>
        static public ProductType ProductType(string typeName)
        {
            typeName = typeName.ToLower();
            if (typeName == "snack")
            {
                return Dagligdagen.ProductType.Snack;
            }
            else if (typeName == "food")
            {
                return Dagligdagen.ProductType.Food;
            }
            else if (typeName == "fun")
            {
                return Dagligdagen.ProductType.Fun;
            }
            else if (typeName == "household")
            {
                return Dagligdagen.ProductType.Household;
            }
            else
            {
                return Dagligdagen.ProductType.NotFound;
            }
        }
        /// <summary>
        /// Parses a string to type of unit
        /// </summary>
        /// <param name="unitType"></param>
        /// <returns></returns>
        static public UnitType UnitType(string unitType)
        {
            unitType = unitType.ToLower();
            //TODO remove the big kg. 
            if (unitType == "kg")
            {
                return Dagligdagen.UnitType.kg;
            }
            else if (unitType == "l")
            {
                return Dagligdagen.UnitType.l;
            }
            else if (unitType == "g")
            {
                return Dagligdagen.UnitType.g;
            }
            else if (unitType == "piece")
            {
                return Dagligdagen.UnitType.piece;
            }
            else
            {
                return Dagligdagen.UnitType.notFound;
            }
}
        /// <summary>
        /// Convert a sting in format DD/MT/YYYY HH:MM:SS to datetime
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        //TODO Better warnings
        //TODO Bette security 
        public static DateTime StringToDateTime(string dateTime)
        {
            try
            {
                //Separate the date from the time
                string[] separated = dateTime.Split(' ');
                //The first entrance is a date
                string[] date = separated[0].Split('/');
                //The second entrance is the time
                string[] time = separated[1].Split(':');

                //This is to test if the format is right. 
                string year = date[2];
                string month = date[1];
                string day = date[0];

                string hour = time[0];
                string minute = time[1];
                string second = time[2];

                //See if the format is right
                if (!(year.Length == 4 && month.Length == 2 && day.Length == 2 && hour.Length == 2 && minute.Length == 2 && second.Length == 2))
                {
                    throw new FormatException();
                }

                //Because of the order things are in, i have had to move around. 
                //                      The year            The Month           The day             The hour            The minute            The second  
                return new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]));
            }
            //Everything that does so this does not work, is a wrong format. Therefore I will throw a format exception
            catch (Exception)
            {
                throw new FormatException(dateTime + " StringToDateTime");
            }
        }
    }
}
