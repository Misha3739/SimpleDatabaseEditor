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
		//We use interfaces to make the components low-coupled
		private readonly IPersonViewEditModel _viewModel;
		private readonly IRepository<Person> _personRepository;
		private Form1() {
			InitializeComponent();
		}

		public Form1(IPersonViewEditModel viewModel, IRepository<Person> personRepository) : this() {
			_viewModel = viewModel;
			_personRepository = personRepository;
			//Disable default empty row
			this.gvPersons.AllowUserToAddRows = false;
			//Init datasource for GridView
			this.gvPersons.DataSource = _viewModel.Persons;
			//Init events
			this._viewModel.CurrentPersonChanged += ViewModel_CurrentPersonChanged;
			this.gvPersons.SelectionChanged += gvPersons_SelectionChanged;
		}

		private void ViewModel_CurrentPersonChanged(object sender, EventArgs e) {
			//Populate the textboxes on grid navigation
			if (this._viewModel.Current != null) {
				this.tbFirstName.Text = _viewModel.Current.FirstName;
				this.tbLastName.Text = _viewModel.Current.LastName;
				this.tbBirthdate.Text = _viewModel.Current.BithtDate.ToString("yyyy-MM-dd");
			}
		}

		//Please never use constructor to perform the database or api calls. Do it here.
		//Instead, you will have errors in form designer
		protected override async void OnLoad(EventArgs e) {
			base.OnLoad(e);

			//Simulate the latency retrieving data from DB (50ms)
			this.Cursor = Cursors.WaitCursor;
			//Retreiveing data
			var persons = await _personRepository.GetAllAsync();
			//Populate model with data
			persons.ForEach(p => _viewModel.Persons.Add(p));
			
			this.Cursor = Cursors.Arrow;
		}

		private void gvPersons_SelectionChanged(object sender, EventArgs e) {
			//Some ugly code to retrieve the current Person
			if (this.gvPersons.SelectedRows.Count > 0) {
				var row = this.gvPersons.SelectedRows[0];
				var id = (int)row.Cells[0].Value;
				this._viewModel.Current = this._viewModel.Persons.FirstOrDefault(p => p.Id == id);
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			//We need to unsibsribe from all of the other components (which were created not inside form) to avoid memory leaks.
			this._viewModel.CurrentPersonChanged -= ViewModel_CurrentPersonChanged;
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
