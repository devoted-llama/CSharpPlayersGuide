using System;

namespace TheCard {
    class Program {
        static void Main(string[] args) {
            foreach (var colour in Enum.GetValues<CardColour>()) {
                foreach (var rank in Enum.GetValues<CardRank>()) {
                    Card card = new Card(colour, rank);
                    Console.WriteLine($"The {card.Colour} {card.Rank} / Facecard: {card.FaceCard}");
                }
            }
        }
    }

    public class Card {
        CardColour _colour;
        public CardColour Colour => _colour;
        CardRank _rank;
        public CardRank Rank => _rank;

        public bool FaceCard {
            get {
                return Rank == CardRank.Dollar || Rank == CardRank.Percentage || Rank == CardRank.Square || Rank == CardRank.Ampersand;
            }
        }

        public Card(CardColour colour, CardRank rank) {
            _colour = colour;
            _rank = rank;
        }
    }

    public enum CardColour {
        Red, Green, Blue, Yellow
    }

    public enum CardRank {
        One = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Dollar, Percentage, Square, Ampersand
    }
}
