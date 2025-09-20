using System;
using System.Collections.Generic;
using System.Linq;

namespace McpTodoServer.ContainerApp.Models
{
    public static class MonkeyHelper
    {
        private static readonly List<Monkey> _monkeys = new List<Monkey>
        {
            // 예시 데이터. 실제 MCP 서버에서 데이터를 가져오도록 변경 필요
            new Monkey { Id = 1, Name = "George", Species = "Capuchin", Age = 5, Description = "활발한 원숭이" },
            new Monkey { Id = 2, Name = "Bella", Species = "Marmoset", Age = 3, Description = "작고 귀여운 원숭이" },
            new Monkey { Id = 3, Name = "Max", Species = "Howler", Age = 7, Description = "큰 소리로 우는 원숭이" }
        };

        private static int _randomAccessCount = 0;

        public static IEnumerable<Monkey> GetAllMonkeys()
        {
            return _monkeys;
        }

        public static Monkey GetRandomMonkey()
        {
            _randomAccessCount++;
            var rand = new Random();
            return _monkeys[rand.Next(_monkeys.Count)];
        }

        public static Monkey FindMonkeyByName(string name)
        {
            return _monkeys.FirstOrDefault(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public static int GetRandomAccessCount()
        {
            return _randomAccessCount;
        }
    }
}