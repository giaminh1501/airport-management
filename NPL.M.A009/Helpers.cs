namespace NPL.M.A009
{
    public static class InputHelper
    {
        /// <summary>
        /// Input a double number from keyboard
        /// If input is invalid, ask user to input again
        /// </summary>
        /// <returns>A double value</returns>
        public static double InputDouble()
        {
            while (true)
            {
                double result;
                bool isValid = double.TryParse(Console.ReadLine(), out result);
                if (isValid && result > 0)
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                }
            }
        }

        /// <summary>
        /// Input a integer number from keyboard
        /// If input is invalid, ask user to input again
        /// </summary>
        /// <returns>A integer value</returns>
        public static int InputInteger()
        {
            while (true)
            {
                int result;
                bool isValid = int.TryParse(Console.ReadLine(), out result);
                if (isValid && result > 0)
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                }
            }
        }

        /// <summary>
        /// Input a integer number from keyboard
        /// If input is invalid, ask user to input again
        /// </summary>
        /// <returns>A integer value</returns>
        public static bool InputInteger(int min, int max, out int result)
        {
            while (true)
            {
                bool isValid = int.TryParse(Console.ReadLine(), out result);
                if (isValid && result > min && result < max)
                {
                    return isValid;
                }
                else
                {
                    return false;
                }
            }
        }

        public static int CreateMenu(string menuTitle, List<string> menuItems)
        {
            int choice;
            while (true)
            {
                Console.WriteLine($"========= {menuTitle} =========");
                menuItems.ForEach(item => Console.WriteLine($"{menuItems.IndexOf(item) + 1}. {item}"));

                Console.Write("Enter a choice: ");
                bool rightChoice = InputHelper.InputInteger(0, menuItems.Count, out choice);

                if (rightChoice)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }

            return choice;
        }

        public static int ShowItem(string Title, List<string> Items)
        {
            int choice;
            while (true)
            {
                Console.WriteLine(Title);
                Items.ForEach(item => Console.WriteLine($"{Items.IndexOf(item) + 1}. {item}"));

                Console.Write("Enter a choice: ");
                bool rightChoice = InputHelper.InputInteger(0, Items.Count, out choice);

                if (rightChoice)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }

            return choice;
        }
    }
}
