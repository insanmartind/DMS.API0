﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DMS.Web.Models.Maestros.DMSLocal
{
    public class DMSLocalViewModel
    {
        public int DMSLocalID { get; set; }
        public string DMSLocalName { get; set; }

        [DefaultValue(1)]
        public int? DMSLocalActive { get; set; }
    }
}
