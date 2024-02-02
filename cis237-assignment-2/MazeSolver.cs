using System;

namespace cis237_assignment_2
{
    /// <summary>
    /// This class is used for solving a char array maze.
    /// You might want to add other methods to help you out.
    /// A print maze method would be very useful, and probably neccessary to print the solution.
    /// If you are real ambitious, you could make a seperate class to handle that.
    /// </summary>
    class MazeSolver
    {
        // Array values of the maze
        private char[,] _maze;
        private int _xStart;
        private int _yStart;
        
        public MazeSolver(char[,] passMaze, int xStart, int yStart)
        {
            this._maze = passMaze;
            this._xStart = xStart;
            this._yStart = yStart;
        }

        /// <summary>
        /// This is the public method that will allow someone to use this class to solve the maze.
        /// Feel free to change the return type, or add more parameters if you like, but it can be done
        /// exactly as it is here without adding anything other than code in the body.
        /// </summary>
        public void SolveMaze()
        {
            // Do work needed to use mazeTraversal recursive call and solve the maze.
            if (!(_maze[_xStart, _yStart] == '#'))
            {
                //
                this.MazeTraversal(_xStart, _yStart);

            }
            else
            {
                //
                Console.WriteLine("[{0},{1}] is not a valid starting location." , _xStart, _yStart);
                Console.WriteLine("Please adjust the starting coordinates.");

            }

        }

        /// <summary>
        /// This should be the recursive method that gets called to solve the maze.
        /// Feel free to change the return type if you like, or pass in parameters that you might need.
        /// This is only a very small starting point.
        /// More than likely you will need to pass in at a minimum the current position
        /// in X and Y maze coordinates. EX: mazeTraversal(int currentX, int currentY)
        /// </summary>
        private void MazeTraversal(int xCoord, int yCoord)
        {
            // Implement maze traversal recursive call

            //
            if (xCoord <= 0 || xCoord >= (_maze.GetLength(0) - 1) || yCoord <= 0 || (yCoord >= _maze.GetLength(1)))
            {
                //
                _maze[xCoord, yCoord] = 'X';

            }
            //
            else
            {

            }

            // Right
            MazeTraversal(xCoord + 1, yCoord);
            
            // Up
            MazeTraversal(xCoord, yCoord + 1);

            // Left
            MazeTraversal(xCoord - 1, yCoord);

            // Down
            MazeTraversal(xCoord, yCoord - 1);            

        }

        /// <summary>
        /// This method will take in a 2 dimensional char array and return
        /// a char array maze that is flipped along the diagonal, or in mathematical
        /// terms, transposed.
        /// ie. if the array looks like 1, 2, 3
        ///                             4, 5, 6
        ///                             7, 8, 9
        /// The returned result will be:
        ///                             1, 4, 7
        ///                             2, 5, 8
        ///                             3, 6, 9
        /// The current return statement is just a placeholder so the program
        /// doesn't complain about no return value.
        /// 
        /// It is important that you return a "new" char array as the transposed maze.
        /// If you do not, you could end up only solving the transposed maze.
        /// </summary>
        /// <param name="mazeToTranspose"></param>
        /// <returns>transposedMaze</returns>
        public char[,] TransposeMaze(char[,] mazeToTranspose)
        {
            //Write code her to create a transposed maze.

            // https://www.w3schools.com/cs/cs_arrays_multi.php
            char[,] transposeChars = new char[mazeToTranspose.GetLength(1), mazeToTranspose.GetLength(0)];

            //
            for (int x = 0; x < mazeToTranspose.GetLength(0); ++x)
            {
                //
                for (int y = 0; y < mazeToTranspose.GetLength(1); ++y)
                {
                    //
                    transposeChars[y, x] = mazeToTranspose[x, y];

                }
            }

            //
            return transposeChars;

        }

    }

}
