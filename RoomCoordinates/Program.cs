using System;

namespace RoomCoordinates {
    class Program {
        static void Main(string[] args) {
            Coordinate c1 = new Coordinate(0, 1);
            Coordinate c2 = new Coordinate(0, 2);
            Coordinate c3 = new Coordinate(1, 1);
            Coordinate c4 = new Coordinate(2, 0);

            Console.WriteLine($"Are c1 and c2 adjacent? Expecting true. Got {c1.IsAdjacent(c2)}");
            Console.WriteLine($"Are c1 and c3 adjacent? Expecting true. Got {c1.IsAdjacent(c3)}");
            Console.WriteLine($"Are c1 and c4 adjacent? Expecting false. Got {c1.IsAdjacent(c4)}");
            Console.WriteLine($"Are c2 and c3 adjacent? Expecting false. Got {c2.IsAdjacent(c3)}");
            Console.WriteLine($"Are c2 and c4 adjacent? Expecting false. Got {c2.IsAdjacent(c4)}");
            Console.WriteLine($"Are c3 and c4 adjacent? Expecting false. Got {c3.IsAdjacent(c4)}");
        }
    }

    struct Coordinate {
        public int Row { get; }
        public int Columm { get; }
        public Coordinate(int row, int column) {
            Row = row;
            Columm = column;
        }
        public bool IsAdjacent(Coordinate c) {
            int rowDiff = c.Row - Row;
            int colDiff = c.Columm - Columm;
            if (rowDiff == 0 && (colDiff == -1 || colDiff == 1)) {
                return true;
            }
            if (colDiff == 0 && (rowDiff == -1 || rowDiff == 1)) {
                return true;
            }
            return false;
        }
    }
}
