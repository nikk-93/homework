using Command;
using Extended;

namespace Lesson8
{
    public class Task4 : TaskBase
    {
        public override void Execute()
        {
            var w = Utility.ReadIntConsole("Введите ширину");
            var h = Utility.ReadIntConsole("Введите высоту");
            var l = Utility.ReadIntConsole("Введите глубину");
            var cube = Utility.CreateCubeWithUnique(w, h, l, 10);
            Utility.DisplayArr(cube, true);
        }

        public override string GetName()
        {
            return "Сформировать трехмерный массив не повторяющимися двузначными числами показать его построчно на экран выводя индексы соответствующего элемента.";
        }
    }
}