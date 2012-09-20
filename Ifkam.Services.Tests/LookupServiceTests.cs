using System.Threading.Tasks;
using Ifkam.Services.Contracts.Implementations;
using Moq;
using NUnit.Framework;
using System.Net.Http;


namespace Ifkam.Services.Tests
{
    

    [TestFixture]
    public class RailsLookupServiceTests
    {
        private Mock<RailsLookupService.ITransport> _transport;
        private const string ReachedRailsText = "Hello from rails";
        private const string NotFoundText = "Sorry, boet, {0} is not defined in this dictionary.";
        
        [SetUp]
        public void SetUp()
        {
            _transport = new Mock<RailsLookupService.ITransport>();
        }

        [Test]
        public void ShouldLookupAWordOverHttp()
        {

            var task = new Task<HttpResponseMessage>(() => new HttpResponseMessage
            {
                Content = new StringContent("{" +
                                            "    \"word\": \"stub\"," +
                                            "    \"definition\": \"Hello from rails\"" +
                                            "}")

            });



            task.RunSynchronously();
            _transport.Setup(x => x.GetAsync(It.IsAny<string>()))
                .Returns(task);
            
            var service = new RailsLookupService(()=> _transport.Object);
            //Act
            var result = service.Lookup("reach_rails");

            //Assert
            Assert.AreEqual(ReachedRailsText, result.Result);
        }

        [Test]
        public void ShouldNotFreakOutWhenItCantLookUpAWord()
        {
            //Arrange

            var task = new Task<HttpResponseMessage>(() => new HttpResponseMessage
            {
                Content = new StringContent("{" +
                                            "    \"word\": \"stub\"," +
                                            "    \"definition\": \"Sorry, boet, this_word_is_almost_guaranteed_not_to_exist_if_only_I_had_mocks_and_stuff_reach is not defined in this dictionary.\"" +
                                            "}")

            });



            task.RunSynchronously();
            _transport.Setup(x => x.GetAsync(It.IsAny<string>()))
                .Returns(task);
            var service = new RailsLookupService(()=>_transport.Object);
            var word = "this_word_is_almost_guaranteed_not_to_exist_if_only_I_had_mocks_and_stuff_reach";
            //Act
            Task<string> lookup = service.Lookup(word);
            var result = lookup;


            //Assert
            Assert.AreEqual(string.Format(NotFoundText, word), result.Result);

        }
    }

   
}
