using log4net;
using log4net.Config;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Swd.TimeManager.Model;
using Swd.TimeManager.Repository;


namespace Swd.TimeManager.Test
{
    public class TimeRecordRepositoryTest
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(TimeRecordRepositoryTest));

        [SetUp]
        public void Setup()
        {
            XmlConfigurator.Configure(new System.IO.FileInfo("log4net.config"));
            log.Debug("Logging started");
        }

        //Add Methods
        [Test]
        public void Add_TimeRecord()
        {
            //Testdaten vorbereiten
            TimeRecord item = GetNewTimeRecord();

            //Test durchführen
            TimeRecordRepository repository = new TimeRecordRepository();
            repository.Add(item);

            //Test auswerten
            Assert.AreNotEqual(0, item.Id);
        }

        [Test]
        public async System.Threading.Tasks.Task Add_TimeRecordAsync()
        {
            //Testdaten vorbereiten
            TimeRecord item = GetNewTimeRecord();

            //Test durchführen
            TimeRecordRepository repository = new TimeRecordRepository();
            await repository.AddAsync(item);

            //Test auswerten
            Assert.AreNotEqual(0, item.Id);
        }

        //Read Methods
        [Test]
        public void ReadAll_TimeRecord()
        {
            //Testdaten vorbereiten

            //Test durchführen
            TimeRecordRepository repository = new TimeRecordRepository();
            List<TimeRecord> timeRecordList = repository.ReadAll().ToList();

            //Test auswerten
            Assert.AreNotEqual(0, timeRecordList.Count);
        }

        [Test]
        public async System.Threading.Tasks.Task ReadAllAsync_TimeRecord()
        {
            //Testdaten vorbereiten

            //Test durchführen
            TimeRecordRepository repository = new TimeRecordRepository();
            List<TimeRecord> timeRecordList = (await repository.ReadAllAsync()).ToList();

            //Test auswerten
            Assert.AreNotEqual(0, timeRecordList.Count);
        }

        [Test]
        public void ReadByKey_TimeRecord()
        {
            //Testdaten vorbereiten
            TimeRecord item = GetNewTimeRecord();
            TimeRecordRepository repository = new TimeRecordRepository();
            repository.Add(item);
            var id = item.Id;

            //Test durchführen
            TimeRecord newTimeRecord = repository.ReadByKey(id);

            //Test auswerten
            Assert.AreEqual(id, newTimeRecord.Id);
        }

        [Test]
        public async System.Threading.Tasks.Task ReadByKeyAsync_TimeRecord()
        {
            //Testdaten vorbereiten
            TimeRecord item = GetNewTimeRecord();
            TimeRecordRepository repository = new TimeRecordRepository();
            repository.Add(item);
            var id = item.Id;

            //Test durchführen
            TimeRecord newTimeRecord = (await repository.ReadByKeyAsync(id));

            //Test auswerten
            Assert.AreEqual(id, newTimeRecord.Id);
        }

        //Update Methods
        [Test]
        public void Update_TimeRecord()
        {
            //Testdaten vorbereiten
            TimeRecord item = GetNewTimeRecord();
            TimeRecordRepository repository = new TimeRecordRepository();
            repository.Add(item);
            var id = item.Id;
            var createdBy = item.CreatedBy;

            //Test durchführen
            item.CreatedBy = "MAIERDAx";
            repository.Update(item, id);

            TimeRecord updateTimeRecord = repository.ReadByKey(id);

            //Test auswerten
            Assert.AreNotEqual(createdBy, updateTimeRecord.CreatedBy);
        }

        [Test]
        public async System.Threading.Tasks.Task UpdateAsync_TimeRecord()
        {
            //Testdaten vorbereiten
            TimeRecord item = GetNewTimeRecord();
            TimeRecordRepository repository = new TimeRecordRepository();
            repository.Add(item);
            var id = item.Id;
            var createdBy = item.CreatedBy;

            //Test durchführen
            item.CreatedBy = "MAIERDAx";
            await repository.UpdateAsync(item, id);

            TimeRecord updateTimeRecord = (await repository.ReadByKeyAsync(id));

            //Test auswerten
            Assert.AreNotEqual(createdBy, updateTimeRecord.CreatedBy);
        }

        //Delete Methods
        [Test]
        public void Delete_TimeRecord()
        {
            //Testdaten vorbereiten
            TimeRecord item = GetNewTimeRecord();
            TimeRecordRepository repository = new TimeRecordRepository();
            repository.Add(item);
            var id = item.Id;

            //Test durchführen
            repository.Delete(id);
            TimeRecord deletedTimeRecord = repository.ReadByKey(id);

            //Test auswerten
            Assert.IsNull(deletedTimeRecord);
        }

        [Test]
        public async System.Threading.Tasks.Task DeleteAsync_TimeRecord()
        {
            //Testdaten vorbereiten
            TimeRecord item = GetNewTimeRecord();
            TimeRecordRepository repository = new TimeRecordRepository();
            repository.Add(item);
            var id = item.Id;

            //Test durchführen
            await repository.DeleteAsync(id);
            TimeRecord deletedTimeRecord = (await repository.ReadByKeyAsync(id));

            //Test auswerten
            Assert.IsNull(deletedTimeRecord);
        }

        //Helper

        //private Model.Task GetNewTask()
        //{
        //    Model.Task t = new Model.Task();
        //    t.Name = string.Format("Project {0}", DateTime.Now);
        //    t.Created = DateTime.Now;
        //    t.CreatedBy = "MAIERDA";
        //    return t;
        //}
        //private Project GetNewProject()
        //{
        //    Project p = new Project();
        //    p.Name = string.Format("Project {0}", DateTime.Now);
        //    p.Created = DateTime.Now;
        //    p.CreatedBy = "MAIERDA";
        //    return p;
        //}
        //private Person GetNewPerson()
        //{
        //    Person p = new Person();
        //    p.FirstName = string.Format("Project {0}", DateTime.Now);
        //    p.LastName = string.Format("Project {0}", DateTime.Now);
        //    p.Email = "test@google.com";
        //    p.EntryDate = DateOnly.FromDateTime(DateTime.Now);
        //    p.Created = DateTime.Now;
        //    p.CreatedBy = "MAIERDA";
        //    return p;
        //}
        private TimeRecord GetNewTimeRecord()
        {
            var rand = new Random();
            var randDuration = new decimal(rand.NextDouble());

            PersonRepository personRepository = new PersonRepository();
            TaskRepository taskRepository = new TaskRepository();
            ProjectRepository projectRepository = new ProjectRepository();

            Person person = personRepository.ReadAll().FirstOrDefault();
            Model.Task task = taskRepository.ReadAll().FirstOrDefault();
            Project project = projectRepository.ReadAll().FirstOrDefault();

            //Person person = GetNewPerson();
            //Project project = GetNewProject();
            //Model.Task task = GetNewTask();

            TimeRecord t = new TimeRecord();
            t.Date = DateOnly.FromDateTime(DateTime.Now);
            t.Duration = randDuration;
            t.PersonId = person.Id;
            t.ProjectId = project.Id;
            t.TaskId = task.Id;
            t.CreatedBy = "MAIERDA";
            return t;
        }
       
    }
}