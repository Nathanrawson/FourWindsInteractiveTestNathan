using System.Linq;
using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Interview
{
    [TestFixture]
    public class Tests
    {
        private IRepository<InMemoryTest> _repository;

        [SetUp]
        public void SetUp()
        {
            _repository = new Repository<InMemoryTest>(PopulateEntities());
        }

        [Test]
        public void TestAll ()
        {
            var result = _repository.All();
            var total = 0;

            var inMemoryTests = result.ToList();
            inMemoryTests.ToList().ForEach(x => total += int.Parse(x.Id.ToString()));

            Assert.IsTrue(total == 190);
            Assert.IsTrue(inMemoryTests.Count() == 20);
        }

        [Test]
        public void TestDelete()
        {
            _repository.Delete(10);

            var result = _repository.FindById(10);

            Assert.IsTrue(result == null);
        }

        [Test]
        public void TestFindById()
        {
            var result = _repository.FindById(2);

            Assert.IsTrue(int.Parse(result.Id.ToString()) == 2);
            Assert.IsTrue(result.Name == "Test2");
        }

        [Test]
        public void TestSave()
        {
            var testItem = new InMemoryTest(){ Id = 23636, Name = "Test23636" };
            _repository.Save(testItem);

           var result =  _repository.FindById(testItem.Id);

            Assert.IsTrue(result.Name == "Test23636");
            Assert.IsTrue(int.Parse(result.Id.ToString()) == 23636);
        }

        private static IList<InMemoryTest> PopulateEntities()
        {
            var entities = new List<InMemoryTest>();

            for (var i = 0; i < 20; i++)
            {
                entities.Add(new InMemoryTest(){Id = i, Name = "Test"+ i });
            }

            return entities;
        }
    }
}