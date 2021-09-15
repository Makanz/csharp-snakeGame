
namespace SnakeGame
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.startButton = new System.Windows.Forms.Button();
            this.snapButton = new System.Windows.Forms.Button();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.txtScore = new System.Windows.Forms.Label();
            this.txtHighscore = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(608, 12);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(126, 57);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartGame);
            // 
            // snapButton
            // 
            this.snapButton.Location = new System.Drawing.Point(608, 75);
            this.snapButton.Name = "snapButton";
            this.snapButton.Size = new System.Drawing.Size(126, 57);
            this.snapButton.TabIndex = 0;
            this.snapButton.Text = "Snap";
            this.snapButton.UseVisualStyleBackColor = true;
            this.snapButton.Click += new System.EventHandler(this.TakeSnapShot);
            // 
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.Color.Silver;
            this.picCanvas.Location = new System.Drawing.Point(13, 12);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(589, 693);
            this.picCanvas.TabIndex = 1;
            this.picCanvas.TabStop = false;
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.UpdatePictureBoxGfx);
            // 
            // txtScore
            // 
            this.txtScore.AutoSize = true;
            this.txtScore.Location = new System.Drawing.Point(608, 147);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(52, 15);
            this.txtScore.TabIndex = 2;
            this.txtScore.Text = "Score: 0";
            // 
            // txtHighscore
            // 
            this.txtHighscore.AutoSize = true;
            this.txtHighscore.Location = new System.Drawing.Point(608, 182);
            this.txtHighscore.Name = "txtHighscore";
            this.txtHighscore.Size = new System.Drawing.Size(68, 15);
            this.txtHighscore.TabIndex = 2;
            this.txtHighscore.Text = "High Score";
            // 
            // gameTimer
            // 
            this.gameTimer.Tick += new System.EventHandler(this.GameTimerEvent);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 717);
            this.Controls.Add(this.txtHighscore);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.snapButton);
            this.Controls.Add(this.startButton);
            this.Name = "Form1";
            this.Text = "Classic Snakes Game";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button snapButton;
        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.Label txtHighscore;
        private System.Windows.Forms.Timer gameTimer;
    }
}

