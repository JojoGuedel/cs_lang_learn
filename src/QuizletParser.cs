using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

class QuizletParser {
    string url = string.Empty;
    string html = string.Empty;
    List<PracticeCard> output = new List<PracticeCard>();

    public QuizletParser(string url) {
        // TODO: Check if url is actually from Quizlet
        this.url = url;
    }

    public async Task request_data() {
        HttpClient client = new HttpClient();

        try {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            // Completly outplay Quizlet by imitating Firefox
            requestMessage.Headers.Add("User-Agent", "Mozilla/5.0");

            HttpResponseMessage response = await client.SendAsync(requestMessage);

            response.EnsureSuccessStatusCode();
            html = await response.Content.ReadAsStringAsync();
        } catch (Exception ex) {
            Console.WriteLine(ex);
        }

        client.Dispose();
    }
    
    public void parse() {
        if (html == string.Empty)
            return;
        
        Searcher searcher = new Searcher(html);
        
        while (true) {
            if (searcher.search_next("class=\"SetPageTerms-term\"") == -1) return;

            int a = searcher.search_next("lang-");
            if (a == -1) return;
            int b = searcher.search_next("\"");
            if (b == -1) return;

            string lang1_s = searcher.text.Substring(a, b - a);
            Language lang1 = parse_lang(lang1_s);

            a = b + 2;
            b = searcher.search_next("<");
            if (b == -1) return;
            string term1 = searcher.text.Substring(a, b - a);

            a = searcher.search_next("lang-");
            if (a == -1) return;
            b = searcher.search_next("\"");
            if (b == -1) return;

            string lang2_s = searcher.text.Substring(a, b - a);
            Language lang2 = parse_lang(lang2_s);

            a = b + 2;
            b = searcher.search_next("<");
            if (b == -1) return;
            string term2 = searcher.text.Substring(a, b - a);
            Console.WriteLine(term1, term2);

            output.Add(new PracticeCard(new TextExpression2(term1, lang1), new TextExpression2(term2, lang2)));
        }
    }

    Language parse_lang(string lang) {
        switch(lang) {
            case "lang-de": return Language.german;
            case "lang-fr": return Language.french;
            case "lang-en": return Language.english;
            default: return Language.unknown;
        }
    }
}
