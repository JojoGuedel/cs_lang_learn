using System;
using System.Collections.Generic;

static class Program {
    static void Main() {
        // QuizletParser quizletParser = new QuizletParser("https://quizlet.com/ch/709980296/chapitre-13-flash-cards/");
        // quizletParser.request_data().Wait();
        // quizletParser.parse();

        Screen screen = new Screen();

        List<ScreenContainer> HomeScreen = new List<ScreenContainer>();


        ScreenContainer topBar = new ScreenContainer(0, 0, screen.Width, 1);
        topBar.Content.SetColor(ConsoleColor.White, ConsoleColor.DarkCyan);
        HomeScreen.Add(topBar);

        screen.SetContainerCollection(HomeScreen);

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
