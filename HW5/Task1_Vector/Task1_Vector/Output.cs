using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Vector
{
    class Output
    {
        public void PrintAllOperations(Vector firstVector,Vector secondVector)
        {
            Vector multiplyByNumber = firstVector * 10;
            Vector divideByNumber = firstVector /2;
            Vector vectorsSum = firstVector + secondVector;
            Vector vectorsMinus = firstVector - secondVector;
            Vector vectorVectorMult = firstVector * secondVector;
            double scalarMult = Vector.ScalarMultiply(firstVector, secondVector);
            Console.WriteLine("\n" + firstVector.getVectorInStringFormat() + $" * 10 = {multiplyByNumber.getVectorInStringFormat()}");
            Console.WriteLine("\n" + firstVector.getVectorInStringFormat() + $" /2 = {divideByNumber.getVectorInStringFormat()}");
            Console.WriteLine("\n" + firstVector.getVectorInStringFormat() +"+"+ secondVector.getVectorInStringFormat()+ $"= {vectorsSum.getVectorInStringFormat()}");
            Console.WriteLine("\n" + firstVector.getVectorInStringFormat() + "-"+ secondVector.getVectorInStringFormat()+ $"= {vectorsMinus.getVectorInStringFormat()}");
            Console.WriteLine("\n" + firstVector.getVectorInStringFormat() + "*"+ secondVector.getVectorInStringFormat()+ $"= {vectorVectorMult.getVectorInStringFormat()}");
            Console.WriteLine("\n scalar multiply:" + firstVector.getVectorInStringFormat() + "*"+ secondVector.getVectorInStringFormat()+ $"= {scalarMult}");
        }
    }
}
