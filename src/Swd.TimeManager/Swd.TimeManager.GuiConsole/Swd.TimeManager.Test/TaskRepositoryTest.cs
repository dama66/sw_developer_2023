using log4net;
using log4net.Config;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Swd.TimeManager.Model;
using Swd.TimeManager.Repository;


namespace Swd.TimeManager.Test
{
    public class TaskRepositoryTest
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(TaskRepositoryTest));

        [SetUp]
        public void Setup()
        {
            XmlConfigurator.Configure(new System.IO.FileInfo("log4net.config"));
            log.Debug("Logging started");
        }

        //Add Methods
        [Test]
        public void Add_Task()
        {
            //Testdaten vorbereiten
            Model.Task item = GetNewTask();

            //Test durchführen
            TaskRepository repository = new TaskRepository();
            repository.Add(item);

            //Test auswerten
            Assert.AreNotEqual(0, item.Id);
        }

        [Test]
        public async System.Threading.Tasks.Task Add_TaskAsync()
        {
            //Testdaten vorbereiten
            Model.Task item = GetNewTask();

            //Test durchführen
            TaskRepository repository = new TaskRepository();
            await repository.AddAsync(item);

            //Test auswerten
            Assert.AreNotEqual(0, item.Id);
        }

        //Read Methods
        [Test]
        public void ReadAll_Task()
        {
            //Testdaten vorbereiten

            //Test durchführen
            TaskRepository repository = new TaskRepository();
            List<Model.Task> taskList = repository.ReadAll().ToList();

            //Test auswerten
            Assert.AreNotEqual(0, taskList.Count);
        }

        [Test]
        public async System.Threading.Tasks.Task ReadAllAsync_Task()
        {
            //Testdaten vorbereiten

            //Test durchführen
            TaskRepository repository = new TaskRepository();
            List<Model.Task> taskList = (await repository.ReadAllAsync()).ToList();

            //Test auswerten
            Assert.AreNotEqual(0, taskList.Count);
        }

        [Test]
        public void ReadByKey_Task()
        {
            //Testdaten vorbereiten
            Model.Task item = GetNewTask();
            TaskRepository repository = new TaskRepository();
            repository.Add(item);
            var id = item.Id;

            //Test durchführen
            Model.Task newTask = repository.ReadByKey(id);

            //Test auswerten
            Assert.AreEqual(id, newTask.Id);
        }

        [Test]
        public async System.Threading.Tasks.Task ReadByKeyAsync_Task()
        {
            //Testdaten vorbereiten
            Model.Task item = GetNewTask();
            TaskRepository repository = new TaskRepository();
            repository.Add(item);
            var id = item.Id;

            //Test durchführen
            Model.Task newTask = (await repository.ReadByKeyAsync(id));

            //Test auswerten
            Assert.AreEqual(id, newTask.Id);
        }

        //Update Methods
        [Test]
        public void Update_Task()
        {
            //Testdaten vorbereiten
            Model.Task item = GetNewTask();
            TaskRepository repository = new TaskRepository();
            repository.Add(item);
            var id = item.Id;
            var createdBy = item.CreatedBy;

            //Test durchführen
            item.CreatedBy = "MAIERDAx";
            repository.Update(item, id);

            Model.Task updateTask = repository.ReadByKey(id);

            //Test auswerten
            Assert.AreNotEqual(createdBy, updateTask.CreatedBy);
        }

        [Test]
        public async System.Threading.Tasks.Task UpdateAsync_Task()
        {
            //Testdaten vorbereiten
            Model.Task item = GetNewTask();
            TaskRepository repository = new TaskRepository();
            repository.Add(item);
            var id = item.Id;
            var createdBy = item.CreatedBy;

            //Test durchführen
            item.CreatedBy = "MAIERDAx";
            await repository.UpdateAsync(item, id);

            Model.Task updateTask = (await repository.ReadByKeyAsync(id));

            //Test auswerten
            Assert.AreNotEqual(createdBy, updateTask.CreatedBy);
        }

        //Delete Methods
        [Test]
        public void Delete_Task()
        {
            //Testdaten vorbereiten
            Model.Task item = GetNewTask();
            TaskRepository repository = new TaskRepository();
            repository.Add(item);
            var id = item.Id;

            //Test durchführen
            repository.Delete(id);
            Model.Task deletedTask = repository.ReadByKey(id);

            //Test auswerten
            Assert.IsNull(deletedTask);
        }

        [Test]
        public async System.Threading.Tasks.Task DeleteAsync_Task()
        {
            //Testdaten vorbereiten
            Model.Task item = GetNewTask();
            TaskRepository repository = new TaskRepository();
            repository.Add(item);
            var id = item.Id;

            //Test durchführen
            await repository.DeleteAsync(id);
            Model.Task deletedTask = (await repository.ReadByKeyAsync(id));

            //Test auswerten
            Assert.IsNull(deletedTask);
        }

        //Helper
        private Model.Task GetNewTask()
        {
            Model.Task t = new Model.Task();
            t.Name = string.Format("Task {0}", DateTime.Now);
            t.CreatedBy = "MAIERDA";
            return t;
        }
       
    }
}