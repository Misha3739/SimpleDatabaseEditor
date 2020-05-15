using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DatabaseEditorSample {
	//ToDo: we will implement it later, there are several ways to do it
	public class PersonRepository : IRepository<Person> {
		public Task DeleteAsync(Person entity) {
			throw new NotImplementedException();
		}

		public async Task<List<Person>> FindAsync(Expression<Func<Person, bool>> predicate) {
			throw new NotImplementedException();
		}

		public async Task<List<Person>> GetAllAsync() {
			throw new NotImplementedException();
		}

		public async Task SaveAsync(Person entity) {
			throw new NotImplementedException();
		}
	}
}
