namespace PashaLifeStockProject.Response
{
    public class ApiError
    {
        public ApiError() { }
        public ApiError(string error) : this() => ErrorMsg = error;
        public string ErrorMsg { get; set; }
    }
}
