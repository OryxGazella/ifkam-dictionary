//TODO: THis is smelly, word1 and word2 are repeated, even in the RAILS service

using System.Collections.Generic;
using System.Threading.Tasks;
using Ifkam.Services.Contracts;

namespace Ifkam.Viewmodels.Tests
{
    public class LocalLookupService : ILookupService
    {
        private readonly Dictionary<string, string> _dictionary = new Dictionary<string, string>
                                                             {
                                                                 {"word1", "nice word"},
                                                                 {"word2", "another word"}
                                                             };
        public Task<string> Lookup(string word)
        {
            var output = "this word you speak of I have not found";
            if (_dictionary.ContainsKey(word))
            {
                 output = _dictionary[word];
            }
            var task = new Task<string>(() => output);
            task.RunSynchronously();
            return task;

        }
    }
}