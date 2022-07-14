using BasicsOOP;

var numb23 = new RationalNumber(2, 3); //0,66(..67)
var numb58_1 = new RationalNumber(5, 8); //0,625
var numb58_2 = new RationalNumber(5, 8); //0,625
var numb21_18 = new RationalNumber(21, 18); //1,166(..67)
// 21/18 > 2/3 > 5/8

static void SetDefault(ref RationalNumber numb23, ref RationalNumber numb58_1, ref RationalNumber numb58_2, ref RationalNumber numb21_18)
{
    numb23.Numerator = 2;
    numb23.Denominator = 3;

    numb58_1.Numerator = 5;
    numb58_1.Denominator = 8;

    numb58_2.Numerator = 5;
    numb58_2.Denominator = 8;

    numb21_18.Numerator = 21;
    numb21_18.Denominator = 18;
}
//SetDefault(ref numb23, ref numb58_1, ref numb58_2, ref numb21_18);

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
    tmp.Numerator = 31;
    tmp.Denominator = 24;
    Console.WriteLine((numb58_1 + numb23) == tmp); // 31/24

    tmp.Numerator = 10;
    tmp.Denominator = 8;
    Console.WriteLine((numb58_1 + numb58_2) == tmp); // 10/8

    tmp.Numerator = 33;
    tmp.Denominator = 18;
    Console.WriteLine((numb23 + numb21_18) == tmp); // 33/18

    //-
    Console.WriteLine("\nТест команды -");
    tmp.Numerator = -1;
    tmp.Denominator = 24;
    Console.WriteLine((numb58_1 - numb23) == tmp); // -1/24

    tmp.Numerator = 0;
    tmp.Denominator = 8;
    Console.WriteLine((numb58_1 - numb58_2) == tmp); // 0/8

    tmp.Numerator = -9;
    tmp.Denominator = 18;
    Console.WriteLine((numb23 - numb21_18) == tmp); // -9/18

    //++
    Console.WriteLine("\nТест команды ++");
    tmp.Numerator = numb23.Numerator + numb23.Denominator;
    tmp.Denominator = numb23.Denominator;
    numb23++;
    Console.WriteLine(numb23 == tmp);

    tmp.Numerator = numb58_1.Numerator + numb58_1.Denominator;
    tmp.Denominator = numb58_1.Denominator;
    numb58_1++;
    Console.WriteLine(numb58_1 == tmp);

    tmp.Numerator = numb21_18.Numerator + numb21_18.Denominator;
    tmp.Denominator = numb21_18.Denominator;
    numb21_18++;
    Console.WriteLine(numb21_18 == tmp);

    //--
    Console.WriteLine("\nТест команды --");
    tmp.Numerator = numb23.Numerator - numb23.Denominator;
    tmp.Denominator = numb23.Denominator;
    numb23--;
    Console.WriteLine(numb23 == tmp);

    tmp.Numerator = numb58_1.Numerator - numb58_1.Denominator;
    tmp.Denominator = numb58_1.Denominator;
    numb58_1--;
    Console.WriteLine(numb58_1 == tmp);

    tmp.Numerator = numb21_18.Numerator - numb21_18.Denominator;
    tmp.Denominator = numb21_18.Denominator;
    numb21_18--;
    Console.WriteLine(numb21_18 == tmp);

    //SetDefault(ref numb23, ref numb58_1, ref numb58_2, ref numb21_18);

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