namespace BreakOutGame
{
    public partial class Form1 : Form
    {
        private string _directionX = "EAST";
        private string _directionY = "SOUTH";
        private int _score = 0;
        private int _tilesCount;
        private int _ballSpeed = 5;
        private int _refreshRate = 20;
        private System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

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
            if(ballPictureBox.Location.X <= 0)
            {
                _directionX = "EAST";
            }
            if(ballPictureBox.Location.X >= this.ClientSize.Width - ballPictureBox.Width)
            {
                _directionX = "WEST";
            }
            if(ballPictureBox.Location.Y <= 0)
            {
                _directionY = "SOUTH";
            }
            if(ballPictureBox.Location.Y >= paddlePictureBox.Location.Y - ballPictureBox.Height && ballPictureBox.Location.X >= paddlePictureBox.Location.X 
                && ballPictureBox.Location.X <= (paddlePictureBox.Location.X + paddlePictureBox.Width)
                )
            {
                _directionY = "NORTH";
            }
            if(ballPictureBox.Location.Y >=this.ClientSize.Height - ballPictureBox.Height &&
                ballPictureBox.Location.X < (paddlePictureBox.Location.X + ballPictureBox.Width)
                || ballPictureBox.Location.Y >= this.ClientSize.Height - ballPictureBox.Height &&
                ballPictureBox.Location.X > (paddlePictureBox.Location.X + paddlePictureBox.Width))
                {
                _timer.Stop();
                _timer.Dispose();
                MessageBox.Show($"Game Over,\n Your score is {0}");
                }
        }

        private void InitialValues()
        {
            
        }
        private void BallMovementHandler()
        {
            if(_directionX == "EAST")
            {
                ballPictureBox.Location = new Point(ballPictureBox.Location.X + _ballSpeed, ballPictureBox.Location.Y);
            }
            else
            {
                ballPictureBox.Location = new Point(ballPictureBox.Location.X - _ballSpeed, ballPictureBox.Location.Y);
            }
            if(_directionY == "SOUTH")
            {
                ballPictureBox.Location = new Point(ballPictureBox.Location.X, ballPictureBox.Location.Y + _ballSpeed);
            }
            else
            {
                ballPictureBox.Location = new Point(ballPictureBox.Location.X, ballPictureBox.Location.Y - _ballSpeed);
            }
        }

        private void ballPictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}
