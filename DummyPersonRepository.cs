using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DatabaseEditorSample {
	public class DummyPersonRepository : IRepository<Person> {
		private readonly List<Person> _persons;

		public DummyPersonRepository() {
			_persons = new List<Person>() { 
				new Person {
					Id = 1,
					FirstName = "Alice",
					LastName = "Smith",
					BithtDate = new DateTime(1991, 01, 01)
				},
				new Person {
					Id = 2,
					FirstName = "Bob",
					LastName = "Brown",
					BithtDate = new DateTime(1997, 06, 03)
				}
			};
		}

		public async Task<List<Person>> FindAsync(Expression<Func<Person, bool>> predicate) {
			await Task.Delay(50);
			return await Task.FromResult(this._persons.AsQueryable().Where(predicate).ToList());
		}

		public async Task<List<Person>> GetAllAsync() {
			await Task.Delay(50);
			return await Task.FromResult(this._persons);
		}

		public async Task SaveAsync(Person entity) {
			var existing = this._persons.FirstOrDefault(p => p.Id == entity.Id);
			if (existing == null) {
				entity.Id = new Random().Next(100, 500);
				this._persons.Add(entity);
			} else {
				existing.FirstName = entity.FirstName;
				existing.LastName = entity.LastName;
				existing.BithtDate = entity.BithtDate;
			}
			await Task.Delay(50);
		}

		public async Task DeleteAsync(Person entity) {
			var existing = this._persons.FirstOrDefault(p => p.Id == entity.Id);
			if (existing == null) {
				throw new InvalidOperationException($"Person with Id = {entity.Id} does not exist!");
			}
			_persons.Remove(existing);
			await Task.Delay(50);
		}
	}
}
