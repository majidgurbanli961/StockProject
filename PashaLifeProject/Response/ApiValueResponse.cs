namespace PashaLifeProject.Response
{
    public class ApiValueResponse<T> : ApiResponse
    {
        public ApiValueResponse(T value) => Value = value;
        public ApiValueResponse()
        {

        }
        public ApiValueResponse(string error) : base(error) { }

        public T Value { get; set; }
    }
}
