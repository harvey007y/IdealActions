using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using IdealActions.Domain;

namespace IdealActions.Infrastructure
{
    interface IContext 
    {
        IQueryable<T> Query<T>() where T : class;
         DbSet<UserInfo> UserInfo { get; set; }
         DbSet<Strategy> Strategy { get; set; }
         DbSet<Tactic> Tactic { get; set; }
         DbSet<TacticEntry> TacticJournal { get; set; }
         DbSet<ToDoEntry> ToDoList { get; set; }
         DbSet<TacticAbstractionLevel> TacticAbstractionLevel { get; set; }
         DbSet<TacticAccountActionType> TacticAccountActionType { get; set; }
         DbSet<ToDoStatus> ToDoStatus { get; set; }
         DbSet<KnowledgeBaseCategory> KnowledgeBaseCategory { get; set; }
         DbSet<KnowledgeBaseEntry> KnowledgeBaseEntry { get; set; }
         IList<Tactic> GetTacticList(string username);
         IList<Strategy> GetStrategyList(string username);
         IList<KnowledgeBaseCategory> GetKnowledgeBaseCategoryList(string username);
         decimal GetTacticJournalTotal(string username);
         decimal GetToDoListTotal(string username);
    }
}
