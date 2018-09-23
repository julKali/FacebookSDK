namespace JulKali.Facebook.Entities
{
    internal class OpenGraphTemplatePayloadEntity : ITemplatePayloadEntity
    {
        public string TemplateType { get; } = "open_graph";

        public OpenGraphElementEntity[] OpenGraphElements { get; set; }
    }
}