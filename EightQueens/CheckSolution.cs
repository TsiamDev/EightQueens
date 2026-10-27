namespace EightQueens
{
    //Checks whether a placement of Queens on the board contains any conflict
    public static class CheckSolution
    {
        //Returns true if at least one Queen is in conflict with another
        //board: 1 marks a Queen, 0 an empty square
        //queenPos: 2 rows and queenNum columns
        //For each queen:
        //row 0 has posX
        //row 1 has posY
        public static bool HasConflict(int[,] board, int[,] queenPos)
        {
            bool returnFlag = false;

            //Check all queen positions for conflicts
            for (int j = 0; j < queenPos.GetLength(1); j++)
            {
                if (CheckHorizontal(board, queenPos[0, j], queenPos[1, j]) == true)
                {
                    returnFlag = true;
                    break;
                }
                if (CheckVertical(board, queenPos[0, j], queenPos[1, j]) == true)
                {
                    returnFlag = true;
                    break;
                }
                if (CheckDiagonal(board, queenPos[0, j], queenPos[1, j]) == true)
                {
                    returnFlag = true;
                    break;
                }
            }

            return returnFlag;
        }

        //Returns true if there is a horizontal collision
        private static bool CheckHorizontal(int[,] board, int x, int y)
        {
            bool returnFlag = false;

            //For given x position check all columns except the current
            for (int i = 0; i < board.GetLength(1); i++)
            {
                //Exclude the current column
                if( i != y )
                {
                    if (board[x, i] == 1)
                    {
                        returnFlag = true;
                        break;
                    }
                }

            }

            return returnFlag;
        }

        //Returns true if there is a vertical collision
        private static bool CheckVertical(int[,] board, int x, int y)
        {
            bool returnFlag = false;

            //For given x position check all rows except the current
            for (int i = 0; i < board.GetLength(0); i++)
            {
                //Exclude the current column
                if (i != x)
                {
                    if (board[i, y] == 1)
                    {
                        returnFlag = true;
                        break;
                    }
                }

            }

            return returnFlag;
        }

        //Returns true if there is a diagonal collision
        private static bool CheckDiagonal(int[,] board, int x, int y)
        {
            //if there is at least one collision return true
            //NOTE: I could have checked it in a single statement
            //but I think this way the execution time is less in terms of O()
            //because there is the possibility that not all functions will get called
            //if a conflict is found earlier in every iteration
            if(CheckUpperLeftDiagonal(board, x, y) == true)
            {
                return true;
            }
            if (CheckLowerRightDiagonal(board, x, y) == true)
            {
                return true;
            }
            if(CheckLowerLeftDiagonal(board, x, y) == true)
            {
                return true;
            }
            if(CheckUpperRightDiagonal(board, x, y) == true)
            {
                return true;
            }

            //If you got to this point then there are no conflicts so return false
            return false;

        }

        private static bool CheckUpperLeftDiagonal(int[,] board, int x, int y)
        {
            bool returnFlag = false;

            for (int i = 1; i < board.GetLength(0); i++)
            {
                if( ((x-i) < 0) || ((y -i) < 0) )
                {
                    //Out of bounds
                    break;
                }
                if(board[x - i, y - i] == 1)
                {
                    returnFlag = true;
                    break;
                }
            }

            return returnFlag;
        }

        private static bool CheckLowerRightDiagonal(int[,] board, int x, int y)
        {
            bool returnFlag = false;

            for (int i = 1; i < board.GetLength(0); i++)
            {
                if (((x + i) >= board.GetLength(0)) || ((y + i) >= board.GetLength(1)))
                {
                    //Out of bounds
                    break;
                }
                if (board[x + i, y + i] == 1)
                {
                    returnFlag = true;
                    break;
                }
            }

            return returnFlag;
        }

        private static bool CheckLowerLeftDiagonal(int[,] board, int x, int y)
        {
            bool returnFlag = false;

            for (int i = 1; i < board.GetLength(0); i++)
            {
                if (((x + i) >= board.GetLength(0)) || ((y - i) < 0))
                {
                    //Out of bounds
                    break;
                }
                if (board[x + i, y - i] == 1)
                {
                    returnFlag = true;
                    break;
                }
            }

            return returnFlag;
        }

        private static bool CheckUpperRightDiagonal(int[,] board, int x, int y)
        {
            bool returnFlag = false;

            for (int i = 1; i < board.GetLength(0); i++)
            {
                if ( ((x - i) < 0) || ((y + i) >= board.GetLength(1)) )
                {
                    //Out of bounds
                    break;
                }
                if (board[x - i, y + i] == 1)
                {
                    returnFlag = true;
                    break;
                }
            }

            return returnFlag;
        }
    }
}
