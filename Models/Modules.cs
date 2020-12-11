using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Testdatabase_10_12_2020.Models
{
    public class Modules
    {
        public int ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public int Modulnummer { get; set; }
        public string Modulname { get; set; }

        public int Semester { get; set; }

        public int Workload { get; set; }

        public int Semesterwochenstunden { get; set; }
        public int Leistungspunkte { get; set; }

        public string Turnus { get; set; }
        public string Curriculare_Zuordnung { get; set; }
        public string Lernziele { get; set; }
        public string Schlüsselqualifikationen { get; set; }
        public string Inhaltliche_Beschreibung { get; set; }
        public string Unterrichtsform { get; set; }
        public string Prüfungsart { get; set; }
        public string Prüfungsform { get; set; }
        public string Verbindlichkeit { get; set; }
        public string Literaturangaben { get; set; }

    }
}
