using Swd.TimeManager.Model;
using Swd.TimeManager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Swd.TimeManager.Business
{
    public class TaskService
    {
        private ITaskRepository _repository;

        public TaskService()
        {
            _repository = new TaskRepository();
        }

        //Add Methods
        public void Add(Model.Task item)
        {
            _repository.Add(item);
        }

        public async System.Threading.Tasks.Task AddAsync(Model.Task item)
        {
            await _repository.AddAsync(item);
        }

        //Read Methods
        public IQueryable<Model.Task> ReadAll()
        {
            return _repository.ReadAll();
        }

        public async Task<IQueryable<Model.Task>> ReadAllAsync()
        {
            return await _repository.ReadAllAsync();
        }

        public Model.Task ReadById(int id)
        {
            return _repository.ReadByKey(id);
        }

        public async Task<Model.Task> ReadByIdAsync(int id)
        {
            return await _repository.ReadByKeyAsync(id);
        }

        //Update Methods
        public void Update(Model.Task item)
        {
            _repository.Update(item, item.Id);
        }

        public async System.Threading.Tasks.Task UpdateAsync(Model.Task item)
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
