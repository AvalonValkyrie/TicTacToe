using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baldwin_ASG12_TTT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Def Area Start
        public struct TicTacToe
        {
            public string playerTurn;
            public int playNumber;
            public int totalXWins;
            public int totalOWins;
            public int totalTies;
            public int totalGames;
        }
        TicTacToe ttt;

        bool winnerIsX = false;
        bool winnerIsO = false;
        
        

        private void Form1_Load(object sender, System.EventArgs e)
        {
            ttt = new TicTacToe();
            ttt.playerTurn = "X";
            checkBoxBotAutoPlay.Checked = true;
            botTurn();
        }
        private void takeTurn(Button buttonClicked)
        {
            buttonClicked.Text = ttt.playerTurn;
            buttonClicked.Enabled = false;
            isWinner();
        }
        private void disableButtons()
        {
            buttonTopLeft.Enabled = false;
            buttonTopCenter.Enabled = false;
            buttonTopRight.Enabled = false;
            buttonMiddleLeft.Enabled = false;
            buttonMiddleCenter.Enabled = false;
            buttonMiddleRight.Enabled = false;
            buttonBottomLeft.Enabled = false;
            buttonBottomCenter.Enabled = false;
            buttonBottomRight.Enabled = false;
        }
        private void enableButtons()
        {
            buttonTopLeft.Enabled = true;
            buttonTopCenter.Enabled = true;
            buttonTopRight.Enabled = true;
            buttonMiddleLeft.Enabled = true;
            buttonMiddleCenter.Enabled = true;
            buttonMiddleRight.Enabled = true;
            buttonBottomLeft.Enabled = true;
            buttonBottomCenter.Enabled = true;
            buttonBottomRight.Enabled = true;
        }
        private void colorWinner(Button button1, Button button2, Button button3)
        {
            button1.BackColor = Color.Green;
            button2.BackColor = Color.Green;
            button3.BackColor = Color.Green;
        }
        private bool isThreeInRow(Button button1, Button button2, Button button3)
        {
            bool isWinner = false;
            if (button1.Enabled == false && button2.Text == button1.Text && button3.Text == button1.Text)
            {
                isWinner = true;
            }
            return isWinner;
        }
        private void isWinner()
        {
            ttt.playNumber = ttt.playNumber + 1;
            //did X win?
            if (isThreeInRow(buttonTopLeft, buttonTopRight, buttonTopCenter))
            {
                if (buttonTopLeft.Text == "O")
                {
                    winnerIsO = true;
                }
                else
                {
                    winnerIsX = true;
                }
                colorWinner(buttonTopLeft, buttonTopRight, buttonTopCenter);
                changeScores();
            }
            else if (isThreeInRow(buttonMiddleLeft, buttonMiddleRight, buttonMiddleCenter))
            {
                if (buttonMiddleLeft.Text == "O")
                {
                    winnerIsO = true;
                }
                else
                {
                    winnerIsX = true;
                }
                colorWinner(buttonMiddleLeft, buttonMiddleRight, buttonMiddleCenter);
                changeScores();
            }
            else if (isThreeInRow(buttonBottomLeft, buttonBottomRight, buttonBottomCenter))
            {
                if (buttonBottomLeft.Text == "O")
                {
                    winnerIsO = true;
                }
                else
                {
                    winnerIsX = true;
                }
                colorWinner(buttonBottomLeft, buttonBottomRight, buttonBottomCenter);
                changeScores();
            }
            else if (isThreeInRow(buttonMiddleCenter, buttonTopLeft, buttonBottomRight))
            {
                if (buttonTopLeft.Text == "O")
                {
                    winnerIsO = true;
                }
                else
                {
                    winnerIsX = true;
                }
                colorWinner(buttonMiddleCenter, buttonTopLeft, buttonBottomRight);
                changeScores();
            }
            else if (isThreeInRow(buttonMiddleCenter, buttonTopRight, buttonBottomLeft))
            {
                if (buttonTopRight.Text == "O")
                {
                    winnerIsO = true;
                }
                else
                {
                    winnerIsX = true;
                }
                colorWinner(buttonMiddleCenter, buttonTopRight, buttonBottomLeft);
                changeScores();
            }
            else if (isThreeInRow(buttonTopLeft, buttonMiddleLeft, buttonBottomLeft))
            {
                if (buttonTopLeft.Text == "O")
                {
                    winnerIsO = true;
                }
                else
                {
                    winnerIsX = true;
                }
                colorWinner(buttonTopLeft, buttonMiddleLeft, buttonBottomLeft);
                changeScores();
            }
            else if (isThreeInRow(buttonTopCenter, buttonMiddleCenter, buttonBottomCenter))
            {
                if (buttonTopCenter.Text == "O")
                {
                    winnerIsO = true;
                }
                else
                {
                    winnerIsX = true;
                }
                colorWinner(buttonTopCenter, buttonMiddleCenter, buttonBottomCenter); 
                changeScores();
            }
            else if (isThreeInRow(buttonTopRight, buttonMiddleRight, buttonBottomRight))
            {
                if (buttonTopRight.Text == "O")
                {
                    winnerIsO = true;
                }
                else
                {
                    winnerIsX = true;
                }
                colorWinner(buttonTopRight, buttonMiddleRight, buttonBottomRight);
                changeScores();
            }
            //was it a Tie?
            else if (ttt.playNumber >= 9)
            {
                changeScores();
            }
            else
            {
                switchTurn();
            }
        }
        private void resetWinner()
        {
            ttt.playNumber = 0;
            enableButtons();
            ttt.playerTurn = "X";
            winnerIsX = false;
            winnerIsO = false;
            
            buttonTopLeft.Text = "";
            buttonTopCenter.Text = "";
            buttonTopRight.Text = "";
            buttonMiddleLeft.Text = "";
            buttonMiddleCenter.Text = "";
            buttonMiddleRight.Text = "";
            buttonBottomLeft.Text = "";
            buttonBottomCenter.Text = "";
            buttonBottomRight.Text = "";
            
            buttonTopLeft.BackColor = Color.White;
            buttonTopCenter.BackColor = Color.White;
            buttonTopRight.BackColor = Color.White;
            buttonMiddleLeft.BackColor = Color.White;
            buttonMiddleCenter.BackColor = Color.White;
            buttonMiddleRight.BackColor = Color.White;
            buttonBottomLeft.BackColor = Color.White;
            buttonBottomCenter.BackColor = Color.White;
            buttonBottomRight.BackColor = Color.White;
        }
        private void switchTurn()
        {
            if (ttt.playerTurn == "X")
            {
                ttt.playerTurn = "O";
                labelWhichTurn.Text = "O Turn To Play";
            }
            else
            {
                ttt.playerTurn = "X";
                labelWhichTurn.Text = "X Turn To Play";
            }
        }

        private string whoIsWinner()
        {
            string winner = "";
            if (winnerIsX == true)
                winner = "X";
            else if (winnerIsO == true)
                winner = "O";
            else
                winner = "Tie";
            return winner;
        }

        private void changeScores()
        {
            disableButtons();
            string winner = whoIsWinner();
            int scoreX = int.Parse(labelTotalXWins.Text);
            int scoreO = int.Parse(labelTotalOWins.Text);
            int scoreTie = int.Parse(labelTotalTies.Text);
            if (winner == "X")
            {
                scoreX = scoreX + 1;
                ttt.totalXWins = scoreX;
                ttt.totalGames = ttt.totalGames + 1;
                labelTotalXWins.Text = scoreX.ToString();
                labelWhichTurn.Text = "X Wins!";
            }
            else if (winner == "O")
            {
                scoreO = scoreO + 1;
                ttt.totalOWins = scoreO;
                ttt.totalGames = ttt.totalGames + 1;
                labelTotalOWins.Text = scoreO.ToString();
                labelWhichTurn.Text = "O Wins!";
            }
            else
            {
                scoreTie = scoreTie + 1;
                ttt.totalTies = scoreTie;
                ttt.totalGames = ttt.totalGames + 1;
                labelTotalTies.Text = scoreTie.ToString();
                labelWhichTurn.Text = "It\'s A Tie!";
            }
        }
        private bool willBeWinner(string letter)
        {
            bool willBeWinner = false;
            if (isThreeInRow(buttonTopLeft, buttonTopRight, buttonTopCenter))
            {
                willBeWinner = true;
            }
            else if (isThreeInRow(buttonMiddleLeft, buttonMiddleRight, buttonMiddleCenter))
            {
                willBeWinner = true;
            }
            else if (isThreeInRow(buttonBottomLeft, buttonBottomRight, buttonBottomCenter))
            {
                willBeWinner = true;
            }
            else if (isThreeInRow(buttonMiddleCenter, buttonTopLeft, buttonBottomRight))
            {
                willBeWinner = true;
            }
            else if (isThreeInRow(buttonMiddleCenter, buttonTopRight, buttonBottomLeft))
            {
                willBeWinner = true;
            }
            else if (isThreeInRow(buttonTopLeft, buttonMiddleLeft, buttonBottomLeft))
            {
                willBeWinner = true;
            }
            else if (isThreeInRow(buttonTopCenter, buttonMiddleCenter, buttonBottomCenter))
            {
                willBeWinner = true;
            }
            else if (isThreeInRow(buttonTopRight, buttonMiddleRight, buttonBottomRight))
            {
                willBeWinner = true;
            }
            else
                willBeWinner = false;
            return willBeWinner;
        }
        private bool canWin() 
        {
            List<Button> buttonList = new List<Button>();
            buttonList.Add(buttonTopLeft);
            buttonList.Add(buttonTopCenter);
            buttonList.Add(buttonTopRight);
            buttonList.Add(buttonMiddleLeft);
            buttonList.Add(buttonMiddleCenter);
            buttonList.Add(buttonMiddleRight);
            buttonList.Add(buttonBottomLeft);
            buttonList.Add(buttonBottomCenter);
            buttonList.Add(buttonBottomRight);

            bool canWin = false; 
            Button botChoice = buttonTopLeft; 
            foreach (Button space in buttonList)
            {
                if (space.Text != "X" && space.Text != "O")
                {
                    space.Text = "X";
                    if (willBeWinner("X") == true)
                    {
                        canWin = true;
                        botChoice = space;
                        break;
                    }
                    else
                        space.Text = "";
                }
            }
            
            if (canWin == true)
               takeTurn(botChoice);
            return canWin;
        }
        private bool needBlock()
        {
            List<Button> buttonList = new List<Button>();
            buttonList.Add(buttonTopLeft);
            buttonList.Add(buttonTopCenter);
            buttonList.Add(buttonTopRight);
            buttonList.Add(buttonMiddleLeft);
            buttonList.Add(buttonMiddleCenter);
            buttonList.Add(buttonMiddleRight);
            buttonList.Add(buttonBottomLeft);
            buttonList.Add(buttonBottomCenter);
            buttonList.Add(buttonBottomRight);

            bool needBlock = false;
            Button botChoice = buttonTopLeft;
            
            foreach (Button space in buttonList)
            {
                if (space.Text != "X" && space.Text != "O")
                {
                    space.Text = "O";
                    if (willBeWinner("O") == true)
                    {
                        needBlock = true;
                        botChoice = space;
                        break;
                    }
                    else
                        space.Text = "";
                }
            }

            if (needBlock == true)
            {
                takeTurn(botChoice);
                return needBlock;
            }
            else 
                return needBlock;
        }
    

        private void bestPlay()
        {
            List<Button> buttonList = new List<Button>();
            buttonList.Add(buttonTopLeft);
            buttonList.Add(buttonTopCenter);
            buttonList.Add(buttonTopRight);
            buttonList.Add(buttonMiddleLeft);
            buttonList.Add(buttonMiddleCenter);
            buttonList.Add(buttonMiddleRight);
            buttonList.Add(buttonBottomLeft);
            buttonList.Add(buttonBottomCenter);
            buttonList.Add(buttonBottomRight);

            Button botChoice = buttonTopLeft;
            if (ttt.playNumber == 0)
                    botChoice = buttonTopLeft;
                
            else if (ttt.playNumber == 2)
            {
                if (buttonMiddleCenter.Enabled == true)
                {
                    if (buttonTopCenter.Text == "O" || buttonTopRight.Text == "O" || buttonMiddleRight.Text == "O" || buttonBottomCenter.Text == "O" || buttonBottomRight.Text == "O")
                    {
                        botChoice = buttonBottomLeft;
                    }
                    else if (buttonMiddleLeft.Text == "O" || buttonBottomLeft.Text == "O")
                    {
                        botChoice = buttonTopRight;
                    }
                    else
                    {//Just incase I missed something, it will always make a move
                        while (botChoice.Enabled == false)
                        {
                            var random = new Random();
                            int index = random.Next(buttonList.Count);
                            botChoice = buttonList[index];
                        }
                    }
                }
                else if (buttonMiddleCenter.Enabled == false)
                    botChoice = buttonBottomRight;
                else
                {//Just incase I missed something, it will always make a move
                    while (botChoice.Enabled == false)
                    {
                        var random = new Random();
                        int index = random.Next(buttonList.Count);
                        botChoice = buttonList[index];
                    }
                }
            }

            else if (ttt.playNumber == 4)
            {
                if (buttonTopRight.Text == "X" && buttonMiddleLeft.Text == "O" && buttonBottomLeft.Enabled == true)
                    botChoice = buttonBottomLeft;
                else if (buttonMiddleCenter.Text == "O" && buttonBottomCenter.Text == "O" && buttonTopCenter.Enabled == true)
                    botChoice = buttonTopCenter;
                else if (buttonMiddleRight.Text == "O" && buttonMiddleCenter.Text == "O" && buttonMiddleLeft.Enabled == true)
                    botChoice = buttonMiddleLeft;
                else if (buttonTopRight.Text == "X" && buttonBottomLeft.Enabled == true)
                    botChoice = buttonBottomRight;
                else if (buttonBottomLeft.Text == "X" && buttonTopCenter.Text == "O" && buttonBottomRight.Enabled == true)
                    botChoice = buttonBottomRight;
                else if (buttonBottomLeft.Text == "X" && buttonTopRight.Enabled == true)
                    botChoice = buttonTopRight;
                else if (buttonBottomLeft.Text == "X" && buttonBottomRight.Enabled == true)
                    botChoice = buttonBottomRight;
                else if (buttonBottomRight.Text == "X" && buttonTopRight.Enabled == true)
                    botChoice = buttonTopRight;
                else if (buttonTopRight.Text == "X" && buttonMiddleCenter.Enabled == true)
                    botChoice = buttonMiddleCenter;
                else
                {//Just incase I missed something, it will always make a move
                    while (botChoice.Enabled == false)
                    {
                        var random = new Random();
                        int index = random.Next(buttonList.Count);
                        botChoice = buttonList[index];
                    }
                }
            }
            else if (ttt.playNumber > 4 && 9 >= ttt.playNumber)//should stop spaces from being open if its a tie and the bot cannot block
                while (botChoice.Enabled == false)
                {
                    var random = new Random();
                        
                            int index = random.Next(buttonList.Count);
                            botChoice = buttonList[index];
                        
                }
            takeTurn(botChoice);
        }
        private void botTurn()
        {
            if (ttt.playerTurn == "X")
            {
                bool didBotPlay = false;
                didBotPlay = canWin();
                if (didBotPlay == false)
                {
                    didBotPlay = needBlock();
                    if (didBotPlay == false)
                    {
                        bestPlay();
                    }
                }
            }
        }//Bot Turn End

        //Def Area End
        //Button Area Start
        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            resetWinner();
            labelWhichTurn.Text = "New Game, X Goes First";
            if (checkBoxBotAutoPlay.Checked == true)
            {
                botTurn();
            }
        }//New Game button end

        private void buttonTopLeft_Click(object sender, EventArgs e)
        {
            takeTurn(buttonTopLeft);
            buttonTopLeft.Enabled = false;
            if(checkBoxBotAutoPlay.Checked == true && willBeWinner("O") == false)
                botTurn();
        }//Top Left button end

        private void buttonTopCenter_Click(object sender, EventArgs e)
        {
            takeTurn(buttonTopCenter);
            if (checkBoxBotAutoPlay.Checked == true && willBeWinner("O") == false)
                botTurn();
        }//Top Center button end

        private void buttonTopRight_Click(object sender, EventArgs e)
        {
            takeTurn(buttonTopRight);
            if (checkBoxBotAutoPlay.Checked == true && willBeWinner("O") == false)
                botTurn();
        }//Top Right button end

        private void buttonMiddleLeft_Click(object sender, EventArgs e)
        {
            takeTurn(buttonMiddleLeft);
            if (checkBoxBotAutoPlay.Checked == true && willBeWinner("O") == false)
                botTurn();
        }//Middle Left button end

        private void buttonMiddleCenter_Click(object sender, EventArgs e)
        {
            takeTurn(buttonMiddleCenter);
            if (checkBoxBotAutoPlay.Checked == true && willBeWinner("O") == false)
                botTurn();
        }//Middle Center button end

        private void buttonMiddleRight_Click(object sender, EventArgs e)
        {
            takeTurn(buttonMiddleRight);
            if (checkBoxBotAutoPlay.Checked == true && willBeWinner("O") == false)
                botTurn();
        }//Middle Right button end

        private void buttonBottomLeft_Click(object sender, EventArgs e)
        {
            takeTurn(buttonBottomLeft);
            if (checkBoxBotAutoPlay.Checked == true && willBeWinner("O") == false)
                botTurn();
        }//Bottom Left button end

        private void buttonBottomCenter_Click(object sender, EventArgs e)
        {
            takeTurn(buttonBottomCenter);
            if (checkBoxBotAutoPlay.Checked == true && willBeWinner("O") == false)
                botTurn();
        }//Bottom Center button end

        private void buttonBottomRight_Click(object sender, EventArgs e)
        {
            takeTurn(buttonBottomRight);
            if (checkBoxBotAutoPlay.Checked == true && willBeWinner("O") == false)
                botTurn();
        }//Bottom Right button end
        //Button Area End
    }
}
