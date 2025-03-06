using System;

public class TheLawsOfFreach : IDo {
    public void Do() {

        int[] array = new int[] { 4, 51, -7, 13, -100, 15, -8, 45, 90 };

        int currentMinimum = int.MaxValue;
        foreach (int item in array) {
            if (item < currentMinimum) {
                currentMinimum = item;
            }
        }
        Console.WriteLine(currentMinimum);

        int total = 0;
        foreach (int item in array) {
            total += item;
        }
        float average = (float)total / array.Length;
        Console.WriteLine(average);
    }
}

