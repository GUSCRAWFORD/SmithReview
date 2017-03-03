using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.SmithReview.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.SmithReview.Domain.Interfaces;
using Moq;
using Data.SmithReview.Domain;
using Data.SmithReview.Tests;

namespace Data.SmithReview.Repos.Tests {
    [TestClass()]
    public class GenRepoTests {
        Mock<IDbContext> unitOfWork;
        GenRepo<IDbContext, Item> repo;
        [TestInitialize()]
        public void GenRepoTestsInitialize() {
            unitOfWork = new Mock<IDbContext>();
            unitOfWork.Setup((context)=>context.Set<Item>()).Returns(Util.GetMockDbSet<Item>(new List<Item> {
                new Item { Id = 1}, new Item { Id = 2 }, new Item { Id = 4, Name = "item" }, new Item { Id = 3, Name = "item" }
            }).Object);
            repo = new GenRepo<IDbContext, Item>(unitOfWork.Object);

        }
        [TestMethod()]
        public void GenRepoTest() {
            
            Assert.IsNotNull(repo);
        }

        [TestMethod()]
        public void QueryTest() {
            var result = repo.Query((item)=>item.Name == "item", 1, 10, "Id");
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.First().Id < result.Last().Id);
            result = repo.Query((item)=>item.Name == "item", 1, 10, "+Id");
            Assert.IsTrue(result.First().Id < result.Last().Id);
            result = repo.Query((item)=>item.Name == "item", 1, 10, "-Id");
            Assert.IsTrue(result.First().Id > result.Last().Id);
        }

        [TestMethod()]
        public void UpsertTest() {
            Assert.Fail();
        }

        [TestMethod()]
        public void FindTest() {
            Assert.Fail();
        }
    }
}