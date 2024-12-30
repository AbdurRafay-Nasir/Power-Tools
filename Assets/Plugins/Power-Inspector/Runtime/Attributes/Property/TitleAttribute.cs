using System;

namespace PowerEditor.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class TitleAttribute : PowerAttribute
    {
        public string title;
        public string description;
        public Alignment alignment;
        public bool boldTitle;
        public bool addHorizontalLine;
        public float titleFontSize;

        public TitleAttribute(string title,
                              string description = "",
                              Alignment alignment = Alignment.Left,                              
                              bool boldTitle = true,
                              bool addHorizontalLine = true,
                              float titleFontSize = 15f)
        {
            this.title = title;
            this.description = description;
            this.alignment = alignment;
            this.boldTitle = boldTitle;
            this.addHorizontalLine = addHorizontalLine;
            this.titleFontSize = titleFontSize;
        }
    }
}