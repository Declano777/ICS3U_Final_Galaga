/*
 Declan O'Neill
 ICS3U
 Galaga Final Project
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace ICS3U_Final_Galaga
{
    public partial class Form1 : Form
    {
        string scoreFilePath = @"C:\Users\Decla\OneDrive\Desktop\comp sci icons\Galaga Scores\galaga scores.txt";
        SoundPlayer music = new SoundPlayer(Properties.Resources.Start_Music___Galaga);
        // PLAYER
        int playerX = 360;
        int playerY = 330;
        int playerWidth = 40;
        int playerHeight = 20;
        int playerSpeed = 3;
        int score = 0;

        bool moveLeft = false;
        bool moveRight = false;

        // PLAYER BULLET
        int bulletX;
        int bulletY;
        int bulletWidth = 4;
        int bulletHeight = 10;
        int bulletSpeed = 7;
        bool bulletActive = false;

        // ALIENS
        const int alienRows = 3;
        const int alienCols = 7;

        int[,] alienX = new int[alienRows, alienCols];
        int[,] alienY = new int[alienRows, alienCols];
        bool[,] alienAlive = new bool[alienRows, alienCols];

        int alienWidth = 40;
        int alienHeight = 30;
        int alienStartX = 30; // move left/right
        int alienStartY = 50;  // move up/down

        int alienSpacingX = 70;
        int alienSpacingY = 50;

        int alienMoveDirection = 1;   // 1 = right, -1 = left
        int alienStepSize = 10;
        int alienStepsTaken = 0;
        int alienMaxSteps = 10;
        int alienMoveDownAmount = 20;

        //Alian Bullets
        int maxAlienBullets = 5;

        int[] alienBulletX;
        int[] alienBulletY;
        bool[] alienBulletActive;

        int alienBulletWidth = 5;
        int alienBulletHeight = 15;
        int alienBulletSpeed = 15;

        Random rand = new Random();

        bool gameOver = false;
        bool youWin = false;

        public Form1()
        {
            InitializeComponent();
            music.PlayLooping();
            SetupAliens();
            this.KeyPreview = true;
            alienBulletX = new int[maxAlienBullets];
            alienBulletY = new int[maxAlienBullets];
            alienBulletActive = new bool[maxAlienBullets];

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
                moveLeft = true;

            if (e.KeyCode == Keys.D)
                moveRight = true;

            if (e.KeyCode == Keys.W && !bulletActive)
            {
                bulletActive = true;
                bulletX = playerX + playerWidth / 2 - bulletWidth / 2;
                bulletY = playerY;
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
                moveLeft = false;

            if (e.KeyCode == Keys.D)
                moveRight = false;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // DRAW PLAYER
            e.Graphics.FillRectangle(
                Brushes.Cyan,
                playerX,
                playerY,
                playerWidth,
                playerHeight
            );

            // DRAW BULLET
            if (bulletActive)
            {
                e.Graphics.FillRectangle(
                    Brushes.Yellow,
                    bulletX,
                    bulletY,
                    bulletWidth,
                    bulletHeight
                );

            }
            // Alien bullets
            for (int i = 0; i < maxAlienBullets; i++)
            {
                if (alienBulletActive[i])
                {
                    e.Graphics.FillRectangle(
                        Brushes.Red,
                        alienBulletX[i],
                        alienBulletY[i],
                        alienBulletWidth,
                        alienBulletHeight);
                }
            }
            // DRAW ALIENS
            for (int r = 0; r < alienRows; r++)
            {
                for (int c = 0; c < alienCols; c++)
                {
                    if (alienAlive[r, c])
                    {
                        e.Graphics.FillRectangle(
                            Brushes.Red,
                            alienX[r, c],
                            alienY[r, c],
                            alienWidth,
                            alienHeight
                        );
                    }
                }
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            // PLAYER MOVEMENT
            if (moveLeft && playerX > 0)
                playerX -= playerSpeed;

            if (moveRight && playerX + playerWidth < ClientSize.Width)
                playerX += playerSpeed;

            // PLAYER BULLET MOVEMENT
            if (bulletActive)
            {
                bulletY -= bulletSpeed;

                if (bulletY < 0)
                    bulletActive = false;
            }
            // Alien bullet hits player
            for (int i = 0; i < maxAlienBullets; i++)
            {
                if (!alienBulletActive[i])
                    continue;

                if (alienBulletX[i] < playerX + playerWidth &&
                    alienBulletX[i] + alienBulletWidth > playerX &&
                    alienBulletY[i] < playerY + playerHeight &&
                    alienBulletY[i] + alienBulletHeight > playerY)
                {
                    GameOver();
                    
                }
            }
            // Move alien bullets
            for (int i = 0; i < maxAlienBullets; i++)
            {
                if (alienBulletActive[i])
                {
                    alienBulletY[i] += alienBulletSpeed;

                    if (alienBulletY[i] > ClientSize.Height)
                        alienBulletActive[i] = false;
                }
            }
            UpdatePlayer();
            // BULLET vs ALIENS
            for (int r = 0; r < alienRows; r++)
            {
                for (int c = 0; c < alienCols; c++)
                {
                    if (!alienAlive[r, c] || !bulletActive)
                        continue;

                    if (bulletX < alienX[r, c] + alienWidth &&
                        bulletX + bulletWidth > alienX[r, c] &&
                        bulletY < alienY[r, c] + alienHeight &&
                        bulletY + bulletHeight > alienY[r, c])
                    {
                        alienAlive[r, c] = false;
                        bulletActive = false;
                        score += 1015;
                        scoreLabel.Text = "Score: " + score;
                        CheckWin();
                    }
                  
                }
               

            }
            this.Invalidate();
        }
        // updates player movment
        private void UpdatePlayer()
        {
            if (moveLeft && playerX > 0)
                playerX -= playerSpeed;

            if (moveRight && playerX + playerWidth < ClientSize.Width)
                playerX += playerSpeed;

            if (bulletActive)
            {
                bulletY -= bulletSpeed;
                if (bulletY < 0)
                    bulletActive = false;
            }
        }
        // sets up the alians 
        void SetupAliens()
        {
            for (int r = 0; r < alienRows; r++)
            {
                for (int c = 0; c < alienCols; c++)
                {
                    alienX[r, c] = alienStartX + c * alienSpacingX;
                    alienY[r, c] = alienStartY + r * alienSpacingY;
                    alienAlive[r, c] = true;
                }
            }
        }
        private void MoveAliens()
        {
            // MOVE SIDEWAYS
            if (alienStepsTaken < alienMaxSteps)
            {
                for (int r = 0; r < alienRows; r++)
                {
                    for (int c = 0; c < alienCols; c++)
                    {
                        if (alienAlive[r, c])
                        {
                            alienX[r, c] += alienStepSize * alienMoveDirection;
                        }
                    }
                }

                alienStepsTaken++;
            }
            else
            {
                // MOVE DOWN
                for (int r = 0; r < alienRows; r++)
                {
                    for (int c = 0; c < alienCols; c++)
                    {
                        if (alienAlive[r, c])
                        {
                            alienY[r, c] += alienMoveDownAmount;
                        }
                    }
                }

                alienStepsTaken = 0;
                alienMoveDirection *= -1;
            }

            Invalidate(); // redraw screen
        }




        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void alianTimer_Tick(object sender, EventArgs e)
        {
            // Find a free bullet
            for (int i = 0; i < maxAlienBullets; i++)
            {
                if (!alienBulletActive[i])
                {
                    // Pick random alien
                    int r = rand.Next(alienRows);
                    int c = rand.Next(alienCols);

                    if (!alienAlive[r, c])
                        return;

                    alienBulletX[i] = alienX[r, c] + alienWidth / 2;
                    alienBulletY[i] = alienY[r, c] + alienHeight;

                    alienBulletActive[i] = true;
                    break;
                }
            }
            // Aliens reach ground
            for (int r = 0; r < alienRows; r++)
            {
                for (int c = 0; c < alienCols; c++)
                {
                    if (alienAlive[r, c] &&
                        alienY[r, c] + alienHeight >= playerY)
                    {
                        GameOver();
                        return;
                    }
                }
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            starLabel.Visible = false;
            titelLabel.Visible = false;
            startButton.Visible = false;
            rulesButton.Visible = false;
            alianTimer2.Enabled = true;
            alianTimer1.Enabled = true;
            gameTimer.Enabled = true;
            score = 0;
            scoreLabel.Text = "Score: 0";
            scoreLabel.Visible = true;
        }


        private void alianTimer1_Tick(object sender, EventArgs e)
        {
            MoveAliens();
        }

        private void RestartGame()
        {
            gameOver = false;

            // Reset score
            score = 0;
            scoreLabel.Text = "Score: 0";

            // Hide game over text
            gameOverLabel.Visible = false;

            // Reset bullet
            bulletActive = false;

            // Reset alien bullets
            for (int i = 0; i < maxAlienBullets; i++)
                alienBulletActive[i] = false;

            // Reset aliens
            SetupAliens();
            alienMoveDirection = 1;

            // Restart timers
            gameTimer.Start();
            alianTimer2.Start();
            alianTimer1.Start();

            restartButton.Visible = false;
            enterNameLabel.Visible = false;
            nameTextBox.Visible = false;
            saveScoreButton.Visible = false;
            blackLabel.Visible = false;
            youWinLabel.Visible = false;

            Invalidate();
        }
        private void rulesButton_Click(object sender, EventArgs e)
        {
            rules rulesForm = new rules();
            rulesForm.Show();
        }
        private void GameOver()
        {
            gameOver = true;

            gameTimer.Stop();
            alianTimer2.Stop();
            alianTimer1.Stop(); 

            gameOverLabel.Visible = true;
            restartButton.Visible = true;
            enterNameLabel.Visible = true;
            nameTextBox.Visible = true;
            saveScoreButton.Visible = true;
            blackLabel.Visible = true;
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void saveScoreButton_Click(object sender, EventArgs e)
        {
            string playerName = nameTextBox.Text;

            if (playerName == "")
                return;

            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(scoreFilePath, true))
            {
                writer.WriteLine(playerName + " - " + score);
            }

            nameTextBox.Text = "";
        }

        private void YouWin()
        {
            youWin = true;
            //stopes all timers
            gameTimer.Stop();
            alianTimer2.Stop();
            alianTimer1.Stop(); 

            youWinLabel.Visible = true;
            restartButton.Visible = true;
            enterNameLabel.Visible = true;
            nameTextBox.Visible = true;
            saveScoreButton.Visible = true;
            blackLabel.Visible = true;
        }
        private void CheckWin()
        {
            for (int r = 0; r < alienRows; r++)
            {
                for (int c = 0; c < alienCols; c++)
                {
                    if (alienAlive[r, c])
                        return; // At least one alien still alive
                }
            }

            YouWin(); // No aliens alive
        }
    }
}
