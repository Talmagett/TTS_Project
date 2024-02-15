namespace Services
{
    public static class PlayerService
    {
        public static string PlayerName { get; set; }
        public static int PlayerSex { get; set; }

        private enum Sex
        {
            Male = 1,
            Female =2
        }
    }
}