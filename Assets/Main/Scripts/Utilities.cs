namespace Main.Scripts
{
    public static class Utilities
    {
        public static int GetNextIndex(int currentIndex, int length)
        {
            ++currentIndex;
            if (currentIndex >= length)
            {
                currentIndex = 0;
            }
            
            return currentIndex;
        }
    }
}