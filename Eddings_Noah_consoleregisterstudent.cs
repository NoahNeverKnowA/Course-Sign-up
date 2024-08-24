using System;

namespace ConsoleRegisterStudent
{
    class Program
    {
        static void Main(string[] args)
        {
            (new Program()).run();
        }

        void run()
        {
            int choice;
            int firstChoice = 0, secondChoice = 0, thirdChoice = 0;
            int totalCredit = 0;
            string yesOrNo = "";

            Console.WriteLine("Noah Eddings");

            do
            {
                WritePrompt();
                choice = Convert.ToInt32(Console.ReadLine());

                switch (ValidateChoice(choice, firstChoice, secondChoice, thirdChoice, totalCredit))
                {
                    case -1:
                        Console.WriteLine("Your entered selection {0} is not a recognized course.", choice);
                        break;
                    case -2:
                        Console.WriteLine("You have already registered for this {0} course.", ChoiceToCourse(choice));
                        break;
                    case -3:
                        Console.WriteLine("You cannot register for more than 9 credit hours.");
                        break;
                    case 0:
                        Console.WriteLine("Registration Confirmed for course {0}.", ChoiceToCourse(choice));
                        totalCredit += 3;
                        if (firstChoice == 0)
                            firstChoice = choice;
                        else if (secondChoice == 0)
                            secondChoice = choice;
                        else if (thirdChoice == 0)
                            thirdChoice = choice;
                        break;
                }

                WriteCurrentRegistration(firstChoice, secondChoice, thirdChoice);
                Console.Write("\nDo you want to try again? (Y|N)? : ");
                yesOrNo = (Console.ReadLine()).ToUpper();
            } while (yesOrNo == "Y");

            Console.WriteLine("Thank you for registering with us");
        }

        void WritePrompt()
        {
            Console.WriteLine("Please select a course for which you want to register by typing the number inside []");
            Console.WriteLine("[1] IT 145\n[2] IT 200\n[3] IT 201\n[4] IT 270\n[5] IT 315\n[6] IT 328\n[7] IT 330");
            Console.Write("Enter your choice: ");
        }

        int ValidateChoice(int choice, int firstChoice, int secondChoice, int thirdChoice, int totalCredit)
        {
            if (choice < 1 || choice > 7)
                return -1;
            else if (choice == firstChoice || choice == secondChoice || choice == thirdChoice)
                return -2;
            else if (totalCredit + 3 > 9)
                return -3;
            return 0;
        }

        void WriteCurrentRegistration(int firstChoice, int secondChoice, int thirdChoice)
        {
            if (firstChoice == 0)
                Console.WriteLine("You are currently not registered for any courses.");
            else if (secondChoice == 0)
                Console.WriteLine("You are currently registered for {0}", ChoiceToCourse(firstChoice));
            else if (thirdChoice == 0)
                Console.WriteLine("You are currently registered for {0}, {1}", ChoiceToCourse(firstChoice), ChoiceToCourse(secondChoice));
            else
                Console.WriteLine("You are currently registered for {0}, {1}, {2}", ChoiceToCourse(firstChoice), ChoiceToCourse(secondChoice), ChoiceToCourse(thirdChoice));
        }

        string ChoiceToCourse(int choice)
        {
            switch (choice)
            {
                case 1:
                    return "IT 145";
                case 2:
                    return "IT 200";
                case 3:
                    return "IT 201";
                case 4:
                    return "IT 270";
                case 5:
                    return "IT 315";
                case 6:
                    return "IT 328";
                case 7:
                    return "IT 330";
                default:
                    return "Unknown Course";
            }
        }
    }
}
