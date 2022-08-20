using System;
using System.Collections.Generic;

static class Program {
    static void Main() {
        // QuizletParser quizletParser = new QuizletParser("https://quizlet.com/ch/709980296/chapitre-13-flash-cards/");
        // quizletParser.request_data().Wait();
        // quizletParser.parse();

        // Screen screen = new Screen();
        // List<ScreenContainer1> HomeScreen = new List<ScreenContainer1>();
        // ScreenContainer1 topBar = new ScreenContainer1(0, 0, screen.Width, 1);
        // topBar.Content.SetColor(ConsoleColor.White, ConsoleColor.DarkCyan);
        // topBar.Content.SetText("Home Screen", ScreenTextAlign.CENTER);
        // HomeScreen.Add(topBar);
        // screen.SetContainerCollection(HomeScreen);

        // ScreenContainer screen = new ScreenContainer();
        // ColumnContainer root = screen.AsColumnContainer();

        // screen.Render();

        TextBoxFormatOptions boxFormatOptions = new TextBoxFormatOptions();

        TextBox box = new TextBox(20, 10, boxFormatOptions);

        box.Write("This");
        box.Write("is");
        box.Write("a");
        box.Write("loooooooooong");
        box.Write("test");
        box.Write("to");
        box.Write("see");
        box.Write("if");
        box.Write("it");
        box.Write("works");

        foreach (TextLine line in box.Lines)
        {
            Console.Write("|");
            Console.Write(line.Text);
            Console.WriteLine("|");
        }

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
