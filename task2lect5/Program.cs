using System;
using System.Collections.Generic;

class Program
{

     static List<int> listNumber = new List<int>();
     
    static void Main()
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Clear();
        char choice ;
        
        listNumber.Add(6);
        listNumber.Add(9);
        listNumber.Add(2);
        

        do
        {
            PrintMenu();
            Console.Write("\n Enter your choice: ");
            choice = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            switch (choice)
            {
                case 'P':
                    PrintNumbers();
                    break;

                case 'A':
                    AddNumbersToList();
                    break;

                case 'M':
                    DisplayMean();
                    break;

                case 'S':
                    DisplaySmallest();
                    break;

                case 'L':
                    DisplayLargest();
                    break;

                case 'F':
                    FindNumber();
                    break;

                case 'O':
                    SortList();
                    break;

                case 'I':
                    SwapByIndex();
                    break;

                case 'V':
                    SwapByValue();
                    break;

                case 'C':
                    ClearList();
                    break;

                case 'Q':
                    Console.WriteLine("\n Goodbye!");
                    break;

                default:
                    Output("Unknown option!");
                    break;

            }
        }

        while (choice != 'Q');
         Console.ResetColor(); 

    }

    static void PrintMenu()
       
    {
        Console.WriteLine("      ╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("      ║                   Main Menu                           ║");
        Console.WriteLine("      ╠═══════════════════════════════════════════════════════╣");
        Console.WriteLine("      ║                   P - Print numbers                   ║");
        Console.WriteLine("      ║                   A - Add a number                    ║");
        Console.WriteLine("      ║                   M - Display mean                    ║");
        Console.WriteLine("      ║                   S - Smallest number                 ║");
        Console.WriteLine("      ║                   L - Largest number                  ║");
        Console.WriteLine("      ║                   F - Find a number                   ║");
        Console.WriteLine("      ║                   O - Sort a number                   ║");
        Console.WriteLine("      ║                   I - Swap by Index                   ║");
        Console.WriteLine("      ║                   V - Swap by value                   ║");
        Console.WriteLine("      ║                   C - Clear the whole list            ║");
        Console.WriteLine("      ║                   Q - Quit                            ║");
        Console.WriteLine("      ╚═══════════════════════════════════════════════════════╝");
    }

    static void Output(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("      ╔══════ Output ═════════════════════════════════════════╗ "); 
        Console.WriteLine("         " + message);
        Console.WriteLine("      ╚═══════════════════════════════════════════════════════╝");
        Console.ForegroundColor = ConsoleColor.Green;
    }


    static bool ListIsEmpty()
    {
        if (listNumber.Count == 0)
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("      ╔══ Output ══════════════════════╗");
            Console.WriteLine("        [] - the list is empty");
            Console.WriteLine("      ╚════════════════════════════════╝");

            Console.ForegroundColor = previousColor;
            return true;
        }

        return false; 
    }

    static void PrintNumbers(){
        string message = "";
        if (ListIsEmpty())
            return;

        string numbers = string.Join(" ", listNumber);
            message = $"[ {numbers} ]";
            Output(message);
       
 
    }


    static void AddNumbersToList()
    {
        string message = "";

        Console.Write(" How many numbers do you want to add to the list? ");
       
        int count;
        while (!int.TryParse(Console.ReadLine(), out count))
        {
            Console.Write(" Please enter a valid number: ");
        }


        for (int i =0; i<count; i++)
        {
            Console.Write($" Enter number {i + 1}: ");
            int num;
            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.Write(" Please enter a valid number: ");
            }

            if (IsNumberExists(num))
            {
                Console.WriteLine("This number is already in the list. Skipping...");
            }
            else
            {
                listNumber.Add(num);
               
            }
        }

        message = " Numbers added.";
        Output(message);
      
    }
    static bool IsNumberExists(int num)
    {
        for (int i = 0; i < listNumber.Count; i++)
        {
            if (listNumber[i] == num)
            {
                return true;
            }
        }
        return false; 
    }

    static void DisplayMean()
    {
        string message = "";
        if (ListIsEmpty())
            return;

        int sum = 0;
        for(int i=0 ; i<listNumber.Count; i++)
        {
            sum += listNumber[i];
        }
        double avg = (double)sum / listNumber.Count; 
        message = $"Mean: {avg}";
        Output(message);
    }

    static void DisplaySmallest()
    {
        if (ListIsEmpty())
            return;
        int smallNum = listNumber[0];
        for (int i = 0; i < listNumber.Count; i++)
        {
            if (smallNum > listNumber[i])
            {
                smallNum = listNumber[i];
            }
           
        }
        Output($"the Smallest number is : {smallNum}");
    }

    static void DisplayLargest()
    {
        if (ListIsEmpty())
            return;
        int largeNum = listNumber[0];
        for (int i = 0; i < listNumber.Count; i++)
        {
            if (largeNum < listNumber[i])
            {
                largeNum = listNumber[i];
            }
           
        }
        Output($"the Largest number is : {largeNum}");
    }

    static void FindNumber()
    {
        if (ListIsEmpty())
            return;

        Console.Write(" Enter Value to search : ");
        int input = Convert.ToInt32(Console.ReadLine());

        bool isFounded = false;

        for (int i = 0; i < listNumber.Count; i++)
        {
            if (input == listNumber[i])
            {
                Output($"Needed number in Index: {i}");
                isFounded = true;
                break;
            }
        }

        if (!isFounded)
            Output($"{input} is not found");


    }
    static void ClearList()
    {
        if (ListIsEmpty())
            return;
        listNumber.Clear();
        Output("List clear successed.");
    }

    static void SortList()
    {
       
        if (ListIsEmpty())
            return;
        //ascending 
        for (int i = 0; i < listNumber.Count - 1; i++)
        {
            for (int j = 0; j < listNumber.Count - i - 1; j++)
            {
                if (listNumber[j] > listNumber[j + 1])
                {
                    int temp = listNumber[j];
                    listNumber[j] = listNumber[j + 1];
                    listNumber[j + 1] = temp;
                }
            }
        }


        string numbers = string.Join(" ", listNumber);
        
        Output($"Sorted list Ascending : [ {numbers} ]");
        //des
        SortListDescending();

    }

    static void SortListDescending()
    {

        if (ListIsEmpty())
            return;
        //descending 
        for (int i = 0; i < listNumber.Count - 1; i++)
        {
            for (int j = 0; j < listNumber.Count - i - 1; j++)
            {
                if (listNumber[j] < listNumber[j + 1])
                {
                    int temp = listNumber[j];
                    listNumber[j] = listNumber[j + 1];
                    listNumber[j + 1] = temp;
                }
            }
        }


        string numbers = string.Join(" ", listNumber);

        Output($"Sorted list Descending: [ {numbers} ]");

    }


    static void SwapByIndex()
    {
        if (ListIsEmpty())
            return;

        Console.Write(" Enter Index 1: ");
        int index1 = Convert.ToInt32(Console.ReadLine());

        Console.Write(" Enter Index 2: ");
        int index2 = Convert.ToInt32(Console.ReadLine());

        if (index1 < 0 || index2 < 0 ||
            index1 >= listNumber.Count || index2 >= listNumber.Count)
        {
            Output("Invalid index!");
            return;
        }

        if (index1 == index2)
        {
            Output("Both indexes are the same. No swap needed.");
            return;
        }

        int temp = listNumber[index1];
        listNumber[index1] = listNumber[index2];
        listNumber[index2] = temp;

        Output("Values swapped successfully.");
    }

    static void SwapByValue()
    {
        if (ListIsEmpty())
            return;

        Console.Write("Enter first value : ");
        int v1 = int.Parse(Console.ReadLine());

        Console.Write("Enter second value : ");
        int v2 = int.Parse(Console.ReadLine());

        int index1 = -1, index2 = -1;

        for (int i = 0; i < listNumber.Count; i++)
        {
            if (listNumber[i] == v1)
                index1 = i;
            if (listNumber[i] == v2)
                index2 = i;
        }

        if (index1 == -1 || index2 == -1)
        {
            Output("One or both values not found.");
            return;
        }

        int temp = listNumber[index1];
        listNumber[index1] = listNumber[index2];
        listNumber[index2] = temp;

        Output("Values swapped successfully.");
    }

}






