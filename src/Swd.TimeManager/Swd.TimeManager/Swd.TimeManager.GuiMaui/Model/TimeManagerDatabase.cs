﻿using SQLite;
using Swd.TimeManager.Model;
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

        async System.Threading.Tasks.Task Init()
        {
            if (_database != null)
            {
                return;
            }
            _database = new SQLiteAsyncConnection(Constants.DATABASEPATH, Constants.FLAGS);
            await _database.CreateTableAsync<Project>();
            await _database.CreateTableAsync<Task>();
            await _database.CreateTableAsync<Person>();
            await _database.CreateTableAsync<TimeRecord>();
        }

        #region Project
        public async Task<List<Project>> GetProjectsAsync()
        {
            await Init();
            return await _database.Table<Project>().ToListAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int key)
        {
            await Init();
            return await _database.Table<Project>().Where(p => p.Id == key).FirstOrDefaultAsync();
        }

        public async Task<int> SaveProjectAsync(Project project)
        {
            await Init();
            if (project.Name != null)
            {
                if (project.Id != 0)
                {
                    return await _database.UpdateAsync(project);
                }
                else
                {
                    return await _database.InsertAsync(project);
                }
            }
            return 0;
        }

        public async Task<int> DeleteProjectAsync(Project project)
        {
            await Init();
            return await _database.DeleteAsync(project);
        }
        #endregion

        #region Task
        public async Task<List<Task>> GetTasksAsync()
        {
            await Init();
            return await _database.Table<Task>().ToListAsync();
        }

        public async Task<Task> GetTaskByIdAsync(int key)
        {
            await Init();
            return await _database.Table<Task>().Where(t => t.Id == key).FirstOrDefaultAsync();
        }

        public async Task<int> SaveTaskAsync(Task task)
        {
            await Init();
            if (task.Name != null)
            {
                if (task.Id != 0)
                {
                    return await _database.UpdateAsync(task);
                }
                else
                {
                    return await _database.InsertAsync(task);
                }
            }
            return 0;
        }

        public async Task<int> DeleteTaskAsync(Task task)
        {
            await Init();
            return await _database.DeleteAsync(task);
        }
        #endregion

        #region Person
        public async Task<List<Person>> GetPersonsAsync()
        {
            await Init();
            return await _database.Table<Person>().ToListAsync();
        }

        public async Task<Person> GetPersonByIdAsync(int key)
        {
            await Init();
            return await _database.Table<Person>().Where(p => p.Id == key).FirstOrDefaultAsync();
        }

        public async Task<int> SavePersonAsync(Person person)
        {
            await Init();
            if (person.FirstName != null)
            {
                if (person.Id != 0)
                {
                    return await _database.UpdateAsync(person);
                }
                else
                {
                    return await _database.InsertAsync(person);
                }
            }
            return 0;

        }

        public async Task<int> DeletePersonAsync(Person person)
        {
            await Init();
            return await _database.DeleteAsync(person);
        }
        #endregion

        #region TimeRecord

        public async Task<List<TimeRecord>> GetTimeRecordsAsync()
        {
            await Init();
            return await _database.Table<TimeRecord>().ToListAsync();
        }

        public async Task<TimeRecord> GetTimeRecordByIdAsync(int key)
        {
            await Init();
            return await _database.Table<TimeRecord>().Where(p => p.Id == key).FirstOrDefaultAsync();
        }

        public async Task<int> SaveTimeRecordAsync(TimeRecord timerecord)
        {
            await Init();

            if (timerecord.Id != 0)
            {
                return await _database.UpdateAsync(timerecord);
            }
            else
            {
                return await _database.InsertAsync(timerecord);
            }

        }

        public async Task<int> DeleteTimeRecordAsync(TimeRecord timerecord)
        {
            await Init();
            return await _database.DeleteAsync(timerecord);
        }


        #endregion


        public async Task<List<SearchResult>> GetSearchResultAsync(string searchValue)
        {
            await Init();

            string sql = string.Empty;
            sql += "SELECT ";
            sql += "TimeRecord.Id as Id, ";
            sql += "TimeRecord.Date as Date, ";
            sql += "TimeRecord.ProjectId as ProjectId, ";
            sql += "Project.Name as ProjectName, ";
            sql += "TimeRecord.TaskId as TaskId, ";
            sql += "Task.Name as TaskName, ";
            sql += "TimeRecord.PersonId as PersonId, ";
            sql += "Person.LastName || ' ' || Person.FirstName as PersonName, ";
            sql += "TimeRecord.Duration as Duration ";
            sql += "FROM TimeRecord ";
            sql += "INNER JOIN Project ON TimeRecord.ProjectId = Project.Id ";
            sql += "INNER JOIN Person ON TimeRecord.PersonId = Person.Id ";
            sql += "INNER JOIN Task ON TimeRecord.TaskId = Person.Id ";
            //sql += "WHERE Project.Name like '%" + searchValue + "%' "; => Achtung SQL Injection
            sql += "WHERE Project.Name like ? ";
            sql += "ORDER BY Project.Name, TimeRecord.Date";

            string adaptedSearchValue = $"%{searchValue}%";

            var result = await _database.QueryAsync<SearchResult>(sql, adaptedSearchValue);
            return result.ToList();



        }

        public async Task<List<OverviewData>> GetOverviewDataAsync()
        {
            //1. Projet aus Datenbank lesen
            //2. Zu jedem Projekt alle Tasks mit Summen lesen
            //3. Overviewdata um Liste mit den Taskinfos (TaskName, Stunden) erweitern
            //4. Gesamtstundenzahl in Overviewdata Duration speichern

            //  await Init();

            OverviewData ov1 = new OverviewData { ProjectId = 1, ProjectName = "Project 1", Duration = 11.0M };
            OverviewData ov2 = new OverviewData { ProjectId = 2, ProjectName = "Project 2", Duration = 22.0M };
            OverviewData ov3 = new OverviewData { ProjectId = 3, ProjectName = "Project 3", Duration = 33.0M };
            OverviewData ov4 = new OverviewData { ProjectId = 4, ProjectName = "Project 4", Duration = 44.0M };

            List<OverviewData> l = new List<OverviewData>();
            l.Add(ov1);
            l.Add(ov2);
            l.Add(ov3);
            l.Add(ov4);

            return l;

            // var result = await _database.QueryAsync<SearchResult>(sql, adaptedSearchValue);
            // return result.ToList();



        }


    }
}

