using Ifkam.Dictionary.ViewModels;
using NUnit.Framework;

namespace Ifkam.Viewmodels.Tests
{
    [TestFixture]
    public class MainPageModelTests
    {
        private const string NotFoundText = "this word you speak of I have not found";

        [Test]
        public void ShouldTellYouWhenAWordCannotBeFound()
        {
            //Arrange
            var mainPageViewModel = new MainPageViewModel
                                        {
                                            Word = "I do not exist",
                                            Definition = string.Empty,
                                            Service = new LocalLookupService()
                                        };
            
            //Act
            mainPageViewModel.Lookup.Execute(null);
            //Assert  
            Assert.AreEqual(NotFoundText, mainPageViewModel.Definition);
        }


        [Test]
        public void ShouldLookupWord()
        {
            //Arrange
            var mainPageViewModel = new MainPageViewModel
                                        {
                                            Word = "word1",
                                            Definition = string.Empty
                                        };
            mainPageViewModel.Service = new LocalLookupService();
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

        [Test]
        public void ShouldRaiseAPropertyChangedEventWhenTheDefinitionIsChanged()
        {
            //Arrange
            var mainPageViewModel = new MainPageViewModel
            {
                Word = "word1",
                Definition = string.Empty
            };
            var eventRaised = false;
            mainPageViewModel.PropertyChanged += (sender, args) => eventRaised = true;

            //Act
            mainPageViewModel.Definition = "WOW, this is changing";

            //Assert
            Assert.That(eventRaised, "we expected the viewmodel to notify us that the data had changed.");
        }
    }
}
