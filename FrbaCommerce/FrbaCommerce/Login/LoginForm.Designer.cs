﻿namespace FrbaCommerce.Login
{
    partial class LoginForm
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
            this.oCmbIngresar = new System.Windows.Forms.Button();
            this.oTbxUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.oTbxPass = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // oCmbIngresar
            // 
            this.oCmbIngresar.Location = new System.Drawing.Point(93, 160);
            this.oCmbIngresar.Name = "oCmbIngresar";
            this.oCmbIngresar.Size = new System.Drawing.Size(75, 23);
            this.oCmbIngresar.TabIndex = 0;
            this.oCmbIngresar.Text = "Ingresar";
            this.oCmbIngresar.UseVisualStyleBackColor = true;
            this.oCmbIngresar.Click += new System.EventHandler(this.oCmbIngresar_Click);
            // 
            // oTbxUsuario
            // 
            this.oTbxUsuario.Location = new System.Drawing.Point(82, 62);
            this.oTbxUsuario.Name = "oTbxUsuario";
            this.oTbxUsuario.Size = new System.Drawing.Size(100, 20);
            this.oTbxUsuario.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Usuario";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contraseña";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // oTbxPass
            // 
            this.oTbxPass.Location = new System.Drawing.Point(82, 118);
            this.oTbxPass.Name = "oTbxPass";
            this.oTbxPass.Size = new System.Drawing.Size(100, 20);
            this.oTbxPass.TabIndex = 4;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.oTbxPass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.oTbxUsuario);
            this.Controls.Add(this.oCmbIngresar);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button oCmbIngresar;
        private System.Windows.Forms.TextBox oTbxUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox oTbxPass;
    }
}