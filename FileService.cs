using System;
using System.IO; // ОБОВ'ЯЗКОВО для роботи з файлами
using System.Windows.Forms; // ОБОВ'ЯЗКОВО для MessageBox

namespace Coursework_2
{
    internal class FileService
    {
        public static void SaveResultsToFile(Graph graph, ShortestPathResult result)
        {
            if (graph == null)
            {
                MessageBox.Show("Граф не створено. Немає чого зберігати.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int n = graph.NumVertices;

            try
            {
                // Створюємо або перезаписуємо файл
                using (StreamWriter writer = new StreamWriter(Const.FILENAME))
                {
                    writer.WriteLine("                ЗВІТ ПРО РОБОТУ ПРОГРАМИ");
                    writer.WriteLine($"Кількість вершин: {n}");
                    writer.WriteLine(" ");

                    writer.WriteLine("1. ВХІДНА МАТРИЦЯ СУМІЖНОСТІ:");
                    WriteMatrix(writer, graph.GetMatrix(), n);
                    writer.WriteLine();

                    writer.WriteLine("2. РЕЗУЛЬТУЮЧА МАТРИЦЯ НАЙКОРОТШИХ ШЛЯХІВ:");
                    if (result == null)
                    {
                        writer.WriteLine("Немає даних: Розрахунок ще не проводився.");
                    }
                    else if (result.HasNegativeCycle)
                    {
                        writer.WriteLine("Немає даних: Знайдено контур від'ємної ваги.");
                    }
                    else
                    {
                        WriteMatrix(writer, result.Dist, n);
                        writer.WriteLine();

                        writer.WriteLine("3. ПРАКТИЧНА СКЛАДНІСТЬ:");
                        writer.WriteLine($"Кількість операцій алгоритму: {result.Operations}");
                    }
                }
                MessageBox.Show($"Звіт успішно збережено у файл:\n{Const.FILENAME}", "Збереження", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при збереженні файлу: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void WriteMatrix(StreamWriter writer, int[,] matrix, int n)
        {
            writer.Write("    ");
            for (int j = 0; j < n; j++)
            {
                writer.Write($"{(j + 1),5}");
            }
            writer.WriteLine();

            for (int i = 0; i < n; i++)
            {
                writer.Write($"{(i + 1),3} ");
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] >= Const.INF) // Використовуємо >= INF для надійності
                        writer.Write($"{"-",5}");
                    else
                        writer.Write($"{matrix[i, j],5}");
                }
                writer.WriteLine();
            }
        }
    }
}