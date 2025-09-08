using System.ComponentModel.Design;
using System.Text.RegularExpressions;
using static System.Random;

/// 20152010 
/// Ashton Anderson-P
/// INTRPROGR AT1
/// 
class Program
{
    //Global Variables
    static int amt_of_numbers = 5;
    static int floor = 1;
    static int ceiling = 100;

    //Main 
    static void Main()
    {
        //Replay System
        bool playAgain = true;

        while (playAgain)
        {
            LotteryApp();

            Console.WriteLine("Play again? y/n: ");
            string again = Console.ReadLine();
            if (again.ToLower() != "y")
            {
                playAgain = false;
                Console.WriteLine("Thanks For Playing");
            }
        }
    }


    static void LotteryApp()
    {
        //Welcome
        Console.WriteLine(@"
██╗      ██████╗ ████████╗████████╗███████╗██████╗ ██╗   ██╗     █████╗ ██████╗ ██████╗     ██╗  ████████╗██████╗    
██║     ██╔═══██╗╚══██╔══╝╚══██╔══╝██╔════╝██╔══██╗╚██╗ ██╔╝    ██╔══██╗██╔══██╗██╔══██╗    ██║  ╚══██╔══╝██╔══██╗   
██║     ██║   ██║   ██║      ██║   █████╗  ██████╔╝ ╚████╔╝     ███████║██████╔╝██████╔╝    ██║     ██║   ██║  ██║   
██║     ██║   ██║   ██║      ██║   ██╔══╝  ██╔══██╗  ╚██╔╝      ██╔══██║██╔═══╝ ██╔═══╝     ██║     ██║   ██║  ██║   
███████╗╚██████╔╝   ██║      ██║   ███████╗██║  ██║   ██║       ██║  ██║██║     ██║         ███████╗██║   ██████╔╝██╗
╚══════╝ ╚═════╝    ╚═╝      ╚═╝   ╚══════╝╚═╝  ╚═╝   ╚═╝       ╚═╝  ╚═╝╚═╝     ╚═╝         ╚══════╝╚═╝   ╚═════╝ ╚═╝
                                               20152010 - Ashton Anderson                            
");
        Console.WriteLine(@"                                         __________________________________________
                                         |     Welcome to the Lottery App!        |
                                         | Select 5 Numbers And 1 WildCard Number |
                                         |     See How Many Matches You Get!      |
                                         |     Each Match Is Worth 5 Points!      |
                                        --------------------------------------------");



        //Arrays
        int[] numbers = NumberInput(amt_of_numbers, ceiling, floor);
        int[] randomNumbers = RandomGenerator(amt_of_numbers, floor, ceiling);

        //Wildcard
        int wildCard_num = wildCard();
        int[] wildCard_array = new int[1];
        wildCard_array[0] = wildCard_num;



        //Matches
        int matches = LotteryCheck(numbers, randomNumbers);
        int wildCard_matches = BinarySearch(randomNumbers, wildCard_num);
        if (wildCard_matches >= 0)
        {
            wildCard_matches = 1; 
        }
        else
        {
            wildCard_matches = 0;
        }

        //Output
        Console.WriteLine("Your Chosen Numbers: " + string.Join(", ", numbers) + $"\nWildcard: {wildCard_num}");
        Console.WriteLine("The Winning Numbers: " + string.Join(", ", randomNumbers));

        //Calculate Score
        int pointTotal = PointGenerator(matches);
        int wildcardPoints = wildcardPointGenerator(wildCard_matches);
        int total = pointTotal + wildcardPoints;
  



        Console.WriteLine($"You have {matches + wildCard_matches} matches!");
        if (wildCard_matches == 1)
        {
            Console.WriteLine("You Guessed The WildCard!");
        }
        Console.WriteLine($"You Scored {total} points!");

        


    }
   

    //Point System + Graphics
    static int PointGenerator(int value)
    {
        for (int i = 0; i < value; i++)
        {
            Console.WriteLine(@"
             .________ __________      .__        __         ._.
    .__      |   ____/ \______   \____ |__| _____/  |_  _____| |
  __|  |___  |____  \   |     ___/  _ \|  |/    \   __\/  ___/ |
 /__    __/  /       \  |    |  (  <_> )  |   |  \  |  \___ \ \|
    |__|    /______  /  |____|   \____/|__|___|  /__| /____  >__
                   \/                          \/          \/ \/");
        }
        int pointTotal = (value * 5);
        return pointTotal;
    }
    static int wildcardPointGenerator(int value)
    {
        for (int i = 0; i < value; i++)
        {
            Console.WriteLine(@"
  ___       __   ___  ___       ________  ________  ________  ________  ________     
|\  \     |\  \|\  \|\  \     |\   ___ \|\   ____\|\   __  \|\   __  \|\   ___ \    
\ \  \    \ \  \ \  \ \  \    \ \  \_|\ \ \  \___|\ \  \|\  \ \  \|\  \ \  \_|\ \   
 \ \  \  __\ \  \ \  \ \  \    \ \  \ \\ \ \  \    \ \   __  \ \   _  _\ \  \ \\ \  
  \ \  \|\__\_\  \ \  \ \  \____\ \  \_\\ \ \  \____\ \  \ \  \ \  \\  \\ \  \_\\ \ 
   \ \____________\ \__\ \_______\ \_______\ \_______\ \__\ \__\ \__\\ _\\ \_______\
    \|____________|\|__|\|_______|\|_______|\|_______|\|__|\|__|\|__|\|__|\|_______|
                                                                                    
                                                                                    
                                                                                    
 ________  ___  ___  _______   ________   ________  _______   ________              
|\   ____\|\  \|\  \|\  ___ \ |\   ____\ |\   ____\|\  ___ \ |\   ___ \             
\ \  \___|\ \  \\\  \ \   __/|\ \  \___|_\ \  \___|\ \   __/|\ \  \_|\ \            
 \ \  \  __\ \  \\\  \ \  \_|/_\ \_____  \\ \_____  \ \  \_|/_\ \  \ \\ \           
  \ \  \|\  \ \  \\\  \ \  \_|\ \|____|\  \\|____|\  \ \  \_|\ \ \  \_\\ \          
   \ \_______\ \_______\ \_______\____\_\  \ ____\_\  \ \_______\ \_______\         
    \|_______|\|_______|\|_______|\_________\\_________\|_______|\|_______|         
                                 \|_________\|_________|                            
                                                                                    
                                                                                    
  _____  ________                                                                   
 / __  \|\   __  \                                                                  
|\/_|\  \ \  \|\  \                                                                 
\|/ \ \  \ \  \\\  \                                                                
     \ \  \ \  \\\  \                                                               
      \ \__\ \_______\                                                              
       \|__|\|_______|                                                              
                                                                                    
                                                                                    
                                                                                    
 ________  ________  ___  ________   _________  ________  ___                       
|\   __  \|\   __  \|\  \|\   ___  \|\___   ___\\   ____\|\  \                      
\ \  \|\  \ \  \|\  \ \  \ \  \\ \  \|___ \  \_\ \  \___|\ \  \                     
 \ \   ____\ \  \\\  \ \  \ \  \\ \  \   \ \  \ \ \_____  \ \  \                    
  \ \  \___|\ \  \\\  \ \  \ \  \\ \  \   \ \  \ \|____|\  \ \__\                   
   \ \__\    \ \_______\ \__\ \__\\ \__\   \ \__\  ____\_\  \|__|                   
    \|__|     \|_______|\|__|\|__| \|__|    \|__| |\_________\  ___                 
                                                  \|_________| |\__\                
                                                               \|__|                 ");
        }
        int pointTotal = (value * 10);
        return pointTotal;
    }




    //Random No. Gen. 
    static int[] RandomGenerator(int amt_of_numbers, int floor, int ceiling)
    {
        Random random = new Random();
        int[] randomNumbers = new int[amt_of_numbers];

        //Create randomNumbers array
        for (int i = 0; i < amt_of_numbers; i++)
        {
            randomNumbers[i] = random.Next(floor, ceiling + 1);
        }
        Array.Sort(randomNumbers);
        return randomNumbers;
    }

    //Wildcard Input System
    static int wildCard()
    {
        int tgt_num = 0;
        bool isValid = false;

        while (isValid == false)
        {
            Console.WriteLine("Enter Your WildCard Number: ");
            string tgt_num_str = Console.ReadLine();
            if (int.TryParse(tgt_num_str, out tgt_num))
            {
                Console.WriteLine($"Confirmed!");
                isValid = true;
            }
            else
                Console.WriteLine("Invalid Input! Try Again.");
        }

        return (tgt_num);
    }

    //Number Input Validation
    static int[] NumberInput(int amt_of_numbers, int ceiling, int floor)
    {

        while (true)
        {
            //Input & convert to array
            Console.WriteLine($"Enter {amt_of_numbers} Numbers between {floor} and {ceiling}: ");
            string input = Console.ReadLine();
            //string result = Regex.Replace(input, @"\D", ",");
            string[] parts = input.Split(',')
                                    .Select(p => p.Trim())
                                    .ToArray();

            //Check amt_of_numbers
            if (parts.Length != amt_of_numbers)
            {
                Console.WriteLine("Invalid Input! Enter exactly 5 numbers. Try Again");
                continue;
            }

            //Convert array to int
            try
            {
                int[] numbers = Array.ConvertAll(parts, s => int.Parse(s.Trim()));


                //Check for in range
                bool valid = true;
                foreach (int digit in numbers)
                {
                    if (digit > ceiling || digit < floor)
                    {
                        Console.WriteLine($"Invalid Input! Please enter only numbers between {floor} and {ceiling}: ");
                        valid = false;
                        break;
                    }
                }
                if (!valid)
                    continue;

                Array.Sort(numbers);
                return numbers;
            }
            catch
            {
                Console.WriteLine("Invalid Input! Please enter only numbers separated by commas.");
            }



        }
    }

    //Binary Search
    static int BinarySearch(int[] array, int value)
    {
        int low = 0;
        int high = array.Length - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;

            if (array[mid] == value)
            {
                return mid;
            }
            if (array[mid] < value)
            {
                low = mid + 1;

            }
            else
            {
                high = mid - 1;
            }

        }

        return -1;
    }


    //Linear Search
    static int LotteryCheck(int[] numbers, int[] randomNumbers)
    {
        int matches = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = 0; j < randomNumbers.Length; j++)
            {
                if (numbers[i] == randomNumbers[j])
                    matches++;
            }
        }
        return matches;
    }
}
