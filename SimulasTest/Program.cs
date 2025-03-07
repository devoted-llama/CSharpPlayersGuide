using System;

namespace SimulasTest {

    enum ChestState {
        Open, Closed, Locked
    }
    class Program {

        static void Main(string[] args) {
            ChestState chest;
            chest = ChestState.Locked;
            while (true) {
                Console.Write($"The chest is {GetReadableChestState(chest)}. What do you want to do? ");
                string command = Console.ReadLine();
                chest = DoChestAction(chest, command);
            }
        }

        static ChestState DoChestAction(ChestState chest, string command) {
            switch (command) {
                case "unlock":
                    if (chest == ChestState.Locked) chest = ChestState.Closed;
                    break;
                case "open":
                    if (chest == ChestState.Closed) chest = ChestState.Open;
                    break;
                case "close":
                    if (chest == ChestState.Open) chest = ChestState.Closed;
                    break;
                case "lock":
                    if (chest == ChestState.Closed) chest = ChestState.Locked;
                    break;
                default:
                    break;
            }
            return chest;
        }

        static string GetReadableChestState(ChestState state) {
            switch (state) {
                case ChestState.Closed:
                    return "unlocked";
                case ChestState.Locked:
                    return "locked";
                case ChestState.Open:
                    return "open";
            }
            return "";
        }
    }
}
