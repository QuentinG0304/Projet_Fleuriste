using MySql.Data.MySqlClient;

namespace Fleuriste
{
    partial class Page_Client
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
            connection = new MySqlConnection();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            label3 = new Label();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            numericUpDown3 = new NumericUpDown();
            numericUpDown4 = new NumericUpDown();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            button6 = new Button();
            numericUpDown5 = new NumericUpDown();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            textBox1 = new TextBox();
            label13 = new Label();
            label14 = new Label();
            numericUpDown6 = new NumericUpDown();
            label15 = new Label();
            numericUpDown7 = new NumericUpDown();
            label16 = new Label();
            numericUpDown8 = new NumericUpDown();
            button7 = new Button();
            label17 = new Label();
            textBox2 = new TextBox();
            panel1 = new Panel();
            label18 = new Label();
            label19 = new Label();
            button8 = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown8).BeginInit();
            SuspendLayout();
            // 
            // connection
            // 
            connection.ConnectionString = "server=localhost;port=3306;database=fleurs;user id=root";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(443, 10);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(364, 41);
            label1.TabIndex = 0;
            label1.Text = "Bonjour Nom_Prenom";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 131);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(238, 27);
            label2.TabIndex = 1;
            label2.Text = "Passer une commande :";
            // 
            // button1
            // 
            button1.Location = new Point(22, 204);
            button1.Name = "button1";
            button1.Size = new Size(171, 36);
            button1.TabIndex = 2;
            button1.Text = "Gros Merci";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(22, 246);
            button2.Name = "button2";
            button2.Size = new Size(171, 36);
            button2.TabIndex = 3;
            button2.Text = "L'Amoureux";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(22, 288);
            button3.Name = "button3";
            button3.Size = new Size(171, 36);
            button3.TabIndex = 4;
            button3.Text = "L'Exotique";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(22, 330);
            button4.Name = "button4";
            button4.Size = new Size(171, 36);
            button4.TabIndex = 5;
            button4.Text = "Maman";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(22, 372);
            button5.Name = "button5";
            button5.Size = new Size(171, 36);
            button5.TabIndex = 6;
            button5.Text = "Vive la mariée";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(338, 131);
            label3.Name = "label3";
            label3.Size = new Size(107, 27);
            label3.TabIndex = 7;
            label3.Text = "Quantité :";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(338, 204);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(58, 35);
            numericUpDown1.TabIndex = 8;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(338, 249);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(58, 35);
            numericUpDown2.TabIndex = 9;
            numericUpDown2.ValueChanged += numericUpDown2_ValueChanged;
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(338, 291);
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(58, 35);
            numericUpDown3.TabIndex = 10;
            numericUpDown3.ValueChanged += numericUpDown3_ValueChanged;
            // 
            // numericUpDown4
            // 
            numericUpDown4.Location = new Point(338, 333);
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(58, 35);
            numericUpDown4.TabIndex = 11;
            numericUpDown4.ValueChanged += numericUpDown4_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(466, 131);
            label4.Name = "label4";
            label4.Size = new Size(147, 27);
            label4.TabIndex = 12;
            label4.Text = "Prix Unitaire :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(466, 213);
            label5.Name = "label5";
            label5.Size = new Size(54, 27);
            label5.TabIndex = 13;
            label5.Text = "45 €";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(466, 255);
            label6.Name = "label6";
            label6.Size = new Size(54, 27);
            label6.TabIndex = 14;
            label6.Text = "65 €";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(466, 299);
            label7.Name = "label7";
            label7.Size = new Size(54, 27);
            label7.TabIndex = 15;
            label7.Text = "40 €";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(466, 341);
            label8.Name = "label8";
            label8.Size = new Size(54, 27);
            label8.TabIndex = 16;
            label8.Text = "80 €";
            // 
            // button6
            // 
            button6.Location = new Point(740, 527);
            button6.Name = "button6";
            button6.Size = new Size(229, 36);
            button6.TabIndex = 17;
            button6.Text = "Bouquet Personnalisé";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // numericUpDown5
            // 
            numericUpDown5.Location = new Point(338, 375);
            numericUpDown5.Name = "numericUpDown5";
            numericUpDown5.Size = new Size(58, 35);
            numericUpDown5.TabIndex = 18;
            numericUpDown5.ValueChanged += numericUpDown5_ValueChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(466, 383);
            label9.Name = "label9";
            label9.Size = new Size(66, 27);
            label9.TabIndex = 19;
            label9.Text = "120 €";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(22, 480);
            label10.Name = "label10";
            label10.Size = new Size(118, 27);
            label10.TabIndex = 20;
            label10.Text = "Prix Total :";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(146, 480);
            label11.Name = "label11";
            label11.Size = new Size(42, 27);
            label11.TabIndex = 21;
            label11.Text = "0 €";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(22, 535);
            label12.Name = "label12";
            label12.Size = new Size(135, 27);
            label12.TabIndex = 22;
            label12.Text = "Description :";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(163, 527);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(495, 35);
            textBox1.TabIndex = 23;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(22, 588);
            label13.Name = "label13";
            label13.Size = new Size(93, 27);
            label13.TabIndex = 24;
            label13.Text = "Pour le :";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(163, 588);
            label14.Name = "label14";
            label14.Size = new Size(71, 27);
            label14.TabIndex = 25;
            label14.Text = "Jour : ";
            // 
            // numericUpDown6
            // 
            numericUpDown6.Location = new Point(240, 586);
            numericUpDown6.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            numericUpDown6.Name = "numericUpDown6";
            numericUpDown6.Size = new Size(64, 35);
            numericUpDown6.TabIndex = 26;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(310, 588);
            label15.Name = "label15";
            label15.Size = new Size(72, 27);
            label15.TabIndex = 27;
            label15.Text = "Mois :";
            // 
            // numericUpDown7
            // 
            numericUpDown7.Location = new Point(388, 586);
            numericUpDown7.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            numericUpDown7.Name = "numericUpDown7";
            numericUpDown7.Size = new Size(57, 35);
            numericUpDown7.TabIndex = 28;
            numericUpDown7.ValueChanged += numericUpDown7_ValueChanged;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(466, 588);
            label16.Name = "label16";
            label16.Size = new Size(87, 27);
            label16.TabIndex = 29;
            label16.Text = "Année :";
            // 
            // numericUpDown8
            // 
            numericUpDown8.Location = new Point(559, 586);
            numericUpDown8.Maximum = new decimal(new int[] { 2050, 0, 0, 0 });
            numericUpDown8.Minimum = new decimal(new int[] { 2023, 0, 0, 0 });
            numericUpDown8.Name = "numericUpDown8";
            numericUpDown8.Size = new Size(99, 35);
            numericUpDown8.TabIndex = 30;
            numericUpDown8.Value = new decimal(new int[] { 2023, 0, 0, 0 });
            numericUpDown8.ValueChanged += numericUpDown8_ValueChanged;
            // 
            // button7
            // 
            button7.BackColor = Color.DarkCyan;
            button7.Location = new Point(29, 713);
            button7.Name = "button7";
            button7.Size = new Size(178, 49);
            button7.TabIndex = 31;
            button7.Text = "Commander";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(22, 642);
            label17.Name = "label17";
            label17.Size = new Size(218, 27);
            label17.TabIndex = 32;
            label17.Text = "Adresse de livraison :";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(246, 634);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(412, 35);
            textBox2.TabIndex = 33;
            // 
            // panel1
            // 
            panel1.Location = new Point(779, 204);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 100);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // label18
            // 
            label18.Location = new Point(0, 0);
            label18.Name = "label18";
            label18.Size = new Size(100, 23);
            label18.TabIndex = 0;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(779, 131);
            label19.Name = "label19";
            label19.Size = new Size(282, 27);
            label19.TabIndex = 34;
            label19.Text = "Historique des commandes :";
            // 
            // button8
            // 
            button8.Location = new Point(12, 14);
            button8.Name = "button8";
            button8.Size = new Size(211, 42);
            button8.TabIndex = 35;
            button8.Text = "Revenir en arrière";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // Page_Client
            // 
            AutoScaleDimensions = new SizeF(13F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1336, 781);
            Controls.Add(button8);
            Controls.Add(label19);
            Controls.Add(panel1);
            Controls.Add(textBox2);
            Controls.Add(label17);
            Controls.Add(button7);
            Controls.Add(numericUpDown8);
            Controls.Add(label16);
            Controls.Add(numericUpDown7);
            Controls.Add(label15);
            Controls.Add(numericUpDown6);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(textBox1);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(numericUpDown5);
            Controls.Add(button6);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(numericUpDown4);
            Controls.Add(numericUpDown3);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Controls.Add(label3);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Page_Client";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Page_Client";
            Load += Page_Client_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown7).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown8).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private MySqlConnection connection;
        private Label label2;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Label label3;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown3;
        private NumericUpDown numericUpDown4;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Button button6;
        private NumericUpDown numericUpDown5;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private TextBox textBox1;
        private Label label13;
        private Label label14;
        private NumericUpDown numericUpDown6;
        private Label label15;
        private NumericUpDown numericUpDown7;
        private Label label16;
        private NumericUpDown numericUpDown8;
        private Button button7;
        private Label label17;
        private TextBox textBox2;
        private Panel panel1;
        private Label label18;
        private Label label19;
        private Button button8;
    }
}