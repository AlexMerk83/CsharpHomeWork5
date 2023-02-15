#region Output Support Methods

string msgAnyKeyRequest = "Press any key to continue...";
string msgNoSuchOption = "There is no such option. Try again.";


void PrintMainMenu()
{
    Console.Clear();

    System.Console.WriteLine();
    System.Console.WriteLine("Homework 5 tasks:");
    System.Console.WriteLine("1 - Task 34: Quantity of even numbers in an array");
    System.Console.WriteLine("2 - Task 36: Sum of odd elements of an array");
    System.Console.WriteLine("3 - Task 38: Difference between max and min numbers in an array");
    System.Console.WriteLine("0 - Exit");
    System.Console.Write("Enter a task nunber: ");    
}

void WaitForAnyKey()
{
        System.Console.WriteLine();
        System.Console.WriteLine(msgAnyKeyRequest);
        Console.ReadKey();
}

void ClearLine(int lineShift = 0, bool keepCursor = true)
{
    int currentTop = Console.CursorTop,
        currentLeft = Console.CursorLeft;
    
    Console.SetCursorPosition(0, currentTop + lineShift);
    Console.Write(new string(' ', Console.WindowWidth));

    if (keepCursor)
        Console.SetCursorPosition(currentLeft, currentTop);
    else
        Console.SetCursorPosition(0, currentTop + lineShift);
}

#endregion

#region Input Support Methods

int ReadInt(string argument)
{
    int intNum = 0,
        inputFieldX = 0,
        inputFieldY = 0;

    System.Console.Write($"Enter {argument}: ");
    inputFieldX = Console.CursorLeft;
    inputFieldY = Console.CursorTop;
    while (!int.TryParse(Console.ReadLine(), out intNum))
    {
        Console.SetCursorPosition(0, inputFieldY);
        ClearLine();
        System.Console.WriteLine($"Enter {argument}: ");
        System.Console.WriteLine("Input error. This is not an integer number. Try again...");
        Console.SetCursorPosition(inputFieldX, inputFieldY);
    }

    ClearLine();
    
    return intNum;
}

#endregion

#region Array Methods

int[] GetRandomIntArray(int length, int minVal, int maxVal)
{
    int[] arr = new int[length];

    Random rnd = new Random();

    for (int i = 0; i < length; i++)
        arr[i] = rnd.Next(minVal, maxVal + 1);
    
    return arr;
}

double[] GetRandomDoubleArray(int length, double minVal, double maxVal)
{
    double[] arr = new double[length];

    Random rnd = new Random();

    for (int i = 0; i < length; i++)
        arr[i] = minVal + rnd.NextDouble() * (maxVal - minVal);

    return arr;
}

#endregion

void main()
{
    bool isWork = true;

    while (isWork)
    {
        PrintMainMenu();

        if (int.TryParse(Console.ReadLine(), out int taskNo))
        {
            System.Console.WriteLine();

            switch (taskNo)
            {
                case 1: Task34EvenNumQuantity(); break;
                case 2: Task36SumOfOddElements(); break;
                case 3: Task38MaxMinNumDiff(); break;
                case 0: isWork = false; break;
                default: System.Console.WriteLine(msgNoSuchOption); break;
            }
            
            if (isWork)
                WaitForAnyKey();
            
        }
        else
        {
            System.Console.WriteLine();
            System.Console.WriteLine(msgNoSuchOption);

            WaitForAnyKey();
        }
    }
}


// Задача 34: Задайте массив заполненный случайными положительными трёхзначными числами. Напишите программу, которая покажет количество чётных чисел в массиве.
// [345, 897, 568, 234] -> 2
void Task34EvenNumQuantity()
{

}

// Задача 36: Задайте одномерный массив, заполненный случайными числами. Найдите сумму элементов, стоящих на нечётных позициях.
// [3, 7, 23, 12] -> 19
// [-4, -6, 89, 6] -> 0
void Task36SumOfOddElements()
{
    
}

// Задача 38: Задайте массив вещественных чисел. Найдите разницу между максимальным и минимальным элементов массива.
// [3 7 22 2 78] -> 76
void Task38MaxMinNumDiff()
{
    
}

main();