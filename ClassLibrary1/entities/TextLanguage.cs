using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.entities
{
    public class TextLanguage
    {
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public int TextId { get; set; }
        public Text Text { get; set; }
        public string TranslatedText { get; set; }

    }
}
