// Задача 60:
// Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
// Напишите программу, которая
// будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером: 2 x 2 x 2
// Результат:
// 66(0,0,0) 25(0,1,0)      27(0,0,1) 90(0,1,1)
// 34(1,0,0) 41(1,1,0)      26(1,0,1) 55(1,1,1)

int[,,] Create3DMatrixUniqueIntNum(int rows, int columns, int depths, int min, int max)
{
    int[,,] mtrx3D = new int[rows, columns, depths];
    int valueElem = min;
    for (int i = 0; i < mtrx3D.GetLength(0); i++)
    {
        for (int j = 0; j < mtrx3D.GetLength(1); j++)
        {
            for (int d = 0; d < mtrx3D.GetLength(2); d++)
            {
                if (valueElem <= max)
                {
                    mtrx3D[i, j, d] = valueElem;
                    valueElem++;
                }
            }
        }
    }
    return mtrx3D; // Если уникальных значений не хватит, в оставшихся элементах будет значение 0.
}

void Output3DMatrixDepthLayers(int[,,] mtrx3D) // В условии задачи такой вывод.
{
    for (int i = 0; i < mtrx3D.GetLength(0); i++)
    {
        for (int d = 0; d < mtrx3D.GetLength(2); d++)
        {
            Console.Write("|");
            for (int j = 0; j < mtrx3D.GetLength(1); j++)
            {
                Console.Write($"{mtrx3D[i, j, d],4}({i},{j},{d})");
            }
            Console.Write("  |    ");
        }
        Console.WriteLine();
    }
}

void Output3DMatrixDepth1DArrays(int[,,] mtrx3D) // Ещё вариант вывода.
{
    for (int i = 0; i < mtrx3D.GetLength(0); i++)
    {
        for (int j = 0; j < mtrx3D.GetLength(1); j++)
        {
            Console.Write("[");
            for (int d = 0; d < mtrx3D.GetLength(2); d++)
            {
                Console.Write($"{mtrx3D[i, j, d],4}({i},{j},{d})");
            }
            Console.Write("  ]    ");
        }
        Console.WriteLine();
        Console.WriteLine();
    }
}

Console.WriteLine();
Console.Write("Введите количество строк 3D матрицы (от 1 до 10 строк): ");
int m = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов 3D матрицы (от 1 до 10 столбцов): ");
int n = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество слоёв 3D матрицы (от 1 до 10 слоёв): ");
int k = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите минимальное значение элементов 3D матрицы (от 10 до 99): ");
int minValue = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите максимальное значение элементов 3D матрицы (от 10 до 99): ");
int maxValue = Convert.ToInt32(Console.ReadLine());
Console.WriteLine();

if (m < 1 || m > 10 || n < 1 || n > 10 || k < 1 || k > 10
    || minValue < 10 || minValue > 99 || maxValue < 10 || maxValue > 99 || minValue > maxValue)
{
    if (m < 1 || m > 10) Console.WriteLine("Количество строк 3D матрицы вне диапазона: [1, 10].");
    if (n < 1 || n > 10) Console.WriteLine("Количество столбцов 3D матрицы вне диапазона: [1, 10].");
    if (k < 1 || k > 10) Console.WriteLine("Количество слоёв 3D матрицы вне диапазона: [1, 10].");
    if (minValue < 10 || minValue > 99) Console.WriteLine("Минимальное значение элементов 3D матрицы вне диапазона: [10, 99].");
    if (maxValue < 10 || maxValue > 99) Console.WriteLine("Максимальное значение элементов 3D матрицы вне диапазона: [10, 99].");
    if (minValue > maxValue) Console.WriteLine("Минимальное значение элементов 3D матрицы больше максимального.");
    return;
}

if (m * n * k > maxValue - minValue + 1)
{
    Console.WriteLine($"Для вывода 3D матрицы {m} x {n} x {k} из {m * n * k} элементов не хватит {maxValue - minValue + 1} уникальных значений.");
    return;
}

// int[,,] matrix3D = new int[2, 2, 2] { { { 66, 27 }, { 25, 90 } }, { { 34, 26 }, { 41, 55 } } }; // 66(0,0,0) 25(0,1,0)      27(0,0,1) 90(0,1,1)
//                                                                                                 // 34(1,0,0) 41(1,1,0)      26(1,0,1) 55(1,1,1)
int[,,] matrix3D = Create3DMatrixUniqueIntNum(m, n, k, minValue, maxValue); // [10,99] => 90 => 10 x 3 x 3 || 6 x 5 x 3 || 9 x 5 x 2

Output3DMatrixDepth1DArrays(matrix3D);
Console.WriteLine();
Output3DMatrixDepthLayers(matrix3D);
