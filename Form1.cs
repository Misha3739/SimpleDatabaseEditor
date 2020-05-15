using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseEditorSample {
	public partial class Form1 : Form {
		private readonly IPersonViewEditModel _viewModel;
		private readonly IRepository<Person> _personRepository;
		private Form1() {
			InitializeComponent();
		}

		public Form1(IPersonViewEditModel viewModel, IRepository<Person> personRepository) : this() {
			_viewModel = viewModel;
			_personRepository = personRepository;

			this.gvPersons.DataSource = _viewModel.Persons;

		}

		//Please never use constructor to perform the database or api calls
		//Instead, you will have errors in form designer
		protected override async void OnLoad(EventArgs e) {
			base.OnLoad(e);

			var persons = await _personRepository.GetAllAsync();
			persons.ForEach(p => _viewModel.Persons.Add(p));
		}
	}
}
