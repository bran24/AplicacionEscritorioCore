using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Entities
{

    [Table("usuario")]

    public class Usuario
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "id")]
        public int id { get; set; }

        [Column(name:"username")]
        [StringLength(50)]
        public string username { get; set; }

        [Column(name: "password")]
        [StringLength(50)]

        public string password { get; set; }


    }
}
