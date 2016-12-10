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
    public class KnowledgeBaseEntry
    {
        public KnowledgeBaseEntry()
        {
            KnowledgeBaseDate = System.DateTime.Now;
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int KnowledgeBaseEntryId { get; set; }
        public DateTime KnowledgeBaseDate { get; set; }
        public string UserName { get; set; }
         [Required]
        public int KnowledgeBaseCategoryId { get; set; }
        [ForeignKey("KnowledgeBaseCategoryId")]
         public virtual KnowledgeBaseCategory  knowledgeBaseCategory { get; set; }
        [Required]
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Details { get; set; }
        

    }
}
