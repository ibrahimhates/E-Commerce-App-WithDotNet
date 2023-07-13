using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Entity.LogModel
{
    public class LogDetails
    {
        public Object? ModelModel { get; set; }
        public Object? Controller { get; set; }
        public Object? Action { get; set; }
        public Object? Id { get; set; }
        public Object? CreateAtDate { get; set; }

        public LogDetails()
        {
            CreateAtDate = DateTime.UtcNow;
        }

        public override string ToString() =>
            JsonSerializer.Serialize(this);

    }
}
