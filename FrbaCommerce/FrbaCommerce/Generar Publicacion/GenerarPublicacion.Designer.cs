﻿namespace FrbaCommerce.Generar_Publicacion
{
    partial class GenerarPublicacion
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
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_Estado = new System.Windows.Forms.ComboBox();
            this.comboBox_TiposDePublicacion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox_Rubro = new System.Windows.Forms.ComboBox();
            this.radioButton_Pregunta = new System.Windows.Forms.RadioButton();
            this.comboBox_Visibilidad = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Descripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_Precio = new System.Windows.Forms.TextBox();
            this.textBox_Stock = new System.Windows.Forms.TextBox();
            this.label_precio = new System.Windows.Forms.Label();
            this.label_stock = new System.Windows.Forms.Label();
            this.button_Generar = new System.Windows.Forms.Button();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.button_Limpiar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comboBox_Estado);
            this.groupBox1.Controls.Add(this.comboBox_TiposDePublicacion);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 72);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de publicacion";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Estado";
            // 
            // comboBox_Estado
            // 
            this.comboBox_Estado.FormattingEnabled = true;
            this.comboBox_Estado.Location = new System.Drawing.Point(112, 40);
            this.comboBox_Estado.Name = "comboBox_Estado";
            this.comboBox_Estado.Size = new System.Drawing.Size(250, 21);
            this.comboBox_Estado.TabIndex = 2;
            // 
            // comboBox_TiposDePublicacion
            // 
            this.comboBox_TiposDePublicacion.FormattingEnabled = true;
            this.comboBox_TiposDePublicacion.Location = new System.Drawing.Point(112, 13);
            this.comboBox_TiposDePublicacion.Name = "comboBox_TiposDePublicacion";
            this.comboBox_TiposDePublicacion.Size = new System.Drawing.Size(250, 21);
            this.comboBox_TiposDePublicacion.TabIndex = 1;
            this.comboBox_TiposDePublicacion.SelectedIndexChanged += new System.EventHandler(this.comboBox_tiposDePublicacion_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo de publicacion";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox_Rubro);
            this.groupBox2.Controls.Add(this.radioButton_Pregunta);
            this.groupBox2.Controls.Add(this.comboBox_Visibilidad);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox_Descripcion);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(368, 167);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Caracterisiticas comunes";
            // 
            // comboBox_Rubro
            // 
            this.comboBox_Rubro.FormattingEnabled = true;
            this.comboBox_Rubro.Location = new System.Drawing.Point(112, 74);
            this.comboBox_Rubro.Name = "comboBox_Rubro";
            this.comboBox_Rubro.Size = new System.Drawing.Size(250, 21);
            this.comboBox_Rubro.TabIndex = 8;
            // 
            // radioButton_Pregunta
            // 
            this.radioButton_Pregunta.AutoSize = true;
            this.radioButton_Pregunta.Location = new System.Drawing.Point(6, 127);
            this.radioButton_Pregunta.Name = "radioButton_Pregunta";
            this.radioButton_Pregunta.Size = new System.Drawing.Size(110, 17);
            this.radioButton_Pregunta.TabIndex = 7;
            this.radioButton_Pregunta.TabStop = true;
            this.radioButton_Pregunta.Text = "Permite preguntas";
            this.radioButton_Pregunta.UseVisualStyleBackColor = true;
            // 
            // comboBox_Visibilidad
            // 
            this.comboBox_Visibilidad.FormattingEnabled = true;
            this.comboBox_Visibilidad.Location = new System.Drawing.Point(112, 100);
            this.comboBox_Visibilidad.Name = "comboBox_Visibilidad";
            this.comboBox_Visibilidad.Size = new System.Drawing.Size(250, 21);
            this.comboBox_Visibilidad.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Visibilidad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Rubro";
            // 
            // textBox_Descripcion
            // 
            this.textBox_Descripcion.Location = new System.Drawing.Point(112, 22);
            this.textBox_Descripcion.Name = "textBox_Descripcion";
            this.textBox_Descripcion.Size = new System.Drawing.Size(250, 20);
            this.textBox_Descripcion.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Descripcion";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox_Precio);
            this.groupBox3.Controls.Add(this.textBox_Stock);
            this.groupBox3.Controls.Add(this.label_precio);
            this.groupBox3.Controls.Add(this.label_stock);
            this.groupBox3.Location = new System.Drawing.Point(12, 263);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(368, 74);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Caracteristicas especiales";
            // 
            // textBox_Precio
            // 
            this.textBox_Precio.Location = new System.Drawing.Point(112, 43);
            this.textBox_Precio.Name = "textBox_Precio";
            this.textBox_Precio.Size = new System.Drawing.Size(250, 20);
            this.textBox_Precio.TabIndex = 3;
            // 
            // textBox_Stock
            // 
            this.textBox_Stock.Location = new System.Drawing.Point(112, 17);
            this.textBox_Stock.Name = "textBox_Stock";
            this.textBox_Stock.Size = new System.Drawing.Size(250, 20);
            this.textBox_Stock.TabIndex = 2;
            // 
            // label_precio
            // 
            this.label_precio.AutoSize = true;
            this.label_precio.Location = new System.Drawing.Point(6, 46);
            this.label_precio.Name = "label_precio";
            this.label_precio.Size = new System.Drawing.Size(37, 13);
            this.label_precio.TabIndex = 1;
            this.label_precio.Text = "Precio";
            // 
            // label_stock
            // 
            this.label_stock.AutoSize = true;
            this.label_stock.Location = new System.Drawing.Point(6, 20);
            this.label_stock.Name = "label_stock";
            this.label_stock.Size = new System.Drawing.Size(35, 13);
            this.label_stock.TabIndex = 0;
            this.label_stock.Text = "Stock";
            // 
            // button_Generar
            // 
            this.button_Generar.Location = new System.Drawing.Point(284, 354);
            this.button_Generar.Name = "button_Generar";
            this.button_Generar.Size = new System.Drawing.Size(96, 30);
            this.button_Generar.TabIndex = 6;
            this.button_Generar.Text = "Generar";
            this.button_Generar.UseVisualStyleBackColor = true;
            this.button_Generar.Click += new System.EventHandler(this.button_generar_Click);
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(12, 354);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(96, 30);
            this.button_Cancelar.TabIndex = 7;
            this.button_Cancelar.Text = "Volver";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // button_Limpiar
            // 
            this.button_Limpiar.Location = new System.Drawing.Point(182, 354);
            this.button_Limpiar.Name = "button_Limpiar";
            this.button_Limpiar.Size = new System.Drawing.Size(96, 30);
            this.button_Limpiar.TabIndex = 8;
            this.button_Limpiar.Text = "Limpiar";
            this.button_Limpiar.UseVisualStyleBackColor = true;
            this.button_Limpiar.Click += new System.EventHandler(this.button_Limpiar_Click);
            // 
            // GenerarPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 396);
            this.Controls.Add(this.button_Limpiar);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.button_Generar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "GenerarPublicacion";
            this.Text = "Generar Publicacion";
            this.Load += new System.EventHandler(this.GenerarPublicacion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_TiposDePublicacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Descripcion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButton_Pregunta;
        private System.Windows.Forms.ComboBox comboBox_Visibilidad;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox_Precio;
        private System.Windows.Forms.TextBox textBox_Stock;
        private System.Windows.Forms.Label label_precio;
        private System.Windows.Forms.Label label_stock;
        private System.Windows.Forms.ComboBox comboBox_Rubro;
        private System.Windows.Forms.Button button_Generar;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.Button button_Limpiar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_Estado;
    }
}