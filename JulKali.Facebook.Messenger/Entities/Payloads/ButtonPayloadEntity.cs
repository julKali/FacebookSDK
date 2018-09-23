namespace JulKali.Facebook.Entities
{
    internal class ButtonTemplatePayloadEntity : ITemplatePayloadEntity
    {
        public string TemplateType { get; } = "button";

        public string Text { get; set; }

        public IButtonEntity[] Buttons { get; set; }

        public bool Shareable { get; set; }
    }
}