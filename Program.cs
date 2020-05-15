using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseEditorSample {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			IRepository<Person> repository = new DummyPersonRepository();
			IPersonViewEditModel viewModel = new PersonViewEditModel();
			Application.Run(new Form1(viewModel, repository));
		}
	}
}
