using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation
{
	public class Calc
	{
		/// <summary>
		/// Возвращает количество необходимого материала с учетом возможного брака
		/// </summary>
		/// <param name="productType"></param>
		/// <param name="materialType"></param>
		/// <param name="count"></param>
		/// <param name="width"></param>
		/// <param name="length"></param>
		/// <returns></returns>
		public int GetQuantityForProduct(int productType, int materialType, int count, float width, float length)
		{
			double coefficient = 0;
			double percentDefective = 0;
			switch (productType)
			{
				case 1: coefficient = 1.1; break;
				case 2: coefficient = 2.5; break;
				case 3: coefficient = 8.43; break;
				default: return -1;
			}
			switch (materialType)
			{
				case 1: percentDefective = 0.3; break;
				case 2: percentDefective = 0.12; break;
				default: return -1;
			}
			if (count <= 0 || width <= 0 || length <= 0) return -1;
			double S = width * length;
			double countProducts = (S * coefficient * count);
			double defective = (countProducts * percentDefective) / 100;
			return (int)Math.Ceiling(countProducts + defective);
		}
	}
}
