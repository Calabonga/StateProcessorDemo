using System.Collections.Generic;
using System.Linq;
using Calabonga.StatusProcessor;

namespace Calabonga.StateProcessor.Demo.Rules {
    /// <summary>
    /// Rules validation for InValidation status
    /// </summary>
    public class InValidationRule : StatusRule<Document, EntityStatus> {

        public InValidationRule(IEnumerable<EntityStatus> statuses) : base(statuses) { }

        public override bool CanEnter(RuleContext<Document, EntityStatus> context) {

            var converterResult = context.Processor.ToEnum<DocumentStatus>(context.Processor.Entity.EntityActiveStatus);
            var isRequestedStatusEqualsDraft = false;
            if (converterResult.Ok) {
                isRequestedStatusEqualsDraft = converterResult.Result == DocumentStatus.Draft;
            }
            var hasRegisterationNumber = !string.IsNullOrEmpty(context.Processor.Entity.Number);
            return isRequestedStatusEqualsDraft && hasRegisterationNumber;
        }

        public override bool CanLeave(RuleContext<Document, EntityStatus> context) {
            return true;
        }

        protected override EntityStatus ValidationForStatus(IEnumerable<EntityStatus> statuses) {
            return statuses.SingleOrDefault(x => x.Name.Equals(DocumentStatus.InValidation.ToString()));
        }
    }
}