// Задача 62:
// Напишите программу, которая
// заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

int[] matrixSizes = new int[2];
InputMatrixSizes(matrixSizes);

int[,] matrix = new int[matrixSizes[0], matrixSizes[1]];
FillMatrixSpirally(matrix.GetLength(0), matrix.GetLength(1));

Console.WriteLine($"Матрица заполненная по спирали значениями от 1 до {matrixSizes[0] * matrixSizes[1]}:");
Console.WriteLine();
OutputMatrix(matrix);

void InputMatrixSizes(int[] matrixSizes)
{
    Console.WriteLine();
    Console.Write("Введите количество строк матрицы (от 1 строки): ");
    matrixSizes[0] = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите количество столбцов матрицы (от 1 столбца): ");
    matrixSizes[1] = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    if (matrixSizes[0] < 1 || matrixSizes[1] < 1)
    {
        if (matrixSizes[0] < 1) Console.WriteLine("Количество строк матрицы меньше 1.");
        if (matrixSizes[1] < 1) Console.WriteLine("Количество столбцов матрицы меньше 1.");
        InputMatrixSizes(matrixSizes);
    } 
}

void FillMatrixSpirally(int downBorder, int rightBorder, int upBorder = 0, int leftBorder = 0, int path = 1, int valueElem = 1)
{
    if (valueElem <= matrix.GetLength(0) * matrix.GetLength(1))
    {
        if (path == 1)
        {
            for (int j = leftBorder; j < rightBorder; j++) matrix[upBorder, j] = valueElem++; // постфиксная запись – берёт значение до увеличения.
            FillMatrixSpirally(downBorder, rightBorder, upBorder + 1, leftBorder, 2, valueElem);
        }
        else if (path == 2)
        {
            for (int i = upBorder; i < downBorder; i++) matrix[i, rightBorder - 1] = valueElem++;
            FillMatrixSpirally(downBorder, rightBorder - 1, upBorder, leftBorder, 3, valueElem);
        }
        else if (path == 3)
        {
            for (int j = rightBorder - 1; j >= leftBorder; j--) matrix[downBorder - 1, j] = valueElem++;
            FillMatrixSpirally(downBorder - 1, rightBorder, upBorder, leftBorder, 4, valueElem);
        }
        else if (path == 4)
        {
            for (int i = downBorder - 1; i >= upBorder; i--) matrix[i, leftBorder] = valueElem++;
            FillMatrixSpirally(downBorder, rightBorder, upBorder, leftBorder + 1, 1, valueElem);
        }
    }
}

void OutputMatrix(int[,] mtrx)
{
    for (int i = 0; i < mtrx.GetLength(0); i++)
    {
        for (int j = 0; j < mtrx.GetLength(1); j++)
        {
            Console.Write($"{mtrx[i, j],6}");
        }
        Console.WriteLine();
    }
}
