namespace EightQueens
{
    //Checks whether a placement of Queens on the board contains any conflict
    public class CheckSolution
    {
        private int[,] board;
        //2 rows and queenNum columns
        //For each queen:
        //row 0 has posX
        //row 1 has posY
        private int[,] queenPos;

        //Returns true if at least one Queen is in conflict with another
        public bool HasConflict(int[,] board, int[,] queenPos)
        {
            this.board = board;
            this.queenPos = queenPos;

            bool returnFlag = false;

            //Check all queen positions for conflicts
            for (int j = 0; j < this.queenPos.GetLength(1); j++)
            {
                if (CheckHorizontal(queenPos[0, j], queenPos[1, j]) == true)
                {
                    returnFlag = true;
                    break;
                }
                if (CheckVertical(queenPos[0, j], queenPos[1, j]) == true)
                {
                    returnFlag = true;
                    break;
                }
                if (CheckDiagonal(queenPos[0, j], queenPos[1, j]) == true)
                {
                    returnFlag = true;
                    break;
                }
            }

            return returnFlag;
        }

        //Returns true if there is a horizontal collision
        private bool CheckHorizontal(int x, int y)
        {
            bool returnFlag = false;

            //For given x position check all columns except the current
            for (int i = 0; i < this.board.GetLength(1); i++)
            {
                //Exclude the current column
                if( i != y )
                {
                    if (this.board[x, i] == 1)
                    {
                        returnFlag = true;
                        break;
                    }
                }

            }

            return returnFlag;
        }

        //Returns true if there is a vertical collision
        private bool CheckVertical(int x, int y)
        {
            bool returnFlag = false;

            //For given x position check all rows except the current
            for (int i = 0; i < this.board.GetLength(0); i++)
            {
                //Exclude the current column
                if (i != x)
                {
                    if (this.board[i, y] == 1)
                    {
                        returnFlag = true;
                        break;
                    }
                }

            }

            return returnFlag;
        }

        //Returns true if there is a diagonal collision
        private bool CheckDiagonal(int x, int y)
        {
            //if there is at least one collision return true
            //NOTE: I could have checked it in a single statement
            //but I think this way the execution time is less in terms of O()
            //because there is the possibility that not all functions will get called
            //if a conflict is found earlier in every iteration
            if(CheckUpperLeftDiagonal(x, y) == true)
            {
                return true;
            }
            if (CheckLowerRightDiagonal(x, y) == true)
            {
                return true;
            }
            if(CheckLowerLeftDiagonal(x, y) == true)
            {
                return true;
            }
            if(CheckUpperRightDiagonal(x, y) == true)
            {
                return true;
            }

            //If you got to this point then there are no conflicts so return false
            return false;

        }

        private bool CheckUpperLeftDiagonal(int x, int y)
        {
            bool returnFlag = false;

            for (int i = 1; i < this.board.GetLength(0); i++)
            {
                if( ((x-i) < 0) || ((y -i) < 0) )
                {
                    //Out of bounds
                    break;
                }
                if(this.board[x - i, y - i] == 1)
                {
                    returnFlag = true;
                    break;
                }
            }

            return returnFlag;
        }

        private bool CheckLowerRightDiagonal(int x, int y)
        {
            bool returnFlag = false;

            for (int i = 1; i < this.board.GetLength(0); i++)
            {
                if (((x + i) >= this.board.GetLength(0)) || ((y + i) >= this.board.GetLength(1)))
                {
                    //Out of bounds
                    break;
                }
                if (this.board[x + i, y + i] == 1)
                {
                    returnFlag = true;
                    break;
                }
            }

            return returnFlag;
        }

        private bool CheckLowerLeftDiagonal(int x, int y)
        {
            bool returnFlag = false;

            for (int i = 1; i < this.board.GetLength(0); i++)
            {
                if (((x + i) >= this.board.GetLength(0)) || ((y - i) < 0))
                {
                    //Out of bounds
                    break;
                }
                if (this.board[x + i, y - i] == 1)
                {
                    returnFlag = true;
                    break;
                }
            }

            return returnFlag;
        }

        private bool CheckUpperRightDiagonal(int x, int y)
        {
            bool returnFlag = false;

            for (int i = 1; i < this.board.GetLength(0); i++)
            {
                if ( ((x - i) < 0) || ((y + i) >= this.board.GetLength(1)) )
                {
                    //Out of bounds
                    break;
                }
                if (this.board[x - i, y + i] == 1)
                {
                    returnFlag = true;
                    break;
                }
            }

            return returnFlag;
        }
    }
}
