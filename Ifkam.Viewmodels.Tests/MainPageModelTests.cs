using NUnit.Framework;

namespace Ifkam.Viewmodels.Tests
{
    [TestFixture]
    public class MainPageModelTests
    {
        [Test]
        public void ShouldLookupWord()
        {
            //Arrange
            var mainPageViewModel = new MainPageViewModel
                                        {
                                            Word = "look_me_up",
                                            Definition = string.Empty
                                        };
            //Act
            mainPageViewModel.Lookup.Execute(null);

            //Assert
            Assert.IsNotNullOrEmpty(mainPageViewModel.Definition);

        }
    }
}
