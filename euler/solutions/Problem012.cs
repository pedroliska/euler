namespace euler.solutions
{
    public class Problem012
    {
        public static void Run()
        {
            var generator = new TriangularNumberGenerator();

            while (true)
            {
                var number = generator.Next();
            }
        }

        private class TriangularNumberGenerator
        {
            private int last = 0;

            public int Next()
            {
                return last + ++last;
            }
        }
    }
}