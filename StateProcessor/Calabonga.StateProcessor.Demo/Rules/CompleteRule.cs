using System.Collections.Generic;
using System.Linq;
using Calabonga.StatusProcessor;

namespace Calabonga.StateProcessor.Demo.Rules
{
    /// <summary>
    /// Rules validation for InValidation status
    /// </summary>
    public class CompleteRule : StatusRule<Document, EntityStatus> {

        public CompleteRule(IEnumerable<EntityStatus> statuses) : base(statuses) { }

        public override bool CanEnter(RuleContext<Document, EntityStatus> context) {
            return true;
        }

        public override bool CanLeave(RuleContext<Document, EntityStatus> context) {
            return true;
        }

        protected override EntityStatus ValidationForStatus(IEnumerable<EntityStatus> statuses) {
            return statuses.SingleOrDefault(x => x.Name.Equals(DocumentStatus.Complete.ToString()));
        }
    }
}