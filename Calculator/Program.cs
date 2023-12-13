namespace Task1
{
    internal interface ICalc
    {
        event EventHandler<EventArgs> GotResult;
        int Sum(int Value);
        int Subatruct(int Value);
        int Multiply(int Value);
        int Divide(int Value);
        void CancelLast();
    }


    internal class Program
    {
        static void Calculator_GotResult(object sendler, EventArgs evenArgs)
        {
            Console.WriteLine($"{((Calculator)sendler).Result}");
        }
        static void Main(string[] args)
        {

            ICalc calc = new Calculator();
            calc.GotResult += Calculator_GotResult;

            while (true)
            {
                Console.WriteLine("Нажмите: Enter - если хотите продолжить, Esc для завершения программы ");

                ConsoleKeyInfo btnRead = Console.ReadKey();
                Console.WriteLine("Введите действие или нажмите для завершения \"q\".");
                if (btnRead.Key == ConsoleKey.Escape)
                {
                    break;
                }
                string? userEntered = Console.ReadLine();

                if (userEntered == "q") break;
                
                    string? newUserEntered = userEntered.Remove(0, 1);
                

                if (int.TryParse(newUserEntered, out int value))
                {
                    switch (userEntered[0])
                    {
                        case '+':
                            calc.Sum(value);
                            break;
                        case '-':
                            calc.Subatruct(value);
                            break;
                        case '/':
                            calc.Divide(value);
                            break;
                        case '*':
                            calc.Multiply(value);
                            break;
                        default:
                            Console.WriteLine("Вы ввели не дейсвие!");
                            break;
                    }
                }
                else { Console.WriteLine("Введите знак действия с числом!"); }
            }
        }
    }
}