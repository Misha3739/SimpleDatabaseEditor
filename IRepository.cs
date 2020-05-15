using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DatabaseEditorSample {
	public interface IRepository<T> {
		Task<List<T>> GetAllAsync();

		Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);

		Task SaveAsync(T entity);

		Task DeleteAsync(T entity);
	}
}
