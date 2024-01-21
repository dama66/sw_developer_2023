using Swd.TimeManager.Model;
using Swd.TimeManager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Swd.TimeManager.Business
{
    public class PersonService
    {
        private IPersonRepository _repository;

        public PersonService()
        {
            _repository = new PersonRepository();
        }

        //Add Methods
        public void Add(Person item)
        {
            _repository.Add(item);
        }

        public async System.Threading.Tasks.Task AddAsync(Person item)
        {
            await _repository.AddAsync(item);
        }

        //Read Methods
        public IQueryable<Person> ReadAll()
        {
            return _repository.ReadAll();
        }

        public async Task<IQueryable<Person>> ReadAllAsync()
        {
            return await _repository.ReadAllAsync();
        }

        public Person ReadById(int id)
        {
            return _repository.ReadByKey(id);
        }

        public async Task<Person> ReadByIdAsync(int id)
        {
            return await _repository.ReadByKeyAsync(id);
        }

        //Update Methods
        public void Update(Person item)
        {
            _repository.Update(item, item.Id);
        }

        public async System.Threading.Tasks.Task UpdateAsync(Person item)
        {
            await _repository.UpdateAsync(item, item.Id);
        }

        //Delete Methods
        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public async System.Threading.Tasks.Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
