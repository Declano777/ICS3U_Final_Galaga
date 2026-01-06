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
        int playerWidth = 40;
        int playerHeight = 20;
        int playerSpeed = 3;

        bool moveLeft = false;
        bool moveRight = false;

        // PLAYER BULLET
        int bulletX;
        int bulletY;
        int bulletWidth = 4;
        int bulletHeight = 10;
        int bulletSpeed = 6;
        bool bulletActive = false;
        public Form1()
        {
            InitializeComponent();
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
            this.Invalidate();
        }
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
    }
}
