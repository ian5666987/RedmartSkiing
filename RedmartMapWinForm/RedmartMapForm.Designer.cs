namespace RedmartMapWinForm {
  partial class RedmartMapForm {
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
      this.buttonLoadMap = new System.Windows.Forms.Button();
      this.labelFileName = new System.Windows.Forms.Label();
      this.labelMapsize = new System.Windows.Forms.Label();
      this.buttonExecute = new System.Windows.Forms.Button();
      this.textBoxResult = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // buttonLoadMap
      // 
      this.buttonLoadMap.Location = new System.Drawing.Point(13, 13);
      this.buttonLoadMap.Name = "buttonLoadMap";
      this.buttonLoadMap.Size = new System.Drawing.Size(123, 31);
      this.buttonLoadMap.TabIndex = 0;
      this.buttonLoadMap.Text = "Load Map";
      this.buttonLoadMap.UseVisualStyleBackColor = true;
      this.buttonLoadMap.Click += new System.EventHandler(this.buttonLoadMap_Click);
      // 
      // labelFileName
      // 
      this.labelFileName.AutoSize = true;
      this.labelFileName.Location = new System.Drawing.Point(142, 20);
      this.labelFileName.MaximumSize = new System.Drawing.Size(500, 35);
      this.labelFileName.Name = "labelFileName";
      this.labelFileName.Size = new System.Drawing.Size(127, 17);
      this.labelFileName.TabIndex = 1;
      this.labelFileName.Text = "(no file is selected)";
      // 
      // labelMapsize
      // 
      this.labelMapsize.AutoSize = true;
      this.labelMapsize.Location = new System.Drawing.Point(12, 47);
      this.labelMapsize.Name = "labelMapsize";
      this.labelMapsize.Size = new System.Drawing.Size(72, 17);
      this.labelMapsize.TabIndex = 2;
      this.labelMapsize.Text = "Size: (NA)";
      // 
      // buttonExecute
      // 
      this.buttonExecute.Location = new System.Drawing.Point(15, 67);
      this.buttonExecute.Name = "buttonExecute";
      this.buttonExecute.Size = new System.Drawing.Size(123, 31);
      this.buttonExecute.TabIndex = 3;
      this.buttonExecute.Text = "Execute";
      this.buttonExecute.UseVisualStyleBackColor = true;
      this.buttonExecute.Click += new System.EventHandler(this.buttonExecute_Click);
      // 
      // textBoxResult
      // 
      this.textBoxResult.Location = new System.Drawing.Point(145, 71);
      this.textBoxResult.Name = "textBoxResult";
      this.textBoxResult.ReadOnly = true;
      this.textBoxResult.Size = new System.Drawing.Size(210, 22);
      this.textBoxResult.TabIndex = 4;
      // 
      // RedmartMapForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(646, 114);
      this.Controls.Add(this.textBoxResult);
      this.Controls.Add(this.buttonExecute);
      this.Controls.Add(this.labelMapsize);
      this.Controls.Add(this.labelFileName);
      this.Controls.Add(this.buttonLoadMap);
      this.Name = "RedmartMapForm";
      this.Text = "Redmart Skiing Challenge v1.0";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button buttonLoadMap;
    private System.Windows.Forms.Label labelFileName;
    private System.Windows.Forms.Label labelMapsize;
    private System.Windows.Forms.Button buttonExecute;
    private System.Windows.Forms.TextBox textBoxResult;
  }
}

