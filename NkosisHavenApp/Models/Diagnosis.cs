﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NkosisHavenApp.Models
{
	public class Diagnosis
	{
		public int DiagnosisId { get; set; }
		public int AppointmentId { get; set; }
		public int PatientId { get; set; }
		public string DiagnosisDetails { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.Now;

	}
}