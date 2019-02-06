using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DMS.Web.Models.Maestros.DMSLocal
{
    public class CrearViewModel
    {
        [Required]
        [StringLength(250)]
        public string DMSLocalName { get; set; }

        [DefaultValue(1)]
        public int DMSLocalActive { get; set; }
    }
}
