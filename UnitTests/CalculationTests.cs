using Calculation;

namespace UnitTests
{
	[TestClass]
	public class CalculationTests
	{
		Calc calc = new Calc();

		//10 методов низкой сложности
		[TestMethod]
		public void GetQuantityForProduct_ProductType1MaterialType1_CorrectResult()
		{
			int expected = 14895;
			int result = calc.GetQuantityForProduct(1, 1, 15, 20, 45);
			Assert.AreEqual(expected, result);
		}

		[TestMethod]
		public void GetQuantityForProduct_ProductType2_MaterialType1_CorrectResult()
		{
			int expected = 33852;
			int result = calc.GetQuantityForProduct(2, 1, 15, 20, 45);
			Assert.AreEqual(expected, result);
		}

		[TestMethod]
		public void GetQuantityForProduct_ProductType3MaterialType1_CorrectResult()
		{
			int expected = 114147;
			int result = calc.GetQuantityForProduct(3, 1, 15, 20, 45);
			Assert.AreEqual(expected, result);
		}

		[TestMethod]
		public void GetQuantityForProduct_ProductType1MaterialType2_CorrectResult()
		{
			int expected = 14868;
			int result = calc.GetQuantityForProduct(1, 2, 15, 20, 45);
			Assert.AreEqual(expected, result);
		}

		[TestMethod]
		public void GetQuantityForProduct_ProductType2MaterialType2_CorrectResult()
		{
			int expected = 33791;
			int result = calc.GetQuantityForProduct(2, 2, 15, 20, 45);
			Assert.AreEqual(expected, result);
		}

		[TestMethod]
		public void GetQuantityForProduct_ProductType3MaterialType2_CorrectResult()
		{
			int expected = 113942;
			int result = calc.GetQuantityForProduct(3, 2, 15, 20, 45);
			Assert.AreEqual(expected, result);
		}

		[TestMethod]
		public void GetQuantityForProduct_CorrectSmallValues_CorrectTypeData()
		{
			int result = calc.GetQuantityForProduct(1, 2, 1, 1, 1);
			Assert.IsInstanceOfType(result, typeof(int));
		}

		[TestMethod]
		public void GetQuantityForProduct_Count1LessCount100_ResultTrue()
		{
			int count1 = calc.GetQuantityForProduct(1, 1, 1, 20, 45);
			int count2 = calc.GetQuantityForProduct(1, 1, 100, 20, 45);
			bool result = count1 < count2;
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void GetQuantityForProduct_Width10LessWidth40_ResultTrue()
		{
			int count1 = calc.GetQuantityForProduct(1, 1, 15, 10, 45);
			int count2 = calc.GetQuantityForProduct(1, 1, 15, 40, 45);
			bool result = count1 < count2;
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void GetQuantityForProduct_Length10LessLength40_ResultTrue()
		{
			int count1 = calc.GetQuantityForProduct(1, 1, 15, 20, 10);
			int count2 = calc.GetQuantityForProduct(1, 1, 15, 20, 40);
			bool result = count1 < count2;
			Assert.IsTrue(result);
		}
		
		//5 методов высокой сложности
		[TestMethod]
		public void GetQuantityForProduct_NonExistentMaterialType_ErrorCode()
		{
			int expected = -1;
			int result = calc.GetQuantityForProduct(0, 2, 15, 20, 45);
			Assert.AreEqual(expected, result);
		}

		[TestMethod]
		public void GetQuantityForProduct_NonExistentProductType_ErrorCode()
		{
			int expected = -1;
			int result = calc.GetQuantityForProduct(1, 0, 15, 20, 45);
			Assert.AreEqual(expected, result);
		}

		[TestMethod]
		public void GetQuantityForProduct_NegativeCount_ErrorCode()
		{
			int expected = -1;
			int result = calc.GetQuantityForProduct(1, 2, -10, 20, 45);
			Assert.AreEqual(expected, result);
		}

		[TestMethod]
		public void GetQuantityForProduct_NegativeWidthAndLength_ErrorCode()
		{
			int expected = -1;
			int result = calc.GetQuantityForProduct(1, 2, 15, -2, -15);
			Assert.AreEqual(expected, result);
		}

		[TestMethod]
		public void GetQuantityForProduct_NullCount_ReturnIsNotNull()
		{
			int result = calc.GetQuantityForProduct(1, 2, Convert.ToInt32(null), 20, 45);
			Assert.IsNotNull(result);
		}
	}

}
