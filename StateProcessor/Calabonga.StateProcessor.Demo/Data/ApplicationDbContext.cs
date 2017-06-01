using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calabonga.StateProcessor.Demo.Data {

    /// <summary>
    /// EntityFramework Code Fisrt Database class
    /// </summary>
    public class ApplicationDbContext : DbContext {

        public ApplicationDbContext()
            : base("DocumentDbConnection") {

        }

        public DbSet<Document> Documents { get; set; }
    }
}
