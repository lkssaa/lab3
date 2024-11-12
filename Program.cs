using System;
using _aaa;



class Program
{


    static void Main(string[] args)
    {
        Console.WriteLine("задание номер");
        try
        {
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1 or 2:
                    Matrix m = new Matrix(true);
                    break;
                case 3:
                    Matrix a = new Matrix(false, true);
                    Matrix b = new Matrix(false, true);
                    Matrix c = new Matrix(false, true);
                    
                    Console.WriteLine((a + 2 * b - 3 * c.transpose()).ToString());

                    break;
                case 4:
                    filetask.gen(4, 15);
                    Console.WriteLine($"произведение отрицательных нечетных компонент файла - {filetask.con(15)}");
                    break;
                case 5:
                    filetask.gen(5, 20);
                    Console.WriteLine($"пассажиров болле чем с двумя багажами - {filetask.twoormore(filetask.read())}");
                    Console.WriteLine($"пассажиров с большим среднего количеством багажа - {filetask.weight(filetask.read())}");
                    break;
                case 6:
                    filetask.gen(6, 30);
                    Console.WriteLine($"сумма квадратов в файле - {filetask.sqare()}");
                    break;
                case 7:
                    filetask.gen(7, 15);
                    Console.WriteLine($"произведение чисел в файле - {filetask.multiplicate()}");
                    break;
                case 8:
                    filetask.gen(8, 1000);
                    filetask.rewrite(20);
                    break;
                default:
                    Console.WriteLine("нет такого");
                    break;
                    //Matrix m = new Matrix();

                    //Matrix a = new Matrix(false,true);
                    //Matrix b = new Matrix(false, true);
                    //Matrix c = new Matrix(false, true);

                    //Matrix d = a + 2*b - 3 * c.transpose();
                    //Console.WriteLine(d.ToString());

                    //filetask.gen(4, 10);
                    //Console.WriteLine(filetask.con(10));

                    //filetask.gen(5, 20);


                    //Console.WriteLine($"пассажиров болле чем с двумя багажами - {filetask.twoormore(filetask.read())}");
                    //Console.WriteLine($"пассажиров с большим среднего количеством багажа - {filetask.weight(filetask.read())}");
                    //filetask.gen(6, 30);

                    //Console.WriteLine($"сумма квадратов в файле - {filetask.sqare()}");

                    //filetask.gen(7, 15);

                    //Console.WriteLine($"произведение чисел в файле - {filetask.multiplicate()}");

                    //filetask.gen(8, 1000);
                    //filetask.rewrite(20);
            }
        }
        catch (FormatException) { Console.WriteLine("некорректный ввод"); }
        catch (OverflowException) { Console.WriteLine("некорректная длина"); }

        catch (Exception e) { Console.WriteLine(e.ToString()); }
        
    }
}
