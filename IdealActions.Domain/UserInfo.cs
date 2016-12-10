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
    public class UserInfo
    {
        public UserInfo()
        {

            Strategies = new List<Strategy>();
            Tactics = new List<Tactic>();
            TacticEntries = new List<TacticEntry>();
            LastLoginDate = System.DateTime.Now;

        }
        [Key]
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime LastLoginDate { get; set; }
        public List<Strategy> Strategies { get; set; }
        public List<Tactic> Tactics { get; set; }
        public List<TacticEntry> TacticEntries { get; set; }
    }
}
