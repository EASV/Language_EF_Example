using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.entities
{
    public class GlobalGoal
    {
        public int Id { get; set; } 
        
        public int TranslationId { get; set; }
        public Text Translation { get; set; }
        
    }
}
