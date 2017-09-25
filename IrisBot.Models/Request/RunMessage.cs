using System.Collections.Generic;

namespace IrisBot.Models.Request
{
    public class RunMessage
    {
        /// <summary>
        /// The result message of the squash and merge.
        /// </summary>
        public string MergeMessage { get; set; }

        /// <summary>
        /// The messages for all conflicting pull requests.
        /// </summary>
        public IEnumerable<string> ConflictMessages { get; set; }

        /// <summary>
        /// The result message of the updated pull request.
        /// </summary>
        public string UpdateMessage { get; set; }
    }
}
