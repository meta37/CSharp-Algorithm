namespace _24._01._18_실습
{
    internal class Program
    {
        public class CheatKey
        {
            // 치트키 문자열을 통해서 바로 함수를 탐색하여 발동시키는 치트키 머신 구현

            private Dictionary<string, Action> cheatDic;

            public CheatKey()
            {
                cheatDic = new Dictionary<string, Action>();
            }
            public void CheatDic(string cheatKey, Action action)
            {
                cheatDic.Add(cheatKey, action);
            }

            public void Run(string cheatKey)
            {
                // if, for 없이 바로 탐색하여 치트키 발동
                Action action;
                action = cheatDic[cheatKey];
                cheatDic.TryGetValue(cheatKey, out action);
                action?.Invoke();
            }

            public void ShowMeTheMoney()
            {
                Console.WriteLine("골드를 늘려주는 치트키 발동");
            }

            public void ThereIsNoCowLevel()
            {
                Console.WriteLine("바로 승리합니다 치트키 발동!");
            }

            public static void Main(string[] args)
            {
                CheatKey Cheat = new CheatKey();
                Cheat.CheatDic("showmethemoney", Cheat.ShowMeTheMoney);
                Cheat.CheatDic("thereisnocowlevel", Cheat.ThereIsNoCowLevel);

                string input = Console.ReadLine();
                Cheat.Run(input);
            }

        }
    }
}
