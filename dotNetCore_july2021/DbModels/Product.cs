using System;
using System.Collections.Generic;

#nullable disable

namespace dotNetCore_july2021.DbModels
{
    public partial class Product
    {
        public Product()
        {
            Lines = new HashSet<Line>();
        }

        public string PCode { get; set; }
        public string PDescript { get; set; }
        public DateTime PInDate { get; set; }
        public int PQoh { get; set; }
        public int PMin { get; set; }
        public double PPrice { get; set; }
        public double? PDiscount { get; set; }
        public int? VCode { get; set; }

        public virtual Vendor VCodeNavigation { get; set; }
        public virtual ICollection<Line> Lines { get; set; }
    }
}
