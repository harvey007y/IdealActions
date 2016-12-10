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
    public class ToDoEntry
    {
        public ToDoEntry()
        {
            ToDoDate = System.DateTime.Now;
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ToDoEntryId { get; set; }
        public DateTime ToDoDate { get; set; }
        public string UserName { get; set; }
         [Required]
        public int TacticId{ get; set; }
        [ForeignKey("TacticId")]
        public virtual Tactic tactic { get; set; }
        public string OptionalDescription { get; set; }
      [DataType(DataType.MultilineText)]
        public string Details { get; set; }
         [Required]
        public int Quantity { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]

        public decimal Amount { get; set; }
        [Required]
        public int ToDoStatusId { get; set; }
        [ForeignKey("ToDoStatusId")]
        public virtual ToDoStatus toDoStatus { get; set; }
        

    }
}
