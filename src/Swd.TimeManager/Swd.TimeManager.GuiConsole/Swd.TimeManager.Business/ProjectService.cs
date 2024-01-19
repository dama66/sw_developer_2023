using Swd.TimeManager.Model;
using Swd.TimeManager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Swd.TimeManager.Business
{
    public class ProjectService
    {
        private IProjectRepository _repository;

        public ProjectService()
        {
            _repository = new ProjectRepository();
        }

        //Add Methods
        public void Add(Project item)
        {
            _repository.Add(item);
        }

        public async System.Threading.Tasks.Task AddAsync(Project item)
        {
            await _repository.AddAsync(item);
        }

        //Read Methods
        public IQueryable<Project> ReadAll()
        {
            return _repository.ReadAll();
        }

        public async Task<IQueryable<Project>> ReadAllAsync()
        {
            return await _repository.ReadAllAsync();
        }

        public Project ReadById(int id)
        {
            return _repository.ReadByKey(id);
        }

        public async Task<Project> ReadByIdAsync(int id)
        {
            return await _repository.ReadByKeyAsync(id);
        }

        //Update Methods
        public void Update(Project item)
        {
            _repository.Update(item, item.Id);
        }

        public async System.Threading.Tasks.Task UpdateAsync(Project item)
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
