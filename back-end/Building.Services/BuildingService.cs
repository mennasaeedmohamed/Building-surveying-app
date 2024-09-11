using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Building.Repositories;
using Building.Dtos;
using Building.Models.Models;

namespace Building.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly IBuildingRepository _buildingRepository;
        private readonly IMapper _mapper;

        public BuildingService(IBuildingRepository buildingRepository, IMapper mapper)
        {

            _buildingRepository = buildingRepository;
            _mapper = mapper;
        }


        public List<BuildingDto> GetAll()
        {
            var Buildings = _buildingRepository.GetAll().ToList();
            var dtos = _mapper.Map<List<BuildingDto>>(Buildings);
            return dtos;
        }


        public BuildingDto GetOne(int Id)
        {
            var category = _buildingRepository.GetAll().FirstOrDefault(u => u.BuildingId == Id);
            var dto = _mapper.Map<BuildingDto>(category);
            return dto;
        }


        public bool Create(BuildingDto e)
        {
            var category = _mapper.Map<Buildings>(e);
            _buildingRepository.Create(category);
            return true;
        }

        public bool Update(int Id, BuildingDto e)
        {
            var existingCategory = _buildingRepository.GetAll().FirstOrDefault(c => c.BuildingId == Id);
            if (existingCategory == null)
                return false;

            _mapper.Map(e, existingCategory);
            _buildingRepository.Update(existingCategory);
            return true;
        }

        public bool Delete(int Id)
        {
            var categoryToDelete = _buildingRepository.GetAll().FirstOrDefault(c => c.BuildingId == Id);
            if (categoryToDelete == null)
                return false;

            _buildingRepository.Delete(categoryToDelete);
            return true;
        }
    }
}
