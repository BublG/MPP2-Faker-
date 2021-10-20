namespace Library.Generator.Impl
{
    public class StringGenerator : IGenerator
    {
        private static IGenerator _generator;

        private StringGenerator()
        {
        }
        
        public static IGenerator GetInstance()
        {
            if (_generator == null)
            {
                _generator = new StringGenerator();
            }

            return _generator;
        }
        
        public object GetValue()
        {
            return "abc";
        }
    }
}