namespace Library.Generator.Impl
{
    public class DoubleGenerator : IGenerator
    {
        private static IGenerator _generator;

        private DoubleGenerator()
        {
        }

        public static IGenerator GetInstance()
        {
            if (_generator == null)
            {
                _generator = new DoubleGenerator();
            }

            return _generator;
        }

        public object GetValue()
        {
            return 0.5;
        }
    }
}