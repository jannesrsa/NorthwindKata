using System;
using System.Collections.Generic;

namespace NorthwindKataRepository.Models
{
    public partial class EmployeeTerritoriesMultiFk
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EmployeeIdFk { get; set; }
        public string TerritoryIdFk { get; set; }

        public EmployeeTerritories EmployeeTerritories { get; set; }
    }
}
