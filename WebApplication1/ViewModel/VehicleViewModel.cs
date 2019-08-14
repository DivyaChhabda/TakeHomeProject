using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModel
{
    public class VehicleViewModel
    {
        public List<tbl_vehicle> tblvehiclelist { get; set; }
        public tbl_Car tblcar { get; set; }
        public tbl_vehicletype tblehicletype { get; set; }
        public tbl_vehicle tblvehicle { get; set; }
        public tbl_bike tblbike { get; set; }

        
    }
}