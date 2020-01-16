using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle
{

    class Triangle
    {
        //create calculator instance for computation
        private readonly Calculator _calculator = new Calculator();

        /// <summary>
        /// Traingle constructor
        /// </summary>
        /// <param name="pointACoordiantes"></param>
        /// <param name="pointBCoordinates"></param>
        /// <param name="pointCCoordinates"></param>
        public Triangle(List<int> pointACoordiantes,List<int> pointBCoordinates, List<int> pointCCoordinates)
        {
            PointA = pointACoordiantes;
            PointB = pointBCoordinates;
            PointC = pointCCoordinates;
            DistanceAB = _calculator.CalculateDistance(PointA, PointB);
            DistanceBC = _calculator.CalculateDistance(PointB, PointC);
            DistanceCA = _calculator.CalculateDistance(PointC, PointA);
            bool exist = GetExistenceInfo();
            if (exist)
            {
                perimetr = _calculator.CalculatePerimetr(DistanceAB, DistanceBC, DistanceCA);
                area = _calculator.CalculateArea(DistanceAB, DistanceBC, DistanceCA);
            }
            else
            {
                throw new Exception("Треугольник не существует");
            }
        }
        /// <summary>
        /// Method displays  triangle's data in console
        /// </summary>
        public void GetTriangleInfo()
        {
            Console.WriteLine($"\nКоординаты точки А:{PointA[0]},{PointA[1]}");
            Console.WriteLine($"\nКоординаты точки B:{PointB[0]},{PointB[1]}");
            Console.WriteLine($"\nКоординаты точки C:{PointC[0]},{PointC[1]}");
            Console.WriteLine($"\n Периметр треугольника: {perimetr}");
            Console.WriteLine($"\n Площадь треугольника: {area}");
        }
        /// <summary>
        /// Check exist triangle or not
        /// </summary>
        /// <returns></returns>
        public bool GetExistenceInfo()
        {
            if (this.DistanceAB + this.distanceBC > this.DistanceCA)
                return true;
            if (this.DistanceAB + this.DistanceCA >  this.distanceBC)
                return true;
            if ( this.distanceBC + this.DistanceCA > this.DistanceAB)
                return true;
            return false;
        }
        //Properties 
        public List<int> PointA { get { return pointAData; } set { pointAData = value; } }
        public List<int> PointB { get { return pointBData; } set { pointBData = value; } }
        public List<int> PointC { get { return pointCData; } set { pointCData = value; } }

        public double DistanceAB { get => distanceAB; set => distanceAB = value; }
        public double DistanceBC { get => distanceBC; set => distanceBC = value; }
        public double DistanceCA { get => distanceCA; set => distanceCA = value; }
        public double Perimetr { get => perimetr; set => perimetr = value; }
        public double Area { get => area; set => area = value; }

        //fields
        private List<int> pointAData = new List<int>();
        private List<int> pointBData = new List<int>();
        private List<int> pointCData = new List<int>();
        private double distanceAB;
        private double distanceBC;
        private double distanceCA;
        private double perimetr;
        private double area;

    }
}
