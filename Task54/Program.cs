// Задача 54:
// Задайте двумерный массив.
// Напишите программу, которая
// упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:      В итоге получается вот такой массив:
// 1 4 7 2                      7 4 2 1
// 5 9 2 3                      9 5 3 2
// 8 4 2 4                      8 4 4 2

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
            Console.Write($"{mtrx[i, j], 5}");
        }
        Console.WriteLine();
    }
}

void SortDescendingElementsRowsMatrix(int[,] mtrx)
{
    for (int i = 0; i < mtrx.GetLength(0); i++)
    {
        for (int j = 0; j < mtrx.GetLength(1) - 1; j++)
        {
            int indexMax = j;
            for (int k = j + 1; k < mtrx.GetLength(1); k++)
            {
                if (mtrx[i, k] > mtrx[i, indexMax]) indexMax = k;
            }
            if (indexMax != j) // jMax > j
                (mtrx[i, j], mtrx[i, indexMax]) = (mtrx[i, indexMax], mtrx[i, j]);
        }
    }
}

Console.WriteLine();
Console.Write("Введите количество строк матрицы: ");
int m = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов матрицы: ");
int n = Convert.ToInt32(Console.ReadLine());
Console.WriteLine();

if (m < 0 || n < 0) // Не очень уверена по поводу такой конструкции проверки входных данных...
{                   // Плюс: читаемость (особенно задача 60). Минус: двойная проверка.
    if (m < 0) Console.WriteLine("Количество строк матрицы не может быть меньше 0.");
    if (n < 0) Console.WriteLine("Количество столбцов матрицы не может быть меньше 0.");
    return;
}

// int[,] matrix = new int[3, 4] { { 1, 4, 7, 2 }, { 5, 9, 2, 3 }, { 8, 4, 2, 4 } };   // –> 7 4 2 1
//                                                                                     // –> 9 5 3 2
//                                                                                     // –> 8 4 4 2
int[,] matrix = CreateMatrixRandomInt(m, n, 1, 9);
Console.WriteLine("Исходная матрица:");
Console.WriteLine();
OutputMatrix(matrix);
Console.WriteLine();

SortDescendingElementsRowsMatrix(matrix);
Console.WriteLine("Матрица, где элементы в каждой строке отсортированы по убыванию:");
Console.WriteLine();
OutputMatrix(matrix);
