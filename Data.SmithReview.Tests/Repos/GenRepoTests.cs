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
        Mock<IDbContextProvider> contextProvider;
        GenRepo<IDbContext, ReviewableItem> repo;
        [TestInitialize()]
        public void GenRepoTestsInitialize() {
            contextProvider = new Mock<IDbContextProvider>();
            unitOfWork = new Mock<IDbContext>();
            contextProvider.Setup(x=>x.Instance()).Returns(unitOfWork.Object);
            unitOfWork.Setup((context)=>context.Set<ReviewableItem>()).Returns(Util.GetMockDbSet<ReviewableItem>(new List<ReviewableItem> {
                new ReviewableItem { Id = 1}, new ReviewableItem { Id = 2 }, new ReviewableItem { Id = 4, Name = "item" }, new ReviewableItem { Id = 3, Name = "item" }
            }).Object);
            repo = new GenRepo<IDbContext, ReviewableItem>(contextProvider.Object);

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