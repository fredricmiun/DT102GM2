using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Models
{
    public class AboutModel
    {
        public string Header { get; set; }
        public string Intro { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string City { get; set; }

        public AboutModel()
        {
            Header = "Om mig";
            Intro = "Välkommen till om-sidan!";
            FirstName = "Fredric";
            Surname = "Färholt";
            Age = 26;
            City = "Stockholm";
        }

    }
}
