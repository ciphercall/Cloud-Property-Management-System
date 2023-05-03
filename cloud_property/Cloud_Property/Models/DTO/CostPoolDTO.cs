using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cloud_Property.Models.DTO
{
    public class CostPoolDTO
    {


       
        public Int64? COSTCID { get; set; }

   
        public string COSTCNM { get; set; }
     
        public Int64? COMPID { get; set; }



       


      
        public Int64? COSTPID { get; set; }

       
        public string COSTPNM { get; set; }

      
        public string COSTPSID { get; set; }
        public string PROJECTFY { get; set; }
        public string LOCATION { get; set; }
        public string PCITY { get; set; }
        public string PSIZE { get; set; }
        public string PTYPE { get; set; }
       
        public string EHODT { get; set; }
       
        public string REMARKS { get; set; }







       
        public string USERPC { get; set; }
        public Int64? INSUSERID { get; set; }

       
        public DateTime? INSTIME { get; set; }

      
        public string INSIPNO { get; set; }
        public string INSLTUDE { get; set; }
        public Int64? UPDUSERID { get; set; }

        public DateTime? UPDTIME { get; set; }

      
        public string UPDIPNO { get; set; }
        public string UPDLTUDE { get; set; }


    }
}