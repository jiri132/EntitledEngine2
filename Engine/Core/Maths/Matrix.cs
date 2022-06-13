using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitledEngine2.Engine.Core.Maths
{
	public class Matrix
	{
		public static float[,] MatMul(float[,] a, float[,] b)
		{
			int rowsA = a.GetLength(0);
			int colsA = a.GetLength(1);

			int rowsB = b.GetLength(0);
			int colsB = b.GetLength(1);

			float[,] results = new float[rowsA, colsB];

			if (colsA != rowsB)
			{
				//Log.Error($"Collum A: {colsA} must be the same length as rows B: {rowsB}");

				return null;
			}

			for (int i = 0; i < rowsA; i++)
			{
				for (int j = 0; j < colsB; j++)
				{
					float sum = 0;
					for (int k = 0; k < colsA; k++)
					{
						sum += a[i, k] * b[k, j];
					}
					results[i, j] = sum;
				}
			}
			return results;

		}

		public static float[,] RotationZ(float angle)
		{
			float[,] rotationZ = new float[,] {
				{ (float)Math.Cos(angle), (float)-Math.Sin(angle) },
				{ (float)Math.Sin(angle), (float)Math.Cos(angle) }
			};
			return rotationZ;
		}


	}
}
