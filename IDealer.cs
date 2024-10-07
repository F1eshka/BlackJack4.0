using PROJECT.BlackJack;

public interface IDealer
{
    Hand Hand { get; }
    void PlayTurn(bool playerBusted);


    void ShowFirstCard();
    void AddCard(Card card);
    void ShowHand();
}