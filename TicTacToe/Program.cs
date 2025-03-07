using System;

namespace TicTacToe {
    class Program {
        static void Main(string[] args) {
            TicTacToeGame game = new();
            game.Play();
        }
    }

    public class TicTacToeGame {
        public void Play() {
            TicTacToeBoard board = new(new TicTacToeView());
            bool draw;
            TicTacToeType winner;
            int index = 0, player = 0;
            while (true) {
                board.DisplayBoard();
                player = (index % 2) + 1;
                bool status;
                do {
                    status = board.SetCellToType(GetPlayerInput(player));
                } while (status == false);
                draw = board.GetDraw();
                winner = board.GetWinner();
                if (draw == true) {
                    board.DisplayBoard();
                    Console.WriteLine("Draw!");
                    break;
                }
                if (winner != TicTacToeType.None) {
                    board.DisplayBoard();
                    Console.WriteLine($"Winner is {winner}!");
                    break;
                }
                index++;
            }

        }

        private TicTacToeInputData GetPlayerInput(int player) {
            if (player < 1 || player > 2) {
                throw new ArgumentOutOfRangeException("Player argument out of range.");
            }
            TicTacToeType type = TicTacToeType.None;
            switch (player) {
                case 1: type = TicTacToeType.Nought; break;
                case 2: type = TicTacToeType.Cross; break;
            }
            TicTacToeInputData data = TicTacToeInput.GetUserInput($"Player {type}, enter your coordinates:", type);
            return data;
        }


    }

    public class TicTacToeInputData {
        public int x;
        public int y;
        public TicTacToeType Type;

        public TicTacToeInputData(int x, int y, TicTacToeType type) {
            this.x = x;
            this.y = y;
            Type = type;
        }
    }


    public class TicTacToeBoard {
        private TicTacToeType[,] _board = new TicTacToeType[3, 3];
        private ITicTacToeBoardDisplayer _displayer;

        public TicTacToeBoard(ITicTacToeBoardDisplayer displayer) {
            _displayer = displayer;
            ClearBoard();
        }

        public void DisplayBoard() {
            _displayer.DisplayBoard(_board);
        }

        private void ClearBoard() {
            for (int x = 0; x < _board.GetLength(0); x++) {
                for (int y = 0; y < _board.GetLength(1); y++) {
                    _board[x, y] = TicTacToeType.None;
                }
            }
        }

        public TicTacToeType GetWinner() {
            return CheckRows() | CheckCols() | CheckDiagonalTopLeft() | CheckDiagonalTopRight();
        }

        public bool GetDraw() {
            if (GetIsBoardFull() && GetWinner() == TicTacToeType.None) {
                return true;
            }
            return false;
        }

        private bool GetIsBoardFull() {
            for (int y = 0; y < _board.GetLength(1); y++) {
                for (int x = 0; x < _board.GetLength(0); x++) {
                    if (_board[x, y] == TicTacToeType.None) {
                        return false;
                    }
                }
            }
            return true;
        }

        private TicTacToeType CheckRows() {
            for (int y = 0; y < _board.GetLength(1); y++) {
                TicTacToeType rowType = TicTacToeType.None;
                for (int x = 0; x < _board.GetLength(0); x++) {
                    if (x == 0) {
                        rowType = _board[x, y];
                    } else if (_board[x, y] != rowType) {
                        return TicTacToeType.None;
                    }
                }
                if (rowType != TicTacToeType.None) {
                    return rowType;
                }
            }
            return TicTacToeType.None;
        }

        private TicTacToeType CheckCols() {
            for (int x = 0; x < _board.GetLength(0); x++) {
                TicTacToeType colType = TicTacToeType.None;
                for (int y = 0; y < _board.GetLength(1); y++) {
                    if (y == 0) {
                        colType = _board[x, y];
                    } else if (_board[x, y] != colType) {
                        return TicTacToeType.None;
                    }
                }
                if (colType != TicTacToeType.None) {
                    return colType;
                }
            }
            return TicTacToeType.None;
        }

        private TicTacToeType CheckDiagonalTopLeft() {
            TicTacToeType type = TicTacToeType.None;
            for (int xy = 0; xy < _board.GetLength(0); xy++) {
                if (xy == 0) {
                    type = _board[xy, xy];
                } else if (_board[xy, xy] != type) {
                    return TicTacToeType.None;
                }
            }
            return type;
        }

        private TicTacToeType CheckDiagonalTopRight() {
            TicTacToeType type = TicTacToeType.None;
            for (int y = 0, x = _board.GetLength(0) - 1; y < _board.GetLength(1) && x >= 0; y++, x--) {
                if (y == 0) {
                    type = _board[x, y];
                } else if (_board[x, y] != type) {
                    return TicTacToeType.None;
                }
            }
            return type;
        }

        public bool SetCellToType(TicTacToeInputData data) {
            if (_board[data.x, data.y] == TicTacToeType.None) {
                _board[data.x, data.y] = data.Type;
                return true;
            }
            return false;
        }
    }

    public static class TicTacToeInput {

        public static TicTacToeInputData GetUserInput(string message, TicTacToeType type) {
            Console.Write(message);
            string input = Console.ReadLine();
            string[] values = input.Split(",");
            int x = int.Parse(values[0]);
            int y = int.Parse(values[1]);
            return new TicTacToeInputData(x, y, type);
        }

    }

    public interface ITicTacToeBoardDisplayer {
        public void DisplayBoard(TicTacToeType[,] board);
    }

    public class TicTacToeView : ITicTacToeBoardDisplayer {
        public void DisplayBoard(TicTacToeType[,] board) {

            string display = "";
            for (int y = 0; y < board.GetLength(1); y++) {
                if (y != 0) {
                    display += "---+---+---\n";
                }
                for (int x = 0; x < board.GetLength(0); x++) {

                    if (x != 0) {
                        display += "|";
                    }
                    switch (board[x, y]) {
                        case TicTacToeType.None: display += "   "; break;
                        case TicTacToeType.Nought: display += " O "; break;
                        case TicTacToeType.Cross: display += " X "; break;
                    }
                }
                display += "\n";

            }
            Console.Write(display);
        }
    }

    public enum TicTacToeType {
        None, Nought, Cross
    }
}
