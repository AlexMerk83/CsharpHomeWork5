main();

void main()
{
    bool isWork = true;

    while (isWork)
    {
        ConsoleIOHandler.PrintMainMenu();

        int taskNo = ConsoleIOHandler.ReadInt("a task number", 0, 3, ConsoleIOHandler.msgNoSuchOption);

        switch (taskNo)
        {
            case 1: Task34EvenNumQuantity(); break;
            case 2: Task36SumOfOddElements(); break;
            case 3: Task38MaxMinNumDifference(); break;
            case 0: isWork = false; break;
            default: System.Console.WriteLine(ConsoleIOHandler.msgNoSuchOption); break;
        }

        if (isWork)
            ConsoleIOHandler.WaitForAnyKey();
    }
}

#region Task34 EvenNumQuantity
// Задача 34: Задайте массив заполненный случайными положительными трёхзначными числами.
// Напишите программу, которая покажет количество чётных чисел в массиве.
// [345, 897, 568, 234] -> 2
void Task34EvenNumQuantity()
{
    Console.Clear();
    System.Console.WriteLine("A new array filled with random 3-digit integer numbers shall be generated.");

    int[] array = ArrayHandler.GetRandomIntArray(ConsoleIOHandler.ReadInt("the array length", 1, 1000), 100, 999);
    
    System.Console.WriteLine($"[{string.Join(", ", array)}]");

    int evenNumCount = 0;

    for (int i = 0; i < array.Length; i++)
        if (array[i] % 2 == 0)
            evenNumCount++;

    System.Console.WriteLine($"The quantity of even numbers in the array is {evenNumCount}");
}
#endregion

#region Task36 SumOfOddElements
// Задача 36: Задайте одномерный массив, заполненный случайными числами.
// Найдите сумму элементов, стоящих на нечётных позициях.
// [3, 7, 23, 12] -> 19
// [-4, -6, 89, 6] -> 0
void Task36SumOfOddElements()
{
    Console.Clear();
    System.Console.WriteLine("Enter parameters of an array filled with random integer numbers.");

    int[] array = ArrayHandler.GetRandomIntArray(ConsoleIOHandler.ReadInt("the array length", 1, 1000),
                                                    ConsoleIOHandler.ReadInt("the minimum value"),
                                                            ConsoleIOHandler.ReadInt("the maximum value"));
    
    System.Console.WriteLine($"[{string.Join(", ", array)}]");

    int evenElementsSum = 0;

    for (int i = 1; i < array.Length; i+=2)
        evenElementsSum += array[i];

    System.Console.WriteLine($"The sum of the numbers in odd positions in the array is {evenElementsSum}");
}
#endregion

#region Task38 MaxMinNumDifference
// Задача 38: Задайте массив вещественных чисел. Найдите разницу между максимальным и минимальным элементов массива.
// [3 7 22 2 78] -> 76
void Task38MaxMinNumDifference()
{
    Console.Clear();
    System.Console.WriteLine("Enter the parameters of an array filled with random real numbers.");

    double[] array = ArrayHandler.GetRandomDoubleArray(ConsoleIOHandler.ReadInt("the array length", 1, 1000),
                                                    ConsoleIOHandler.ReadDouble("the minimum value"),
                                                            ConsoleIOHandler.ReadDouble("the maximum value"));
    
    System.Console.WriteLine($"[{string.Join(", ", array)}]");

    double[] minMax = ArrayHandler.GetMinAndMaxElements(array);
    
    System.Console.WriteLine($"The difference between the maximum and minimum numbers in the array is {minMax[1]-minMax[0]}");    
}
#endregion


#region Input and Output methods
class ConsoleIOHandler
{
    #region Output Support Methods

    public const string msgAnyKeyRequest = "Press any key to continue...";
    public const string msgNoSuchOption = "There is no such option. Try again.";


    public static void PrintMainMenu()
    {
        Console.Clear();

        System.Console.WriteLine("Homework 5 tasks:");
        System.Console.WriteLine("1 - Task 34: Quantity of even numbers in an array");
        System.Console.WriteLine("2 - Task 36: Sum of odd elements of an array");
        System.Console.WriteLine("3 - Task 38: Difference between max and min numbers in an array");
        System.Console.WriteLine("0 - Exit");
    }

