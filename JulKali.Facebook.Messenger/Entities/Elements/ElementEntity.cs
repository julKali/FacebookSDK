namespace JulKali.Facebook.Entities
{
    internal class ElementEntity
    {
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string ImageUrl { get; set; }

        public DefaultActionEntity DefaultAction { get; set; }

        public IButtonEntity[] Buttons { get; set; }
    }
}