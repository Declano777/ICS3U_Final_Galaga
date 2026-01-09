namespace ICS3U_Final_Galaga
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.alianTimer2 = new System.Windows.Forms.Timer(this.components);
            this.starLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.titelLabel = new System.Windows.Forms.Label();
            this.rulesButton = new System.Windows.Forms.Button();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.alianTimer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 16;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // alianTimer2
            // 
            this.alianTimer2.Interval = 2000;
            this.alianTimer2.Tick += new System.EventHandler(this.alianTimer_Tick);
            // 
            // starLabel
            // 
            this.starLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.starLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.starLabel.Location = new System.Drawing.Point(0, -2);
            this.starLabel.Name = "starLabel";
            this.starLabel.Size = new System.Drawing.Size(803, 455);
            this.starLabel.TabIndex = 0;
            this.starLabel.Text = resources.GetString("starLabel.Text");
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(256, 265);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(276, 29);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // titelLabel
            // 
            this.titelLabel.Font = new System.Drawing.Font("Papyrus", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titelLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.titelLabel.Location = new System.Drawing.Point(217, 67);
            this.titelLabel.Name = "titelLabel";
            this.titelLabel.Size = new System.Drawing.Size(342, 177);
            this.titelLabel.TabIndex = 2;
            this.titelLabel.Text = "Galaga";
            this.titelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rulesButton
            // 
            this.rulesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rulesButton.Location = new System.Drawing.Point(271, 314);
            this.rulesButton.Name = "rulesButton";
            this.rulesButton.Size = new System.Drawing.Size(251, 29);
            this.rulesButton.TabIndex = 3;
            this.rulesButton.Text = "Rules";
            this.rulesButton.UseVisualStyleBackColor = true;
            this.rulesButton.Click += new System.EventHandler(this.rulesButton_Click);
            // 
            // scoreLabel
            // 
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.scoreLabel.Location = new System.Drawing.Point(626, 9);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(162, 48);
            this.scoreLabel.TabIndex = 4;
            this.scoreLabel.Text = "Score: 0";
            this.scoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // alianTimer1
            // 
            this.alianTimer1.Interval = 400;
            this.alianTimer1.Tick += new System.EventHandler(this.alianTimer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.rulesButton);
            this.Controls.Add(this.titelLabel);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.starLabel);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Timer alianTimer2;
        private System.Windows.Forms.Label starLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label titelLabel;
        private System.Windows.Forms.Button rulesButton;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Timer alianTimer1;
    }
}

