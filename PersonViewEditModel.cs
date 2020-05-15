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
		bool CurrentIsDirty { get; }

		bool RefreshEnabled { get; }

		bool SaveEnabled { get; }

		bool AddEnabled { get; }

		bool DeleteEnabled { get; }

		event EventHandler CurrentPersonChanged;
	}
	public class PersonViewEditModel : IPersonViewEditModel {
		public BindingList<Person> Persons { get; }

		private Person _current;
		private Person _currentOrigin;

		public Person Current {
			get => _current;
			set {
				if (_current != value) {
					_current = value;
					if (_current != null) {
						_currentOrigin = new Person {
							Id = _current.Id,
							BithtDate = _current.BithtDate,
							FirstName = _current.FirstName,
							LastName = _current.LastName
						};
					} else {
						_currentOrigin = null;
					}
					CurrentPersonChanged?.Invoke(this, EventArgs.Empty);
				}
			}
		}

		public event EventHandler CurrentPersonChanged;

		public bool CurrentIsDirty {
			get {
				if (_current == null || _currentOrigin == null) {
					return false;
				}
				return Current.Id == 0 || !(_current.Id == _currentOrigin.Id
					&& _current.FirstName == _currentOrigin.FirstName
					&& _current.LastName == _current.LastName
					&& _current.BithtDate == _current.BithtDate);
			}
		}

		public bool RefreshEnabled => !CurrentIsDirty;

		public bool SaveEnabled => CurrentIsDirty || Current?.Id == 0;

		public bool AddEnabled => !CurrentIsDirty;

		public bool DeleteEnabled => Current != null && !CurrentIsDirty;

		public PersonViewEditModel() {
			this.Persons = new BindingList<Person>();
		}
	}
}
