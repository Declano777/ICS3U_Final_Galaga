using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICS3U_Final_Galaga
{
    public partial class Form1 : Form
    {
        // PLAYER
        int playerX = 360;
        int playerY = 730;
        int playerWidth = 80;
        int playerHeight = 40;
        int playerSpeed = 3;

        bool moveLeft = false;
        bool moveRight = false;

        // PLAYER BULLET
        int bulletX;
        int bulletY;
        int bulletWidth = 8;
        int bulletHeight = 20;
        int bulletSpeed = 6;
        bool bulletActive = false;

        // ALIENS
        const int alienRows = 3;
        const int alienCols = 10;

        int[,] alienX = new int[alienRows, alienCols];
        int[,] alienY = new int[alienRows, alienCols];
        bool[,] alienAlive = new bool[alienRows, alienCols];

        int alienWidth = 60;
        int alienHeight = 40;
        public Form1()
        {
            InitializeComponent();
            SetupAliens();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
                moveLeft = true;

            if (e.KeyCode == Keys.D)
                moveRight = true;

            if (e.KeyCode == Keys.Space && !bulletActive)
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
                    }
                }
            }
            this.Invalidate();
        }
        // updates player movment
        void UpdatePlayer()
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
                    alienX[r, c] = 100 + c * 145;
                    alienY[r, c] = 40 + r * 100;
                    alienAlive[r, c] = true;
                }
            }
        }
    }
}
