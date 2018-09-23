namespace JulKali.Facebook.Entities
{
    internal class ListTemplatePayloadEntity : ITemplatePayloadEntity
    {
        public string TemplateType { get; } = "list";

        // optional, [compact, large]
        public string TopElementStyle { get; set; }

        // optional, max 1
        public IButtonEntity[] Buttons { get; set; }

        // min 2, max 4
        public ElementEntity[] Elements { get; set; }

        // optional
        public bool Shareable { get; set; }
    }
}