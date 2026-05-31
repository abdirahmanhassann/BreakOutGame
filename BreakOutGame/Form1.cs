using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BreakOutGame
{
    public partial class Form1 : Form
    {
        private string _directionX = "EAST";
        private string _directionY = "SOUTH";
        private int _score = 0;
        private int _level = 1;
        private int _ballSpeed = 3;
        private int _refreshRate = 20;
        private class Tiles()
        {
            public bool IsHit { get; set; }
            public PictureBox TilePictureBox { get; set; }
        }
        private List<Tiles> _tilesList = new List<Tiles>();
        private System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            InitialValues();
            _timer.Tick += new EventHandler(GameLoop);
            _timer.Interval = _refreshRate;
            _timer.Start();
        }

        private void GameLoop(object sender, EventArgs e)
        {
            BallCollisionHandler();
            BallMovementHandler();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right && paddlePictureBox.Location.X < this.ClientSize.Width - paddlePictureBox.Width)
            {
                paddlePictureBox.Location = new Point(paddlePictureBox.Location.X + 10, paddlePictureBox.Location.Y);
            }
            if (e.KeyCode == Keys.Left && paddlePictureBox.Location.X > 0)
            {
                paddlePictureBox.Location = new Point(paddlePictureBox.Location.X - 10, paddlePictureBox.Location.Y);
            }
        }

        private void BallCollisionHandler()
        {
            if (ballPictureBox.Location.X <= 0)
            {
                _directionX = "EAST";
            }
            if (ballPictureBox.Location.X >= this.ClientSize.Width - ballPictureBox.Width)
            {
                _directionX = "WEST";
            }
            if (ballPictureBox.Location.Y <= 0)
            {
                _directionY = "SOUTH";
            }
            if (ballPictureBox.Location.Y >= paddlePictureBox.Location.Y - ballPictureBox.Height && ballPictureBox.Location.X >= paddlePictureBox.Location.X
                && ballPictureBox.Location.X <= (paddlePictureBox.Location.X + paddlePictureBox.Width)
                )
            {
                _directionY = "NORTH";
            }
            if (ballPictureBox.Location.Y >= this.ClientSize.Height - ballPictureBox.Height &&
                ballPictureBox.Location.X < (paddlePictureBox.Location.X + ballPictureBox.Width)
                || ballPictureBox.Location.Y >= this.ClientSize.Height - ballPictureBox.Height &&
                ballPictureBox.Location.X > (paddlePictureBox.Location.X + paddlePictureBox.Width))
            {
                _timer.Stop();
                _timer.Dispose();
                MessageBox.Show($"Game Over,\n Your score is {0}");
            }
            for (int i = 0; i < _tilesList.Count(); i++)
            {
                if (!_tilesList[i].IsHit)
                {
                    if (ballPictureBox.Location.Y >= (_tilesList[i].TilePictureBox.Location.Y)
                        && ballPictureBox.Location.Y <= (_tilesList[i].TilePictureBox.Location.Y + _tilesList[i].TilePictureBox.Height)
                        && ballPictureBox.Location.X >= _tilesList[i].TilePictureBox.Location.X
                        && ballPictureBox.Location.X <= (_tilesList[i].TilePictureBox.Location.X + _tilesList[i].TilePictureBox.Width)
                         )
                    {
                        _score++;
                        _directionY = "SOUTH";
                        _tilesList[i].IsHit = true;
                        _tilesList[i].TilePictureBox.Visible = false;
                        _tilesList.RemoveAt(i);
                    }
                }

            }

        }

        private void InitialValues()
        {
            GenerateNewTiles(_level);
        }
        private void BallMovementHandler()
        {
            if (_directionX == "EAST")
            {
                ballPictureBox.Location = new Point(ballPictureBox.Location.X + _ballSpeed, ballPictureBox.Location.Y);
            }
            else
            {
                ballPictureBox.Location = new Point(ballPictureBox.Location.X - _ballSpeed, ballPictureBox.Location.Y);
            }
            if (_directionY == "SOUTH")
            {
                ballPictureBox.Location = new Point(ballPictureBox.Location.X, ballPictureBox.Location.Y + _ballSpeed);
            }
            else
            {
                ballPictureBox.Location = new Point(ballPictureBox.Location.X, ballPictureBox.Location.Y - _ballSpeed);
            }
        }

        private void GenerateNewTiles(int level)
        {
            for (int i = 0; i < level; i++)
            {
                int j = 0;
                while (_tilesList.Count == 0 || (_tilesList[_tilesList.Count() - 1].TilePictureBox.Location.X + (_tilesList[_tilesList.Count() - 1].TilePictureBox.Width * 2) + 20) < this.ClientSize.Width)
                {
                    PictureBox tilePictureBox = new PictureBox();
                    tilePictureBox.BackColor = SystemColors.ControlDark;
                    tilePictureBox.Name = $"pictureBox{_tilesList.Count()}";
                    tilePictureBox.Size = new Size(100, 13);
                    tilePictureBox.Location = new Point(_tilesList.Count > 0 ? _tilesList[_tilesList.Count() - 1].TilePictureBox.Location.X + tilePictureBox.Width + 20 : 100, 12);
                    tilePictureBox.TabIndex = 2;
                    tilePictureBox.TabStop = false;
                    this.Controls.Add(tilePictureBox);
                    Tiles tile = new Tiles();
                    tile.IsHit = false;
                    tile.TilePictureBox = tilePictureBox;
                    _tilesList.Add(tile);
                }
            }
        }

        private void ballPictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}
