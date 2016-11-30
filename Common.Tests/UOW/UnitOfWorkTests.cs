using Common.UOW;
using NUnit.Framework;

namespace Common.Tests.UOW
{
    [TestFixture]
    public class UnitOfWorkTests
    {
        [Test]
        public void EqualityTests()
        {
            UnitOfWork uow1 = new UnitOfWork(1231, 4221, 1378);
            UnitOfWork uow2 = new UnitOfWork(1231, 4221, 1378);

            Assert.AreEqual(uow1, uow2);

            uow1 = new UnitOfWork(1231, 4221, 1378);
            uow2 = new UnitOfWork(121, 221, 1378);

            Assert.AreNotEqual(uow1, uow2);
        }

        [Test]
        public void SerializationTest()
        {
            UnitOfWork uow1 = new UnitOfWork(12312, 316, 9794);
            byte[] bytes = UnitOfWork.ToBytes(uow1);
            UnitOfWork uow2 = UnitOfWork.GetFromBytes(bytes);

            Assert.AreEqual(uow1, uow2);
        }
    }
}
