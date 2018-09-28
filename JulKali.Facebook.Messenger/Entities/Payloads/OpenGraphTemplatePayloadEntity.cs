using System.Collections.Generic;

namespace JulKali.Facebook.Entities
{
    internal class OpenGraphTemplatePayloadEntity : ITemplatePayloadEntity
    {
        public string TemplateType { get; } = "open_graph";

        public IList<OpenGraphElementEntity> OpenGraphElements { get; set; }
    }
}