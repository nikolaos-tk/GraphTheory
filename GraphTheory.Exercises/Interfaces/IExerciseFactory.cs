namespace GraphTheory.Exercises.Interfaces
{
    public interface IExerciseFactory
    {
        IExercise Construct(byte exercise);
    }
}
