using Ifkam.Dictionary.ViewModels;
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
                                            Word = "word1",
                                            Definition = string.Empty
                                        };
            //Act
            mainPageViewModel.Lookup.Execute(null);
            var resultOfFirstLookup = mainPageViewModel.Definition;
            mainPageViewModel.Word = "word2";
            mainPageViewModel.Lookup.Execute(null);
            var resultOfSecondLookup = mainPageViewModel.Definition;

            //Assert
            Assert.IsNotNullOrEmpty(resultOfFirstLookup);
            Assert.AreNotEqual(resultOfFirstLookup, resultOfSecondLookup);

        }
    }
}
