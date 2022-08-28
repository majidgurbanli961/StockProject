using NUnit.Framework;
using PashaLifeStockProject.Data.Entities;
using PashaLifeStockProject.Helper;
using PashaLifeStockProject.Service.Abstract;
using PashaLifeStockProject.Service.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace PashaLifeTest
{
    internal class InitialTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckIsZeroOrLessResultFals()
        {
            List<Stock> stocks = new List<Stock>();
           

            Assert.AreEqual(true,HelperFunctions.IsZeroOrLess(stocks));

        }
        [Test]
        
        public void CheckIsZeroOrLessResultTrue()
        {
            List<Stock> stocksFull = new List<Stock>()
            {
                new Stock()
                {
                    ChangedProductCount=10,
                    ProductId = 2

                }
            };

            Assert.AreEqual(false, HelperFunctions.IsZeroOrLess(stocksFull));

        }
    }
}
