namespace JulKali.Facebook.Entities
{
    internal class MediaTemplatePayloadEntity : ITemplatePayloadEntity
    {
        public string TemplateType { get; } = "media";

        // excatly 1 element
        public MediaElementEntity[] Elements { get; set; }

        public bool Shareable { get; set; }
    }
}