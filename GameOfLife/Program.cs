using System;

class GameOfLife
{
    static void Main()
    {
       
        int rows = 10;
        int cols = 10;
        
        
        int[,] board = new int[rows, cols];
        
        
        Random cels = new Random();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                board[i, j] = cels.Next(0,2); 
            }
        }

        while (true)
        {
            Console.Clear();
            PrintBoard(board, rows, cols);
            board = NextGeneration(board, rows, cols);
            System.Threading.Thread.Sleep(500); 
        }
    }

    static void PrintBoard(int[,] board, int rows, int cols)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(board[i, j] == 1 ? "■" : "□"); 
            }
            Console.WriteLine();
        }
    }

    static int[,] NextGeneration(int[,] board, int rows, int cols)
    {
        int[,] newBoard = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                int liveNeighbors = CountLiveNeighbors(board, i, j, rows, cols);

                
                if (board[i, j] == 1)
                {
                    newBoard[i, j] = (liveNeighbors < 2 || liveNeighbors > 3) ? 0 : 1;
                }
                else
                {
                    newBoard[i, j] = (liveNeighbors == 3) ? 1 : 0;
                }
            }
        }

        return newBoard;
    }

    static int CountLiveNeighbors(int[,] board, int x, int y, int rows, int cols)
    {
        int liveNeighbors = 0;

        
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0)
                    continue;

                int nx = x + i;
                int ny = y + j;

                if (nx >= 0 && nx < rows && ny >= 0 && ny < cols)
                {
                    liveNeighbors += board[nx, ny];
                }
            }
        }

        return liveNeighbors;
    }
}
