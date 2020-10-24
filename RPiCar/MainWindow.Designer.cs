namespace RPiCar
{
    partial class MainWindow
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.trackBarSpeed = new System.Windows.Forms.TrackBar();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.buttonForward = new System.Windows.Forms.Button();
            this.buttonBackward = new System.Windows.Forms.Button();
            this.buttonLeftTurn = new System.Windows.Forms.Button();
            this.buttonRightTurn = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.checkBoxN1 = new System.Windows.Forms.CheckBox();
            this.checkBoxN2 = new System.Windows.Forms.CheckBox();
            this.checkBoxN3 = new System.Windows.Forms.CheckBox();
            this.checkBoxN4 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTurnSpeed1 = new System.Windows.Forms.Label();
            this.labelTurnSpeed = new System.Windows.Forms.Label();
            this.trackBarTurnSpeed = new System.Windows.Forms.TrackBar();
            this.labelServoVal = new System.Windows.Forms.Label();
            this.trackBarServo = new System.Windows.Forms.TrackBar();
            this.labelServo = new System.Windows.Forms.Label();
            this.trackBarENA1 = new System.Windows.Forms.TrackBar();
            this.trackBarENA2 = new System.Windows.Forms.TrackBar();
            this.labelENA1 = new System.Windows.Forms.Label();
            this.labelENA2 = new System.Windows.Forms.Label();
            this.labelENA1Value = new System.Windows.Forms.Label();
            this.labelENA2Value = new System.Windows.Forms.Label();
            this.listBoxKey = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTurnSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarServo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarENA1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarENA2)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarSpeed
            // 
            this.trackBarSpeed.Location = new System.Drawing.Point(11, 30);
            this.trackBarSpeed.Maximum = 100;
            this.trackBarSpeed.Name = "trackBarSpeed";
            this.trackBarSpeed.Size = new System.Drawing.Size(147, 45);
            this.trackBarSpeed.TabIndex = 4;
            this.trackBarSpeed.Scroll += new System.EventHandler(this.trackBarSpeed_Scroll);
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Location = new System.Drawing.Point(77, 65);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(13, 13);
            this.labelSpeed.TabIndex = 5;
            this.labelSpeed.Text = "0";
            // 
            // buttonForward
            // 
            this.buttonForward.Location = new System.Drawing.Point(92, 81);
            this.buttonForward.Name = "buttonForward";
            this.buttonForward.Size = new System.Drawing.Size(75, 74);
            this.buttonForward.TabIndex = 9;
            this.buttonForward.TabStop = false;
            this.buttonForward.Text = "Forward";
            this.buttonForward.UseVisualStyleBackColor = true;
            this.buttonForward.Click += new System.EventHandler(this.buttonForward_Click);
            // 
            // buttonBackward
            // 
            this.buttonBackward.Location = new System.Drawing.Point(92, 161);
            this.buttonBackward.Name = "buttonBackward";
            this.buttonBackward.Size = new System.Drawing.Size(75, 74);
            this.buttonBackward.TabIndex = 10;
            this.buttonBackward.TabStop = false;
            this.buttonBackward.Text = "Backward";
            this.buttonBackward.UseVisualStyleBackColor = true;
            this.buttonBackward.Click += new System.EventHandler(this.buttonBackward_Click);
            // 
            // buttonLeftTurn
            // 
            this.buttonLeftTurn.Location = new System.Drawing.Point(11, 161);
            this.buttonLeftTurn.Name = "buttonLeftTurn";
            this.buttonLeftTurn.Size = new System.Drawing.Size(75, 74);
            this.buttonLeftTurn.TabIndex = 11;
            this.buttonLeftTurn.TabStop = false;
            this.buttonLeftTurn.Text = "Left Turn";
            this.buttonLeftTurn.UseVisualStyleBackColor = true;
            this.buttonLeftTurn.Click += new System.EventHandler(this.buttonLeftTurn_Click);
            // 
            // buttonRightTurn
            // 
            this.buttonRightTurn.Location = new System.Drawing.Point(173, 161);
            this.buttonRightTurn.Name = "buttonRightTurn";
            this.buttonRightTurn.Size = new System.Drawing.Size(75, 74);
            this.buttonRightTurn.TabIndex = 12;
            this.buttonRightTurn.TabStop = false;
            this.buttonRightTurn.Text = "Right Turn";
            this.buttonRightTurn.UseVisualStyleBackColor = true;
            this.buttonRightTurn.Click += new System.EventHandler(this.buttonRightTurn_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(173, 81);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 74);
            this.buttonStop.TabIndex = 13;
            this.buttonStop.TabStop = false;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // checkBoxN1
            // 
            this.checkBoxN1.AutoSize = true;
            this.checkBoxN1.Location = new System.Drawing.Point(437, 111);
            this.checkBoxN1.Name = "checkBoxN1";
            this.checkBoxN1.Size = new System.Drawing.Size(40, 17);
            this.checkBoxN1.TabIndex = 14;
            this.checkBoxN1.Text = "N1";
            this.checkBoxN1.UseVisualStyleBackColor = true;
            this.checkBoxN1.CheckedChanged += new System.EventHandler(this.checkBoxN_CheckedChanged);
            // 
            // checkBoxN2
            // 
            this.checkBoxN2.AutoSize = true;
            this.checkBoxN2.Location = new System.Drawing.Point(437, 134);
            this.checkBoxN2.Name = "checkBoxN2";
            this.checkBoxN2.Size = new System.Drawing.Size(40, 17);
            this.checkBoxN2.TabIndex = 15;
            this.checkBoxN2.Text = "N2";
            this.checkBoxN2.UseVisualStyleBackColor = true;
            this.checkBoxN2.CheckedChanged += new System.EventHandler(this.checkBoxN_CheckedChanged);
            // 
            // checkBoxN3
            // 
            this.checkBoxN3.AutoSize = true;
            this.checkBoxN3.Location = new System.Drawing.Point(437, 157);
            this.checkBoxN3.Name = "checkBoxN3";
            this.checkBoxN3.Size = new System.Drawing.Size(40, 17);
            this.checkBoxN3.TabIndex = 16;
            this.checkBoxN3.Text = "N3";
            this.checkBoxN3.UseVisualStyleBackColor = true;
            this.checkBoxN3.CheckedChanged += new System.EventHandler(this.checkBoxN_CheckedChanged);
            // 
            // checkBoxN4
            // 
            this.checkBoxN4.AutoSize = true;
            this.checkBoxN4.Location = new System.Drawing.Point(437, 180);
            this.checkBoxN4.Name = "checkBoxN4";
            this.checkBoxN4.Size = new System.Drawing.Size(40, 17);
            this.checkBoxN4.TabIndex = 17;
            this.checkBoxN4.Text = "N4";
            this.checkBoxN4.UseVisualStyleBackColor = true;
            this.checkBoxN4.CheckedChanged += new System.EventHandler(this.checkBoxN_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Vitesse:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(419, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Controller test";
            // 
            // labelTurnSpeed1
            // 
            this.labelTurnSpeed1.AutoSize = true;
            this.labelTurnSpeed1.Location = new System.Drawing.Point(198, 11);
            this.labelTurnSpeed1.Name = "labelTurnSpeed1";
            this.labelTurnSpeed1.Size = new System.Drawing.Size(66, 13);
            this.labelTurnSpeed1.TabIndex = 20;
            this.labelTurnSpeed1.Text = "Turn Speed:";
            // 
            // labelTurnSpeed
            // 
            this.labelTurnSpeed.AutoSize = true;
            this.labelTurnSpeed.Location = new System.Drawing.Point(228, 59);
            this.labelTurnSpeed.Name = "labelTurnSpeed";
            this.labelTurnSpeed.Size = new System.Drawing.Size(13, 13);
            this.labelTurnSpeed.TabIndex = 22;
            this.labelTurnSpeed.Text = "0";
            // 
            // trackBarTurnSpeed
            // 
            this.trackBarTurnSpeed.Location = new System.Drawing.Point(164, 27);
            this.trackBarTurnSpeed.Name = "trackBarTurnSpeed";
            this.trackBarTurnSpeed.Size = new System.Drawing.Size(147, 45);
            this.trackBarTurnSpeed.TabIndex = 21;
            this.trackBarTurnSpeed.Scroll += new System.EventHandler(this.trackBarTurnSpeed_Scroll);
            // 
            // labelServoVal
            // 
            this.labelServoVal.AutoSize = true;
            this.labelServoVal.Location = new System.Drawing.Point(381, 59);
            this.labelServoVal.Name = "labelServoVal";
            this.labelServoVal.Size = new System.Drawing.Size(13, 13);
            this.labelServoVal.TabIndex = 25;
            this.labelServoVal.Text = "0";
            // 
            // trackBarServo
            // 
            this.trackBarServo.Location = new System.Drawing.Point(317, 27);
            this.trackBarServo.Name = "trackBarServo";
            this.trackBarServo.Size = new System.Drawing.Size(147, 45);
            this.trackBarServo.TabIndex = 24;
            this.trackBarServo.Scroll += new System.EventHandler(this.trackBarServo_Scroll);
            // 
            // labelServo
            // 
            this.labelServo.AutoSize = true;
            this.labelServo.Location = new System.Drawing.Point(351, 11);
            this.labelServo.Name = "labelServo";
            this.labelServo.Size = new System.Drawing.Size(83, 13);
            this.labelServo.TabIndex = 23;
            this.labelServo.Text = "Servo Direction:";
            // 
            // trackBarENA1
            // 
            this.trackBarENA1.Location = new System.Drawing.Point(266, 95);
            this.trackBarENA1.Maximum = 100;
            this.trackBarENA1.Name = "trackBarENA1";
            this.trackBarENA1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarENA1.Size = new System.Drawing.Size(45, 147);
            this.trackBarENA1.TabIndex = 26;
            this.trackBarENA1.Scroll += new System.EventHandler(this.trackBarENA1_Scroll);
            this.trackBarENA1.ValueChanged += new System.EventHandler(this.trackBarENA1_ValueChanged);
            // 
            // trackBarENA2
            // 
            this.trackBarENA2.Location = new System.Drawing.Point(349, 95);
            this.trackBarENA2.Maximum = 100;
            this.trackBarENA2.Name = "trackBarENA2";
            this.trackBarENA2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarENA2.Size = new System.Drawing.Size(45, 147);
            this.trackBarENA2.TabIndex = 27;
            this.trackBarENA2.Scroll += new System.EventHandler(this.trackBarENA2_Scroll);
            this.trackBarENA2.ValueChanged += new System.EventHandler(this.trackBarENA2_ValueChanged);
            // 
            // labelENA1
            // 
            this.labelENA1.AutoSize = true;
            this.labelENA1.Location = new System.Drawing.Point(263, 81);
            this.labelENA1.Name = "labelENA1";
            this.labelENA1.Size = new System.Drawing.Size(35, 13);
            this.labelENA1.TabIndex = 28;
            this.labelENA1.Text = "ENA1";
            // 
            // labelENA2
            // 
            this.labelENA2.AutoSize = true;
            this.labelENA2.Location = new System.Drawing.Point(346, 81);
            this.labelENA2.Name = "labelENA2";
            this.labelENA2.Size = new System.Drawing.Size(35, 13);
            this.labelENA2.TabIndex = 29;
            this.labelENA2.Text = "ENA2";
            // 
            // labelENA1Value
            // 
            this.labelENA1Value.AutoSize = true;
            this.labelENA1Value.Location = new System.Drawing.Point(272, 236);
            this.labelENA1Value.Name = "labelENA1Value";
            this.labelENA1Value.Size = new System.Drawing.Size(13, 13);
            this.labelENA1Value.TabIndex = 30;
            this.labelENA1Value.Text = "0";
            // 
            // labelENA2Value
            // 
            this.labelENA2Value.AutoSize = true;
            this.labelENA2Value.Location = new System.Drawing.Point(356, 236);
            this.labelENA2Value.Name = "labelENA2Value";
            this.labelENA2Value.Size = new System.Drawing.Size(13, 13);
            this.labelENA2Value.TabIndex = 31;
            this.labelENA2Value.Text = "0";
            // 
            // listBoxKey
            // 
            this.listBoxKey.FormattingEnabled = true;
            this.listBoxKey.Location = new System.Drawing.Point(11, 269);
            this.listBoxKey.Name = "listBoxKey";
            this.listBoxKey.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listBoxKey.Size = new System.Drawing.Size(490, 108);
            this.listBoxKey.TabIndex = 32;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 399);
            this.Controls.Add(this.listBoxKey);
            this.Controls.Add(this.labelENA2Value);
            this.Controls.Add(this.labelENA1Value);
            this.Controls.Add(this.labelENA2);
            this.Controls.Add(this.labelENA1);
            this.Controls.Add(this.trackBarENA2);
            this.Controls.Add(this.trackBarENA1);
            this.Controls.Add(this.labelServoVal);
            this.Controls.Add(this.trackBarServo);
            this.Controls.Add(this.labelServo);
            this.Controls.Add(this.labelTurnSpeed);
            this.Controls.Add(this.trackBarTurnSpeed);
            this.Controls.Add(this.labelTurnSpeed1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBoxN4);
            this.Controls.Add(this.checkBoxN3);
            this.Controls.Add(this.checkBoxN2);
            this.Controls.Add(this.checkBoxN1);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonLeftTurn);
            this.Controls.Add(this.buttonBackward);
            this.Controls.Add(this.buttonForward);
            this.Controls.Add(this.labelSpeed);
            this.Controls.Add(this.trackBarSpeed);
            this.Controls.Add(this.buttonRightTurn);
            this.KeyPreview = true;
            this.Name = "MainWindow";
            this.Text = "Car Controller";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTurnSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarServo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarENA1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarENA2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TrackBar trackBarSpeed;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.Button buttonForward;
        private System.Windows.Forms.Button buttonBackward;
        private System.Windows.Forms.Button buttonLeftTurn;
        private System.Windows.Forms.Button buttonRightTurn;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.CheckBox checkBoxN1;
        private System.Windows.Forms.CheckBox checkBoxN2;
        private System.Windows.Forms.CheckBox checkBoxN3;
        private System.Windows.Forms.CheckBox checkBoxN4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTurnSpeed1;
        private System.Windows.Forms.Label labelTurnSpeed;
        private System.Windows.Forms.TrackBar trackBarTurnSpeed;
        private System.Windows.Forms.Label labelServoVal;
        private System.Windows.Forms.TrackBar trackBarServo;
        private System.Windows.Forms.Label labelServo;
        private System.Windows.Forms.TrackBar trackBarENA1;
        private System.Windows.Forms.TrackBar trackBarENA2;
        private System.Windows.Forms.Label labelENA1;
        private System.Windows.Forms.Label labelENA2;
        private System.Windows.Forms.Label labelENA1Value;
        private System.Windows.Forms.Label labelENA2Value;
        private System.Windows.Forms.ListBox listBoxKey;
    }
}

