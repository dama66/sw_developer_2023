
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.TimeManager.GuiMaui.Model
{

    public class TimeManagerDatabase
    {
        SQLiteAsyncConnection _database;

        async Task Init()
        {
            if (_database != null) 
            {
            return;
            }
            _database = new SQLiteAsyncConnection(Constants.DATABASEPATH, Constants.FLAGS);
            await _database.CreateTableAsync<Project>();
        }

        public async Task<List<Project>> GetProjectsAsync()
        {
            await Init();
            return await _database.Table<Project>().ToListAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int key)
        {
            await Init();
            return await _database.Table<Project>().Where(p=>p.Id == key).FirstOrDefaultAsync();
        }

        public async Task<int> SaveProjectAsync(Project project)
        {
            await Init();
            if (project.Id != 0) 
            {
                return await _database.UpdateAsync(project);
            }
            else
            {
                return await _database.InsertAsync(project);
                
            }
        }

        public async Task<int> DeleteProjectAsync(Project project)
        {
            await Init();
            return await _database.DeleteAsync(project);
        }

    }
}
