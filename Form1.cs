using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class Form1 : Form
    {
        private List<Circle> Snake = new List<Circle>();
        private Circle food = new Circle();
        int maxWidth;
        int maxHeight;

        int score;
        int highScore;
        Random rnd = new Random();

        bool goLeft, goRight, goDown, goUp;
        public Form1()
        {
            InitializeComponent();

            new Settings();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && Settings.directions != "right")
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right && Settings.directions != "left")
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Up && Settings.directions != "Down")
            {
                goUp = true;
            }
            if (e.KeyCode == Keys.Down && Settings.directions != "Up")
            {
                goDown = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
        }

        private void StartGame(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void TakeSnapShot(object sender, EventArgs e)
        {
            Label caption = new Label();
            caption.Text = $"I scored: {score} and my highscore is: {highScore}";
            caption.Font = new Font("Ariel", 12, FontStyle.Bold);
            caption.ForeColor = Color.Black;
            caption.AutoSize = false;
            caption.Width = picCanvas.Width;
            caption.Height = 30;
            caption.TextAlign = ContentAlignment.MiddleCenter;
            picCanvas.Controls.Add(caption);

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = "Snake Game Snapshot";
            dialog.DefaultExt = "jpg";
            dialog.Filter = "JPG Image File | *.jpg";
            dialog.ValidateNames = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                int width = Convert.ToInt32(picCanvas.Width);
                int height = Convert.ToInt32(picCanvas.Height);
                Bitmap bmp = new Bitmap(width, height);
                picCanvas.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));
                bmp.Save(dialog.FileName, ImageFormat.Jpeg);
                picCanvas.Controls.Remove(caption);
            }

        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            // setting the directions
            if (goLeft)
            {
                Settings.directions = "left";
            }
            if (goRight)
            {
                Settings.directions = "right";
            }
            if (goUp)
            {
                Settings.directions = "up";
            }
            if (goDown)
            {
                Settings.directions = "down";
            }
            // end of directions

            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (Settings.directions)
                    {
                        case "left":
                            Snake[i].X--;
                            break;
                        case "right":
                            Snake[i].X++;
                            break;
                        case "up":
                            Snake[i].Y--;
                            break;
                        case "down":
                            Snake[i].Y++;
                            break;
                    }

                    // If out of bounds move to other side
                    if (Snake[i].X < 0)
                    {
                        Snake[i].X = maxWidth;
                    }
                    if (Snake[i].X > maxWidth)
                    {
                        Snake[i].X = 0;
                    }
                    if (Snake[i].Y < 0)
                    {
                        Snake[i].Y = maxHeight;
                    }
                    if (Snake[i].Y > maxHeight)
                    {
                        Snake[i].Y = 0;
                    }

                    // Check collision of food
                    if (Snake[i].X == food.X && Snake[i].Y == food.Y)
                    {
                        EatFood();
                        if (score < 5)
                        {
                            gameTimer.Interval = 100;
                        }
                        else if (score < 10)
                        {
                            gameTimer.Interval = 70;
                        }
                        else if (score < 15)
                        {
                            gameTimer.Interval = 40;
                        }
                    }

                    for (int j = 1; j < Snake.Count; j++)
                    {
                        if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                        {
                            GameOver();
                        }
                    }
                }
                else
                {
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }

            picCanvas.Invalidate();
        }

        private void UpdatePictureBoxGfx(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            Brush snakeColor;

            for (var i = 0; i < Snake.Count(); i++)
            {
                if (i == 0)
                {
                    snakeColor = Brushes.Black;
                }
                else
                {
                    snakeColor = Brushes.DarkGreen;
                }

                canvas.FillEllipse(snakeColor, new Rectangle
                    (
                        Snake[i].X * Settings.Width,
                        Snake[i].Y * Settings.Height,
                        Settings.Width, Settings.Height
                    ));
            }

            canvas.FillEllipse(Brushes.DarkRed, new Rectangle
            (
                food.X * Settings.Width,
                food.Y * Settings.Height,
                Settings.Width, Settings.Height
            ));
        }

        private void RestartGame()
        {
            maxWidth = picCanvas.Width / Settings.Width;
            maxHeight = picCanvas.Height / Settings.Height;

            Snake.Clear();

            startButton.Enabled = false;
            snapButton.Enabled = false;
            score = 0;
            txtScore.Text = "Score: " + score;

            Circle head = new Circle { X = 10, Y = 5 };
            Snake.Add(head); // adding the head part to the snake to the list

            for (int i = 0; i < Settings.snakeLength - 1; i++)
            {
                Circle body = new Circle();
                Snake.Add(body);
            }

            CreateFood();

            gameTimer.Interval = 100;
            gameTimer.Start();
        }

        private void EatFood()
        {
            score += 1;
            txtScore.Text = "Score: " + score;

            Circle body = new Circle
            {
                X = Snake[Snake.Count - 1].X,
                Y = Snake[Snake.Count - 1].Y
            };

            Snake.Add(body);

            CreateFood();
        }

        private void GameOver()
        {
            gameTimer.Stop();
            startButton.Enabled = true;
            snapButton.Enabled = true;

            if (score > highScore)
            {
                highScore = score;
                txtHighscore.Text = "High Score: " + Environment.NewLine + highScore;
                txtHighscore.ForeColor = Color.Maroon;
                txtHighscore.TextAlign = ContentAlignment.MiddleCenter;
            }
        }

        private void CreateFood()
        {
            // Create a new food with random position
            food = new Circle { X = rnd.Next(2, maxWidth), Y = rnd.Next(2, maxHeight) };

            // Prevent food from spawn on snake
            for(int i=0;i < Snake.Count;i++)
            {
                if (Snake[i].X == food.X && Snake[i].Y == food.Y)
                {
                    CreateFood();
                }
            }
        }
    }
}
