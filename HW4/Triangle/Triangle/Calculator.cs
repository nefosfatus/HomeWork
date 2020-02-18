using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle
{
    class Calculator
    {
        /// <summary>
        /// Calculate distance between two points
        /// </summary>
        /// <param name="firstPointCoordinates"></param>
        /// <param name="secondPointCoordintes"></param>
        /// <returns>Distance.</returns>
        public double CalculateDistance(List<int> firstPointCoordinates, List<int> secondPointCoordintes)
        {
            int firstPointCoordinateX = firstPointCoordinates[0];
            int firstPointCoordinateY = firstPointCoordinates[1];
            int secondPointCoordinateX = secondPointCoordintes[0];
            int secondPointCoordinateY = secondPointCoordintes[1];

            double distanceX = Math.Pow((secondPointCoordinateX - firstPointCoordinateX), 2); //(x2-x1)^2
            double distanceY = Math.Pow((secondPointCoordinateY - firstPointCoordinateY), 2); //(y2-y1)^2

            double distanceBetweenPoints = Math.Sqrt(distanceX + distanceY);//sqrt(((x2-x1)^2) + (//(y2-y1)^2))

            return distanceBetweenPoints;
        }

        /// <summary>
        /// Calculate perimetr
        /// </summary>
        /// <param name="firstDistance">AB distance</param>
        /// <param name="secondDistance">BC distance</param>
        /// <param name="thirdDistance">CA distance</param>
        /// <returns>Perimetr.</returns>
        public double CalculatePerimetr(double firstDistance, double secondDistance, double thirdDistance)
        {
            double perimetr = firstDistance + secondDistance + thirdDistance;//AB+BC+CA
            return perimetr;
        }
        /// <summary>
        /// Calculate area by Heron's formula
        /// </summary>
        /// <param name="firstDistance">AB distance</param>
        /// <param name="secondDistance">BC distance</param>
        /// <param name="thirdDistance">CA distance</param>
        /// <returns>Area.</returns>
        public double CalculateArea(double firstDistance, double secondDistance, double thirdDistance)
        {
            double semiPerimetr = (firstDistance + secondDistance + thirdDistance) / 2; // p = (AB+BC+CA)2
            double semiPerimetrMinusA = semiPerimetr - firstDistance;  //p - AB
            double semiPerimetrMinusB = semiPerimetr - secondDistance; //p - BC
            double semiPerimetrMinusC = semiPerimetr - thirdDistance;  //p - CA
            double area = Math.Sqrt(semiPerimetr * semiPerimetrMinusA * semiPerimetrMinusB * semiPerimetrMinusC); //sqrt(p*(p - AB)*(p - BC)*(p - CA))
            return area;
        }
        /// <summary>
        /// Calculate angle
        /// </summary>
        /// <param name="firstDistance">AB distance</param>
        /// <param name="secondDistance">BC distance</param>
        /// <param name="thirdDistance">CA distance</param>
        /// <returns>Opposite third distance angle in degrees</returns>
        public double CalculateAngle(double firstDistance, double secondDistance, double thirdDistance)
        {
            double numerator = Math.Pow(firstDistance, 2) + Math.Pow(secondDistance, 2) - Math.Pow(thirdDistance, 2);
            double denomirator = 2 * firstDistance * secondDistance;
            double angleAcos = Math.Acos(numerator/denomirator);
            double angleInDegrees = angleAcos * (180 / Math.PI);
            return angleInDegrees;
        }
    }
}
