using System;
using System.Net.Http;
using System.Threading.Tasks;
using BibleConnector.Models;

namespace BibleConnector
{
    public abstract class AbstractBibleService
    {
        // Fields ---------------------------------------------------------------------------------

        private HttpClient client;


        // Properties -----------------------------------------------------------------------------

        /// <summary>
        /// Even if we create this service we don't want to initialize the HttpClient until we 
        /// actually need it.
        /// </summary>
        /// <returns></returns>
        protected HttpClient Client => client == null ? client = MakeHttpClient() : client;


        // Methods --------------------------------------------------------------------------------

        /// <summary>
        /// Initialize the HttpClient. This should probably include adding a base url and any 
        /// headers like authorization.
        /// </summary>
        /// <returns></returns>
        protected abstract HttpClient MakeHttpClient();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        /// <param name="chapter"></param>
        /// <returns></returns>
        public abstract Task<Passage> GetPassage(string book, int chapter);
    }
}