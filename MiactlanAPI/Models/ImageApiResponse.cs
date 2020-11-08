using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiactlanAPI.Models
{
    public class ImageApiResponse
    {
        public float AdultClassificationScore { get; set; }
        public bool IsImageAdultClassified { get; set; }
        public float RacyClassificationScore { get; set; }
        public bool IsImageRacyClassified { get; set; }
        public bool Result { get; set; }
    }
}
