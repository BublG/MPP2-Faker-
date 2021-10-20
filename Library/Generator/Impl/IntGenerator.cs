namespace Library.Generator.Impl
{
    public class IntGenerator : IGenerator
    {
        private static IGenerator _generator;

        private IntGenerator()
        {
        }
        
        public static IGenerator GetInstance()
        {
            if (_generator == null)
            {
                _generator = new IntGenerator();
            }

            return _generator;
        }

        public object GetValue()
        {
            return 12;
        }
    }
}