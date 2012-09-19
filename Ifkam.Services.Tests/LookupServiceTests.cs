using Ifkam.Services.Contracts.Implementations;
using NUnit.Framework;

namespace Ifkam.Services.Tests
{
    [TestFixture]
    public class LookupServiceTests
    {
        private const string NotFoundText = "this word you speak of I have not found";


        [Test]
        public void ShouldLookupAWord()
        {
            //Arrange
            var service = new LocalLookupService();
            //Act
            var result = service.Lookup("word1");
            //Assert  
            Assert.AreEqual("nice word", result.Result);
        }

        [Test]
        public void ShouldTellYouWhenAWordCannotBeFound()
        {
            //Arrange
            var service = new LocalLookupService();
            //Act
            var result =  service.Lookup("I do not exist");
            //Assert  
            Assert.AreEqual(NotFoundText, result.Result); 
        }
        
    }

    [TestFixture]
    public class RailsLookupServiceTests
    {
        private const string ReachedRailsText = "Hello from rails";
        //TODO: MOCK THIS OUT!!!!!!!, this is not a unit test any more,
        //rather make a spy to see that HTTP is being called.
        //Obligatory facepalm...
        //        ............................................________ 
        //....................................,.-'"...................``~., 
        //.............................,.-"..................................."-., 
        //.........................,/...............................................":, 
        //.....................,?......................................................, 
        //.................../...........................................................,} 
        //................./......................................................,:`^`..} 
        //.............../...................................................,:"........./ 
        //..............?.....__.........................................:`.........../ 
        //............./__.(....."~-,_..............................,:`........../ 
        //.........../(_...."~,_........"~,_....................,:`........_/ 
        //..........{.._$;_......"=,_......."-,_.......,.-~-,},.~";/....} 
        //...........((.....*~_......."=-._......";,,./`..../"............../ 
        //...,,,___.`~,......"~.,....................`.....}............../ 
        //............(....`=-,,.......`........................(......;_,,-" 
        //............/.`~,......`-...................................../ 
        //.............`~.*-,.....................................|,./.....,__ 
        //,,_..........}.>-._...................................|..............`=~-, 
        //.....`=~-,__......`,................................. 
        //...................`=~-,,.,............................... 
        //................................`:,,...........................`..............__ 
        //.....................................`=-,...................,%`>--==`` 
        //........................................_..........._,-%.......` 
        //..................................., 
        [Test]
        public void ShouldLookupAWordOverHttp()
        {
            //Arrange
            var service = new RailsLookupService();
            //Act
            var result = service.Lookup("reach_rails");

            //Assert
            Assert.AreEqual(ReachedRailsText, result.Result);
        }
    }

   
}
