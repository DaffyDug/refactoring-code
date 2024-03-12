using System.Text;


internal class Program
{
    static void Main(string[] args)
    {
        StringBuilder stringBuilder = new StringBuilder();
        IAction[] actions = new IAction[]
        {
            new InputText(),
            new OutputText(),
            new ClearText(),
            new ReplaceText(),
            new ClearConsole(),

        };
        while (true)
        {
            ManagerText.managerText.Menu();
            if (int.TryParse(Console.ReadLine(), out int b))
            {
                if (b >= 1 && b <= actions.Length)
                    actions[b - 1].Run();

            }
            
        }
    }
    class ManagerText
    {
        public static readonly ManagerText managerText;
        private ManagerText()
        { }
        static ManagerText()
        {
            managerText = new ManagerText();
        }

        StringBuilder stringBuilder = new StringBuilder();

        public StringBuilder inputText()
        {
            Console.WriteLine($"1--{TypeLine.Line}");
            Console.WriteLine($"2--{TypeLine.NewLine}");
            int.TryParse(Console.ReadLine(), out int intvalue);
            if (intvalue == 1)
            {
                Console.WriteLine("Введите ваш текст\n");
                string Print_text = Console.ReadLine();
                stringBuilder.Append($"{Print_text}");
            }
            else if (intvalue == 2)
            {
                Console.WriteLine("Введите ваш текст\n");
                string Print_text = Console.ReadLine();
                stringBuilder.Append($"\n{Print_text}");
            }
            return stringBuilder;
        }
        public void outputText()
        {
            if (stringBuilder.Length != 0)
            {
                Console.WriteLine(stringBuilder);
            }
            else
            {
                Console.WriteLine("Пусто!");
            }

        }
        public void clearText()
        {
            if (stringBuilder.Length == 0)
            {
                Console.WriteLine("Там пусто!!!");
            }
            else
            {
                Check();
                int.TryParse(Console.ReadLine(), out int k);
                if (k == 1)
                {
                    stringBuilder.Clear();
                }
            }
        }
        public void replaceText()
        {
            if (stringBuilder.Length == 0)
            {
                Console.WriteLine("Там пусто!!!");
            }
            else
            {
                Console.WriteLine(stringBuilder);
                Console.WriteLine("Какую строку вы хотите заменить?");
                string FirstText = Console.ReadLine();
                Console.WriteLine("На что вы хотите заменить ее?");
                string SecondText = Console.ReadLine();
                Console.WriteLine("Вы хотите заменить " + FirstText + " на " + SecondText + "?");
                Check();
                int.TryParse(Console.ReadLine(), out int IntValue);
                if (IntValue == 1)
                {
                    stringBuilder.Replace(FirstText, SecondText);
                    Console.WriteLine(stringBuilder);
                }
            }
        }
        public void clearConsole()
        {
            Console.Clear();
        }
        static void Check()
        {
            Console.WriteLine("Вы уверены ?\n 1 - Да\n 2 - Нет");
        }
        public void Menu()
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("|1 - Ввод текста        |");
            Console.WriteLine("|2 - Вывод текста       |");
            Console.WriteLine("|3 - Удалить весь текст |");
            Console.WriteLine("|4 - Заменить текст     |");
            Console.WriteLine("|5 - Отчистить экран    |");
            Console.WriteLine("-------------------------");
        }
    }

    class InputText : IAction
    {
        public void Run()
        {
            ManagerText.managerText.inputText();
        }
    }
    class OutputText : IAction
    {
        public void Run()
        {
            ManagerText.managerText.outputText();
        }
    }

    class ClearText : IAction
    {
        public void Run()
        {
            ManagerText.managerText.clearText();
        }
    }

    class ReplaceText : IAction
    {
        public void Run()
        {
            ManagerText.managerText.replaceText();
        }
    }
    class ClearConsole : IAction
    {
        public void Run()
        {
            ManagerText.managerText.clearConsole();
        }
    }
}

public interface IAction
{
    public void Run();
}

public enum TypeLine
{
    Line = 1,
    NewLine
}