class Playing_card
{
    public string Suit { get; }
    public int Type { get; }

    public Playing_card(string suit, int type)
    {
        Suit = suit;
        Type = type;
    }

    public string get_description()
    {
        string type_str = Type switch
        {
            1 => "Ace",
            11 => "Jack",
            12 => "Queen",
            13 => "King",
            _ => Type.ToString()
        };
        return $"{type_str} of {Suit}";
    }

    public static int operator +(Playing_card a, Playing_card b)
    {
        return a.Type + b.Type;
    }
}

class Deck
{
    private List<Playing_card> cards = new List<Playing_card>();
    private static string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };

    public Deck()
    {
        foreach (var suit in suits)
        {
            for (int type = 1; type <= 13; type++)
            {
                cards.Add(new Playing_card(suit, type));
            }
        }
    }

    public void Shuffle()
    {
        Random rand_num = new Random();
        int n = cards.Count;
        while (n > 1)
        {

            int k = rand_num.Next(n);
            var value = cards[k];
            cards[k] = cards[n - 1];
            cards[n - 1] = value;
            n--;
        }

    }
    public Playing_card this[int index]
    {
        get { return cards[index]; }
    }

    public List<Playing_card> Cards => cards;
}

class Program
{
    static void Main()
    {
        List<List<Playing_card>> poker_hands = new()
        {
            new() { new("Hearts", 3), new("Diamonds", 3), new("Clubs", 3), new("Spades", 7), new("Hearts", 7) },
            new() { new("Hearts", 5), new("Diamonds", 5), new("Clubs", 5), new("Spades", 2), new("Hearts", 2) },
            new() { new("Hearts", 10), new("Diamonds", 10), new("Clubs", 10), new("Spades", 8), new("Hearts", 9) }
        };

        var full_house =
           from hand in poker_hands
           let type_groups =
               from card in hand
               group card by card.Type into grouped_cards
               select grouped_cards
           where type_groups.Count() == 2 &&
                 (from g in type_groups where g.Count() == 3 select g).Any() &&
                 (from g in type_groups where g.Count() == 2 select g).Any()
           select hand;

        Console.WriteLine("Full Houses:");
        foreach (var hand in full_house)
        {
            foreach (var card in hand)
            {
                Console.Write($"{card.get_description()}, ");
            }
            Console.WriteLine();
        }
    }
}

