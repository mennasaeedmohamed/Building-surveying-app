using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Building.Dtos
{
    public class BuildingDto
    {
       // public int BuildingId { get; set; }
        public int BuildingNumber { get; set; }
        public int NoOfFloors { get; set; }
        public bool HasElectricity { get; set; }
        public bool HasWater { get; set; }
        public string Location { get; set; }
        public float XCoordinate { get; set; }
        public float YCoordinate { get; set; }
        //public byte[] BuildingImage { get; set; }
        public DateTime DateTime { get; set; }

    }
}
