using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ifkam.Services.Contracts.Implementations
{
    public class RailsLookupService : ILookupService
    {
        public async Task<string> Lookup(string word)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(string.Format("http://localhost:3000/api/words?q={0}", word));

            var serializer = new DataContractJsonSerializer(typeof(Word));
            var jsonstr = await response.Content.ReadAsStreamAsync();
            var deserialisedWord = (Word)serializer.ReadObject(jsonstr);

            return deserialisedWord.definition ?? "Sorry, boet. No definition was found.";
        }
    }
    [DataContract]
    public struct Word
    {
        [DataMember]
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
        public string name { get; set; }
// ReSharper restore UnusedMember.Global
// ReSharper restore InconsistentNaming

        [DataMember]
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedAutoPropertyAccessor.Global
        public string definition { get; set; }
// ReSharper restore UnusedAutoPropertyAccessor.Global
// ReSharper restore InconsistentNaming
    }
}