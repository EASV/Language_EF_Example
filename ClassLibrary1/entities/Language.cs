using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.entities
{
    public class Language
    {
        public string ISO { get; set; }
        public string Country { get; set; }
        public List<TextLanguage> Texts { get; set; }
    }
}
