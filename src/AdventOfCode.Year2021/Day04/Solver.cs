namespace AdventOfCode.Year2021.Day04;

public static class Solver
{
    public static int GetSumOfUnmarkedNumbersMultipliedWithLastNumberForWinningBoard(string input)
    {
        var draws = GetDraws(input);
        var cards = GetCards(input);

        var firstWinCard = GetFirstWinningCard(cards, draws);

        return firstWinCard.GetResult();
    }

    public static int GetSumOfUnmarkedNumbersMultipliedWithLastNumberForLastWinningBoard(string input)
    {
        var draws = GetDraws(input);
        var cards = GetCards(input);

        var firstWinCard = GetLastWinningCard(cards, draws);

        return firstWinCard.GetResult();
    }

    private static BingoCard GetFirstWinningCard(List<BingoCard> cards, List<int> draws)
    {
        var cardsToCalculate = cards;

        for (var i = 0; i < draws.Count; i++)
        {
            AddDrawToCards(cardsToCalculate, draws.ElementAt(i));
            var winningGame = cardsToCalculate.Where(x => x.IsGameWinning());

            if (winningGame.Count() == 1) return winningGame.First();

            if (winningGame.Count() > 1) throw new InvalidOperationException("Dual winner");
        }

        throw new InvalidOperationException("No winner");
    }

    private static BingoCard GetLastWinningCard(List<BingoCard> cards, List<int> draws)
    {
        var cardsToCalculate = cards;

        for (var i = 0; i < draws.Count; i++)
        {
            AddDrawToCards(cardsToCalculate, draws.ElementAt(i));
            var winningGames = cards.Where(x => x.IsGameWinning()).ToList();

            if (cardsToCalculate.Count == 1 && cardsToCalculate.First().IsGameWinning())
                return cardsToCalculate.First();

            if (cardsToCalculate.Count > 1 && winningGames.Count > 0)
                for (var y = 0; y < winningGames.Count; y++)
                    cardsToCalculate.Remove(winningGames.ElementAt(y));
        }

        throw new InvalidOperationException("No winner");
    }

    private static void AddDrawToCards(List<BingoCard> cards, int draw)
    {
        foreach (var card in cards) card.AddDraw(draw);
    }

    private static List<BingoCard> GetCards(string input)
    {
        var cardStringChunks = input.Split("\r\n").Take(2..).Where(x => !string.IsNullOrEmpty(x)).Select(x => x.Trim())
            .Chunk(5);

        return cardStringChunks.Select(x => new BingoCard(x)).ToList();
    }

    private static List<int> GetDraws(string input)
    {
        var drawsString = input.Split("\r\n").First();

        return drawsString.Split(",").Select(x => int.Parse(x)).ToList();
    }
}