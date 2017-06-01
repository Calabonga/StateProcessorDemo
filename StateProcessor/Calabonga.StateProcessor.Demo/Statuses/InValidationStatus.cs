using System;
using Calabonga.StatusProcessor;

namespace Calabonga.StateProcessor.Demo.Statuses
{
    /// <summary>
    /// In validation Status
    /// </summary>
    public class InValidationStatus : EntityStatus {

        public static Guid Guid => Guid.Parse("D9F00E28-B865-43B3-B140-B5EB144D37E3");

        public static string StatusDisplayName = "На проверке";

        protected override string StatusName() {
            return DocumentStatus.InValidation.ToString();
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