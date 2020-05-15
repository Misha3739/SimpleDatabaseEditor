using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseEditorSample {
	public interface IPersonViewEditModel {
		BindingList<Person> Persons { get; }
		Person Current { get; set; }

		event EventHandler CurrentPersonChanged;
	}
	public class PersonViewEditModel : IPersonViewEditModel {
		public BindingList<Person> Persons { get; }

		private Person _current;

		public Person Current {
			get => _current;
			set { 
				if(_current != value) {
					_current = value;
					CurrentPersonChanged(this, EventArgs.Empty);
				}
			}
		}

		public event EventHandler CurrentPersonChanged;

		public PersonViewEditModel() {
			this.Persons = new BindingList<Person>();
		}
	}
}
