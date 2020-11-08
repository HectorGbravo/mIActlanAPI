using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiactlanAPI.Models
{
    public class TextApiResponse
    {
        public string OriginalText { get; set; }
        public string NormalizedText { get; set; }
        public List<TermApi> Terms { get; set; }
    }
}
