using System.Linq;
using Dadata;
using Dadata.Model;

namespace TestApp.Data
{
    public class ContractorsChecker
    {
        private string token;

        public ContractorsChecker(string apiKey)
        {
            token = apiKey;
        }

        public string Suggest(string inn, string kpp=null)
        {
            var api = new SuggestClientSync(token);
            var request = new FindPartyRequest(query: inn, kpp: kpp);
            var result = api.FindParty(request);
            if (!result.suggestions.Any())
            {
                return null;
            }
            string companyName = result.suggestions[0].data.name.full_with_opf;
            return companyName;
        }
    }
}
