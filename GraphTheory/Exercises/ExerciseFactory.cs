using System;

namespace GraphTheory1.Exercises
{
    public class ExerciseFactory
    {
        public IExercise Construct(byte exercise)
        {
            switch (exercise)
            {
                case 1:
                    return new Exercise1();
                case 2:
                    return new Exercise2();
                default:
                    throw new Exception();
            }
        }
    }
}
