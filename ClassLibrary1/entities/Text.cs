using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.entities
{
    public class Text
    {
        public int Id { get; set; }
        public List<TextLanguage> Languages { get; set; }
    }
}
