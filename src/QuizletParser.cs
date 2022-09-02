using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

class QuizletParser {
    string url = string.Empty;
    string html = string.Empty;

    PracticeSetModel output = new PracticeSetModel();
    public PracticeSetModel Output { get => output; }

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
        int a, b;

        // TODO: searchNextEnd
        a = searcher.SearchNextEnd("<meta property=\"og:title\" content=\"");
        if (a == -1) return;
        b = searcher.SearchNext("\"");
        if (b == -1) return;
        Console.WriteLine(html.Substring(a, b - a));
        
        while (true) {
            if (searcher.SearchNext("class=\"SetPageTerms-term\"") == -1) return;

            a = searcher.SearchNext("lang-");
            if (a == -1) return;
            b = searcher.SearchNext("\"");
            if (b == -1) return;

            string lang1_s = searcher.text.Substring(a, b - a);
            Language lang1 = parse_lang(lang1_s);

            a = b + 2;
            b = searcher.SearchNext("<");
            if (b == -1) return;
            string term1 = searcher.text.Substring(a, b - a);

            a = searcher.SearchNext("lang-");
            if (a == -1) return;
            b = searcher.SearchNext("\"");
            if (b == -1) return;

            string lang2_s = searcher.text.Substring(a, b - a);
            Language lang2 = parse_lang(lang2_s);

            a = b + 2;
            b = searcher.SearchNext("<");
            if (b == -1) return;
            string term2 = searcher.text.Substring(a, b - a);

            output.AddCard(new PracticeCardModel(term1, lang1_s, term2, lang2_s));
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
