// Задача 56:
// Задайте прямоугольный двумерный массив.
// Напишите программу, которая
// будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке,
// и выдаёт номер строки с наименьшей суммой элементов: –> 1 строка.

int[,] CreateMatrixRandomInt(int rows, int columns, int min, int max)
{
    int[,] mtrx = new int[rows, columns];
    var random = new Random();
    for (int i = 0; i < mtrx.GetLength(0); i++)
    {
        for (int j = 0; j < mtrx.GetLength(1); j++)
        {
            mtrx[i, j] = random.Next(min, max + 1);
        }
    }
    return mtrx;
}

void OutputMatrix(int[,] mtrx)
{
    for (int i = 0; i < mtrx.GetLength(0); i++)
    {
        for (int j = 0; j < mtrx.GetLength(1); j++)
        {
            Console.Write($"{mtrx[i, j],5}");
        }
        Console.WriteLine();
    }
}

int[] SumsElementsRowsMatrix(int[,] mtrx)
{
    int[] arr = new int[mtrx.GetLength(0)];
    for (int i = 0; i < mtrx.GetLength(0); i++)
    {
        for (int j = 0; j < mtrx.GetLength(1); j++)
        {
            arr[i] += mtrx[i, j];
        }
    }
    return arr;
}

int PositionMinElemArray(int[] arr)
{
    int indexMinElem = 0;
    for (int i = 1; i < arr.Length; i++)
    {
        if (arr[i] < arr[indexMinElem]) indexMinElem = i;
    }
    return indexMinElem + 1;
}

Console.WriteLine();
Console.Write("Введите количество строк матрицы (от 1 строки): ");
int m = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов матрицы (от 1 столбца): ");
int n = Convert.ToInt32(Console.ReadLine());
Console.WriteLine();

if (m < 1 || n < 1)
{
    if (m < 1) Console.WriteLine("Количество строк матрицы меньше 1.");
    if (n < 1) Console.WriteLine("Количество столбцов матрицы меньше 1.");
    return;
}

// int[,] matrix = new int[4, 4] { { 1, 4, 7, 2 }, { 5, 9, 2, 3 }, { 8, 4, 2, 4 }, { 5, 2, 6, 7 } }; // –> 1
int[,] matrix = CreateMatrixRandomInt(m, n, 1, 9);
OutputMatrix(matrix);
Console.WriteLine();

int[] array = SumsElementsRowsMatrix(matrix);
Console.Write("Суммы элементов в каждой строке:  ");
Console.WriteLine(string.Join("  ", array));

int result = PositionMinElemArray(array);
Console.WriteLine($"Строка с наименьшей суммой элементов: {result}");
