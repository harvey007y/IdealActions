using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace IdealActions.Domain
{
    public class ToDoStatus
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ToDoStatusId { get; set; }       
        public string UserName { get; set; }
       [Required]
        public string Status { get; set; }
        
    }
}
