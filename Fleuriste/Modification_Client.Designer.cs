namespace Fleuriste
{
    partial class Modification_Client
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            button1 = new Button();
            label9 = new Label();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 16F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(500, 10);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(326, 36);
            label1.TabIndex = 0;
            label1.Text = "Modification de Client";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(56, 178);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(99, 27);
            label2.TabIndex = 1;
            label2.Text = "Prénom :";
            // 
            // label3
            // 
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Location = new Point(632, 174);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(608, 219);
            panel1.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(56, 227);
            label4.Name = "label4";
            label4.Size = new Size(71, 27);
            label4.TabIndex = 3;
            label4.Text = "Nom :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(56, 277);
            label5.Name = "label5";
            label5.Size = new Size(80, 27);
            label5.TabIndex = 4;
            label5.Text = "Statut :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(181, 178);
            label6.Name = "label6";
            label6.Size = new Size(152, 27);
            label6.TabIndex = 5;
            label6.Text = "Prenom_client";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(204, 227);
            label7.Name = "label7";
            label7.Size = new Size(129, 27);
            label7.TabIndex = 6;
            label7.Text = "Nom_Client";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(195, 277);
            label8.Name = "label8";
            label8.Size = new Size(138, 27);
            label8.TabIndex = 7;
            label8.Text = "Statut_Client";
            // 
            // button1
            // 
            button1.BackColor = Color.DarkOrchid;
            button1.Location = new Point(120, 354);
            button1.Name = "button1";
            button1.Size = new Size(199, 39);
            button1.TabIndex = 8;
            button1.Text = "Changer le statut ";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(632, 127);
            label9.Name = "label9";
            label9.Size = new Size(302, 27);
            label9.TabIndex = 9;
            label9.Text = "Historique de ses commandes:";
            // 
            // button2
            // 
            button2.Location = new Point(22, 25);
            button2.Name = "button2";
            button2.Size = new Size(210, 46);
            button2.TabIndex = 10;
            button2.Text = "Revenir en arrière";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Modification_Client
            // 
            AutoScaleDimensions = new SizeF(13F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1386, 533);
            Controls.Add(button2);
            Controls.Add(label9);
            Controls.Add(button1);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Modification_Client";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Modification_Client";
            Load += Modification_Client_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Panel panel1;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Button button1;
        private Label label9;
        private Button button2;
    }
}