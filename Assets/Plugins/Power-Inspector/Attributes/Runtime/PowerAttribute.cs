namespace PowerTools.Attributes
{
    public class PowerAttribute : UnityEngine.PropertyAttribute
    {
        public float PaddingLeft { get; set; }
        public float PaddingRight { get; set; }
        public float PaddingTop { get; set; }
        public float PaddingBottom { get; set; }

        public float MarginLeft { get; set; }
        public float MarginRight { get; set; }
        public float MarginTop { get; set; }
        public float MarginBottom { get; set; }
    }
}