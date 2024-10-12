

namespace Application.Generic
{
    public class GetResponse<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public IEnumerable<T> ObjectData { get; set; }
    }
}
