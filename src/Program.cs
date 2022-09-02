using System;
using System.Collections.Generic;

static class Program
{
    static void Main()
    {
        // string url = "https://quizlet.com/ch/714744922/learning-the-press-thinkinglearning-without-word-formation-flash-cards/";
        // string url = "https://quizlet.com/ch/709980296/chapitre-13-flash-cards/"
        // QuizletParser quizletParser = new QuizletParser(url);
        // quizletParser.request_data().Wait();
        // quizletParser.parse();

        Application.Init();
        Application.LoadStartMenu();
        Application.Run();

        // ScreenContainer screen = new ScreenContainer(120, 30, ContainerGrowDirection.TB);

        // LayoutContainer topBar = screen.AddLayoutContainer(1);
        // LayoutContainer body = screen.AddLayoutContainer(screen.Height - 2);
        // LayoutContainer bottomBar = screen.AddLayoutContainer(1);

        // TextContainer topBarTitle = topBar.AddTextContainer(20);
        // topBarTitle.TextBox.Write("Home");

        // LayoutContainer a = body.AddLayoutContainer(20);
        // TextContainer textBox = a.AddTextContainer(4);
        // textBox.TextBox.Write("Hey,");
        // textBox.TextBox.Write("this");
        // textBox.TextBox.Write("is");
        // textBox.TextBox.Write("a");
        // textBox.TextBox.Write("looooooooooooooooooooong");
        // textBox.TextBox.Write("text");

        // screen.Render();

        const string DATADIR = "C:/dev/cs_lang_learn/data/learnsets/";
        // model.Name = "en_1";
        // model.ToFile(DATADIR);

        // PracticeSetModel model = PracticeSetModel.FromFile(DATADIR + "en_1");

        // bool swap_cards = true;
        // while (true)
        // {
        //     int progress = 0;
        //     int max_errors = 10;
        //     int errors = 0;
        //     int correct_min = 1;
        //     string input = string.Empty;

        //     while (errors < max_errors)
        //     {
        //         progress %= model.Cards.Count;

        //         PracticeExpression expr1 = swap_cards ? model.Cards[progress].Expr2 : model.Cards[progress].Expr1;
        //         PracticeExpression expr2 = swap_cards ? model.Cards[progress].Expr1 : model.Cards[progress].Expr2;

        //         int is_known = expr1.Correct;

        //         if (correct_min <= is_known)
        //         {
        //             progress++;
        //             continue;
        //         }

        //         expr1.Visited++;
        //         Console.Clear();
        //         Console.WriteLine(expr1.Content);
        //         Console.WriteLine();

        //         string? _input = Console.ReadLine();
        //         if (_input != null)
        //             input = _input;

        //         if (input == expr2.Content)
        //         {
        //             expr1.Correct++;
        //             progress++;
        //             continue;
        //         }

        //         Console.Clear();
        //         Console.WriteLine("Wrong!");
        //         Console.WriteLine(expr1.Content);
        //         Console.WriteLine();
        //         Console.WriteLine();
        //         Console.WriteLine(expr2.Content);
        //         Console.WriteLine();
        //         Console.WriteLine(input);

        //         _input = Console.ReadLine();
        //         if (_input != null)
        //             input = _input;

        //         if (input == "n")
        //         {
        //             expr1.Correct++;
        //             progress++;
        //             continue;
        //         }
        //         else if (input == "reset")
        //         {
        //             model.Reset();
        //             break;
        //         }
        //         else if (input == "save")
        //         {
        //             model.ToFile(DATADIR);
        //         }
        //         else if (input == "exit")
        //         {
        //             model.ToFile(DATADIR);
        //             return;
        //         }

        //         errors++;
        //         progress++;
        //     }

        //     if (errors == 0) 
        //     {
        //         Console.Clear();
        //         Console.WriteLine("Finished!");
        //         Console.ReadKey(true);
        //         model.Reset();
        //     }
        // }

        // PracticeSetModel? practiceSet = PracticeSetModel.FromFile(DATADIR + "/test");
        // Console.WriteLine(Toml.FromModel(practiceSet));
        // practiceSet.Cards[0].Expr1.Content = "fett";
        // Console.WriteLine(Toml.FromModel(practiceSet));
        // practiceSet.ToFile(DATADIR + "/test");
    }
}

class PracticeResult
{
    public bool learned { get; private set; }
    public int visited_count { get; private set; }

    PracticeCard practiceCard;

    public PracticeResult(PracticeCard practiceCard)
    {
        this.practiceCard = practiceCard;
    }
}

class Practice
{
    List<PracticeResult> terms = new List<PracticeResult>();

    public Practice(List<PracticeCard> cards)
    {
        for (int i = 0; i < cards.Count; i++)
            terms.Add(new PracticeResult(cards[i]));
    }
}