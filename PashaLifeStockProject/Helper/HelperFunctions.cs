using PashaLifeStockProject.Data.Entities;
using System.Collections.Generic;

namespace PashaLifeStockProject.Helper
{
    public class HelperFunctions
    {
        public static bool IsZeroOrLess(List<Stock> stocks)
        {
            if (stocks.Count == 0)
            {
                return true;
            }
            int totalSum = GetTotalStockValue(stocks);
            if (totalSum <= 0)
            {
                return true;
            }
            return false;
        }
        public static int GetTotalStockValue(List<Stock> stocks)
        {
            int totalSum = 0;
            foreach (var stock in stocks)
            {
                totalSum += stock.ChangedProductCount;
            }
            return totalSum;
        }
    }
}
