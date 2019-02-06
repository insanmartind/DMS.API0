using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DMS.Entidades.Maestros
{
    public class DMSLocal
    {
        [Key]
        public int DMSLocalID { get; set; }

        [Required]
        [StringLength(250)]
        public string DMSLocalName { get; set; }

        [DefaultValue(1)]
        public int DMSLocalActive { get; set; }

    }
}
