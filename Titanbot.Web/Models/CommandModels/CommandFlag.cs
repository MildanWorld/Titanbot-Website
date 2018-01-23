using System.Collections.Generic;
using System.Linq;

namespace Titanbot.Web.Models.CommandModels
{
    public class CommandFlag
    {
        public char ShortInvokation { get; set; }
        public string Invokation { get; set; }
        public string Description { get; set; }
        public List<string> Arguments { get; set; } = new List<string>();

        public string ShortInvokationString() => "-" + ShortInvokation;
        public string InvokationString() => "--" + Invokation;

        public string GetArguments()
        {
            if (Arguments.Count <= 0)
                return "";

            // Combine arguments
            var aggregated = Arguments.Aggregate("", (current, arg) => current + "<" + arg + "> ");

            // Trim last space
            return aggregated.Remove(aggregated.Length - 1);
        }
    }
}
