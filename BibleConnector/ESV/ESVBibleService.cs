using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BibleConnector.Extensions;
using BibleConnector.Models;
using Newtonsoft.Json;

namespace BibleConnector.ESV
{
    public class ESVBibleService : AbstractBibleService
    {
        public const string ESV_API_URL = "https://api.esv.org/v3/passage/text/";

        private string esvApiKey;

        public ESVBibleService(string esvApiKey)
        {
            this.esvApiKey = esvApiKey;
        }

        protected override HttpClient MakeHttpClient()
        {
            var esvClient = new HttpClient();
            esvClient.BaseAddress = new Uri(ESV_API_URL);
            esvClient.DefaultRequestHeaders.Add("Authorization", $"Token {esvApiKey}");
            return esvClient;
        }

        public override async Task<Passage> GetPassage(string book, int chapter)
        {
            var parameters = new Dictionary<string, string>
            {
                { "q", book + "+" + chapter },
                { "include-headings", "False" },
                { "include-footnotes", "False" },
                { "include-verse-numbers", "True" },
                { "include-short-copyright", "False" },
                { "include-passage-references", "False" }
            };

            using (var response = await Client.GetAsync("?" + parameters.ToQueryString()))
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var passage = JsonConvert.DeserializeObject<EsvResponse>(responseString);
                return new Passage
                {
                    Reference = passage.Query,
                    Text = string.Join(' ', passage.Passages),
                };
            }
        }
    }
}