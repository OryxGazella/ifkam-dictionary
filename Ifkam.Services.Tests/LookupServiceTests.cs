using System.Threading.Tasks;
using Ifkam.Services.Contracts.Implementations;
using NUnit.Framework;

namespace Ifkam.Services.Tests
{
    

    [TestFixture]
    public class RailsLookupServiceTests
    {
        private const string ReachedRailsText = "Hello from rails";
        private const string NotFoundText = "Sorry, boet, {0} is not defined in this dictionary.";
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

        [Test]
        public void ShouldNotFreakOutWhenItCantLookUpAWord()
        {
            //Arrange
            var service = new RailsLookupService();
            var word = "this_word_is_almost_guaranteed_not_to_exist_if_only_I_had_mocks_and_stuff_reach";
            //Act
            Task<string> lookup = service.Lookup(word);
            var result = lookup;


            //Assert
            Assert.AreEqual(string.Format(NotFoundText, word), result.Result);

        }
    }

   
}
