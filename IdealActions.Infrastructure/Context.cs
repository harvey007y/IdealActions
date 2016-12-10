using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using IdealActions.Domain;

namespace IdealActions.Infrastructure
{
    public class Context: DbContext, IContext
    {
        public Context(string connString)
        : base(connString)
    {
    }


        public IQueryable<T> Query<T>() where T : class
        {
            return Set<T>();
        }


        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<Strategy> Strategy { get; set; }
        public DbSet<Tactic> Tactic { get; set; }
        public DbSet<TacticEntry> TacticJournal { get; set; }
        public DbSet<ToDoEntry> ToDoList { get; set; }
        public DbSet<TacticAbstractionLevel> TacticAbstractionLevel { get; set; }
        public DbSet<TacticAccountActionType> TacticAccountActionType { get; set; }
        public DbSet<ToDoStatus> ToDoStatus { get; set; }
        public DbSet<KnowledgeBaseCategory> KnowledgeBaseCategory { get; set; }
        public DbSet<KnowledgeBaseEntry> KnowledgeBaseEntry { get; set; }
        public IList<Tactic> GetTacticList(string username)
        {
            var result = (from x in Tactic
                          where x.UserName == username
                          select x);
            return result.ToList<Tactic>();
        }

        public IList<Strategy> GetStrategyList(string username)
        {
            var result = (from x in Strategy
                          where x.UserName == username
                              select x);
            return result.ToList<Strategy>();
        }

        public IList<KnowledgeBaseCategory> GetKnowledgeBaseCategoryList(string username)
        {
            var result = (from x in KnowledgeBaseCategory
                          where x.UserName == username
                          select x);
            return result.ToList<KnowledgeBaseCategory>();
        }
        public decimal GetTacticJournalTotal(string username)
        {
            decimal myTot = 0;
            if (TacticJournal.Where(x=>x.UserName == username).Count() > 0)
            {
                myTot = (from x in TacticJournal
                         where x.UserName == username
                         select x.Amount).Sum();
            }
           
            return myTot;
                         
        }

        public decimal GetToDoListTotal(string username)
        {
            decimal myTot = 0;
            if (ToDoList.Where(x => x.UserName == username).Count() > 0)
            {
                myTot = (from x in ToDoList
                         where x.UserName == username
                         select x.Amount).Sum();
            }

            return myTot;

        }

    }
}
