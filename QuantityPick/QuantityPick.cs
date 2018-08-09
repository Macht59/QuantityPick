using System.Collections.Generic;
using System.Linq;

namespace QuantityPick
{
	public class QuantityPick
	{
		private readonly decimal _desiredSumm;
		private readonly List<decimal> _quantitiesToPickFrom;

		public QuantityPick(decimal desiredSumm, List<decimal> quantities)
		{
			_desiredSumm = desiredSumm;
			_quantitiesToPickFrom = quantities;
		}

		public List<decimal> FindBestSummands()
		{
			var pickedList = new List<decimal>();
			return FindBestSummandsRecursive(_desiredSumm, _quantitiesToPickFrom, pickedList);
		}

		private List<decimal> FindBestSummandsRecursive(decimal summ, List<decimal> qtyListToPickFrom, List<decimal> pickedQtyList)
		{
			if (summ == 0)
			{
				return pickedQtyList;
			}
			else if (summ < 0)
			{
				return null;
			}
			else
			{
				var resultList = new List<List<decimal>>();
				foreach (var qty in qtyListToPickFrom.Where(x => x <= summ))
				{

					var originalListClone = qtyListToPickFrom.ToList();
					var pickedQtyListClone = pickedQtyList.ToList();
					originalListClone.Remove(qty);
					pickedQtyListClone.Add(qty);
					resultList.Add(FindBestSummandsRecursive(summ - qty, originalListClone, pickedQtyListClone));
				}

				return resultList.Where(x => x != null).Where(x => x.Count == resultList.Min(y => y.Count)).FirstOrDefault();
			}
		}
	}
}
