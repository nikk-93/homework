using System.Reflection;
using Command;

namespace Extended
{
    public class TaskManager
    {
        public void Start()
        {
            var tasks = Utility.GetTasks(Assembly.GetEntryAssembly()!);
            var invoker = new Invoker();

            while (true)
            {
                Console.Clear();

                WriteTittle(tasks);

                string str = Console.ReadLine() ?? "0";
                if (!(int.TryParse(str, out int select) && tasks.ContainsKey(select)))
                {
                    Console.WriteLine("Выход...");
                    Console.ReadKey();
                    return;
                }

                Console.Clear();
                Console.WriteLine($"{select}. {tasks[select].GetName()}");

                invoker.SetCommand(tasks[select]);
                invoker.Start();

                Console.WriteLine("Для продолжения нажмите любую клавишу...");
                Console.ReadKey();
            }
        }

        void WriteTittle(Dictionary<int, TaskBase> tasks)
        {
            foreach (var item in tasks)
            {
                Console.WriteLine($"{item.Key}. {item.Value.GetName()}");
            }
            Console.WriteLine($"Для выхода нажмите любую другую клавишу...");
            Console.WriteLine();
            Console.Write("Выберите задание: ");
        }
    }
}