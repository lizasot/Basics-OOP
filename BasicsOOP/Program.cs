using BasicsOOP;
using Numbers;

static void TestComplexNumber()
{
    ComplexNumber numb1;
    ComplexNumber numb2;

    Console.WriteLine("\nТест команды +");
    numb1 = new ComplexNumber(4, 2);
    numb2 = new ComplexNumber(-5, 3);
    Console.WriteLine(numb1 + " + " + numb2 + " = " + (numb1+ numb2));
    Console.Write("Совпадает ли с ожидаемым результатом: ");
    Console.WriteLine(numb1 + numb2 == new ComplexNumber(-1, 5));

    Console.WriteLine("\nТест команды *");
    numb1 = new ComplexNumber(2, 3);
    numb2 = new ComplexNumber(5, 4);
    Console.WriteLine(numb1 + " * " + numb2 + " = " + (numb1 * numb2));
    Console.Write("Совпадает ли с ожидаемым результатом: ");
    Console.WriteLine(numb1 * numb2 == new ComplexNumber(-2, 23));

    Console.WriteLine("\nТест команды -");
    numb1 = new ComplexNumber(5, 4);
    numb2 = new ComplexNumber(-2, 3);
    Console.WriteLine(numb1 + " - " + numb2 + " = " + (numb1 - numb2));
    Console.Write("Совпадает ли с ожидаемым результатом: ");
    Console.WriteLine(numb1 - numb2 == new ComplexNumber(7, 1));

    Console.WriteLine("\nТест команды ==");
    Console.WriteLine(numb1 + " == " + numb2 + " = " + (numb1 == numb2));
    Console.Write("Совпадает ли с ожидаемым результатом: ");
    Console.WriteLine((numb1 == numb2) == false);

    numb1 = new ComplexNumber(-2, 3);
    Console.WriteLine(numb1 + " == " + numb2 + " = " + (numb1 == numb2));
    Console.Write("Совпадает ли с ожидаемым результатом: ");
    Console.WriteLine((numb1 == numb2) == true);
}

