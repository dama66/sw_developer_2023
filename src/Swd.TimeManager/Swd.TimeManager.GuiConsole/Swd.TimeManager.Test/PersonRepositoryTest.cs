using log4net;
using log4net.Config;
using Swd.TimeManager.Model;
using Swd.TimeManager.Repository;


namespace Swd.TimeManager.Test
{
    public class PersonRepositoryTest
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(PersonRepositoryTest));

        [SetUp]
        public void Setup()
        {
            XmlConfigurator.Configure(new System.IO.FileInfo("log4net.config"));
            log.Debug("Logging started");
        }

        //Add Methods
        [Test]
        public void Add_Person()
        {
            //Testdaten vorbereiten
            Person item = GetNewPerson();

            //Test durchführen
            PersonRepository repository = new PersonRepository();
            repository.Add(item);

            //Test auswerten
            Assert.AreNotEqual(0, item.Id);
        }

        [Test]
        public async System.Threading.Tasks.Task Add_PersonAsync()
        {
            //Testdaten vorbereiten
            Person item = GetNewPerson();

            //Test durchführen
            PersonRepository repository = new PersonRepository();
            await repository.AddAsync(item);

            //Test auswerten
            Assert.AreNotEqual(0, item.Id);
        }

        //Read Methods
        [Test]
        public void ReadAll_Person()
        {
            //Testdaten vorbereiten

            //Test durchführen
            PersonRepository repository = new PersonRepository();
            List<Person> personList = repository.ReadAll().ToList();

            //Test auswerten
            Assert.AreNotEqual(0, personList.Count);
        }

        [Test]
        public async System.Threading.Tasks.Task ReadAllAsync_Person()
        {
            //Testdaten vorbereiten

            //Test durchführen
            PersonRepository repository = new PersonRepository();
            List<Person> personList = (await repository.ReadAllAsync()).ToList();

            //Test auswerten
            Assert.AreNotEqual(0, personList.Count);
        }

        [Test]
        public void ReadByKey_Person()
        {
            //Testdaten vorbereiten
            Person item = GetNewPerson();
            PersonRepository repository = new PersonRepository();
            repository.Add(item);
            var id = item.Id;

            //Test durchführen
            Person newPerson = repository.ReadByKey(id);

            //Test auswerten
            Assert.AreEqual(id, newPerson.Id);
        }

        [Test]
        public async System.Threading.Tasks.Task ReadByKeyAsync_Person()
        {
            //Testdaten vorbereiten
            Person item = GetNewPerson();
            PersonRepository repository = new PersonRepository();
            repository.Add(item);
            var id = item.Id;

            //Test durchführen
            Person newPerson = (await repository.ReadByKeyAsync(id));

            //Test auswerten
            Assert.AreEqual(id, newPerson.Id);
        }

        //Update Methods
        [Test]
        public void Update_Person()
        {
            //Testdaten vorbereiten
            Person item = GetNewPerson();
            PersonRepository repository = new PersonRepository();
            repository.Add(item);
            var id = item.Id;
            var createdBy = item.CreatedBy;

            //Test durchführen
            item.CreatedBy = "MAIERDAx";
            repository.Update(item, id);

            Person updatePerson = repository.ReadByKey(id);

            //Test auswerten
            Assert.AreNotEqual(createdBy, updatePerson.CreatedBy);
        }

        [Test]
        public async System.Threading.Tasks.Task UpdateAsync_Person()
        {
            //Testdaten vorbereiten
            Person item = GetNewPerson();
            PersonRepository repository = new PersonRepository();
            repository.Add(item);
            var id = item.Id;
            var createdBy = item.CreatedBy;

            //Test durchführen
            item.CreatedBy = "MAIERDAx";
            await repository.UpdateAsync(item, id);

            Person updatePerson = (await repository.ReadByKeyAsync(id));

            //Test auswerten
            Assert.AreNotEqual(createdBy, updatePerson.CreatedBy);
        }

        //Delete Methods
        [Test]
        public void Delete_Person()
        {
            //Testdaten vorbereiten
            Person item = GetNewPerson();
            PersonRepository repository = new PersonRepository();
            repository.Add(item);
            var id = item.Id;

            //Test durchführen
            repository.Delete(id);
            Person deletedPerson = repository.ReadByKey(id);

            //Test auswerten
            Assert.IsNull(deletedPerson);
        }

        [Test]
        public async System.Threading.Tasks.Task DeleteAsync_Person()
        {
            //Testdaten vorbereiten
            Person item = GetNewPerson();
            PersonRepository repository = new PersonRepository();
            repository.Add(item);
            var id = item.Id;

            //Test durchführen
            await repository.DeleteAsync(id);
            Person deletedPerson = (await repository.ReadByKeyAsync(id));

            //Test auswerten
            Assert.IsNull(deletedPerson);
        }

        //Helper
        private Person GetNewPerson()
        {
            Person p = new Person();
            p.FirstName = string.Format("FirstName {0}", DateTime.Now);
            p.LastName = string.Format("LastName {0}", DateTime.Now);
            p.Email = "test@google.com";
            p.EntryDate = DateOnly.FromDateTime(DateTime.Now);
            p.CreatedBy = "MAIERDA";
            return p;
        }
    }
}