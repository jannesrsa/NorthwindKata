using System;
using System.Collections.Generic;

namespace NorthwindKataRepository.Models
{
    public partial class DecimalPlaceTest
    {
        public int Id { get; set; }
        public decimal? RandDecimal { get; set; }
        public decimal? RandNumber { get; set; }
        public string RandString { get; set; }
    }
}
