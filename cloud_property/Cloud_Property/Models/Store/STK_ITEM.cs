﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cloud_Property.Models
{
    public class STK_ITEM
    {
        [Key]
        public Int64 STK_ITEM_ID { get; set; }

        [Display(Name = "Company ID")]
        public Int64? COMPID { get; set; }
        
        //[Required(ErrorMessage = "Select a valid category!")]
        [Display(Name = "Catagory ID")]
        public Int64? CATID { get; set; }
        
        [Display(Name = "Item ID")]
        public Int64? ITEMID { get; set; }

        // [Required(ErrorMessage = "Item name can not be empty!")]
        [Display(Name = "Item Name")]
        public string ITEMNM { get; set; }
        public string BRAND { get; set; }
        public string UNIT { get; set; }

        [Display(Name = "Buy Rate")]
        public decimal? BUYRT { get; set; }

        [Display(Name = "Sale Rate")]
        public decimal? SALRT { get; set; }

        [Display(Name = "Stock Minimum")]
        public decimal? STKMIN { get; set; }

        [Display(Name = "Discount")]
        public decimal? DISCRT { get; set; }

        [Display(Name = "CPQTY")]
        public decimal? CPQTY { get; set; }

        [Display(Name = "Remarks")]
        public string REMARKS { get; set; }






        [Display(Name = "User PC")]
        public string USERPC { get; set; }
        public Int64? INSUSERID { get; set; }

        [Display(Name = "Insert Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? INSTIME { get; set; }

        [Display(Name = "Inesrt IP ADDRESS")]
        public string INSIPNO { get; set; }
        public string INSLTUDE { get; set; }
        public Int64? UPDUSERID { get; set; }

        [Display(Name = "Update Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? UPDTIME { get; set; }

        [Display(Name = "Update IP ADDRESS")]
        public string UPDIPNO { get; set; }
        public string UPDLTUDE { get; set; }
    }
}