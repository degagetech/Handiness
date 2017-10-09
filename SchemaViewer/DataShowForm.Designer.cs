namespace SchemaViewer
{
    partial class DataShowForm
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
            this._dgvDataShow = new SchemaViewer.DataGridViewEx();
            ((System.ComponentModel.ISupportInitialize)(this._dgvDataShow)).BeginInit();
            this.SuspendLayout();
            // 
            // _dgvDataShow
            // 
            this._dgvDataShow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dgvDataShow.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this._dgvDataShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvDataShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgvDataShow.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._dgvDataShow.Location = new System.Drawing.Point(0, 0);
            this._dgvDataShow.MultiSelect = false;
            this._dgvDataShow.Name = "_dgvDataShow";
            this._dgvDataShow.RowHeadersVisible = false;
            this._dgvDataShow.RowTemplate.Height = 23;
            this._dgvDataShow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvDataShow.Size = new System.Drawing.Size(1071, 582);
            this._dgvDataShow.TabIndex = 0;
            // 
            // DataShowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 582);
            this.Controls.Add(this._dgvDataShow);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DataShowForm";
            this.Text = "DataShowForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DataShowForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this._dgvDataShow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridViewEx _dgvDataShow;
    }
}