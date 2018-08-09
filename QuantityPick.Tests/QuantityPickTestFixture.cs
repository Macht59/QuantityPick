using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace QuantityPick.Tests
{
	[TestFixture]
	public class QuantityPickTestFixture
	{
		[Test]
		public void PickFromOneExactQuantity()
		{
			var qp = new QuantityPick(3, new List<decimal> { 3 });
			var resultSet = qp.FindBestSummands();

			Assert.That(resultSet, Is.Not.Null);
			Assert.That(resultSet, Is.Not.Empty);
			Assert.That(resultSet[0], Is.EqualTo(3));
		}

		[Test]
		public void PickFromEmptyListReturnsNull()
		{
			var qp = new QuantityPick(3, new List<decimal>());
			var resultSet = qp.FindBestSummands();

			Assert.That(resultSet, Is.Null);
		}

		[Test]
		public void CanPickFromTwoExactSummands()
		{
			var qp = new QuantityPick(3, new List<decimal> { 2, 1 });
			var resultSet = qp.FindBestSummands();

			Assert.That(resultSet, Is.Not.Null);
			Assert.That(resultSet.Count, Is.EqualTo(2));
			Assert.That(resultSet[0], Is.EqualTo(2));
			Assert.That(resultSet[1], Is.EqualTo(1));
		}

		[Test]
		public void CanNotPickSummandsWhenQuantitiesAreNotSuitable()
		{
			var qp = new QuantityPick(3, new List<decimal> { 2, 2 });
			var resultSet = qp.FindBestSummands();

			Assert.That(resultSet, Is.Null);
		}

		[Test]
		public void CanPickBestSummandsWhenThereAreMoreThanOnePossibleSummandsCombination()
		{
			var qp = new QuantityPick(5, new List<decimal> { 2, 2, 1, 4, 6, 0 });
			var resultSet = qp.FindBestSummands();

			Assert.That(resultSet, Is.Not.Null);
			Assert.That(resultSet.Count, Is.EqualTo(2));
			Assert.That(resultSet.Any(x => x == 1));
			Assert.That(resultSet.Any(x => x == 4));
		}
	}
}
