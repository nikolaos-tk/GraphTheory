using GraphTheory.Exercises.Interfaces;
using System;

namespace GraphTheory.Exercises
{
    public sealed class ExerciseFactory : IExerciseFactory
    {
        public IExercise Construct(byte exercise)
        {
            switch (exercise)
            {
                case 1:
                    return new Exercise1();

                case 2:
                    return new Exercise2();

                case 3:
                    return new Exercise3();

                case 4:
                    return new Exercise4();

                default:
                    throw new Exception();
            }
        }
    }
}
