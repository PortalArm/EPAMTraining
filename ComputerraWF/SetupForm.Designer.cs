namespace ComputerraWF
{
    partial class SetupForm
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
            this.RowsBox = new System.Windows.Forms.TextBox();
            this.ColsBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tickCountLabel = new System.Windows.Forms.Label();
            this.tickDurationLabel = new System.Windows.Forms.Label();
            this.TickCountBox = new System.Windows.Forms.TextBox();
            this.TickDurationBox = new System.Windows.Forms.TextBox();
            this.colsLabel = new System.Windows.Forms.Label();
            this.rowsLabel = new System.Windows.Forms.Label();
            this.placeholderLabel = new System.Windows.Forms.Label();
            this.PlaceholderBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RowsBox
            // 
            this.RowsBox.Location = new System.Drawing.Point(6, 19);
            this.RowsBox.Name = "RowsBox";
            this.RowsBox.Size = new System.Drawing.Size(32, 20);
            this.RowsBox.TabIndex = 0;
            this.RowsBox.Text = "20";
            // 
            // ColsBox
            // 
            this.ColsBox.Location = new System.Drawing.Point(6, 45);
            this.ColsBox.Name = "ColsBox";
            this.ColsBox.Size = new System.Drawing.Size(32, 20);
            this.ColsBox.TabIndex = 1;
            this.ColsBox.Text = "20";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tickCountLabel);
            this.groupBox1.Controls.Add(this.tickDurationLabel);
            this.groupBox1.Controls.Add(this.TickCountBox);
            this.groupBox1.Controls.Add(this.TickDurationBox);
            this.groupBox1.Controls.Add(this.colsLabel);
            this.groupBox1.Controls.Add(this.ColsBox);
            this.groupBox1.Controls.Add(this.RowsBox);
            this.groupBox1.Controls.Add(this.rowsLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 76);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Размерность поля и настройки симуляции";
            // 
            // tickCountLabel
            // 
            this.tickCountLabel.AutoSize = true;
            this.tickCountLabel.Location = new System.Drawing.Point(156, 48);
            this.tickCountLabel.Name = "tickCountLabel";
            this.tickCountLabel.Size = new System.Drawing.Size(68, 13);
            this.tickCountLabel.TabIndex = 7;
            this.tickCountLabel.Text = "тиков всего";
            // 
            // tickDurationLabel
            // 
            this.tickDurationLabel.AutoSize = true;
            this.tickDurationLabel.Location = new System.Drawing.Point(156, 22);
            this.tickDurationLabel.Name = "tickDurationLabel";
            this.tickDurationLabel.Size = new System.Drawing.Size(56, 13);
            this.tickDurationLabel.TabIndex = 6;
            this.tickDurationLabel.Text = "мс в тике";
            // 
            // TickCountBox
            // 
            this.TickCountBox.Location = new System.Drawing.Point(110, 45);
            this.TickCountBox.Name = "TickCountBox";
            this.TickCountBox.Size = new System.Drawing.Size(40, 20);
            this.TickCountBox.TabIndex = 5;
            this.TickCountBox.Text = "500";
            // 
            // TickDurationBox
            // 
            this.TickDurationBox.Location = new System.Drawing.Point(110, 19);
            this.TickDurationBox.Name = "TickDurationBox";
            this.TickDurationBox.Size = new System.Drawing.Size(40, 20);
            this.TickDurationBox.TabIndex = 4;
            this.TickDurationBox.Text = "100";
            // 
            // colsLabel
            // 
            this.colsLabel.AutoSize = true;
            this.colsLabel.Location = new System.Drawing.Point(44, 48);
            this.colsLabel.Name = "colsLabel";
            this.colsLabel.Size = new System.Drawing.Size(54, 13);
            this.colsLabel.TabIndex = 3;
            this.colsLabel.Text = "столбцов";
            // 
            // rowsLabel
            // 
            this.rowsLabel.AutoSize = true;
            this.rowsLabel.Location = new System.Drawing.Point(44, 22);
            this.rowsLabel.Name = "rowsLabel";
            this.rowsLabel.Size = new System.Drawing.Size(37, 13);
            this.rowsLabel.TabIndex = 2;
            this.rowsLabel.Text = "рядов";
            // 
            // placeholderLabel
            // 
            this.placeholderLabel.AutoSize = true;
            this.placeholderLabel.Location = new System.Drawing.Point(15, 97);
            this.placeholderLabel.Name = "placeholderLabel";
            this.placeholderLabel.Size = new System.Drawing.Size(82, 13);
            this.placeholderLabel.TabIndex = 3;
            this.placeholderLabel.Text = "placeholder text";
            // 
            // PlaceholderBox
            // 
            this.PlaceholderBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlaceholderBox.Location = new System.Drawing.Point(164, 94);
            this.PlaceholderBox.Name = "PlaceholderBox";
            this.PlaceholderBox.Size = new System.Drawing.Size(100, 20);
            this.PlaceholderBox.TabIndex = 4;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(12, 120);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(252, 23);
            this.startButton.TabIndex = 5;
            this.startButton.Text = "Start simulation";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 150);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.PlaceholderBox);
            this.Controls.Add(this.placeholderLabel);
            this.Controls.Add(this.groupBox1);
            this.Name = "SetupForm";
            this.Text = "SetupForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox RowsBox;
        private System.Windows.Forms.TextBox ColsBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label colsLabel;
        private System.Windows.Forms.Label rowsLabel;
        private System.Windows.Forms.Label placeholderLabel;
        private System.Windows.Forms.TextBox PlaceholderBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label tickCountLabel;
        private System.Windows.Forms.Label tickDurationLabel;
        private System.Windows.Forms.TextBox TickCountBox;
        private System.Windows.Forms.TextBox TickDurationBox;
    }
}