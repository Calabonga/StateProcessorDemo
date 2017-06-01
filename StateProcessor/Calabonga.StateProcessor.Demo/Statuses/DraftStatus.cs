using System;
using Calabonga.StatusProcessor;

namespace Calabonga.StateProcessor.Demo.Statuses {

    /// <summary>
    /// Draft Status
    /// </summary>
    public class DraftStatus : EntityStatus {

        public static Guid Guid => Guid.Parse("49446068-0CCE-4168-B7AC-CD36E032F2BC");

        public static string StatusDisplayName = "Черновик";

        public override string GetDisplayName() {
            return StatusDisplayName;
        }

        protected override string StatusName() {
            return DocumentStatus.Draft.ToString();
        }

        protected override Guid GetUniqueInentifier() {
            return Guid;
        }
    }
}
