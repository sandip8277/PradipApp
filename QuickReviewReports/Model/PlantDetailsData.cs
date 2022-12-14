using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReviewReports.Model
{
    public class PlantDetailsData
    {
       public int Id { get; set; }
        public int PlantId { get; set; }
        public string PlantName { get; set; }
        public string AreaName { get; set; }
        public string MachineName { get; set; }
        public string MachineLocation { get; set; }

    }

    public class QuickReviewPdf
    {
        public int PlantId { get; set; }
        public string PlantName { get; set; }
        public string AreaName { get; set; }
        public string MachineName { get; set; }
        public string MachineLocation { get; set; }
        public string Image { get; set; }

    }
}
