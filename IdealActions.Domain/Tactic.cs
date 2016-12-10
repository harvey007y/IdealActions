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
    public class Tactic
    {
        public Tactic()
        {
            Strategy strategy = new Strategy();
            strategy.StrategyId = 0;
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int TacticId { get; set; }
        public string UserName { get; set; }
         [Required]
        public string Description { get; set; }
        [Required]
        public int StrategyId { get; set; }
        [ForeignKey("StrategyId")]
        public virtual Strategy strategy { get; set; }
        [Required]
        public int TacticAbstractionLevelId { get; set; }
        [ForeignKey("TacticAbstractionLevelId")]
        public virtual TacticAbstractionLevel tacticAbstractionLevel { get; set; }
        [Required]
        public int TacticAccountActionTypeId { get; set; }
        [ForeignKey("TacticAccountActionTypeId")]
        public virtual TacticAccountActionType tacticAccountActionType { get; set; }
         [Required]
         [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public decimal Amount { get; set; }
    }
}
