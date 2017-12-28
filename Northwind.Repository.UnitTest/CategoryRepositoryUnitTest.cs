using System;
using System.Collections.Generic;
using System.Text;

using Northwind.Model;
using Northwind.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Northwind.Repository.UnitTest
{
    [TestClass]
    public class CategoryRepositoryUnitTest
    {
        private IDapperContext _context;
        private ICategoryRepository _repo;

        [TestInitialize]
        public void Init()
        {
            _context = new DapperContext();
            _repo = new CategoryRepository(_context);
        }

        [TestCleanup]
        public void CleanUp()
        {
            _repo = null;
            _context.Dispose();
        }

        [TestMethod]
        public void GetByNameTest()
        {
            var name = "con";

            var index = 0;
            var oList = _repo.GetByName(name);
            var obj = oList[index];

            Assert.IsNotNull(obj);
            Assert.AreEqual(2, obj.categoryid);
            Assert.AreEqual("Condiments", obj.categoryname);
            Assert.AreEqual("Sweet and savory sauces, relishes, spreads, and seasonings", obj.description);
        }

        [TestMethod]
        public void GetAllTest()
        {
            var index = 1;
            var oList = _repo.GetAll();
            var obj = oList[index];

            Assert.IsNotNull(obj);
            Assert.AreEqual(2, obj.categoryid);
            Assert.AreEqual("Condiments", obj.categoryname);
            Assert.AreEqual("Sweet and savory sauces, relishes, spreads, and seasonings", obj.description);
        }

        [TestMethod]
        public void SaveTest()
        {
            var obj = new Category
            {
                categoryid = 9,
                categoryname = "Seafood xyz",
                description = "Seaweed and fish xyz"
            };

            var result = _repo.Save(obj);

            Assert.IsTrue(result != 0);

            var newObj = _repo.GetByID(obj.categoryid);
            Assert.IsNotNull(newObj);
            Assert.AreEqual(obj.categoryid, newObj.categoryid);
            Assert.AreEqual(obj.categoryname, newObj.categoryname);
            Assert.AreEqual(obj.description, newObj.description);
        }

        [TestMethod]
        public void DeleteTest()
        {
            var obj = new Category
            {
                categoryid = 9
            };

            var result = _repo.Delete(obj);
            Assert.IsTrue(result != 0);

            var deletedObj = _repo.GetByID(obj.categoryid);
            Assert.IsNull(deletedObj);
        }
    }
}
