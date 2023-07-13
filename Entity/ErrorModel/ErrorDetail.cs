
using System.Text.Json;

namespace Entity.ErrorModel
{
    public class ErrorDetail
    {
        public string ErrorMessage { get; set; }
        public int StatusCode { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
