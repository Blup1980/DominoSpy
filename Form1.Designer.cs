
namespace DominoSpy
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Domino1_found = new System.Windows.Forms.Label();
            this.Domino2_found = new System.Windows.Forms.Label();
            this.slot2 = new DominoSpy.DominoControl();
            this.slot3 = new DominoSpy.DominoControl();
            this.slot4 = new DominoSpy.DominoControl();
            this.slot5 = new DominoSpy.DominoControl();
            this.slot6 = new DominoSpy.DominoControl();
            this.slot7 = new DominoSpy.DominoControl();
            this.slot8 = new DominoSpy.DominoControl();
            this.slot9 = new DominoSpy.DominoControl();
            this.slot1 = new DominoSpy.DominoControl();
            this.slot0 = new DominoSpy.DominoControl();
            this.domino2_out = new DominoSpy.DominoControl();
            this.domino1_out = new DominoSpy.DominoControl();
            this.restartBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(341, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(571, 532);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 434);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 25);
            this.label1.TabIndex = 20;
            this.label1.Text = "Dominos cachés :";
            // 
            // Domino1_found
            // 
            this.Domino1_found.AutoSize = true;
            this.Domino1_found.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Domino1_found.Location = new System.Drawing.Point(59, 493);
            this.Domino1_found.Name = "Domino1_found";
            this.Domino1_found.Size = new System.Drawing.Size(57, 20);
            this.Domino1_found.TabIndex = 21;
            this.Domino1_found.Text = "Trouvé";
            // 
            // Domino2_found
            // 
            this.Domino2_found.AutoSize = true;
            this.Domino2_found.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Domino2_found.Location = new System.Drawing.Point(223, 493);
            this.Domino2_found.Name = "Domino2_found";
            this.Domino2_found.Size = new System.Drawing.Size(57, 20);
            this.Domino2_found.TabIndex = 22;
            this.Domino2_found.Text = "Trouvé";
            // 
            // slot2
            // 
            this.slot2.CorrectA = "";
            this.slot2.CorrectB = "";
            this.slot2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.slot2.Location = new System.Drawing.Point(737, 298);
            this.slot2.Name = "slot2";
            this.slot2.ShowCorrect = false;
            this.slot2.Size = new System.Drawing.Size(75, 150);
            this.slot2.Status = DominoSpy.DominoStatus.NotPlaced;
            this.slot2.TabIndex = 19;
            this.slot2.TabStop = false;
            this.slot2.TextA = "0";
            this.slot2.TextB = "5";
            this.slot2.Vertical = true;
            // 
            // slot3
            // 
            this.slot3.CorrectA = "";
            this.slot3.CorrectB = "";
            this.slot3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.slot3.Location = new System.Drawing.Point(737, 217);
            this.slot3.Name = "slot3";
            this.slot3.ShowCorrect = false;
            this.slot3.Size = new System.Drawing.Size(150, 75);
            this.slot3.Status = DominoSpy.DominoStatus.NotPlaced;
            this.slot3.TabIndex = 18;
            this.slot3.TabStop = false;
            this.slot3.TextA = "0";
            this.slot3.TextB = "3";
            this.slot3.Vertical = false;
            // 
            // slot4
            // 
            this.slot4.CorrectA = "";
            this.slot4.CorrectB = "";
            this.slot4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.slot4.Location = new System.Drawing.Point(812, 61);
            this.slot4.Name = "slot4";
            this.slot4.ShowCorrect = false;
            this.slot4.Size = new System.Drawing.Size(75, 150);
            this.slot4.Status = DominoSpy.DominoStatus.NotPlaced;
            this.slot4.TabIndex = 17;
            this.slot4.TabStop = false;
            this.slot4.TextA = "2";
            this.slot4.TextB = "3";
            this.slot4.Vertical = true;
            // 
            // slot5
            // 
            this.slot5.CorrectA = "";
            this.slot5.CorrectB = "";
            this.slot5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.slot5.Location = new System.Drawing.Point(657, 61);
            this.slot5.Name = "slot5";
            this.slot5.ShowCorrect = false;
            this.slot5.Size = new System.Drawing.Size(150, 75);
            this.slot5.Status = DominoSpy.DominoStatus.NotPlaced;
            this.slot5.TabIndex = 16;
            this.slot5.TabStop = false;
            this.slot5.TextA = "6";
            this.slot5.TextB = "2";
            this.slot5.Vertical = false;
            // 
            // slot6
            // 
            this.slot6.CorrectA = "";
            this.slot6.CorrectB = "";
            this.slot6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.slot6.Location = new System.Drawing.Point(576, 25);
            this.slot6.Name = "slot6";
            this.slot6.ShowCorrect = false;
            this.slot6.Size = new System.Drawing.Size(75, 150);
            this.slot6.Status = DominoSpy.DominoStatus.NotPlaced;
            this.slot6.TabIndex = 15;
            this.slot6.TabStop = false;
            this.slot6.TextA = "6";
            this.slot6.TextB = "6";
            this.slot6.Vertical = true;
            // 
            // slot7
            // 
            this.slot7.CorrectA = "";
            this.slot7.CorrectB = "";
            this.slot7.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.slot7.Location = new System.Drawing.Point(420, 61);
            this.slot7.Name = "slot7";
            this.slot7.ShowCorrect = false;
            this.slot7.Size = new System.Drawing.Size(150, 75);
            this.slot7.Status = DominoSpy.DominoStatus.NotPlaced;
            this.slot7.TabIndex = 14;
            this.slot7.TabStop = false;
            this.slot7.TextA = "5";
            this.slot7.TextB = "6";
            this.slot7.Vertical = false;
            // 
            // slot8
            // 
            this.slot8.CorrectA = "";
            this.slot8.CorrectB = "";
            this.slot8.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.slot8.Location = new System.Drawing.Point(416, 141);
            this.slot8.Name = "slot8";
            this.slot8.ShowCorrect = false;
            this.slot8.Size = new System.Drawing.Size(75, 150);
            this.slot8.Status = DominoSpy.DominoStatus.NotPlaced;
            this.slot8.TabIndex = 13;
            this.slot8.TabStop = false;
            this.slot8.TextA = "5";
            this.slot8.TextB = "1";
            this.slot8.Vertical = true;
            // 
            // slot9
            // 
            this.slot9.CorrectA = "1";
            this.slot9.CorrectB = "1";
            this.slot9.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.slot9.Location = new System.Drawing.Point(378, 298);
            this.slot9.Name = "slot9";
            this.slot9.ShowCorrect = false;
            this.slot9.Size = new System.Drawing.Size(150, 75);
            this.slot9.Status = DominoSpy.DominoStatus.NotPlaced;
            this.slot9.TabIndex = 12;
            this.slot9.TabStop = false;
            this.slot9.TextA = "1";
            this.slot9.TextB = "1";
            this.slot9.Vertical = false;
            // 
            // slot1
            // 
            this.slot1.CorrectA = "0";
            this.slot1.CorrectB = "4";
            this.slot1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.slot1.Location = new System.Drawing.Point(497, 454);
            this.slot1.Name = "slot1";
            this.slot1.ShowCorrect = false;
            this.slot1.Size = new System.Drawing.Size(150, 75);
            this.slot1.Status = DominoSpy.DominoStatus.NotPlaced;
            this.slot1.TabIndex = 11;
            this.slot1.TabStop = false;
            this.slot1.TextA = "0";
            this.slot1.TextB = "4";
            this.slot1.Vertical = false;
            // 
            // slot0
            // 
            this.slot0.CorrectA = "1";
            this.slot0.CorrectB = "0";
            this.slot0.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.slot0.Location = new System.Drawing.Point(416, 379);
            this.slot0.Name = "slot0";
            this.slot0.ShowCorrect = false;
            this.slot0.Size = new System.Drawing.Size(75, 150);
            this.slot0.Status = DominoSpy.DominoStatus.NotPlaced;
            this.slot0.TabIndex = 10;
            this.slot0.TabStop = false;
            this.slot0.Text = "domino0_out";
            this.slot0.TextA = "1";
            this.slot0.TextB = "0";
            this.slot0.Vertical = true;
            // 
            // domino2_out
            // 
            this.domino2_out.CorrectA = "";
            this.domino2_out.CorrectB = "";
            this.domino2_out.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.domino2_out.Location = new System.Drawing.Point(176, 465);
            this.domino2_out.Name = "domino2_out";
            this.domino2_out.ShowCorrect = false;
            this.domino2_out.Size = new System.Drawing.Size(150, 75);
            this.domino2_out.Status = DominoSpy.DominoStatus.NotPlaced;
            this.domino2_out.TabIndex = 9;
            this.domino2_out.TabStop = false;
            this.domino2_out.Text = "domino8";
            this.domino2_out.TextA = "0";
            this.domino2_out.TextB = "5";
            this.domino2_out.Vertical = false;
            // 
            // domino1_out
            // 
            this.domino1_out.CorrectA = "";
            this.domino1_out.CorrectB = "";
            this.domino1_out.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.domino1_out.Location = new System.Drawing.Point(12, 465);
            this.domino1_out.Name = "domino1_out";
            this.domino1_out.ShowCorrect = false;
            this.domino1_out.Size = new System.Drawing.Size(150, 75);
            this.domino1_out.Status = DominoSpy.DominoStatus.NotPlaced;
            this.domino1_out.TabIndex = 3;
            this.domino1_out.TabStop = false;
            this.domino1_out.TextA = "0";
            this.domino1_out.TextB = "4";
            this.domino1_out.Vertical = false;
            // 
            // restartBtn
            // 
            this.restartBtn.Location = new System.Drawing.Point(12, 14);
            this.restartBtn.Name = "restartBtn";
            this.restartBtn.Size = new System.Drawing.Size(75, 23);
            this.restartBtn.TabIndex = 23;
            this.restartBtn.Text = "Redémarrer";
            this.restartBtn.UseVisualStyleBackColor = true;
            this.restartBtn.Click += new System.EventHandler(this.restartBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 559);
            this.Controls.Add(this.restartBtn);
            this.Controls.Add(this.Domino2_found);
            this.Controls.Add(this.Domino1_found);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.slot2);
            this.Controls.Add(this.slot3);
            this.Controls.Add(this.slot4);
            this.Controls.Add(this.slot5);
            this.Controls.Add(this.slot6);
            this.Controls.Add(this.slot7);
            this.Controls.Add(this.slot8);
            this.Controls.Add(this.slot9);
            this.Controls.Add(this.slot1);
            this.Controls.Add(this.slot0);
            this.Controls.Add(this.domino2_out);
            this.Controls.Add(this.domino1_out);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(940, 598);
            this.MinimumSize = new System.Drawing.Size(940, 598);
            this.Name = "Form1";
            this.Text = "DominoSpy";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private DominoControl domino1_out;
        private DominoControl domino2_out;
        private DominoControl slot0;
        private DominoControl slot1;
        private DominoControl slot9;
        private DominoControl slot8;
        private DominoControl slot7;
        private DominoControl slot6;
        private DominoControl slot5;
        private DominoControl slot4;
        private DominoControl slot3;
        private DominoControl slot2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Domino1_found;
        private System.Windows.Forms.Label Domino2_found;
        private System.Windows.Forms.Button restartBtn;
    }
}

