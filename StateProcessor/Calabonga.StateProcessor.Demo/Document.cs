using System;
using Calabonga.StatusProcessor;

namespace Calabonga.StateProcessor.Demo
{
    /// <summary>
    /// Entiti with states
    /// </summary>
    public class Document : IEntity
    {
        public Document()
        {
            
        }

        /// <summary>
        /// Unique indentificator
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Author of the document
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Registration number
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Status (IEntity)
        /// </summary>
        public Guid EntityActiveStatus { get; set; }
    }
}
