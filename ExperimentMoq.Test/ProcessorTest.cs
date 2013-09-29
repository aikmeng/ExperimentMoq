using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ExperimentMoq.Test
{
    [TestClass]
    public class ProcessorTest
    {
        [TestMethod]
        public void TestFind()
        {
            //Arrange
            const int expectedId = 1;
            var expected = new DbEntity { Id = expectedId, Name = "Entity 1" };
            var data = new List<DbEntity> 
            { 
                expected,
                new DbEntity { Id = 2, Name = "Entity 2" },
                new DbEntity { Id = 3, Name = "Entity 3" },
                new DbEntity { Id = 4, Name = "Entity 4" }
            }.AsQueryable();

            var dbSetMock = new Mock<IDbSet<DbEntity>>();
            dbSetMock.Setup(m => m.Provider).Returns(data.Provider);
            dbSetMock.Setup(m => m.Expression).Returns(data.Expression);
            dbSetMock.Setup(m => m.ElementType).Returns(data.ElementType);
            dbSetMock.Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var customDbContextMock = new Mock<CustomDbContext>();
            customDbContextMock
                .Setup(x => x.DbEntities)
                .Returns(dbSetMock.Object);

            var classUnderTest = new Processor(customDbContextMock.Object);

            //Action
            var actual = classUnderTest.Find(expectedId);

            //Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Name, actual.Name);
        }
    }
}
