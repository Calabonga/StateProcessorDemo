using System;
using Calabonga.StatusProcessor;

namespace Calabonga.StateProcessor.Demo.Statuses
{
    /// <summary>
    /// Complete Status
    /// </summary>
    public class CompleteStatus : EntityStatus {

        public static Guid Guid => Guid.Parse("2B04504A-784C-419E-8B6B-1EC90609F9ED");

        public static string StatusDisplayName = "Утвержден";

        protected override string StatusName() {
            return DocumentStatus.Complete.ToString();
        }

        protected override Guid GetUniqueInentifier()
        {
            return Guid;
        }

        public override string GetDisplayName()
        {
            return StatusDisplayName;
        }
    }
}