using System;
using System.Collections.Generic;

namespace NorthwindKataRepository.Models
{
    public partial class EmployeeTerritories
    {
        public EmployeeTerritories()
        {
            EmployeeTerritoriesMultiFk = new HashSet<EmployeeTerritoriesMultiFk>();
        }

        public int EmployeeId { get; set; }
        public string TerritoryId { get; set; }

        public Employees Employee { get; set; }
        public Territories Territory { get; set; }
        public ICollection<EmployeeTerritoriesMultiFk> EmployeeTerritoriesMultiFk { get; set; }
    }
}
