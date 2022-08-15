static class Program {
    static void Main() {
        QuizletParser quizletParser = new QuizletParser("https://quizlet.com/ch/709980296/chapitre-13-flash-cards/");
        quizletParser.request_data().Wait();
        quizletParser.parse();

        Console.ReadKey(true);
    }
}

class PracticeResult {
    public bool learned { get; private set; }
    public int visited_count { get; private set; }

    PracticeCard practiceCard;

    public PracticeResult(PracticeCard practiceCard) {
        this.practiceCard = practiceCard;
    }
}

class Practice {
    List<PracticeResult> terms = new List<PracticeResult>();

    public Practice(List<PracticeCard> cards) {
        for (int i = 0; i < cards.Count; i++)
            terms.Add(new PracticeResult(cards[i]));
    }
}

class Comparator {
    
}

interface PracticeMode {
    
}