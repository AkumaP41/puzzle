namespace PuzzleGame
{
    class Player
    {
        private string userName;
        private string passWord;
        private int? attemptCount;
        private int? moveCount;
        private int? time;
        private int? score;

        public Player()
        {
        }

        public Player(string userName, string passWord)
        {
            this.userName = userName;
            this.passWord = passWord;
        }

        public string UserName { get => userName; set => userName = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public string PlayerName { get; set; }
        public int? AttemptCount { get => attemptCount; set => attemptCount = value; }
        public int? MoveCount { get => moveCount; set => moveCount = value; }
        public int? Time { get => time; set => time = value; }
        public int? Score { get => score; set => score = value; }
    }
}
