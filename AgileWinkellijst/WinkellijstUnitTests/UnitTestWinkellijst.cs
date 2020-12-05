using System;
using FakeItEasy;
using NUnit.Framework;
using System.Collections.ObjectModel;
using AgileWinkellijst_DAL;
using System.Linq;

namespace WinkellijstUnitTests
{
    [TestFixture]
    public class UnitTestWinkellijst
    {
        [Test]
        public void TestZoekWinkellijst()
        {
            //Arrange
            Winkellijst winkellijst = A.Fake<Winkellijst>();

            //Act
            DatabaseOperations.AddWinkellijst(winkellijst);

            //Assert
            Assert.NotNull(winkellijst);
            Assert.IsInstanceOf<Winkellijst>(winkellijst);

            //Handig bij het testen van de methode die bijvoorbeeld aan een knop gebonden is
            //Hiermee kan je controleren of het klikken op die knop de database operatie heeft uitgevoerd die je zou verwachten
            //A.CallTo(() => unitOfWork.ReeksRepo.ZoekOpPK(winkellijst.ReeksID)).MustHaveHappened();
        }
    }
}
