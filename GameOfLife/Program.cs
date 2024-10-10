using System;

class GameOfLife {
  static void Main() {

    int rows = 10;
    int cols = 10;
    int[,] board = new int[rows, cols];

    Random cels = new Random();
    for (int i = 0; i < rows; i++){
      for (int j = 0; j < cols; j++){
        board[i, j] = cels.Next(0,2); 
        }
      }

  }

  static void PrintBoard(int[,] board, int rows, int cols){
    {
      for (int i=0; i<rows; i++){
        for (int j=0; j<cols; j++){
          Console.Write(board[i, j]== 1 ? "■" : "□");
        Console.WriteLine();
        }

      }
    }
  }
}
