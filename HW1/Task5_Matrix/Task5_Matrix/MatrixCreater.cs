using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_Matrix
{
	public class MatrixCreater
	{
		private static readonly Random random = new Random();
		/// <summary>
		/// Create Random matrix
		/// </summary>
		/// <param name="rowCount"></param>
		/// <param name="columnCount"></param>
		/// <returns>Random matrix</returns>
		public static Matrix CreateRandomMatrix(int rowCount, int columnCount)
		{
			Matrix randomMatrix = new Matrix(){
                    Massive = new int[columnCount, rowCount]
                };
			int randomMinValue = -99;
			int randomMaxValue = 99;

			if (rowCount <= 0 && columnCount <= 0)
				throw new ArgumentException("Размерность матриц должна быть больше 0");
			
			for (int i = 0; i < rowCount; i++)
			{
				for (int j = 0; j < columnCount; j++)
				{
					randomMatrix.Massive[i,j] = random.Next(randomMinValue, randomMaxValue);
				}
			}
			return randomMatrix;
		}
	}
}
