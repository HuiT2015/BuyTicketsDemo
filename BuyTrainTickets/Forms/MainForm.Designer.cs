namespace BuyTrainTickets.Forms
{
    partial class MainForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonQuery = new System.Windows.Forms.Button();
            this.checkBoxAutoSubmit = new System.Windows.Forms.CheckBox();
            this.checkBoxYZ = new System.Windows.Forms.CheckBox();
            this.checkBoxYW = new System.Windows.Forms.CheckBox();
            this.textBoxAlternativeDate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxPassenger = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBoxTypeOther = new System.Windows.Forms.CheckBox();
            this.checkBoxTypeD = new System.Windows.Forms.CheckBox();
            this.checkBoxTypeGC = new System.Windows.Forms.CheckBox();
            this.checkBoxTypeK = new System.Windows.Forms.CheckBox();
            this.checkBoxTypeT = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxTypeZ = new System.Windows.Forms.CheckBox();
            this.comboBoxTimePeriod = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerStartOff = new System.Windows.Forms.DateTimePicker();
            this.comboBoxEndStation = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxStartStation = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.buttonQuery);
            this.groupBox1.Controls.Add(this.checkBoxAutoSubmit);
            this.groupBox1.Controls.Add(this.checkBoxYZ);
            this.groupBox1.Controls.Add(this.checkBoxYW);
            this.groupBox1.Controls.Add(this.textBoxAlternativeDate);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBoxPassenger);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.checkBoxTypeOther);
            this.groupBox1.Controls.Add(this.checkBoxTypeD);
            this.groupBox1.Controls.Add(this.checkBoxTypeGC);
            this.groupBox1.Controls.Add(this.checkBoxTypeK);
            this.groupBox1.Controls.Add(this.checkBoxTypeT);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.checkBoxTypeZ);
            this.groupBox1.Controls.Add(this.comboBoxTimePeriod);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dateTimePickerStartOff);
            this.groupBox1.Controls.Add(this.comboBoxEndStation);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxStartStation);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1022, 240);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件：";
            // 
            // buttonQuery
            // 
            this.buttonQuery.Location = new System.Drawing.Point(815, 197);
            this.buttonQuery.Name = "buttonQuery";
            this.buttonQuery.Size = new System.Drawing.Size(75, 23);
            this.buttonQuery.TabIndex = 24;
            this.buttonQuery.Text = "查询";
            this.buttonQuery.UseVisualStyleBackColor = true;
            this.buttonQuery.Click += new System.EventHandler(this.buttonQuery_Click);
            // 
            // checkBoxAutoSubmit
            // 
            this.checkBoxAutoSubmit.AutoSize = true;
            this.checkBoxAutoSubmit.Location = new System.Drawing.Point(919, 201);
            this.checkBoxAutoSubmit.Name = "checkBoxAutoSubmit";
            this.checkBoxAutoSubmit.Size = new System.Drawing.Size(72, 16);
            this.checkBoxAutoSubmit.TabIndex = 23;
            this.checkBoxAutoSubmit.Text = "自动提交";
            this.checkBoxAutoSubmit.UseVisualStyleBackColor = true;
            // 
            // checkBoxYZ
            // 
            this.checkBoxYZ.AutoSize = true;
            this.checkBoxYZ.Location = new System.Drawing.Point(173, 152);
            this.checkBoxYZ.Name = "checkBoxYZ";
            this.checkBoxYZ.Size = new System.Drawing.Size(48, 16);
            this.checkBoxYZ.TabIndex = 22;
            this.checkBoxYZ.Text = "硬座";
            this.checkBoxYZ.UseVisualStyleBackColor = true;
            // 
            // checkBoxYW
            // 
            this.checkBoxYW.AutoSize = true;
            this.checkBoxYW.Location = new System.Drawing.Point(101, 152);
            this.checkBoxYW.Name = "checkBoxYW";
            this.checkBoxYW.Size = new System.Drawing.Size(48, 16);
            this.checkBoxYW.TabIndex = 21;
            this.checkBoxYW.Text = "硬卧";
            this.checkBoxYW.UseVisualStyleBackColor = true;
            // 
            // textBoxAlternativeDate
            // 
            this.textBoxAlternativeDate.Location = new System.Drawing.Point(101, 196);
            this.textBoxAlternativeDate.Name = "textBoxAlternativeDate";
            this.textBoxAlternativeDate.Size = new System.Drawing.Size(185, 21);
            this.textBoxAlternativeDate.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 200);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 19;
            this.label8.Text = "备选日期:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "优先席位:";
            // 
            // textBoxPassenger
            // 
            this.textBoxPassenger.Location = new System.Drawing.Point(101, 105);
            this.textBoxPassenger.Name = "textBoxPassenger";
            this.textBoxPassenger.Size = new System.Drawing.Size(185, 21);
            this.textBoxPassenger.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "乘车人:";
            // 
            // checkBoxTypeOther
            // 
            this.checkBoxTypeOther.AutoSize = true;
            this.checkBoxTypeOther.Location = new System.Drawing.Point(583, 68);
            this.checkBoxTypeOther.Name = "checkBoxTypeOther";
            this.checkBoxTypeOther.Size = new System.Drawing.Size(48, 16);
            this.checkBoxTypeOther.TabIndex = 14;
            this.checkBoxTypeOther.Text = "其他";
            this.checkBoxTypeOther.UseVisualStyleBackColor = true;
            // 
            // checkBoxTypeD
            // 
            this.checkBoxTypeD.AutoSize = true;
            this.checkBoxTypeD.Location = new System.Drawing.Point(226, 67);
            this.checkBoxTypeD.Name = "checkBoxTypeD";
            this.checkBoxTypeD.Size = new System.Drawing.Size(60, 16);
            this.checkBoxTypeD.TabIndex = 13;
            this.checkBoxTypeD.Text = "D-动车";
            this.checkBoxTypeD.UseVisualStyleBackColor = true;
            // 
            // checkBoxTypeGC
            // 
            this.checkBoxTypeGC.AutoSize = true;
            this.checkBoxTypeGC.Location = new System.Drawing.Point(101, 66);
            this.checkBoxTypeGC.Name = "checkBoxTypeGC";
            this.checkBoxTypeGC.Size = new System.Drawing.Size(96, 16);
            this.checkBoxTypeGC.TabIndex = 12;
            this.checkBoxTypeGC.Text = "GC-高铁/城际";
            this.checkBoxTypeGC.UseVisualStyleBackColor = true;
            // 
            // checkBoxTypeK
            // 
            this.checkBoxTypeK.AutoSize = true;
            this.checkBoxTypeK.Location = new System.Drawing.Point(497, 68);
            this.checkBoxTypeK.Name = "checkBoxTypeK";
            this.checkBoxTypeK.Size = new System.Drawing.Size(60, 16);
            this.checkBoxTypeK.TabIndex = 11;
            this.checkBoxTypeK.Text = "K-快速";
            this.checkBoxTypeK.UseVisualStyleBackColor = true;
            // 
            // checkBoxTypeT
            // 
            this.checkBoxTypeT.AutoSize = true;
            this.checkBoxTypeT.Location = new System.Drawing.Point(412, 67);
            this.checkBoxTypeT.Name = "checkBoxTypeT";
            this.checkBoxTypeT.Size = new System.Drawing.Size(60, 16);
            this.checkBoxTypeT.TabIndex = 10;
            this.checkBoxTypeT.Text = "T-特快";
            this.checkBoxTypeT.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "车次类型:";
            // 
            // checkBoxTypeZ
            // 
            this.checkBoxTypeZ.AutoSize = true;
            this.checkBoxTypeZ.Location = new System.Drawing.Point(317, 67);
            this.checkBoxTypeZ.Name = "checkBoxTypeZ";
            this.checkBoxTypeZ.Size = new System.Drawing.Size(60, 16);
            this.checkBoxTypeZ.TabIndex = 8;
            this.checkBoxTypeZ.Text = "Z-直达";
            this.checkBoxTypeZ.UseVisualStyleBackColor = true;
            // 
            // comboBoxTimePeriod
            // 
            this.comboBoxTimePeriod.FormattingEnabled = true;
            this.comboBoxTimePeriod.Location = new System.Drawing.Point(870, 28);
            this.comboBoxTimePeriod.Name = "comboBoxTimePeriod";
            this.comboBoxTimePeriod.Size = new System.Drawing.Size(121, 20);
            this.comboBoxTimePeriod.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(813, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "时间段:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(503, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "日期：";
            // 
            // dateTimePickerStartOff
            // 
            this.dateTimePickerStartOff.Location = new System.Drawing.Point(559, 29);
            this.dateTimePickerStartOff.Name = "dateTimePickerStartOff";
            this.dateTimePickerStartOff.Size = new System.Drawing.Size(200, 21);
            this.dateTimePickerStartOff.TabIndex = 4;
            // 
            // comboBoxEndStation
            // 
            this.comboBoxEndStation.FormattingEnabled = true;
            this.comboBoxEndStation.Location = new System.Drawing.Point(317, 28);
            this.comboBoxEndStation.Name = "comboBoxEndStation";
            this.comboBoxEndStation.Size = new System.Drawing.Size(133, 20);
            this.comboBoxEndStation.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(252, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "终点站:";
            // 
            // comboBoxStartStation
            // 
            this.comboBoxStartStation.FormattingEnabled = true;
            this.comboBoxStartStation.Location = new System.Drawing.Point(88, 27);
            this.comboBoxStartStation.Name = "comboBoxStartStation";
            this.comboBoxStartStation.Size = new System.Drawing.Size(133, 20);
            this.comboBoxStartStation.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "起始站:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listView1);
            this.groupBox2.Location = new System.Drawing.Point(13, 260);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1022, 431);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "车次信息：";
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(3, 17);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1016, 411);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(316, 151);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(48, 16);
            this.checkBox1.TabIndex = 26;
            this.checkBox1.Text = "软座";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(246, 152);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(48, 16);
            this.checkBox2.TabIndex = 25;
            this.checkBox2.Text = "软卧";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 703);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "12306抢票";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxStartStation;
        private System.Windows.Forms.ComboBox comboBoxEndStation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartOff;
        private System.Windows.Forms.ComboBox comboBoxTimePeriod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBoxTypeZ;
        private System.Windows.Forms.CheckBox checkBoxTypeT;
        private System.Windows.Forms.CheckBox checkBoxTypeK;
        private System.Windows.Forms.CheckBox checkBoxTypeOther;
        private System.Windows.Forms.CheckBox checkBoxTypeD;
        private System.Windows.Forms.CheckBox checkBoxTypeGC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxPassenger;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxAlternativeDate;
        private System.Windows.Forms.CheckBox checkBoxYZ;
        private System.Windows.Forms.CheckBox checkBoxYW;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.CheckBox checkBoxAutoSubmit;
        private System.Windows.Forms.Button buttonQuery;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
    }
}