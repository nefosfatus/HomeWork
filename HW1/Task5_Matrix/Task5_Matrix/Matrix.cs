using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_Matrix
{
    public struct Matrix
    {
        /// <summary>
        /// Matrix -> 2D massive
        /// </summary>
        public int[,] Massive { get; set; }
        public int RowCount { 
            get 
            {
                if (this.Massive == null)
                    return 0;
                return this.Massive.GetLength(0); 
            } 
        }
        public int ColumnCount
        {
            get
            {
                if (this.Massive == null)
                    return 0;
                return this.Massive.GetLength(1);
            }
        }

        /// <summary>
        /// Matrix sum
        /// </summary>
        /// <param name="leftMatrix"></param>
        /// <param name="rightMatrix"></param>
        /// <returns>Summed matrix</returns>
        public static Matrix operator +(Matrix leftMatrix, Matrix rightMatrix)
        {
            if(leftMatrix == rightMatrix)
            {
                Matrix summedMatrix = new Matrix
                {
                    Massive = new int[leftMatrix.ColumnCount, leftMatrix.RowCount]
                };
                for (int i = 0; i < leftMatrix.RowCount; i++)
                {
                    for (int j = 0; j < leftMatrix.ColumnCount; j++)
                    {
                        summedMatrix.Massive[i,j] = leftMatrix.Massive[i, j] + rightMatrix.Massive[i, j];
                    }
                }
                return summedMatrix;
            }
            throw new ArgumentException("Размерность матриц не совпадает");
        }
        /// <summary>
        /// Matrix diff
        /// </summary>
        /// <param name="leftMatrix"></param>
        /// <param name="rightMatrix"></param>
        /// <returns>Matrix diff</returns>
        public static Matrix operator -(Matrix leftMatrix, Matrix rightMatrix)
        {
            if (leftMatrix == rightMatrix)
            {
                Matrix newMatrix = new Matrix
                {
                    Massive = new int[leftMatrix.ColumnCount, leftMatrix.RowCount]
                };
                for (int i = 0; i < leftMatrix.RowCount; i++)
                {
                    for (int j = 0; j < leftMatrix.ColumnCount; j++)
                    {
                        newMatrix.Massive[i, j] = leftMatrix.Massive[i, j] - rightMatrix.Massive[i, j];
                    }
                }
                return newMatrix;
            }
            throw new ArgumentException("Размерность матриц не совпадает");
        }
        /// <summary>
        /// Matrix Multiply
        /// </summary>
        /// <param name="leftMatrix"></param>
        /// <param name="rightMatrix"></param>
        /// <returns>Matrix mult</returns>
        public static Matrix operator *(Matrix leftMatrix, Matrix rightMatrix)
        {
            if (leftMatrix.ColumnCount == rightMatrix.RowCount)
            {
                Matrix newMatrix = new Matrix
                {
                    Massive = new int[leftMatrix.ColumnCount, leftMatrix.RowCount]
                };
                for (int i = 0; i < leftMatrix.RowCount; i++)
                {
                    for (int j = 0; j < rightMatrix.ColumnCount; j++)
                    {
                        int s = 0;
                        for (int z = 0; z < leftMatrix.ColumnCount; ++z)
                            s += leftMatrix.Massive[i, z] * rightMatrix.Massive[z, j];
                        newMatrix.Massive[i, j] = s;

                    }
                }
                return newMatrix;
            }
            throw new ArgumentException("Размерность матриц не совпадает");
        }
        /// <summary>
        /// Compare 2 matrices
        /// </summary>
        /// <param name="leftMatrix"></param>
        /// <param name="rightMatrix"></param>
        /// <returns>Equal or not in bool</returns>
        public static bool operator ==(Matrix leftMatrix, Matrix rightMatrix)
        {
            if (leftMatrix.ColumnCount == rightMatrix.ColumnCount && leftMatrix.RowCount == rightMatrix.RowCount)
                return true;
            return false;
        }
        /// <summary>
        /// Compare 2 matrices
        /// </summary>
        /// <param name="leftMatrix"></param>
        /// <param name="rightMatrix"></param>
        /// <returns>Equal or not in bool</returns>
        public static bool operator !=(Matrix leftMatrix, Matrix rightMatrix)
        {
            if (leftMatrix.ColumnCount == rightMatrix.ColumnCount && leftMatrix.RowCount == rightMatrix.RowCount)
                return false;
            return true;
        }
        /// <summary>
        /// Matrix * vector
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="vector"></param>
        /// <returns>Matrix</returns>
        public static Matrix operator *(Matrix matrix, Vector vector)
        {
            int vectorSize = vector.Massive.Length;
            int matrixColumnSize = matrix.ColumnCount;
            if(matrixColumnSize != vectorSize) {
                throw new ArgumentException("Размерности не подходят для умножения");
            }
            Matrix newMatrix = new Matrix
            {
                Massive = new int[matrix.ColumnCount, matrix.RowCount]
            };
            for (int i = 0; i < matrix.RowCount; i++)
            {
                for (int j = 0; j < matrix.ColumnCount; j++)
                {
                    newMatrix.Massive[i, j] = matrix.Massive[i, j] * vector.Massive[j];
                }
            }
            return newMatrix;
        }
        
        
        public override  bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return (this.ColumnCount << 2) ^ this.RowCount/3;
            
        }
    }
}
