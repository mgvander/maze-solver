/// Author: Michael VanderMyde
/// Course: CIS-237
/// Assignment 2

using System;
using System.Threading;

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
        /**************************************************************
         * Variables/Backing Fields
         * ***********************************************************/
        // Two dimensional array containing the char values that represent the
        // walls and paths of the maze
        private char[,] _maze;
        // Starting x-axis location 
        private int _xStart;
        // Starting y-axis location
        private int _yStart;
        // Boolean value that becomes true when the bounds of the maze have
        // located
        private bool _exitFound;

        /**************************************************************
         * Constructors
         * ***********************************************************/
        /// <summary>
        /// Used for creating instances of this class by having passed in,
        /// a maze made of '.' paths
        /// </summary>
        /// <param name="passMaze"> A two dimensional array containing a series 
        /// of '.' path characters and '#' wall characters </param>
        /// <param name="xStart"> Integer value of the x coordinate the program
        /// will attempt to solve the maze from </param>
        /// <param name="yStart"> Integer value of the x coordinate the program
        /// will attempt to solve the maze from </param>
        public MazeSolver(char[,] passMaze, int xStart, int yStart)
        {
            // Set the class variables to the passed in values
            this._maze = passMaze;
            this._xStart = xStart;
            this._yStart = yStart;

        }

        /**************************************************************
         * Methods
         * ***********************************************************/
        /// <summary>
        /// This is the public method that will allow someone to use this class to solve the maze.
        /// Feel free to change the return type, or add more parameters if you like, but it can be done
        /// exactly as it is here without adding anything other than code in the body.
        /// </summary>
        public void SolveMaze()
        {
            // Do work needed to use mazeTraversal recursive call and solve the maze.
            
            // Check that the starting location is located on a path coordinate
            if (_maze[_xStart, _yStart] == '.')
            {
                // Prompt the user with how to see the next step in traversing the maze
                Console.WriteLine("Press <Enter> to progress");
                Console.WriteLine();

                // Call the MazeTraversal method and pass in the starting coordinate
                this.MazeTraversal(_xStart, _yStart);

                // Display to the user that the exit has been reached
                Console.WriteLine("Maze Solved!");
                Console.WriteLine("============");
                Console.WriteLine();

            }
            // The starting coordinates were not that of a path character
            else
            {
                // Display the error message for an invalid starting location
                Console.WriteLine($"[{_xStart},{_yStart}] is not a valid starting location.");
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

            // Check if the exit has NOT been found in a previous recursion
            if (!_exitFound)
            {
                // Display the maze in its current state of being solved
                Console.Write(this.DisplayMaze());
                // Creates a visible pause in the execution of the program to allow the
                // user to proceed at their own pace.
                Console.ReadLine();

                // Base Case: An Exit will be '.' and will be at one of the four boundaries of the 2D-array
                if ((_maze[xCoord, yCoord] == '.') &&
                    (xCoord <= 0 || xCoord >= (_maze.GetLength(0) - 1) || yCoord <= 0 || (yCoord >= _maze.GetLength(1) - 1)))
                {
                    // Mark the exit with the char value of progression: 'X'
                    _maze[xCoord, yCoord] = 'X';

                    // Display the maze in its current state of being solved
                    Console.Write(this.DisplayMaze());
                    // Creates a visible pause in the execution of the program to allow the
                    // user to proceed at their own pace.
                    Console.ReadLine();

                    // An exit to the maze has been located
                    _exitFound = true;

                }
                // No exit has been located yet
                else
                {
                    // Mark the current location with in the maze, as having been explored
                    _maze[xCoord, yCoord] = 'X';

                    // Check if the coordinate 1 unit to the right is an unexplored pathway
                    if (_maze[xCoord + 1, yCoord] == '.')
                    {
                        // Call the MazeTraversal method and pass in the coordinate directly
                        // to the right of this call's current location
                        MazeTraversal(xCoord + 1, yCoord);

                    }

                    // Check if the coordinate 1 unit above is an unexplored pathway
                    if (_maze[xCoord, yCoord + 1] == '.')
                    {
                        // Call the MazeTraversal method and pass in the coordinate directly
                        // above this call's current location
                        MazeTraversal(xCoord, yCoord + 1);

                    }

                    // Check if the coordinate 1 unit to the left is an unexplored pathway
                    if (_maze[xCoord - 1, yCoord] == '.')
                    {
                        // Call the MazeTraversal method and pass in the coordinate directly
                        // to the left of this call's current location
                        MazeTraversal(xCoord - 1, yCoord);

                    }

                    // Check if the coordinate 1 unit below is an unexplored pathway
                    if (_maze[xCoord, yCoord - 1] == '.')
                    {
                        // Call the MazeTraversal method and pass in the coordinate directly
                        // below this call's current location
                        MazeTraversal(xCoord, yCoord - 1);

                    }

                    // Check if an exit has NOT been found, even after checking all other directions
                    if (!_exitFound)
                    {
                        // Display the maze in its current state of being solved
                        Console.Write(this.DisplayMaze());
                        // Creates a visible pause in the execution of the program to allow the
                        // user to proceed at their own pace.
                        Console.ReadLine();

                        // The current location has no more explorable pathways in any direction
                        // from the current location
                        _maze[xCoord, yCoord] = '0';

                    }                    

                }

            }

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

            // Code taken from >> https://www.w3schools.com/cs/cs_arrays_multi.php
            // Create a new 2 dimensional array with each dimension having the length of
            // the passed in maze's opposite dimension. As in: maze2 dimension 0 will be
            // the length of maze1 dimension 1.
            char[,] transposeChars = new char[mazeToTranspose.GetLength(1), mazeToTranspose.GetLength(0)];

            // Iterate through the x coordinates from index 0 to the greatest index
            for (int x = 0; x < mazeToTranspose.GetLength(0); ++x)
            {
                // Iterate through the y coordinates from index 0 to the greatest index
                // Do this once for each loop of the x coordinates
                for (int y = 0; y < mazeToTranspose.GetLength(1); ++y)
                {
                    // Take the element in the maze and copy it into the inverse location
                    // in the new maze
                    transposeChars[y, x] = mazeToTranspose[x, y];

                }

            }
            // <<

            // Return the transposed maze
            return transposeChars;

        }

        /// <summary>
        /// Stores the elements from the 2 dimentional maze in a grid space 
        /// with positive increase on the x-axis, right oriented, and positive
        /// increase on the y-axis, up oriented.
        /// </summary>
        /// <returns> string containing the rectangular spaced maze </returns>
        private string DisplayMaze()
        {
            // Initialize the output string
            string outputMazeString = "";

            // Iterate through the y coordinates from the greatest index to the 0
            // index
            for (int y = (_maze.GetLength(1) - 1); y >= 0; --y)
            {
                // Iterate through the x coordinates from 0 to the greatest index
                // Do this once for each loop of the y coordinates
                for (int x = 0; x < _maze.GetLength(0); ++x)
                {
                    // Concatenate the current element into the string
                    outputMazeString += _maze[x, y].ToString();

                }

                // Move to a new line for the next y value and x values
                outputMazeString += Environment.NewLine;

            }

            // Return the formatted maze
            return outputMazeString;

        }

    }

}
