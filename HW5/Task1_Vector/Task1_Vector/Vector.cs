namespace Task1_Vector
{
    public struct Vector
    {
        public double xAxisNumber { get; set; }
        public double yAxisNumber { get; set; }
        public double zAxisNumber { get; set; }

        //operator overload to copare the position
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
        public static Vector operator /(Vector vector, double number)
        {
            vector = new Vector
            {
                xAxisNumber = vector.xAxisNumber / number,
                yAxisNumber = vector.yAxisNumber / number,
                zAxisNumber = vector.zAxisNumber /
                
                number
            };
            return vector;
        }
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

        public static double  ScalarMultiply(Vector vector, Vector vector2)
        {
            double scalarMultiply = vector.xAxisNumber * vector2.xAxisNumber + vector.yAxisNumber * vector2.yAxisNumber + vector.zAxisNumber * vector2.zAxisNumber;
            return scalarMultiply;
        }
        public static Vector operator *(Vector vector, Vector vector2)
        {
            Vector vectorMult = new Vector();
            vectorMult.xAxisNumber = vector.yAxisNumber * vector2.zAxisNumber - vector2.yAxisNumber * vector.zAxisNumber;
            vectorMult.yAxisNumber = vector.yAxisNumber * vector2.xAxisNumber - vector.xAxisNumber * vector2.yAxisNumber;
            vectorMult.zAxisNumber = vector.xAxisNumber * vector2.yAxisNumber - vector.yAxisNumber * vector2.xAxisNumber;
            return vectorMult;
        }

        public string getVectorInStringFormat()
        {
            string stringAnswer = $"[{this.xAxisNumber},{this.yAxisNumber},{this.zAxisNumber}]";
            return stringAnswer;
        }
    }
}
