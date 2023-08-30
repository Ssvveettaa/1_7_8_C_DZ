// Задача 58:
// Задайте две матрицы.
// Напишите программу, которая
// будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

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

bool CheckMultipliabilityMatrices(int[,] firstMtrx, int[,] secondMtrx)
{
    return firstMtrx.GetLength(1) == secondMtrx.GetLength(0);
}

int[,] MultiplicationMatrices(int[,] firstMtrx, int[,] secondMtrx)
{
    int[,] resultMtrx = new int[firstMtrx.GetLength(0), secondMtrx.GetLength(1)];
    for (int i = 0; i < resultMtrx.GetLength(0); i++)
    {
        for (int j = 0; j < resultMtrx.GetLength(1); j++)
        {
            for (int k = 0; k < firstMtrx.GetLength(1); k++)
            {
                resultMtrx[i, j] += firstMtrx[i, k] * secondMtrx[k, j];
            }
        }
    }
    return resultMtrx;
}

Console.WriteLine();
Console.Write("Введите количество строк матрицы A (от 1 строки): ");
int mA = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов матрицы A (от 1 столбца): ");
int nA = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество строк матрицы B (от 1 строки): ");
int mB = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов матрицы B (от 1 столбца): ");
int nB = Convert.ToInt32(Console.ReadLine());
Console.WriteLine();

if (mA < 1 || nA < 1 || mB < 1 || nB < 1)
{
    if (mA < 1) Console.WriteLine("Количество строк матрицы A меньше 1.");
    if (nA < 1) Console.WriteLine("Количество столбцов матрицы A меньше 1.");
    if (mB < 1) Console.WriteLine("Количество строк матрицы B меньше 1.");
    if (nB < 1) Console.WriteLine("Количество столбцов матрицы B меньше 1.");
    return;
}

// int[,] firstMatrix = new int[2, 2] { { 2, 4 }, { 3, 2 } };  // 18 20
// int[,] secondMatrix = new int[2, 2] { { 3, 4 }, { 3, 3 } }; // 15 18
int[,] firstMatrix = CreateMatrixRandomInt(mA, nA, 1, 9);  // 4, 3: firstMtrx.GetLength(1) ==
int[,] secondMatrix = CreateMatrixRandomInt(mB, nB, 1, 9); // 3, 4: == secondMtrx.GetLength(0)

Console.WriteLine("Матрица A:");
Console.WriteLine();
OutputMatrix(firstMatrix);
Console.WriteLine();
Console.WriteLine("Матрица B:");
Console.WriteLine();
OutputMatrix(secondMatrix);
Console.WriteLine();

if (CheckMultipliabilityMatrices(firstMatrix, secondMatrix))
{
    int[,] resultMatrix = MultiplicationMatrices(firstMatrix, secondMatrix);
    Console.WriteLine("Матрица C = A x B:");
    Console.WriteLine();
    OutputMatrix(resultMatrix);
}
else Console.WriteLine("Данные матрицы не перемножить, т.к. кол-во столбцов первой матрицы (A) не равно кол-ву строк второй матрицы (B).");
