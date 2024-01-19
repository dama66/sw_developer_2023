using log4net;
using log4net.Config;
using Swd.TimeManager.Model;
using Swd.TimeManager.Repository;


namespace Swd.TimeManager.Test
{
    public class RepositoryTest
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(RepositoryTest));

        [SetUp]
        public void Setup()
        {
            XmlConfigurator.Configure(new System.IO.FileInfo("log4net.config"));
            log.Debug("Logging started");
        }

        //Add Methods
        [Test]
        public void Add_Project()
        {
            //Testdaten vorbereiten
            Project item = GetNewProject();

            //Test durchführen
            ProjectRepository repository = new ProjectRepository();
            repository.Add(item);

            //Test auswerten
            Assert.AreNotEqual(0, item.Id);
        }

        [Test]
        public async System.Threading.Tasks.Task Add_ProjectAsync()
        {
            //Testdaten vorbereiten
            Project item = GetNewProject();

            //Test durchführen
            ProjectRepository repository = new ProjectRepository();
            await repository.AddAsync(item);

            //Test auswerten
            Assert.AreNotEqual(0, item.Id);
        }

        //Read Methods
        [Test]
        public void ReadAll_Project()
        {
            //Testdaten vorbereiten

            //Test durchführen
            ProjectRepository repository = new ProjectRepository();
            List<Project> projectList = repository.ReadAll().ToList();

            //Test auswerten
            Assert.AreNotEqual(0, projectList.Count);
        }

        [Test]
        public async System.Threading.Tasks.Task ReadAllAsync_Project()
        {
            //Testdaten vorbereiten

            //Test durchführen
            ProjectRepository repository = new ProjectRepository();
            List<Project> projectList = (await repository.ReadAllAsync()).ToList();

            //Test auswerten
            Assert.AreNotEqual(0, projectList.Count);
        }

        [Test]
        public void ReadByKey_Project()
        {
            //Testdaten vorbereiten
            Project item = GetNewProject();
            ProjectRepository repository = new ProjectRepository();
            repository.Add(item);
            var id = item.Id;

            //Test durchführen
            Project newProject = repository.ReadByKey(id);

            //Test auswerten
            Assert.AreEqual(id, newProject.Id);
        }

        [Test]
        public async System.Threading.Tasks.Task ReadByKeyAsync_Project()
        {
            //Testdaten vorbereiten
            Project item = GetNewProject();
            ProjectRepository repository = new ProjectRepository();
            repository.Add(item);
            var id = item.Id;

            //Test durchführen
            Project newProject = (await repository.ReadByKeyAsync(id));

            //Test auswerten
            Assert.AreEqual(id, newProject.Id);
        }

        //Update Methods
        [Test]
        public void Update_Project()
        {
            //Testdaten vorbereiten
            Project item = GetNewProject();
            ProjectRepository repository = new ProjectRepository();
            repository.Add(item);
            var id = item.Id;
            var createdBy = item.CreatedBy;

            //Test durchführen
            item.CreatedBy = "MAIERDAx";
            repository.Update(item, id);

            Project updateProject = repository.ReadByKey(id);

            //Test auswerten
            Assert.AreNotEqual(createdBy, updateProject.CreatedBy);
        }

        [Test]
        public async System.Threading.Tasks.Task UpdateAsync_Project()
        {
            //Testdaten vorbereiten
            Project item = GetNewProject();
            ProjectRepository repository = new ProjectRepository();
            repository.Add(item);
            var id = item.Id;
            var createdBy = item.CreatedBy;

            //Test durchführen
            item.CreatedBy = "MAIERDAx";
            await repository.UpdateAsync(item, id);

            Project updateProject = (await repository.ReadByKeyAsync(id));

            //Test auswerten
            Assert.AreNotEqual(createdBy, updateProject.CreatedBy);
        }

        //Delete Methods
        [Test]
        public void Delete_Project()
        {
            //Testdaten vorbereiten
            Project item = GetNewProject();
            ProjectRepository repository = new ProjectRepository();
            repository.Add(item);
            var id = item.Id;

            //Test durchführen
            repository.Delete(id);
            Project deletedProject = repository.ReadByKey(id);

            //Test auswerten
            Assert.IsNull(deletedProject);
        }

        [Test]
        public async System.Threading.Tasks.Task DeleteAsync_Project()
        {
            //Testdaten vorbereiten
            Project item = GetNewProject();
            ProjectRepository repository = new ProjectRepository();
            repository.Add(item);
            var id = item.Id;

            //Test durchführen
            await repository.DeleteAsync(id);
            Project deletedProject = (await repository.ReadByKeyAsync(id));

            //Test auswerten
            Assert.IsNull(deletedProject);
        }

        //Helper
        private Project GetNewProject()
        {
            Project p = new Project();
            p.Name = string.Format("Project {0}", DateTime.Now);
            p.Created = DateTime.Now;
            p.CreatedBy = "MAIERDA";
            return p;
        }
    }
}