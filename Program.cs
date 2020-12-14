using System;

namespace Substitution_cipher
{
    class Program
    {
        static void EncodeAndDecode(bool encode)
        {
            //We need a string of the alphabet with numbers
            string alphabet = " abcdefghijklmnopqrstuvwxyz0123456789";
            //We need an array version of that alphabet
            char[] alphabetCharArray = alphabet.ToCharArray();
            //Ask the user to give you a sentence.
            //sets the color to blue if encoding and purple if decoding
            if (encode)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Please enter a sentence to be encoded");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Please enter a sentence to be decoded");
            }
            //Validate user input, (convert case)
            string input = Console.ReadLine();
            while (String.IsNullOrEmpty(input))
            {
                //saves color of foreground, changes to red, yells at user, changes back to inital color
                var lastcolor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("hey dummy why don't you write in something?");
                Console.ForegroundColor = lastcolor;
                input = Console.ReadLine();
            }
            input = input.ToLower();
            //makes an array of the characters from the user's input
            char[] inputArray = input.ToCharArray();
            //Decide on how we are going to shift characther (length)
            int shift = 5;
            //Do a loop over the user input and figure out the indexes
            string output = "";
            //Console.WriteLine(alphabet);
            bool isValid = true;
            for (int i = 0; i < inputArray.Length; i++)
            {
                int index = Array.IndexOf(alphabetCharArray, inputArray[i]);
                if (index == -1)
                {
                    isValid = false;
                    break;
                }
                //Console.WriteLine($"{inputArray[i]}: {index}");
                //Inside that loop, increase the index number by shift amount
                if (encode)
                {
                    index = index + shift;   
                    if (index >= alphabetCharArray.Length)
                    {
                        //Subtract the length of the array to go back to the begining of the array.
                        index = index - alphabetCharArray.Length;
                        //index = alphabetCharArray.Length
                    }
                }
                else
                {
                    index = index - shift;
                    if (index < 0)
                    {
                        index = index + alphabetCharArray.Length;
                    }
                }
                //Console.WriteLine(index);
                //Use an if statement to see if the shifted index is higher than the total array length.

                
                //Console.WriteLine($"{inputArray[i]}: new index: {index}");
                //Get the shifted characther from array using the your new index number.
                //Console.WriteLine($"{inputArray[i]} becomes {alphabetCharArray[index]}");
                //Combine all the new characthers and create the new sentence
                output += alphabetCharArray[index];
            }
            if (isValid)
            {
                Console.WriteLine($"'{output}'");
            }
            else
            {
                Console.WriteLine("unable to encode string");
                EncodeAndDecode(encode);
            }
            
        }
        static void Main(string[] args)
        {
            Console.Title = "totally legit not at all held together through duct tape encoder";
            //have user choose whether to [e] encode or [d] decode
            bool stillplaying = true;
            while (stillplaying)
            {
                Console.ResetColor();
                Console.WriteLine("Please write 'e' for encode or 'd' for decode or 'x' to exit");
                var choice = Console.ReadKey();
                Console.WriteLine("");
                switch (choice.Key)
                {
                    default:
                    case ConsoleKey.E:
                        EncodeAndDecode(true);
                        break;
                    case ConsoleKey.D:
                        EncodeAndDecode(false);
                        break;
                    case ConsoleKey.X:
                        stillplaying = false;
                        break;
                }
            }
            
            
        }
    }
}
