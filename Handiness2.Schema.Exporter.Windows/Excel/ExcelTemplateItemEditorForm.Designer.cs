namespace Handiness2.Schema.Exporter.Windows
{
    partial class ExcelTemplateItemEditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExcelTemplateItemEditorForm));
            this._pgTemplateItemEditor = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // _pgTemplateItemEditor
            // 
            resources.ApplyResources(this._pgTemplateItemEditor, "_pgTemplateItemEditor");
            this._pgTemplateItemEditor.Name = "_pgTemplateItemEditor";
            // 
            // ExcelTemplateItemEditorForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._pgTemplateItemEditor);
            this.MaximizeBox = false;
            this.Name = "ExcelTemplateItemEditorForm";
            this.ShowIcon = false;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid _pgTemplateItemEditor;
    }
}