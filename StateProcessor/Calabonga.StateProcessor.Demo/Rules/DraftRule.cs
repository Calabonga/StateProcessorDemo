using System;
using System.Collections.Generic;
using System.Linq;
using Calabonga.StatusProcessor;

namespace Calabonga.StateProcessor.Demo.Rules {

    /// <summary>
    /// Rules validation for Draft status
    /// </summary>
    public class DraftRule : StatusRule<Document, EntityStatus> {

        public DraftRule(IEnumerable<EntityStatus> statuses) : base(statuses) { }

        public override bool CanEnter(RuleContext<Document, EntityStatus> context) {
            var hasAuthor =  !string.IsNullOrEmpty(context.Processor.Entity.Author);
            var hasNoStatus = context.Processor.Entity.EntityActiveStatus == Guid.Empty;
            return hasAuthor && hasNoStatus;
        }

        public override bool CanLeave(RuleContext<Document, EntityStatus> context) {
            return true;
        }

        protected override EntityStatus ValidationForStatus(IEnumerable<EntityStatus> statuses) {
            return statuses.SingleOrDefault(x => x.Name.Equals(DocumentStatus.Draft.ToString()));
        }
    }
}
