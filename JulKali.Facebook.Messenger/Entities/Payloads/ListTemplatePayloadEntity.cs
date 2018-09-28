using System.Collections.Generic;

namespace JulKali.Facebook.Entities
{
    internal class ListTemplatePayloadEntity : ITemplatePayloadEntity
    {
        public string TemplateType { get; } = "list";

        // optional, [compact, large]
        public string TopElementStyle { get; set; }

        // optional, max 1
        public IList<IButtonEntity> Buttons { get; set; }

        // min 2, max 4
        public IList<ElementEntity> Elements { get; set; }

        // optional
        public bool Shareable { get; set; }
    }
}