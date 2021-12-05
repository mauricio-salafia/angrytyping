using System.Diagnostics.CodeAnalysis;

namespace TwoSense.Angry.Core
{
    [ExcludeFromCodeCoverage]
    public class EmailModel
    {
        public string EmailAddres { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
