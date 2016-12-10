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
    public class TacticEntry
    {
        public TacticEntry()
        {
            TacticalDate = System.DateTime.Now;
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int TacticEntryId { get; set; }
        public DateTime TacticalDate { get; set; }
        public string UserName { get; set; }
         [Required]
        public int TacticId{ get; set; }
        [ForeignKey("TacticId")]
        public virtual Tactic tactic { get; set; }
        public string OptionalDescription { get; set; }
         [Required]
        public int Quantity { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]

        public decimal Amount { get; set; }
        

    }
}
