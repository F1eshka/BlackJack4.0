using PROJECT.BlackJack;

public interface IPlayer
{
    string Name { get; }
    Hand Hand { get; }
    void AddCard(Card card, bool toSecondHand = false);
    bool HasBusted();
    void ShowPlayerHand();
}