using System;

public class VariableShop : IDo {
    public void Do() {
        //16 types
        //ints
        byte a = 255;
        short b = 32767;
        int c = 2147483647;
        long d = 9223372036854775807;
        sbyte e = -128;
        ushort f = 65535;
        uint g = 4294967295;
        ulong h = 18446744073709551615;
        //text
        string i = "hello";
        char j = 'h';
        //floats
        float k = 3.4e-45f;
        double l = 1.7e-324;
        decimal m = 7.9e-28m;
        //bool
        bool n = true;

        Console.Write($"{a}\n{b}\n{c}\n{d}\n{e}\n{f}\n{g}\n{h}\n{i}\n{j}\n{k}\n{l}\n{m}\n{n}");

        //ints
        a = 1;
        b = 377;
        c = 218347;
        d = 922336854775807;
        e = -12;
        f = 655;
        g = 424995;
        h = 18446709551615;
        //text
        i = "helo";
        j = '.';
        //floats
        k = 3.4e-5f;
        l = 1.7e-24;
        m = 7.9e-8m;
        //bool
        n = false;

        Console.Write($"{a}\n{b}\n{c}\n{d}\n{e}\n{f}\n{g}\n{h}\n{i}\n{j}\n{k}\n{l}\n{m}\n{n}");
    }
}

