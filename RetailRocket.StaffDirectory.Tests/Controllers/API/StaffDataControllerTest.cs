using NUnit.Framework;
using Ninject;
using RetailRocket.StaffDirectory.Controllers.API;
using RetailRocket.StaffDirectory.Data;

namespace RetailRocket.StaffDirectory.Tests.Controllers.API
{
    /// <summary>
    /// Tests StaffDataController.
    /// </summary>
    [TestFixture]
    public class StaffDataControllerTest : ApiControllerTestBase
    {
        private StaffDataController _staffDataController;

        [TestFixtureSetUp]
        public override void TestSetup()
        {
            base.TestSetup();

            _staffDataController = new StaffDataController
            {
                Repository = Utils.AppKernel.Get<IRepository>()
            };
        }

        [Test]
        public void ShouldSuccessExecuteGet()
        {
            var result = _staffDataController.Get();
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Count);
        }
    }
}
