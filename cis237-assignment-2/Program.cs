/// Author: Michael VanderMyde
/// Course: CIS-237
/// Assignment 2

using System;

namespace cis237_assignment_2
{
    class Program
    {
        /// <summary>
        /// This is the main entry point for the program.
        /// You are free to add anything else you would like to this program,
        /// however the maze solving part needs to occur in the MazeSolver class.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Starting Coordinates.
            const int X_START = 1;
            const int Y_START = 1;

            // The first maze that needs to be solved.
            // Note: You may want to make a smaller version to test and debug with.
            // You don't have to, but it might make your life easier.
            char[,] maze1 =
            { { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            { '#', '.', '.', '.', '#', '.', '.', '.', '.', '.', '.', '#' },
            { '#', '.', '#', '.', '#', '.', '#', '#', '#', '#', '.', '#' },
            { '#', '#', '#', '.', '#', '.', '.', '.', '.', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '#', '#', '#', '.', '#', '.', '.' },
            { '#', '#', '#', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '.', '.', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '#', '.', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '.', '.', '.', '.', '#', '.', '#' },
            { '#', '#', '#', '#', '#', '#', '.', '#', '#', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '.', '.', '#', '.', '.', '.', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' } };

            // - y y y +
            // x . . .
            // x . . .
            // x . . .
            // +
            // 
            // maze1[x,y]
            //
            //char[,] maze1 =
            //    { { '#', '#', '#' },
            //    { '#', '.', '.' },
            //    { '#', '.', '#' },
            //    { '#', '#', '#' } };            

            // Create a new instance of a mazeSolver.
            MazeSolver mazeSolver1 = new MazeSolver(maze1, X_START, Y_START);

            // Create the second maze by transposing the first maze
            char[,] maze2 = mazeSolver1.TransposeMaze(maze1);

            // Solve the original maze.
            mazeSolver1.SolveMaze();            

            // Create a new instance of a mazeSolver.
            MazeSolver mazeSolver2 = new MazeSolver(maze2, X_START, Y_START);

            // Solve the transposed maze.
            mazeSolver2.SolveMaze();
            
        }

        //

        ///// <summary>
        ///// This method will take in a 2 dimensional char array and return
        ///// a char array maze that is flipped along the diagonal, or in mathematical
        ///// terms, transposed.
        ///// ie. if the array looks like 1, 2, 3
        /////                             4, 5, 6
        /////                             7, 8, 9
        ///// The returned result will be:
        /////                             1, 4, 7
        /////                             2, 5, 8
        /////                             3, 6, 9
        ///// The current return statement is just a placeholder so the program
        ///// doesn't complain about no return value.
        ///// 
        ///// It is important that you return a "new" char array as the transposed maze.
        ///// If you do not, you could end up only solving the transposed maze.
        ///// </summary>
        ///// <param name="mazeToTranspose"></param>
        ///// <returns>transposedMaze</returns>
        //static char[,] transposeMaze(char[,] mazeToTranspose)
        //{
        //    //Write code her to create a transposed maze.

        //    // https://www.w3schools.com/cs/cs_arrays_multi.php
        //    char[,] transposeChars = new char[mazeToTranspose.GetLength(1), mazeToTranspose.GetLength(0)];

        //    //
        //    for (int x = 0; x < mazeToTranspose.GetLength(0); ++x)
        //    {
        //        //
        //        for (int y = 0; y < mazeToTranspose.GetLength(1); ++y)
        //        {
        //            //
        //            transposeChars[y, x] = mazeToTranspose[x, y];

        //        }
        //    }

        //    //
        //    return transposeChars;

        //}
    }
}
