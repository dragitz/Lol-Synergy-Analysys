
namespace Lol_Synergy_Analysys
{
    partial class Title
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GetChampions_btn = new System.Windows.Forms.Button();
            this.ADC_Box = new System.Windows.Forms.ComboBox();
            this.SUPPORT_Box = new System.Windows.Forms.ComboBox();
            this.JUNGLER_Box = new System.Windows.Forms.ComboBox();
            this.MID_Box = new System.Windows.Forms.ComboBox();
            this.TOP_Box = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Calculate_btn = new System.Windows.Forms.Button();
            this.Output = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dragon_version = new System.Windows.Forms.Label();
            this.api_version = new System.Windows.Forms.Label();
            this.status1 = new System.Windows.Forms.Label();
            this.debug = new System.Windows.Forms.RichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.synergy_label = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GetChampions_btn
            // 
            this.GetChampions_btn.Location = new System.Drawing.Point(41, 36);
            this.GetChampions_btn.Name = "GetChampions_btn";
            this.GetChampions_btn.Size = new System.Drawing.Size(109, 23);
            this.GetChampions_btn.TabIndex = 2;
            this.GetChampions_btn.Text = "Get champions";
            this.GetChampions_btn.UseVisualStyleBackColor = true;
            this.GetChampions_btn.Click += new System.EventHandler(this.GetChampions_btn_Click);
            // 
            // ADC_Box
            // 
            this.ADC_Box.FormattingEnabled = true;
            this.ADC_Box.Location = new System.Drawing.Point(29, 149);
            this.ADC_Box.Name = "ADC_Box";
            this.ADC_Box.Size = new System.Drawing.Size(121, 23);
            this.ADC_Box.TabIndex = 3;
            this.ADC_Box.SelectedIndexChanged += new System.EventHandler(this.ADC_Box_SelectedIndexChanged);
            // 
            // SUPPORT_Box
            // 
            this.SUPPORT_Box.FormattingEnabled = true;
            this.SUPPORT_Box.Location = new System.Drawing.Point(156, 149);
            this.SUPPORT_Box.Name = "SUPPORT_Box";
            this.SUPPORT_Box.Size = new System.Drawing.Size(121, 23);
            this.SUPPORT_Box.TabIndex = 4;
            this.SUPPORT_Box.SelectedIndexChanged += new System.EventHandler(this.SUPPORT_Box_SelectedIndexChanged);
            // 
            // JUNGLER_Box
            // 
            this.JUNGLER_Box.FormattingEnabled = true;
            this.JUNGLER_Box.Location = new System.Drawing.Point(283, 149);
            this.JUNGLER_Box.Name = "JUNGLER_Box";
            this.JUNGLER_Box.Size = new System.Drawing.Size(121, 23);
            this.JUNGLER_Box.TabIndex = 5;
            this.JUNGLER_Box.SelectedIndexChanged += new System.EventHandler(this.JUNGLER_Box_SelectedIndexChanged);
            // 
            // MID_Box
            // 
            this.MID_Box.FormattingEnabled = true;
            this.MID_Box.Location = new System.Drawing.Point(410, 149);
            this.MID_Box.Name = "MID_Box";
            this.MID_Box.Size = new System.Drawing.Size(121, 23);
            this.MID_Box.TabIndex = 6;
            this.MID_Box.SelectedIndexChanged += new System.EventHandler(this.MID_Box_SelectedIndexChanged);
            // 
            // TOP_Box
            // 
            this.TOP_Box.FormattingEnabled = true;
            this.TOP_Box.Location = new System.Drawing.Point(537, 149);
            this.TOP_Box.Name = "TOP_Box";
            this.TOP_Box.Size = new System.Drawing.Size(121, 23);
            this.TOP_Box.TabIndex = 7;
            this.TOP_Box.SelectedIndexChanged += new System.EventHandler(this.TOP_Box_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "ADC";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(192, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "SUPPORT";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(315, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "JUNGLER";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(453, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "MID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(579, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "TOP";
            // 
            // Calculate_btn
            // 
            this.Calculate_btn.Location = new System.Drawing.Point(71, 217);
            this.Calculate_btn.Name = "Calculate_btn";
            this.Calculate_btn.Size = new System.Drawing.Size(75, 23);
            this.Calculate_btn.TabIndex = 13;
            this.Calculate_btn.Text = "Calculate";
            this.Calculate_btn.UseVisualStyleBackColor = true;
            this.Calculate_btn.Click += new System.EventHandler(this.Calculate_btn_Click);
            // 
            // Output
            // 
            this.Output.Location = new System.Drawing.Point(29, 246);
            this.Output.Name = "Output";
            this.Output.Size = new System.Drawing.Size(411, 192);
            this.Output.TabIndex = 14;
            this.Output.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(271, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(149, 15);
            this.label9.TabIndex = 20;
            this.label9.Text = "Select only one champion";
            // 
            // dragon_version
            // 
            this.dragon_version.AutoSize = true;
            this.dragon_version.Location = new System.Drawing.Point(563, 9);
            this.dragon_version.Name = "dragon_version";
            this.dragon_version.Size = new System.Drawing.Size(93, 15);
            this.dragon_version.TabIndex = 23;
            this.dragon_version.Text = "Dragon Version: ";
            // 
            // api_version
            // 
            this.api_version.AutoSize = true;
            this.api_version.Location = new System.Drawing.Point(584, 40);
            this.api_version.Name = "api_version";
            this.api_version.Size = new System.Drawing.Size(72, 15);
            this.api_version.TabIndex = 24;
            this.api_version.Text = "API Version: ";
            // 
            // status1
            // 
            this.status1.AutoSize = true;
            this.status1.Location = new System.Drawing.Point(156, 40);
            this.status1.Name = "status1";
            this.status1.Size = new System.Drawing.Size(45, 15);
            this.status1.TabIndex = 25;
            this.status1.Text = "Status: ";
            // 
            // debug
            // 
            this.debug.Location = new System.Drawing.Point(471, 246);
            this.debug.Name = "debug";
            this.debug.Size = new System.Drawing.Size(317, 192);
            this.debug.TabIndex = 26;
            this.debug.Text = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(601, 225);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 15);
            this.label11.TabIndex = 27;
            this.label11.Text = "debug box";
            // 
            // synergy_label
            // 
            this.synergy_label.AutoSize = true;
            this.synergy_label.Location = new System.Drawing.Point(71, 187);
            this.synergy_label.Name = "synergy_label";
            this.synergy_label.Size = new System.Drawing.Size(112, 15);
            this.synergy_label.TabIndex = 28;
            this.synergy_label.Text = "Avg. synergy score: ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(245, 217);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 23);
            this.button1.TabIndex = 29;
            this.button1.Text = "Find best score";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(396, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 15);
            this.label1.TabIndex = 30;
            this.label1.Text = "0/0";
            // 
            // Title
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.synergy_label);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.debug);
            this.Controls.Add(this.status1);
            this.Controls.Add(this.api_version);
            this.Controls.Add(this.dragon_version);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.Calculate_btn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TOP_Box);
            this.Controls.Add(this.MID_Box);
            this.Controls.Add(this.JUNGLER_Box);
            this.Controls.Add(this.SUPPORT_Box);
            this.Controls.Add(this.ADC_Box);
            this.Controls.Add(this.GetChampions_btn);
            this.Name = "Title";
            this.Text = "Lol Synergy Analysys";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button GetChampions_btn;
        private System.Windows.Forms.ComboBox ADC_Box;
        private System.Windows.Forms.ComboBox SUPPORT_Box;
        private System.Windows.Forms.ComboBox JUNGLER_Box;
        private System.Windows.Forms.ComboBox MID_Box;
        private System.Windows.Forms.ComboBox TOP_Box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Calculate_btn;
        private System.Windows.Forms.RichTextBox Output;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label dragon_version;
        private System.Windows.Forms.Label api_version;
        private System.Windows.Forms.Label status1;
        private System.Windows.Forms.RichTextBox debug;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label synergy_label;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}

