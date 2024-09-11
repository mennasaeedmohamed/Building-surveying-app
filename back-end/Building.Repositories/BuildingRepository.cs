using Building.Context.Context;
using Building.Models.Models;
using Building.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building.Repositories
{
    public class BuildingRepository : GenericRepository<Buildings>, IBuildingRepository
    {
        BuildingDbContext buildingDbContext;
        public BuildingRepository(BuildingDbContext _buildingDbContext) : base(_buildingDbContext)
        {
            buildingDbContext = _buildingDbContext;
        }
    }
}


