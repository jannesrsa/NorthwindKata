using System;
using System.Collections.Generic;

namespace NorthwindKataRepository.Models
{
    public partial class NumericInsertTest
    {
        public decimal Id { get; set; }
        public decimal? RandDecimal { get; set; }
        public decimal? RandNumber { get; set; }
        public string RandString { get; set; }
    }
}
