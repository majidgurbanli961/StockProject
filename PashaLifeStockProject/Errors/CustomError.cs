using System;

namespace PashaLifeStockProject.Errors
{
    public class CustomError : Exception
    {
        public CustomError(string errorMessage)
            : base(errorMessage)
        {


        }
    }
}
