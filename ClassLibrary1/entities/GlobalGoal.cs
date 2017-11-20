using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.entities
{
    public class GlobalGoal
    {
        public int Id { get; set; } 

        public int DescriptionId { get; set; }
        public Text Description { get; set; }

        public int TitleId { get; set; }
        public Text Title { get; set; }

    }
}
