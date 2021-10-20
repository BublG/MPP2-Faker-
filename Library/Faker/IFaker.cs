namespace Library.Faker
{
    public interface IFaker
    {
        T Create<T>();
    }
}