static void TestRationalNumber()
{
    var numb23 = new RationalNumber(2, 3); //0,66(..67)
    var numb58_1 = new RationalNumber(5, 8); //0,625
    var numb58_2 = new RationalNumber(5, 8); //0,625
    var numb21_18 = new RationalNumber(21, 18); //1,166(..67)
    // 21/18 > 2/3 > 5/8
    var tmp = new RationalNumber();


    //Тест в виде: Выводит на экран всегда true, если результат совпадает с ожидаемым
    //Команда в формате: ВыводНаЭкран(func() == ожидаемый_результат);

    try
    {
        //==
        Console.WriteLine("\nТест команды ==");
        Console.WriteLine((numb58_1 == numb23) == false);
        Console.WriteLine((numb58_1 == numb58_2) == true);
        Console.WriteLine((numb23 == numb21_18) == false);

        //!=
        Console.WriteLine("\nТест команды !=");
        Console.WriteLine((numb58_1 != numb23) == true);
        Console.WriteLine((numb58_1 != numb58_2) == false);
        Console.WriteLine((numb23 != numb21_18) == true);

        //<
        Console.WriteLine("\nТест команды <");
        Console.WriteLine((numb58_1 < numb23) == true);
        Console.WriteLine("======");
        Console.WriteLine((numb58_1 == numb58_2) == true);
        Console.WriteLine(numb58_1 == numb58_2);
        Console.WriteLine((numb58_1 < numb58_2) == false);
        Console.WriteLine("======");
        Console.WriteLine((numb23 < numb21_18) == true);

        //>
        Console.WriteLine("\nТест команды >");
        Console.WriteLine((numb58_1 > numb23) == false);
        Console.WriteLine((numb58_1 > numb58_2) == false);
        Console.WriteLine((numb23 > numb21_18) == false);

        //<=
        Console.WriteLine("\nТест команды <=");
        Console.WriteLine((numb58_1 <= numb23) == true);
        Console.WriteLine((numb58_1 <= numb58_2) == true);
        Console.WriteLine((numb23 <= numb21_18) == true);

        //>=
        Console.WriteLine("\nТест команды >=");
        Console.WriteLine((numb58_1 >= numb23) == false);
        Console.WriteLine((numb58_1 >= numb58_2) == true);
        Console.WriteLine((numb23 >= numb21_18) == false);

        //+
        Console.WriteLine("\nТест команды +");
        tmp = new RationalNumber(31, 24);
        Console.WriteLine((numb58_1 + numb23) == tmp); // 31/24

        tmp = new RationalNumber(10, 8);
        Console.WriteLine((numb58_1 + numb58_2) == tmp); // 10/8

        tmp = new RationalNumber(33, 18);
        Console.WriteLine((numb23 + numb21_18) == tmp); // 33/18

        //-
        Console.WriteLine("\nТест команды -");
        tmp = new RationalNumber(-1, 24);
        Console.WriteLine((numb58_1 - numb23) == tmp); // -1/24

        tmp = new RationalNumber(0, 8);
        Console.WriteLine((numb58_1 - numb58_2) == tmp); // 0/8

        tmp = new RationalNumber(-9, 18);
        Console.WriteLine((numb23 - numb21_18) == tmp); // -9/18

        //++
        Console.WriteLine("\nТест команды ++");
        tmp = new RationalNumber(numb23.Numerator + numb23.Denominator, numb23.Denominator);
        Console.WriteLine(numb23);
        Console.WriteLine(tmp);
        Console.WriteLine(++numb23 == tmp);
        Console.WriteLine(numb23);
        Console.WriteLine(tmp);

        tmp = new RationalNumber(numb58_1.Numerator + numb58_1.Denominator, numb58_1.Denominator);
        Console.WriteLine(++numb58_1 == tmp);

        tmp = new RationalNumber(numb21_18.Numerator + numb21_18.Denominator, numb21_18.Denominator);
        Console.WriteLine(++numb21_18 == tmp);

        //--
        Console.WriteLine("\nТест команды --");
        tmp = new RationalNumber(numb23.Numerator - numb23.Denominator, numb23.Denominator);
        Console.WriteLine(--numb23 == tmp);

        tmp = new RationalNumber(numb58_1.Numerator - numb58_1.Denominator, numb58_1.Denominator);
        Console.WriteLine(--numb58_1 == tmp);


        tmp = new RationalNumber(numb21_18.Numerator - numb21_18.Denominator, numb21_18.Denominator);
        Console.WriteLine(--numb21_18 == tmp);

        //ToString()
        Console.WriteLine("\nТест команды ToString()");
        Console.WriteLine("numb23 = " + numb23);
        Console.WriteLine("numb58_1 = " + numb58_1);
        Console.WriteLine("numb21_18 = " + numb21_18);

        //float
        Console.WriteLine("\nТест команды (float)");
        Console.WriteLine("(float)numb23 = " + (float)numb23);
        Console.WriteLine("(float)numb58_1 = " + (float)numb58_1);
        Console.WriteLine("(float)numb21_18 = " + (float)numb21_18);

        //int
        Console.WriteLine("\nТест команды (int)");
        Console.WriteLine("(int)numb23 = " + (int)numb23);
        Console.WriteLine("(int)numb58_1 = " + (int)numb58_1);
        Console.WriteLine("(int)numb21_18 = " + (int)numb21_18);

        //*
        Console.WriteLine("\nТест команды *");
        Console.WriteLine((numb58_1 * numb23) == new RationalNumber(10, 24));
        Console.WriteLine("======");
        Console.WriteLine(numb58_1 * numb58_2);
        Console.WriteLine((numb58_1 * numb58_2) == new RationalNumber(25, 64));
        Console.WriteLine("======");
        Console.WriteLine((numb23 * numb21_18) == new RationalNumber(42, 54));

        //"/"
        Console.WriteLine("\nТест команды /");
        Console.WriteLine((numb58_1 / numb23) == new RationalNumber(15, 16));
        Console.WriteLine((numb58_1 / numb58_2) == new RationalNumber(40, 40));
        Console.WriteLine((numb23 / numb21_18) == new RationalNumber(36, 63));

        //%
        Console.WriteLine("\nТест команды %");
        Console.WriteLine((numb58_1 % numb23) == new RationalNumber(15, 16));
        Console.WriteLine((numb58_1 % numb58_2) == new RationalNumber(0, 40));
        Console.WriteLine((numb23 % numb21_18) == new RationalNumber(36, 63));
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }

}

TestComplexNumber();
Console.WriteLine("TestRationalNumber:");
TestRationalNumber();