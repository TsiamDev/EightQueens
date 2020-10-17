using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace EightQueens
{
    public partial class Form1 : Form
    {
        #region Declarations
        //main variables
        private int[,] board;
        private int queenNum;
        //2 rows and queenNum columns
        //For each queen:
        //row 0 has posX
        //row 1 has posY
        private int[,] queenPos;
        //INdex of last queen (used column) in queenPos
        private int queenIndex;

        //for reproducible results
        private int seed;

        //metrics
        private long checkSolutionMs;

        //Visuals
        private PictureBox[,] pictureBoxes;

        //Labels
        private string exeTimeText;

        //Chart variables
        private List<int> barChartX = new List<int>();
        private List<long> barChartY = new List<long>();
        #endregion

        #region Initialization
        public Form1()
        {
            InitializeComponent();

            var watch = System.Diagnostics.Stopwatch.StartNew();

            InitializeParameters();
            checkSolutionMs = 0;
            pictureBoxes = new PictureBox[8, 8];
            //set the Random seed
            this.seed = 1;

            watch.Stop();
            var elapsed = watch.ElapsedMilliseconds;
            Console.WriteLine("Initialization time: " + elapsed);

        }

        private void InitializeParameters()
        {
            //Init the 8x8 array with zeros
            this.board = new int[8, 8];

            //set queen number
            this.queenNum = 8;

            //initialize queen position dictionary
            this.queenPos = new int[2, queenNum];

            //reset index
            this.queenIndex = 0;

            //clear strings
            this.exeTimeText = "";
        }

        #endregion

        #region Brute Force solution - 1 Queen on each row
        //This method places the Queens one by one on each row
        //Begins at first row - picks a random column - places Queen
        //Second row - picks random column - places Queen
        //etc
        //Search Space: 8*8*...*8 = 8^8 = 16,777,216 possible placements
        private void FindSolutionBruteForce1onEachRow(int inputSeed)
        {
            Random rnd = new Random(inputSeed);
            bool terminationFlag;
            do
            {
                InitializeParameters();

                for (int xPos = 0; xPos < this.queenNum; xPos++)
                {
                    int yPos = rnd.Next(0, 8);  //Get a random column
                    //Update the board and dictionary
                    this.board[xPos, yPos] = 1;
                    this.queenPos[0, queenIndex] = xPos;
                    this.queenPos[1, queenIndex] = yPos;
                    this.queenIndex++;
                }

                var watch = System.Diagnostics.Stopwatch.StartNew();
                terminationFlag = CheckSolution();
                watch.Stop();
                checkSolutionMs += watch.ElapsedMilliseconds;

            } while (terminationFlag == true);
            Console.WriteLine("Found Solution!");

            PrintSolution();
            Console.WriteLine("CheckSolution total time: " + checkSolutionMs);
            exeTimeText += "CheckSolution total time: " + checkSolutionMs + " ms" + "\n";
        }
        #endregion

        #region Brute Force solution
        //TODO: the function as is doesn't avoid checking same solutions

        //This method places the Queens one by one on one of the open places on the board
        //Begins for first Queen - picks random xPos, yPos - places Queen
        //Second Queen - picks a random xPos, yPos excluding the previous - places Queen
        //etc
        //Search Space: 64*63*...*57 = 64!/56! = 281,474,976,710,656 possible placements
        private void FindSolutionBruteForce(int inputSeed)
        {
            Console.WriteLine("seed used for this iteration: " + inputSeed);
            Random rnd = new Random(inputSeed);
            bool flag = false;
            bool terminationFlag;

            //Untill you have a solution
            do
            {
                //Reinitialize for a new solution
                InitializeParameters();
                //For all queens generate random position
                for (int i = 0; i < this.queenNum; i++)
                {
                    flag = false;
                    do
                    {
                        //Generate random position in [0,8)
                        int posX = rnd.Next(0, 8);
                        int posY = rnd.Next(0, 8);
                        //CHeck if the generated position is occupied
                        if (this.board[posX, posY] == 1)
                        {
                            //discard this position
                            flag = false;
                        }
                        else
                        {
                            //Update the board
                            this.board[posX, posY] = 1;
                            //Add a new queen position to the list
                            this.queenPos[0, queenIndex] = posX;
                            this.queenPos[1, queenIndex] = posY;
                            this.queenIndex++;
                            flag = true;
                        }
                    } while (flag == false);
                }
                var watch = System.Diagnostics.Stopwatch.StartNew();
                terminationFlag = CheckSolution();
                watch.Stop();
                checkSolutionMs += watch.ElapsedMilliseconds;
                
            } while (terminationFlag == true);
            Console.WriteLine("Found Solution!");

            PrintSolution();
            Console.WriteLine("CheckSolution total time: " + checkSolutionMs);
            exeTimeText += "CheckSolution total time: " + checkSolutionMs + " ms" + "\n";
        }

        #endregion

        #region Print solution to console
        private void PrintSolution()
        {
            string str = "";
            for (int i = 0; i < this.board.GetLength(0); i++)
            {
                str = "";
                for (int j = 0; j < this.board.GetLength(1); j++)
                {
                    if(this.board[i,j] == 1)
                    {
                        str += "X";
                    }
                    else
                    {
                        str += "0";
                    }
                }
                Console.WriteLine(str);
            }
        }

        #endregion

        #region  Check if current solution is acceptable
        private bool CheckSolution()
        {
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
        #endregion

        #region Button click handlers
        private void bruteForceButton_Click(object sender, EventArgs e)
        {
            int inputSeed = ReadSeed();
            Console.WriteLine("Input seed " + inputSeed);
            BruteForceWrapper(inputSeed);
        }

        private void exeTestButton_Click(object sender, EventArgs e)
        {
            TestBench();
        }

        private void ExecuteTest2Button_Click(object sender, EventArgs e)
        {
            TestBench1onEachRow();
        }

        //Returns user seed or 1 if not defined
        private int ReadSeed()
        {
            int userSeed = 1;
            if (!string.IsNullOrEmpty(inputSeedTextBox.Text))
            {
                try
                {
                    userSeed = int.Parse(inputSeedTextBox.Text);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return userSeed;
        }
        #endregion

        #region Wrappers
        private void BruteForceWrapper(int inputSeed)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            FindSolutionBruteForce(inputSeed);
            watch.Stop();
            var elapsed = watch.ElapsedMilliseconds;

            Console.WriteLine("FindSolutionBruteForce total time: " + elapsed + " ms");
            Console.WriteLine("New solution generation total time: " + (elapsed - checkSolutionMs) + " ms");
            exeTimeText += "FindSolutionBruteForce total time: " + elapsed + " ms" + "\n";
            exeTimeText += "New solution generation total time: " + (elapsed - checkSolutionMs) + " ms";
            this.barChartY.Add(elapsed);

            BruteForceUpdateTexts();

            InitializePictureBoxes();
        }

        private void BruteForce1onEachRowWrapper(int inputSeed)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            FindSolutionBruteForce1onEachRow(inputSeed);
            watch.Stop();
            var elapsed = watch.ElapsedMilliseconds;

            Console.WriteLine("FindSolutionBruteForce1onEachRow total time: " + elapsed + " ms");
            Console.WriteLine("New solution generation total time: " + (elapsed - checkSolutionMs) + " ms");
            exeTimeText += "FindSolutionBruteForce1onEachRow total time: " + elapsed + " ms" + "\n";
            exeTimeText += "New solution generation total time: " + (elapsed - checkSolutionMs) + " ms";
            this.barChartY.Add(elapsed);

            BruteForceUpdateTexts();

            InitializePictureBoxes();
        }
        #endregion

        #region Miscelaneous
        private void BruteForceUpdateTexts()
        {
            methodLabel.Text = "Method Used: Brute Force";
            exeTimeLabel.Text = exeTimeText;
        }

        private void UpdateBarChart()
        {
            barChart.Series[0].LegendText = "Brute Force Statistics";
            barChart.Series[0].ChartType = SeriesChartType.Column;
            barChart.Series[0].IsValueShownAsLabel = true;
            barChart.Series[0].Points.DataBindXY(barChartX, barChartY);
        }

        private void ReinitializePanel()
        {
            if (flowLayoutPanel1 != null)
            {
                List<Control> listControls = flowLayoutPanel1.Controls.Cast<Control>().ToList();

                foreach (Control control in listControls)
                {
                    flowLayoutPanel1.Controls.Remove(control);
                    control.Dispose();
                }

                //One liner for the same thing
                //flowLayoutPanel1.Controls.OfType<PictureBox>().ToList().ForEach(btn => btn.Dispose());
            }
        }

        private void InitializePictureBoxes()
        {
            ReinitializePanel();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    pictureBoxes[i, j] = new PictureBox();
                    if (this.board[i, j] == 1)
                    {
                        pictureBoxes[i, j].Image = EightQueens.Properties.Resources.queen50x50NoBackground;
                    }
                    //Pick a different color for the different tiles
                    if ((i + j == 1) || (i + j == 3) || (i + j == 5) || (i + j == 7) || (i + j == 9) || (i + j == 11) || (i + j == 13))
                    {
                        pictureBoxes[i, j].BackColor = Color.Red;
                    }
                    else
                    {
                        pictureBoxes[i, j].BackColor = Color.Green;
                    }
                    pictureBoxes[i, j].Size = new Size(50, 50);
                    flowLayoutPanel1.Controls.Add(pictureBoxes[i, j]);
                }
            }
        }
        #endregion

        #region Testbench
        private void TestBench()
        {
            int maxIter = 15;
            for (int i = 0; i < maxIter; i++)
            {
                Console.WriteLine(i + "/" + maxIter + " iteration");

                BruteForceWrapper(seed);

                this.barChartX.Add(seed);
                this.seed++;
            }
            //Console.WriteLine("X length: " + barChartX.Count);
            //Console.WriteLine("Y length: " + barChartY.Count);
            UpdateBarChart();
        }

        private void TestBench1onEachRow()
        {
            int maxIter = 15;
            for (int i = 0; i < maxIter; i++)
            {
                Console.WriteLine(i + "/" + maxIter + " iteration");

                BruteForce1onEachRowWrapper(seed);
                //FindSolutionBruteForce1onEachRow(seed);

                this.barChartX.Add(seed);
                this.seed++;
            }
            //Console.WriteLine("X length: " + barChartX.Count);
            //Console.WriteLine("Y length: " + barChartY.Count);
            UpdateBarChart();
        }
        #endregion
    }
}
