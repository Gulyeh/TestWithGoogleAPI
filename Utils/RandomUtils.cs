namespace Task4_0.Utils
{
    public static class RandomUtils
    {
        public static T GetRandomObject<T>(IList<T> value)
        {
            Random random = new Random();
            var index = random.Next(value.Count() - 1);
            if (index < 0) index = 0;
            return value[index];
        }
    }
}