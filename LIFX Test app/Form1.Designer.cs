namespace Lifx_Test_app
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
            this.button1 = new System.Windows.Forms.Button();
            this.mBulbIPTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.mPowerStateOnCB = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mTargetMACTB = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.mPANControllerTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.mLabelTB = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.mTagsTB = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.mBulbColorP = new System.Windows.Forms.Panel();
            this.button10 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.mKelvinTB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.mFadeTimeTB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.mDimLevelTB = new System.Windows.Forms.TextBox();
            this.button11 = new System.Windows.Forms.Button();
            this.mLightStatusGB = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mTagLevelTB = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.mLabelsGB = new System.Windows.Forms.GroupBox();
            this.mPowerGB = new System.Windows.Forms.GroupBox();
            this.mLightStatusGB.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.mLabelsGB.SuspendLayout();
            this.mPowerGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Find bulb";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mBulbIPTB
            // 
            this.mBulbIPTB.Location = new System.Drawing.Point(99, 41);
            this.mBulbIPTB.Name = "mBulbIPTB";
            this.mBulbIPTB.Size = new System.Drawing.Size(100, 20);
            this.mBulbIPTB.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Bulb IP:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 33);
            this.button2.TabIndex = 4;
            this.button2.Text = "Set power state";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // mPowerStateOnCB
            // 
            this.mPowerStateOnCB.AutoSize = true;
            this.mPowerStateOnCB.Location = new System.Drawing.Point(135, 30);
            this.mPowerStateOnCB.Name = "mPowerStateOnCB";
            this.mPowerStateOnCB.Size = new System.Drawing.Size(40, 17);
            this.mPowerStateOnCB.TabIndex = 5;
            this.mPowerStateOnCB.Text = "On";
            this.mPowerStateOnCB.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Target MAC:";
            // 
            // mTargetMACTB
            // 
            this.mTargetMACTB.Location = new System.Drawing.Point(99, 64);
            this.mTargetMACTB.Name = "mTargetMACTB";
            this.mTargetMACTB.Size = new System.Drawing.Size(100, 20);
            this.mTargetMACTB.TabIndex = 6;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(15, 60);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(114, 33);
            this.button3.TabIndex = 8;
            this.button3.Text = "Toggle";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // mPANControllerTB
            // 
            this.mPANControllerTB.Location = new System.Drawing.Point(99, 89);
            this.mPANControllerTB.Name = "mPANControllerTB";
            this.mPANControllerTB.Size = new System.Drawing.Size(100, 20);
            this.mPANControllerTB.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "PAN controller:";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(26, 33);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 33);
            this.button4.TabIndex = 11;
            this.button4.Text = "Get Label";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(242, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Label:";
            // 
            // mLabelTB
            // 
            this.mLabelTB.Location = new System.Drawing.Point(300, 33);
            this.mLabelTB.Name = "mLabelTB";
            this.mLabelTB.Size = new System.Drawing.Size(100, 20);
            this.mLabelTB.TabIndex = 12;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(107, 33);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(91, 33);
            this.button5.TabIndex = 14;
            this.button5.Text = "Set Label";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(26, 26);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 33);
            this.button6.TabIndex = 15;
            this.button6.Text = "Get Tags";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(211, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Tags:";
            // 
            // mTagsTB
            // 
            this.mTagsTB.Location = new System.Drawing.Point(256, 33);
            this.mTagsTB.Name = "mTagsTB";
            this.mTagsTB.Size = new System.Drawing.Size(100, 20);
            this.mTagsTB.TabIndex = 16;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(107, 26);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 33);
            this.button7.TabIndex = 18;
            this.button7.Text = "Set Tags";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(26, 19);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(94, 33);
            this.button8.TabIndex = 19;
            this.button8.Text = "Get Light status";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(188, 22);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(94, 33);
            this.button9.TabIndex = 20;
            this.button9.Text = "Select color";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // mBulbColorP
            // 
            this.mBulbColorP.Location = new System.Drawing.Point(142, 22);
            this.mBulbColorP.Name = "mBulbColorP";
            this.mBulbColorP.Size = new System.Drawing.Size(40, 69);
            this.mBulbColorP.TabIndex = 21;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(26, 58);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(94, 33);
            this.button10.TabIndex = 22;
            this.button10.Text = "Set Light status";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(339, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Kelvin (1-65536):";
            // 
            // mKelvinTB
            // 
            this.mKelvinTB.Location = new System.Drawing.Point(432, 19);
            this.mKelvinTB.Name = "mKelvinTB";
            this.mKelvinTB.Size = new System.Drawing.Size(100, 20);
            this.mKelvinTB.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(339, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Fade time (MS):";
            // 
            // mFadeTimeTB
            // 
            this.mFadeTimeTB.Location = new System.Drawing.Point(432, 45);
            this.mFadeTimeTB.Name = "mFadeTimeTB";
            this.mFadeTimeTB.Size = new System.Drawing.Size(100, 20);
            this.mFadeTimeTB.TabIndex = 25;
            this.mFadeTimeTB.Text = "4000";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(308, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Dim Level:";
            // 
            // mDimLevelTB
            // 
            this.mDimLevelTB.Location = new System.Drawing.Point(371, 75);
            this.mDimLevelTB.Name = "mDimLevelTB";
            this.mDimLevelTB.Size = new System.Drawing.Size(100, 20);
            this.mDimLevelTB.TabIndex = 27;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(488, 71);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(94, 33);
            this.button11.TabIndex = 29;
            this.button11.Text = "Set Dim level";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // mLightStatusGB
            // 
            this.mLightStatusGB.Controls.Add(this.button8);
            this.mLightStatusGB.Controls.Add(this.button11);
            this.mLightStatusGB.Controls.Add(this.button9);
            this.mLightStatusGB.Controls.Add(this.label8);
            this.mLightStatusGB.Controls.Add(this.mBulbColorP);
            this.mLightStatusGB.Controls.Add(this.mDimLevelTB);
            this.mLightStatusGB.Controls.Add(this.button10);
            this.mLightStatusGB.Controls.Add(this.label7);
            this.mLightStatusGB.Controls.Add(this.mKelvinTB);
            this.mLightStatusGB.Controls.Add(this.mFadeTimeTB);
            this.mLightStatusGB.Controls.Add(this.label6);
            this.mLightStatusGB.Enabled = false;
            this.mLightStatusGB.Location = new System.Drawing.Point(12, 206);
            this.mLightStatusGB.Name = "mLightStatusGB";
            this.mLightStatusGB.Size = new System.Drawing.Size(663, 116);
            this.mLightStatusGB.TabIndex = 30;
            this.mLightStatusGB.TabStop = false;
            this.mLightStatusGB.Text = "Light status";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.mTagLevelTB);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.button7);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.mTagsTB);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 350);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(663, 78);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tags";
            this.groupBox2.Visible = false;
            // 
            // mTagLevelTB
            // 
            this.mTagLevelTB.Location = new System.Drawing.Point(514, 29);
            this.mTagLevelTB.Name = "mTagLevelTB";
            this.mTagLevelTB.Size = new System.Drawing.Size(100, 20);
            this.mTagLevelTB.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(450, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Tag Label:";
            // 
            // mLabelsGB
            // 
            this.mLabelsGB.Controls.Add(this.button4);
            this.mLabelsGB.Controls.Add(this.mLabelTB);
            this.mLabelsGB.Controls.Add(this.label4);
            this.mLabelsGB.Controls.Add(this.button5);
            this.mLabelsGB.Enabled = false;
            this.mLabelsGB.Location = new System.Drawing.Point(12, 119);
            this.mLabelsGB.Name = "mLabelsGB";
            this.mLabelsGB.Size = new System.Drawing.Size(663, 81);
            this.mLabelsGB.TabIndex = 32;
            this.mLabelsGB.TabStop = false;
            this.mLabelsGB.Text = "Labels";
            // 
            // mPowerGB
            // 
            this.mPowerGB.Controls.Add(this.button2);
            this.mPowerGB.Controls.Add(this.mPowerStateOnCB);
            this.mPowerGB.Controls.Add(this.button3);
            this.mPowerGB.Enabled = false;
            this.mPowerGB.Location = new System.Drawing.Point(226, 2);
            this.mPowerGB.Name = "mPowerGB";
            this.mPowerGB.Size = new System.Drawing.Size(449, 111);
            this.mPowerGB.TabIndex = 33;
            this.mPowerGB.TabStop = false;
            this.mPowerGB.Text = "Power";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 440);
            this.Controls.Add(this.mPowerGB);
            this.Controls.Add(this.mLabelsGB);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.mLightStatusGB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mPANControllerTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mTargetMACTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mBulbIPTB);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.mLightStatusGB.ResumeLayout(false);
            this.mLightStatusGB.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.mLabelsGB.ResumeLayout(false);
            this.mLabelsGB.PerformLayout();
            this.mPowerGB.ResumeLayout(false);
            this.mPowerGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox mBulbIPTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox mPowerStateOnCB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox mTargetMACTB;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox mPANControllerTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox mLabelTB;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox mTagsTB;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Panel mBulbColorP;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox mKelvinTB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox mFadeTimeTB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox mDimLevelTB;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.GroupBox mLightStatusGB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox mTagLevelTB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox mLabelsGB;
        private System.Windows.Forms.GroupBox mPowerGB;
    }
}

