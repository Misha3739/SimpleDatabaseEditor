using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DatabaseEditorSample {
	public class Person {
		[Key]
		public int Id { get; set; }

		public string FirstName { get; set; }
		public string LastName { get; set; }

		public DateTime BithtDate { get; set; }
	}
}
