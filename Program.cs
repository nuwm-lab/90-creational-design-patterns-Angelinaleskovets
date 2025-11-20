using System;

namespace AccountingSystem
{
    // -------------------------------------------------------
    // Інтерфейс принтера (для тестування і розширення)
    // -------------------------------------------------------
    public interface IReportPrinter
    {
        void Print(string reportText);
    }

    // -------------------------------------------------------
    // Реалізація Singleton — Віртуальний бухгалтерський принтер
    // -------------------------------------------------------
    public sealed class VirtualPrinter : IReportPrinter
    {
        // Лінива потокобезпечна ініціалізація
        private static readonly Lazy<VirtualPrinter> _instance =
            new Lazy<VirtualPrinter>(() => new VirtualPrinter());

        // Публічний доступ
        public static VirtualPrinter Instance => _instance.Value;

        // Приватний конструктор — ніхто не створить екземпляр зовні
        private VirtualPrinter()
        {
            Console.WriteLine(">>> Віртуальний принтер ініціалізовано.");
        }

        // Метод друку
        public void Print(string reportText)
        {
            Console.WriteLine("----- ДРУК ЗВІТУ -----");
            Console.WriteLine(reportText);
            Console.WriteLine("----------------------");
        }
    }

    // -------------------------------------------------------
    // Клієнтська частина системи
    // -------------------------------------------------------
    public static class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Введіть текст бухгалтерського звіту:");

            string? text = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(text))
            {
                Console.WriteLine("❗ Звіт порожній — друк скасовано.");
                return;
            }

            // Отримання єдиного екземпляра принтера
            IReportPrinter printer = VirtualPrinter.Instance;

            // Вивід звіту
            printer.Print(text);

            // Демонстрація, що екземпляр один
            Console.WriteLine("\nПеревірка Singleton:");
            Console.WriteLine(Object.ReferenceEquals(printer, VirtualPrinter.Instance)
                ? "Так, це один і той самий екземпляр."
                : "Помилка: створено кілька екземплярів!");

            Console.WriteLine("\nРобота завершена.");
        }
    }
}
