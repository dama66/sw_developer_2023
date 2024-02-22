using Swd.TimeManager.Model;
using Swd.TimeManager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Swd.TimeManager.Business
{
    public class TimeRecordService
    {
        private ITimeRecordRepository _repository;

        public TimeRecordService()
        {
            _repository = new TimeRecordRepository();
        }

        //Add Methods
        public void Add(TimeRecord item)
        {
            _repository.Add(item);
        }

        public async System.Threading.Tasks.Task AddAsync(TimeRecord item)
        {
            await _repository.AddAsync(item);
        }

        //Read Methods
        public IQueryable<TimeRecord> ReadAll()
        {
            return _repository.ReadAll();
        }

        public async Task<IQueryable<TimeRecord>> ReadAllAsync()
        {
            return await _repository.ReadAllAsync();
        }

        public TimeRecord ReadById(int id)
        {
            return _repository.ReadByKey(id);
        }

        public async Task<TimeRecord> ReadByIdAsync(int id)
        {
            return await _repository.ReadByKeyAsync(id);
        }

        //Update Methods
        public void Update(TimeRecord item)
        {
            _repository.Update(item, item.Id);
        }

        public async System.Threading.Tasks.Task UpdateAsync(TimeRecord item)
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
