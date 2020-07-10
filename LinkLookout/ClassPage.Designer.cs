namespace LinkLookout
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Bson;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows.Forms;

    partial class ClassPage : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        /// 
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.classBox = new System.Windows.Forms.ListBox();
            this.showClassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.addClassButton = new System.Windows.Forms.Button();
            this.textBoxClass = new System.Windows.Forms.TextBox();
            this.linkBox = new System.Windows.Forms.ListBox();
            this.textBoxLink = new System.Windows.Forms.TextBox();
            this.addLinkButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.classListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Delete = new System.Windows.Forms.Button();
            this.DeleteLink = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.showClassBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(653, 401);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // classBox
            // 
            this.classBox.DataSource = this.showClassBindingSource;
            this.classBox.FormattingEnabled = true;
            this.classBox.ItemHeight = 16;
            this.classBox.Location = new System.Drawing.Point(59, 23);
            this.classBox.Name = "classBox";
            this.classBox.Size = new System.Drawing.Size(201, 228);
            this.classBox.TabIndex = 1;
            this.classBox.SelectedIndexChanged += new System.EventHandler(this.classBox_SelectedIndexChanged);
            // 
            // addClassButton
            // 
            this.addClassButton.Location = new System.Drawing.Point(59, 296);
            this.addClassButton.Name = "addClassButton";
            this.addClassButton.Size = new System.Drawing.Size(94, 28);
            this.addClassButton.TabIndex = 2;
            this.addClassButton.Text = "Add Class";
            this.addClassButton.UseVisualStyleBackColor = true;
            this.addClassButton.Click += new System.EventHandler(this.addClassButton_Click);
            // 
            // textBoxClass
            // 
            this.textBoxClass.Location = new System.Drawing.Point(59, 268);
            this.textBoxClass.Name = "textBoxClass";
            this.textBoxClass.Size = new System.Drawing.Size(201, 22);
            this.textBoxClass.TabIndex = 3;
            // 
            // linkBox
            // 
            this.linkBox.DisplayMember = "stringLink";
            this.linkBox.FormattingEnabled = true;
            this.linkBox.ItemHeight = 16;
            this.linkBox.Location = new System.Drawing.Point(542, 23);
            this.linkBox.Name = "linkBox";
            this.linkBox.Size = new System.Drawing.Size(198, 228);
            this.linkBox.TabIndex = 4;
            this.linkBox.SelectedIndexChanged += new System.EventHandler(this.linkBox_SelectedIndexChanged);
            // 
            // textBoxLink
            // 
            this.textBoxLink.Location = new System.Drawing.Point(542, 268);
            this.textBoxLink.Name = "textBoxLink";
            this.textBoxLink.Size = new System.Drawing.Size(201, 22);
            this.textBoxLink.TabIndex = 5;
            // 
            // addLinkButton
            // 
            this.addLinkButton.Location = new System.Drawing.Point(542, 296);
            this.addLinkButton.Name = "addLinkButton";
            this.addLinkButton.Size = new System.Drawing.Size(103, 28);
            this.addLinkButton.TabIndex = 6;
            this.addLinkButton.Text = "Add Link";
            this.addLinkButton.UseVisualStyleBackColor = true;
            this.addLinkButton.Click += new System.EventHandler(this.addLinkButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(320, 185);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(163, 66);
            this.button2.TabIndex = 7;
            this.button2.Text = "Scan";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.AcceptsTab = true;
            this.textBox1.Location = new System.Drawing.Point(277, 296);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(259, 145);
            this.textBox1.TabIndex = 8;
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(168, 296);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(92, 28);
            this.Delete.TabIndex = 9;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // DeleteLink
            // 
            this.DeleteLink.Location = new System.Drawing.Point(651, 297);
            this.DeleteLink.Name = "DeleteLink";
            this.DeleteLink.Size = new System.Drawing.Size(91, 27);
            this.DeleteLink.TabIndex = 10;
            this.DeleteLink.Text = "Delete";
            this.DeleteLink.UseVisualStyleBackColor = true;
            this.DeleteLink.Click += new System.EventHandler(this.DeleteLink_Click);
            // 
            // ClassPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 453);
            this.Controls.Add(this.DeleteLink);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.addLinkButton);
            this.Controls.Add(this.textBoxLink);
            this.Controls.Add(this.linkBox);
            this.Controls.Add(this.textBoxClass);
            this.Controls.Add(this.addClassButton);
            this.Controls.Add(this.classBox);
            this.Controls.Add(this.button1);
            this.Name = "ClassPage";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClassPage_FormClosing);
            this.Load += new System.EventHandler(this.ClassPage_FormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.showClassBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classListBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox classBox;
        private System.Windows.Forms.Button addClassButton;
        private System.Windows.Forms.TextBox textBoxClass;
        private System.Windows.Forms.ListBox linkBox;
        private System.Windows.Forms.TextBox textBoxLink;
        private System.Windows.Forms.Button addLinkButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.BindingSource classListBindingSource;
        private System.Windows.Forms.BindingSource showClassBindingSource;
        private Button Delete;
        private Button DeleteLink;
    }
}