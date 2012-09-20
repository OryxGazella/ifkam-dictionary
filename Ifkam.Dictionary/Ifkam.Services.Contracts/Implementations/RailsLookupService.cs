using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ifkam.Services.Contracts.Implementations
{
    public class RailsLookupService : ILookupService
    {
        private readonly Func<ITransport> _transportFactory;


        public RailsLookupService()
            : this(() => new HttpTransport())
        {
        }

        public RailsLookupService(Func<ITransport> transportFactory)
        {
            _transportFactory = transportFactory;
        }

        public async Task<string> Lookup(string word)
        {

            using (var client = _transportFactory())
            {
                var response = await client.GetAsync(string.Format("http://localhost:3000/api/words?q={0}", word));

                var serializer = new DataContractJsonSerializer(typeof (Word));
                var jsonstr = await response.Content.ReadAsStreamAsync();
                var deserialisedWord = (Word) serializer.ReadObject(jsonstr);

                return deserialisedWord.definition ?? "Sorry, boet. No definition was found.";
            }
        }

        public interface ITransport : IDisposable
        {
            Task<HttpResponseMessage> GetAsync(string uri);
        }

        internal class HttpTransport : HttpClient, ITransport
        {
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
}