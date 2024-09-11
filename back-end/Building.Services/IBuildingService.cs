using Building.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building.Services
{
    public interface IBuildingService
    {
        public List<BuildingDto> GetAll();
        public BuildingDto GetOne(int Id);
        public bool Create(BuildingDto e);
        public bool Update(int Id, BuildingDto e);
        public bool Delete(int Id);
    }
}