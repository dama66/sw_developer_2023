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

        public void Add(Project item)
        {
            _repository.Add(item); 
        }

        public async System.Threading.Tasks.Task AddAsync(Project item)
        {
          await _repository.AddAsync(item);
        }

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

        public void Update(Project item)
        {
            _repository.Update(item, item.Id);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
