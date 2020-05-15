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
		private void SetButtonBindings() {
			this.btnRefresh.DataBindings.Clear();
			this.btnSave.DataBindings.Clear();
			this.btnAdd.DataBindings.Clear();
			this.btnDelete.DataBindings.Clear();
			this.btnRefresh.DataBindings.Add("Enabled", _viewModel, nameof(IPersonViewEditModel.RefreshEnabled));
			this.btnSave.DataBindings.Add("Enabled", _viewModel, nameof(IPersonViewEditModel.SaveEnabled));
			this.btnAdd.DataBindings.Add("Enabled", _viewModel, nameof(IPersonViewEditModel.AddEnabled));
			this.btnDelete.DataBindings.Add("Enabled", _viewModel, nameof(IPersonViewEditModel.DeleteEnabled));
		}

		private void SetEditControlsBindings() {
			this.tbFirstName.DataBindings.Clear();
			this.tbLastName.DataBindings.Clear();
			this.tbFirstName.DataBindings.Add("Text", _viewModel.Current, nameof(Person.FirstName), true, DataSourceUpdateMode.OnPropertyChanged);
			this.tbLastName.DataBindings.Add("Text", _viewModel.Current, nameof(Person.LastName), true, DataSourceUpdateMode.OnPropertyChanged);
			this.tbBirthdate.Text = _viewModel.Current.BithtDate.ToString("yyyy-MM-dd");
		}

		//Please never use constructor to perform the database or api calls. Do it here.
		//Instead, you will have errors in form designer
		protected override async void OnLoad(EventArgs e) {
			base.OnLoad(e);

			await LoadDataAsync();
		}

		private async Task LoadDataAsync() {
			this.Cursor = Cursors.WaitCursor;

			_viewModel.Persons.Clear();
		   //Retreiveing data
		   var persons = await _personRepository.GetAllAsync();
			//Populate model with data
			persons.ForEach(p => _viewModel.Persons.Add(p));

			if (!_viewModel.Persons.Any()) {
				_viewModel.Persons.Add(new Person());
			}
			this._viewModel.Current = _viewModel.Persons.First();
			this.SetButtonBindings();

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

		private void ViewModel_CurrentPersonChanged(object sender, EventArgs e) {
			//Populate the textboxes on grid navigation
			if (this._viewModel.Current != null) {
				this.SetEditControlsBindings();
				this.SetButtonBindings();
			}
		}

		private async void btnRefresh_Click(object sender, EventArgs e) {
			await LoadDataAsync();
		}

		private async void btnSave_Click(object sender, EventArgs e) {
			await _personRepository.SaveAsync(this._viewModel.Current);
			await LoadDataAsync();
		}

		private void btnAdd_Click(object sender, EventArgs e) {
			this._viewModel.Current = this._viewModel.Persons.AddNew();
		}

		private async void btnDelete_Click(object sender, EventArgs e) {
			if (this._viewModel.Current.Id > 0) {
				await _personRepository.DeleteAsync(this._viewModel.Current);
			}
			this._viewModel.Persons.Remove(this._viewModel.Current);
			this._viewModel.Current = this._viewModel.Persons.FirstOrDefault();
			this.SetButtonBindings();
		}

		private void Form_CurrentValueChanged(object sender, EventArgs e) {
			SetButtonBindings();
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
