using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Entities
{

    [Table("producto")]
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "id")]
        public int id { get; set; }
        [Column(name: "nombre")]
        [StringLength(50)]
        public string nombre { get; set; }
        [Column(name: "precio")]
        public decimal precio{ get; set; }

        [Column(name: "cantidad")]
        public int cantidad { get; set; }


        [Column(name: "eliminado")]
        public int eliminado { get; set; }



    }

}