    public static void WaitForAnyKey()
    {
            System.Console.WriteLine();
            System.Console.WriteLine(msgAnyKeyRequest);
            Console.ReadKey();
    }

    public static void ClearLine(int lineShift = 0, bool keepCursor = true)
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

    public const string defaultIntErrorMessage = "Input error. Please enter an integer number.";
    private const string defaultRangeErrorMessage = "Input error. Please enter an integer number from the range {0}..{1}.";
    public const string defaultDoubleErrorMessage = "Input error. Please enter a real number.";
    
    public static int ReadInt(string argument)
    {
        int parsedNum = 0,
            inputFieldX = 0,
            inputFieldY = 0;

        System.Console.Write($"Enter {argument}: ");
        inputFieldX = Console.CursorLeft;
        inputFieldY = Console.CursorTop;
        while (!int.TryParse(Console.ReadLine(), out parsedNum))
        {
            Console.SetCursorPosition(0, inputFieldY);
            ClearLine();
            System.Console.WriteLine($"Enter {argument}: ");
            System.Console.WriteLine(defaultIntErrorMessage);
            Console.SetCursorPosition(inputFieldX, inputFieldY);
        }

        ClearLine();
        
        return parsedNum;
    }

    public static int ReadInt(string argument, int minValue, int maxValue, string errorMessage = defaultRangeErrorMessage)
    {
        int parsedNum = 0,
            inputFieldX = 0,
            inputFieldY = 0;

        System.Console.Write($"Enter {argument}: ");
        inputFieldX = Console.CursorLeft;
        inputFieldY = Console.CursorTop;
        while (!int.TryParse(Console.ReadLine(), out parsedNum) || parsedNum < minValue || parsedNum > maxValue)
        {
            Console.SetCursorPosition(0, inputFieldY);
            ClearLine();
            System.Console.WriteLine($"Enter {argument}: ");
            System.Console.WriteLine(errorMessage, minValue, maxValue);
            Console.SetCursorPosition(inputFieldX, inputFieldY);
        }

        ClearLine();
        
        return parsedNum;
    }

    public static double ReadDouble(string argument)
    {
        double parsedNum = 0.0;
        int inputFieldX = 0,
            inputFieldY = 0;

        System.Console.Write($"Enter {argument}: ");
        inputFieldX = Console.CursorLeft;
        inputFieldY = Console.CursorTop;
        while (!double.TryParse(Console.ReadLine(), out parsedNum))
        {
            Console.SetCursorPosition(0, inputFieldY);
            ClearLine();
            System.Console.WriteLine($"Enter {argument}: ");
            System.Console.WriteLine(defaultDoubleErrorMessage);
            Console.SetCursorPosition(inputFieldX, inputFieldY);
        }

        ClearLine();
        
        return parsedNum;
    }
    #endregion
}
#endregion


#region Array Methods

class ArrayHandler
{
    public static int[] GetRandomIntArray(int length, int minVal, int maxVal)
    {
        int[] arr = new int[length];

        Random rnd = new Random();

        for (int i = 0; i < length; i++)
            arr[i] = rnd.Next(minVal, maxVal + 1);
        
        return arr;
    }

    public static double[] GetRandomDoubleArray(int length, double minVal, double maxVal)
    {
        double[] arr = new double[length];

        Random rnd = new Random();

        for (int i = 0; i < length; i++)
            arr[i] = minVal + rnd.NextDouble() * (maxVal - minVal);

        return arr;
    }

    public static double[] GetMinAndMaxElements(double[] array)
    {
        double[] arrMinMax = new double[2];
        
        arrMinMax[0] = array[0];
        arrMinMax[1] = array[0];

        for (int i = 1; i < array.Length; i++)
            if (array[i] < arrMinMax[0]) arrMinMax[0] = array[i];
            else if (array[i] > arrMinMax[1]) arrMinMax[1] = array[i];

        return arrMinMax;
    }

}

#endregion
