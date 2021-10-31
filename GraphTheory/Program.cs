using GraphTheory1.Exercises;
using System;

namespace GraphTheory1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello there! Welcome to the \"Graph Theory\" exercises!");

            var factory = new ExerciseFactory();
            string cmd = ReadInputCommand();
            while (!cmd.Equals("Exit", StringComparison.OrdinalIgnoreCase))
            {
                ExecuteExercise(factory, byte.Parse(cmd));
                cmd = ReadInputCommand();
            }

            Console.WriteLine("I hope you enjoyed your time! See you next time!");
        }

        private static string ReadInputCommand()
        {
            Console.Write("Please select what exercise you want to execute (1-2) or exit: ");

            string cmd = Console.ReadLine();
            while (!InputCommandIsValid(cmd))
            {
                Console.Write("Please select what exercise you want to execute (1-2) or exit: ");
                cmd = Console.ReadLine();
            }

            return cmd;
        }

        private static bool InputCommandIsValid(string cmd)
        {
            return cmd.Equals("Exit", StringComparison.OrdinalIgnoreCase) || 
                   (byte.TryParse(cmd, out byte exerciseNumber) && Extras.Exercises.IsAvailable(exerciseNumber));
        }

        private static void ExecuteExercise(ExerciseFactory factory, byte exerciseNumber)
        {
            factory.Construct(exerciseNumber).Execute();
        }
    }
}