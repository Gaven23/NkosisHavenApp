using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NkosisHavenApp.Data.Entities
{
    public class Medication
    {
        public int MedicationId { get; set; }
        public int DiagnosisId { get; set; }
        public int PatientId { get; set; }
        public string MedicationName { get; set; }
        public string Dosage { get; set; }
        public string Instructions { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual Diagnosis Diagnosis { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
