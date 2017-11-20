using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.entities
{
    public class TextLanguage
    {
        public string LanguageISO { get; set; }
        public Language Language { get; set; }
        public int TextId { get; set; }
        public Text Text { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

    }
}
