using Data.SmithReview.Domain;
using Data.SmithReview.Domain.Interfaces;
using Data.SmithReview.Repos.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.SmithReview;
using Moq;
using Operations.SmithReview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations.SmithReview.Tests {
    [TestClass]
    public class ItemOperationsTests {
        ItemOperations operations;
        Mock<IDbContext> mockContext;
        Mock<IGenRepo<IDbContext, ReviewableItem>> mockRepository;

        [TestInitialize]
        public void ItemOperationsTestsIntialize() {
            mockContext = new Mock<IDbContext>();
            mockRepository = new Mock<IGenRepo<IDbContext, ReviewableItem>>();
            operations = new ItemOperations(mockContext.Object, mockRepository.Object);

        }
        [TestMethod]
        public void ItemOperationsTest() {
            int lookingFor = 1;
            ReviewableItem expectedDomainModel = new ReviewableItem() {
                Id = lookingFor
            };
            ItemModel actualModel;
                mockRepository.Setup(
                    (repo)=>repo.Find(It.IsAny<object>())
                ).Returns(expectedDomainModel).Verifiable();
            actualModel = operations.SingleByKey(lookingFor);
            mockRepository.Verify((repo)=>repo.Find(lookingFor), Times.Once);
            Assert.AreEqual(expectedDomainModel.Id, actualModel.Id);
        }
    }
}