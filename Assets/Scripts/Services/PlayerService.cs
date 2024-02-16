namespace Services
{
    public static class PlayerService
    {
        public static string PlayerName { get; set; } = "Асан";
        public static int PlayerSex { get; set; }=1;

        private enum Sex
        {
            Male = 1,
            Female =2
        }
    }
}