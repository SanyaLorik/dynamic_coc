namespace _KotletaGames.Additional_M
{
    public static class AsyncExtension
    {
        public static int ToDelayMillisecond(this float number) =>
            (int)(number * 1000);

        public static int ToDelayMillisecond(this int number) =>
            (int)(number * 1000);
    }
}