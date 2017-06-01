using System.Collections.Generic;
using System.Linq;
using Calabonga.StatusProcessor;

namespace Calabonga.StateProcessor.Demo {

    /// <summary>
    /// Document RuleProcessor
    /// </summary>
    public class DocumentRuleProcessor : RuleProcessor<Document, EntityStatus> {
        public DocumentRuleProcessor(IEnumerable<IStatusRule<Document, EntityStatus>> rules, IEnumerable<EntityStatus> statuses)
            : base(rules, statuses) {
        }

        /// <summary>
        /// Returns initial status for entity Document
        /// </summary>
        /// <returns></returns>
        protected override IEntityStatus InitialStatus() {
            return Statuses.FirstOrDefault(x => x.Name.Equals(DocumentStatus.Draft.ToString()));
        }
    }
}