using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Imaginecupbox.Models
{
    //POCO - plain old C# objetc - java POJO
    [Table("Aluno")]
    public class Aluno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public String nome { get; set; }
        public int idade { get; set; }
        public int sexo { get; set; }
        public String email { get; set; }
    }
}
