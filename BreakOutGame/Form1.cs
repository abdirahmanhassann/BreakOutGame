using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace BreakOutGame
{
    public partial class Form1 : Form
    {
        private string _directionX = "EAST";
        private string _directionY = "SOUTH";
        private int _score = 0;
        private int _level = 1;
        private int _ballSpeed = 1;
        private int _refreshRate = 1;
        private bool _levelChange = false;
        private int _hitInLevel = 0;
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
            LevelChecker();
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
                    //if (ballPictureBox.Location.Y >= (_tilesList[i].TilePictureBox.Location.Y)
                    //    && ballPictureBox.Location.Y <= (_tilesList[i].TilePictureBox.Location.Y + _tilesList[i].TilePictureBox.Height)
                    //    && ballPictureBox.Location.X >= _tilesList[i].TilePictureBox.Location.X
                    //    && ballPictureBox.Location.X <= (_tilesList[i].TilePictureBox.Location.X + _tilesList[i].TilePictureBox.Width)
                    //     )
                    if (ballPictureBox.Location.Y == (_tilesList[i].TilePictureBox.Location.Y + _tilesList[i].TilePictureBox.Height)
                        && ballPictureBox.Location.X + ballPictureBox.Width >= _tilesList[i].TilePictureBox.Location.X
                        && ballPictureBox.Location.X <= (_tilesList[i].TilePictureBox.Location.X + _tilesList[i].TilePictureBox.Width)
                        && _tilesList[i].IsHit == false
                        )
                    {
                        _score++;
                        _hitInLevel++;
                        _directionY = "SOUTH";
                        _tilesList[i].IsHit = true;
                        _tilesList[i].TilePictureBox.Visible = false;
                        //  _tilesList.RemoveAt(i);
                    }
                    else if ((ballPictureBox.Location.Y + ballPictureBox.Height) == _tilesList[i].TilePictureBox.Location.Y
                       && ballPictureBox.Location.X + ballPictureBox.Width >= _tilesList[i].TilePictureBox.Location.X
                       && ballPictureBox.Location.X <= (_tilesList[i].TilePictureBox.Location.X + _tilesList[i].TilePictureBox.Width)
                       && _tilesList[i].IsHit == false
                       )
                    {
                        _score++;
                        _hitInLevel++;
                        _directionY = "NORTH";
                        _tilesList[i].IsHit = true;
                        _tilesList[i].TilePictureBox.Visible = false;
                     //   _tilesList.RemoveAt(i);
                    }
                    else if (ballPictureBox.Location.X == (_tilesList[i].TilePictureBox.Location.X + _tilesList[i].TilePictureBox.Width)
                       && ballPictureBox.Location.Y + ballPictureBox.Height >= _tilesList[i].TilePictureBox.Location.Y
                       && ballPictureBox.Location.Y <= (_tilesList[i].TilePictureBox.Location.Y + _tilesList[i].TilePictureBox.Height)
                       && _tilesList[i].IsHit == false
                       )
                    {
                        _score++;
                        _hitInLevel++;
                        _directionX = "EAST";
                        _tilesList[i].IsHit = true;
                        _tilesList[i].TilePictureBox.Visible = false;
                     //   _tilesList.RemoveAt(i);
                    }
                    else if ( (ballPictureBox.Location.X + ballPictureBox.Width) == _tilesList[i].TilePictureBox.Location.X
                       && ballPictureBox.Location.Y + ballPictureBox.Height >= _tilesList[i].TilePictureBox.Location.Y
                       && ballPictureBox.Location.Y <= (_tilesList[i].TilePictureBox.Location.Y + _tilesList[i].TilePictureBox.Height)
                       && _tilesList[i].IsHit == false
                       )
                    {
                        _score++;
                        _hitInLevel++;
                        _directionX = "WEST";
                        _tilesList[i].IsHit = true;
                        _tilesList[i].TilePictureBox.Visible = false;
                     //   _tilesList.RemoveAt(i);
                    }

                }

            }

        }

        private void InitialValues()
        {
            GenerateNewTiles();
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

        private void GenerateNewTiles()
        {
            for (int i = 0; i < _level; i++)
            {
                int j = 0;
                while (_tilesList.Count == 0 || (_tilesList[_tilesList.Count() - 1].TilePictureBox.Location.X + (_tilesList[_tilesList.Count() - 1].TilePictureBox.Width ) + 100) < this.ClientSize.Width
                    || _levelChange == true
                    )
                {
                    PictureBox tilePictureBox = new PictureBox();
                    tilePictureBox.BackColor = SystemColors.ControlDark;
                    tilePictureBox.Name = $"pictureBox{_tilesList.Count}";
                    tilePictureBox.Size = new Size(100, 14);
                    tilePictureBox.Location = new Point(_tilesList.Count % 5 != 0 ? _tilesList[_tilesList.Count() - 1].TilePictureBox.Location.X + ballPictureBox.Width + 150 : 30, 96 * _level);
                    tilePictureBox.TabIndex = 2;
                    tilePictureBox.TabStop = false;
                    this.Controls.Add(tilePictureBox);
                    Tiles tile = new Tiles();
                    tile.IsHit = false;
                    tile.TilePictureBox = tilePictureBox;
                    _tilesList.Add(tile);
                    _levelChange = false;
                }
            }
        }
        private void LevelChecker()
        {
            if(_hitInLevel == _tilesList.Count)
            {
                _level++;
                foreach(Tiles tile in _tilesList)
                {
                    tile.IsHit = false;
                    _levelChange = true;
                    tile.TilePictureBox.Visible = true;
                    
                }
                GenerateNewTiles();
                _hitInLevel = 0;
            }
        }

        private void ballPictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}
