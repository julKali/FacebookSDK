namespace JulKali.Facebook.Entities
{
    internal class GenericTemplatePayloadEntity : ITemplatePayloadEntity
    {
        public string TemplateType { get; } = "generic";

        public bool Shareable { get; set; }

        public string ImageAspectRatio { get; set; }

        public ElementEntity[] Elements { get; set; }
    }
}