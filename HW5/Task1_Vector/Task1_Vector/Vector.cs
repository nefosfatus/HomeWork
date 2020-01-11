namespace Task1_Vector
{
    public struct Vector
    {
        /// <summary>
        /// Vector coordinate
        /// </summary>
        public double xAxisNumber { get; set; }
        public double yAxisNumber { get; set; }
        public double zAxisNumber { get; set; }

        /// <summary>
        /// multiply vector on number
        /// </summary>
        public static Vector operator *(Vector vector, double number)
        {
            vector = new Vector
            {
                xAxisNumber = vector.xAxisNumber * number,
                yAxisNumber = vector.yAxisNumber * number,
                zAxisNumber = vector.zAxisNumber * number
            };
            return vector;
        }
        /// <summary>
        /// divide vector on number
        /// </summary>
        public static Vector operator /(Vector vector, double number)
        {
            vector = new Vector
            {
                xAxisNumber = vector.xAxisNumber / number,
                yAxisNumber = vector.yAxisNumber / number,
                zAxisNumber = vector.zAxisNumber / number
            };
            return vector;
        }
        /// <summary>
        /// Vectors sum
        /// </summary>
        public static Vector operator +(Vector vector, Vector vector2)
        {
            vector = new Vector
            {
                xAxisNumber = vector.xAxisNumber + vector2.xAxisNumber,
                yAxisNumber = vector.yAxisNumber + vector2.yAxisNumber,
                zAxisNumber = vector.zAxisNumber + vector2.zAxisNumber
            };
            return vector;
        }
        /// <summary>
        /// Vectors diff
        /// </summary>
        public static Vector operator -(Vector vector, Vector vector2)
        {
            vector = new Vector
            {
                xAxisNumber = vector.xAxisNumber - vector2.xAxisNumber,
                yAxisNumber = vector.yAxisNumber - vector2.yAxisNumber,
                zAxisNumber = vector.zAxisNumber - vector2.zAxisNumber
            };
            return vector;
        }
        /// <summary>
        /// Vectors scalar multiply
        /// </summary>
        public static double  ScalarMultiply(Vector vector, Vector vector2)
        {
            double scalarMultiply = vector.xAxisNumber * vector2.xAxisNumber + vector.yAxisNumber * vector2.yAxisNumber + vector.zAxisNumber * vector2.zAxisNumber;
            return scalarMultiply;
        }
        /// <summary>
        /// Vectors multiply for right basis
        /// </summary>
        public static Vector operator *(Vector vector, Vector vector2)
        {
            Vector vectorMult = new Vector();
            vectorMult.xAxisNumber = vector.yAxisNumber * vector2.zAxisNumber - vector2.yAxisNumber * vector.zAxisNumber;
            vectorMult.yAxisNumber = vector.yAxisNumber * vector2.xAxisNumber - vector.xAxisNumber * vector2.yAxisNumber;
            vectorMult.zAxisNumber = vector.xAxisNumber * vector2.yAxisNumber - vector.yAxisNumber * vector2.xAxisNumber;
            return vectorMult;
        }

        /// <summary>
        /// get vector in format [x,y,z]
        /// </summary>
        /// <returns></returns>
        public string getVectorInStringFormat()
        {
            string stringAnswer = $"[{this.xAxisNumber},{this.yAxisNumber},{this.zAxisNumber}]";
            return stringAnswer;
        }
    }
}
