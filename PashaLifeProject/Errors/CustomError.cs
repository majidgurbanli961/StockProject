using System;

namespace PashaLifeProject.Errors
{
    public class CustomError : Exception
    {
        public CustomError(string errorMessage)
            : base(errorMessage)
        {


        }
    }
}
