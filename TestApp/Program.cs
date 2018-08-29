using System;

namespace GameManager
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\SEXTON\Downloads\NecromantiaRisen.rgf";
            GameFileHandler.Instance = new GameFileHandler(path);
            Scenario s0 = GameFileHandler.Instance.GetScenario("0");
            Scenario s01 = GameFileHandler.Instance.GetScenario("01");
            Console.Read();
        }
    }
}
