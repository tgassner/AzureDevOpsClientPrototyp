namespace AzureDevOpsClientPrototypWinForm {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxOrganisationName = new System.Windows.Forms.TextBox();
            this.textBoxProjectName = new System.Windows.Forms.TextBox();
            this.textBoxWorkItemId = new System.Windows.Forms.TextBox();
            this.textBoxPersonalAccessToken = new System.Windows.Forms.TextBox();
            this.buttonGO = new System.Windows.Forms.Button();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Organisation Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Project Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Work Item Id:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Personal Access Token:";
            // 
            // textBoxOrganisationName
            // 
            this.textBoxOrganisationName.Location = new System.Drawing.Point(159, 6);
            this.textBoxOrganisationName.Name = "textBoxOrganisationName";
            this.textBoxOrganisationName.Size = new System.Drawing.Size(596, 20);
            this.textBoxOrganisationName.TabIndex = 4;
            this.textBoxOrganisationName.Text = "thomasgassner";
            // 
            // textBoxProjectName
            // 
            this.textBoxProjectName.Location = new System.Drawing.Point(159, 32);
            this.textBoxProjectName.Name = "textBoxProjectName";
            this.textBoxProjectName.Size = new System.Drawing.Size(596, 20);
            this.textBoxProjectName.TabIndex = 4;
            this.textBoxProjectName.Text = "Test";
            // 
            // textBoxWorkItemId
            // 
            this.textBoxWorkItemId.Location = new System.Drawing.Point(159, 58);
            this.textBoxWorkItemId.Name = "textBoxWorkItemId";
            this.textBoxWorkItemId.Size = new System.Drawing.Size(596, 20);
            this.textBoxWorkItemId.TabIndex = 4;
            this.textBoxWorkItemId.Text = "1";
            // 
            // textBoxPersonalAccessToken
            // 
            this.textBoxPersonalAccessToken.Location = new System.Drawing.Point(159, 84);
            this.textBoxPersonalAccessToken.Name = "textBoxPersonalAccessToken";
            this.textBoxPersonalAccessToken.Size = new System.Drawing.Size(596, 20);
            this.textBoxPersonalAccessToken.TabIndex = 4;
            // 
            // buttonGO
            // 
            this.buttonGO.Location = new System.Drawing.Point(761, 6);
            this.buttonGO.Name = "buttonGO";
            this.buttonGO.Size = new System.Drawing.Size(119, 99);
            this.buttonGO.TabIndex = 5;
            this.buttonGO.Text = "GO";
            this.buttonGO.UseVisualStyleBackColor = true;
            this.buttonGO.Click += new System.EventHandler(this.ButtonGO_Click);
            // 
            // textBoxResult
            // 
            this.textBoxResult.Location = new System.Drawing.Point(12, 121);
            this.textBoxResult.Multiline = true;
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.ReadOnly = true;
            this.textBoxResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxResult.Size = new System.Drawing.Size(1176, 545);
            this.textBoxResult.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 678);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.buttonGO);
            this.Controls.Add(this.textBoxPersonalAccessToken);
            this.Controls.Add(this.textBoxWorkItemId);
            this.Controls.Add(this.textBoxProjectName);
            this.Controls.Add(this.textBoxOrganisationName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxOrganisationName;
        private System.Windows.Forms.TextBox textBoxProjectName;
        private System.Windows.Forms.TextBox textBoxWorkItemId;
        private System.Windows.Forms.TextBox textBoxPersonalAccessToken;
        private System.Windows.Forms.Button buttonGO;
        private System.Windows.Forms.TextBox textBoxResult;
    }
}

