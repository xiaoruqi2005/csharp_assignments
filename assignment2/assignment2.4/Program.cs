namespace assignment2._4
{
    internal class Program
    {
        static bool IsToeplitzMatrix(int[][]matrix)
        {
            int x = matrix.Length;
            int y = matrix[0].Length;
            for(int i = 0; i < x-1; i++)
            {
                for(int j = 0; j < y-1; j++)
                {
                    if (matrix[i][j] != matrix[i+1][j+1])
                        return false;
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            int[][] matrix = new int[][] 
            {
                new int[] {1, 2, 3, 4},
                new int[] {5, 1, 2, 3},
                new int[] {9, 5, 1, 2}
            };
            Console.WriteLine(IsToeplitzMatrix(matrix));
        }
    }
}
