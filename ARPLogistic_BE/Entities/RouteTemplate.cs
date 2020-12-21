namespace ARPLogistic_BE.Entities
{
    public partial class RouteTemplate : EclipseLayer
    {
        public int RouteTemplateID { get; set; } // int, not null
        public string Name { get; set; } // varchar(210), not null
        public string Description { get; set; } // varchar(80), null
        public byte? Blocked { get; set; } // tinyint, null

        public RouteTemplate()
        {
            RouteTemplateID = 0;
            Name = "";
            Description = "";
            Blocked = 0;
        }
    }
}
