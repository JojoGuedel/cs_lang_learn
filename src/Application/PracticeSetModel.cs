using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Tomlyn;

class PracticeSetModel
{
    public string Name { get; set; }
    public List<PracticeCardModel> Cards { get; set; }

    public PracticeSetModel()
    {
        Random random = new Random();
        Name = "Noname_" + random.NextInt64().ToString();
        Cards = new List<PracticeCardModel>();
    }

    public void AddCard(PracticeCardModel card)
    {
        Cards.Add(card);
    }

    public void Reset()
    {
        foreach (PracticeCardModel card in Cards)
        {
            card.Expr1.Visited = 0;
            card.Expr1.Correct = 0;

            card.Expr2.Visited = 0;
            card.Expr2.Correct = 0;
        }
    }

    public static PracticeSetModel? FromFile(string path)
    {
        try
        {
            PracticeSetModel practiceSet = new PracticeSetModel();
            string file = File.ReadAllText(path);
            practiceSet = Toml.ToModel<PracticeSetModel>(file);
            practiceSet.Name = Path.GetFileName(path);

            // Console.WriteLine(file);

            return practiceSet;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public void ToFile(string home_path)
    {
        using (FileStream fs = File.Create(Path.Join(home_path, Name)))
        {
            string tomlStr = Toml.FromModel(this);
            Byte[] bytes = new UTF8Encoding(true).GetBytes(tomlStr);
            fs.Write(bytes, 0, bytes.Length);
        }
    }
}