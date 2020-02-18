using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_Matrix
{
	public class Logic
	{
		public void Start()
		{
            int mainMenuInput = Input.MainMenu();
			if (mainMenuInput == 1)
			{
				Matrix firstMatrix = CreateMatrixbyUserVariant();
				Print(firstMatrix);
				Console.WriteLine("Создадим вторую матрицу.");
				Matrix secondMatrix = CreateMatrixbyUserVariant();
				Print(secondMatrix);
				Matrix result = firstMatrix + secondMatrix;
				Console.WriteLine();
				Console.WriteLine("Итог:");
				GetMatrixStaticInfo(result);
				Console.ReadLine();
			}
			if (mainMenuInput == 2)
			{
				Matrix firstMatrix = CreateMatrixbyUserVariant();
				Print(firstMatrix);
				Console.WriteLine("Создадим вторую матрицу.");
				Matrix secondMatrix = CreateMatrixbyUserVariant();
				Print(secondMatrix);
				Matrix result = firstMatrix * secondMatrix;
				Console.WriteLine();
				Console.WriteLine("Итог:");
				GetMatrixStaticInfo(result);
				Console.ReadLine();
			}
			if (mainMenuInput == 3)
			{
				Matrix firstMatrix = CreateMatrixbyUserVariant();
				Print(firstMatrix);
				Console.WriteLine("Создадим вектор.");
				int vectorSize = Input.GetVectorSize();
				Vector vector = FillVectorbyUserInput(vectorSize);
				Matrix result = firstMatrix * vector;
				Console.WriteLine();
				Console.WriteLine("Итог:");
				GetMatrixStaticInfo(result);
				Console.ReadLine();
			}

		}
		public Matrix CreateMatrixbyUserVariant()
		{
			Matrix matrix = new Matrix();
			int matrixInputVarian = Input.MatrixCreateVariant();
			if (matrixInputVarian == 1)
			{
				int rows = Input.GetRowsCount();
				int columns = Input.GetColumnsCount();
				matrix = MatrixCreater.CreateRandomMatrix(rows, columns);
			}
			if(matrixInputVarian == 2)
			{
				int rows = Input.GetRowsCount();
				int columns = Input.GetColumnsCount();
				matrix = FillMatrixbyUserInput(rows, columns);
			}
			if (matrixInputVarian == 3)
			{
				matrix = GetMatrixFromFile();
			}
			return matrix;
		}
		public Matrix GetMatrixFromFile()
		{
			Matrix matrix = new Matrix();
			string fileName = "Matrix.txt";
			string directory = Directory.GetCurrentDirectory();
			string path = directory + "//" + fileName;
			string[] fileContent = File.ReadAllLines(directory + "//" + fileName);
			if (fileContent == null)
				throw new FormatException("Файл не соделжит данные для создания матрицы");
			matrix.Massive = new int[3, 3];
			int lineNum = 0;
			int elementNum = 0;
			int[,] massive;
			foreach (string line in fileContent)
			{
				string[] rowsElements = line.Split(',');
				foreach (string element in rowsElements)
				{
					int elementInNumberFormat = int.Parse(element);
					matrix.Massive[lineNum, elementNum] = elementInNumberFormat;
					elementNum++;
				}
				lineNum++;
				elementNum = 0;
			}
			return matrix;
		}
		public Matrix FillMatrixbyUserInput(int rows, int columns)
		{
			Matrix matrix = new Matrix
			{
				Massive = new int[rows, columns]
			};
			int elementNumber = 0;
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < columns; j++)
				{
					matrix.Massive[i, j] = Input.GetMatrixElements(elementNumber);
					elementNumber++;
				}
			}
			return matrix;
		}
		public Vector FillVectorbyUserInput(int size)
		{
			Vector vector = new Vector
			{
				Massive = new int[size]
			};
			int elementNumber = 0;
			for (int i = 0; i < size; i++)
			{
				vector.Massive[i] = Input.GetMatrixElements(elementNumber);
				elementNumber++;
			}
			return vector;
		}

		public void Print(Matrix matrix)
		{
			Console.WriteLine();
			for (int i = 0; i < matrix.RowCount; i++)
			{
				for (int j = 0; j < matrix.ColumnCount; j++)
				{
					Console.Write(matrix.Massive[i, j] + " ");
				}
				Console.WriteLine();
			}
		}
		public void GetMatrixStaticInfo(Matrix matrix)
		{
			Print(matrix);
			GetSumOfPositiveNumbers(matrix);
			PrintOnlyPositiveElements(matrix);
			PrintEvenElements(matrix);
			PrintPrimeElements(matrix);
		}
		public void GetSumOfPositiveNumbers(Matrix matrix)
		{
			if (matrix.Massive == null)
				throw new ArgumentException("Матрица пуста");
			int positiveElementsSum = 0;
			for (int i = 0; i < matrix.RowCount; i++)
			{
				for (int j = 0; j < matrix.ColumnCount; j++)
				{
					if (matrix.Massive[i, j] > 0)
						positiveElementsSum += matrix.Massive[i, j];
				}
				Console.WriteLine();
			}
			Console.WriteLine("Сумма положительных элементов матрицы: "+ positiveElementsSum);
		}
		public void PrintOnlyPositiveElements(Matrix matrix)
		{
			Console.WriteLine("Только положительные элементы:");
			Console.WriteLine();
			for (int i = 0; i < matrix.RowCount; i++)
			{
				for (int j = 0; j < matrix.ColumnCount; j++)
				{
					if (matrix.Massive[i, j] > 0)
						Console.Write(matrix.Massive[i, j] + " ");
					if (matrix.Massive[i, j] <= 0)
						Console.Write("*" + " ");
				}
				Console.WriteLine();
			}
		}
		public void PrintEvenElements(Matrix matrix)
		{
			Console.WriteLine("Только четные элементы");
			Console.WriteLine();
			for (int i = 0; i < matrix.RowCount; i++)
			{
				for (int j = 0; j < matrix.ColumnCount; j++)
				{
					if (CheckForEven(matrix.Massive[i, j]))
						Console.Write(matrix.Massive[i, j] + " ");
					else
						Console.Write("*" + " ");
				}
				Console.WriteLine();
			}
		}

		public void PrintPrimeElements(Matrix matrix)
		{
			Console.WriteLine("Только простые элементы");
			Console.WriteLine();
			for (int i = 0; i < matrix.RowCount; i++)
			{
				for (int j = 0; j < matrix.ColumnCount; j++)
				{
					if (IsPrimeNumber(matrix.Massive[i, j]))
						Console.Write(matrix.Massive[i, j] + " ");
					else
						Console.Write("*" + " ");
				}
				Console.WriteLine();
			}
		}
		public bool IsPrimeNumber(int number)
		{
			int sqrtNumber = (int)(Math.Sqrt(number));
			for (int i = 2; i <= sqrtNumber; i++)
			{
				if (number % 2 == 0)
					return false;
			}
			return true;
		}
		public bool CheckForEven(int number)
		{
			if (number % 2 == 0)
				return true;
			return false;
		}
	}
}
