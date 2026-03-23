namespace EmergencyDeviceLoader;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
private System.ComponentModel.IContainer components = null;

      // Fields for UI controls
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.ComboBox comboEDLPorts;
      private System.Windows.Forms.Button btnRefresh;
      private System.Windows.Forms.Button btnConnect;
      private System.Windows.Forms.Label lblStatus;
      private System.Windows.Forms.TextBox txtLog;

     /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        this.label1 = new System.Windows.Forms.Label();
        this.comboEDLPorts = new System.Windows.Forms.ComboBox();
        this.btnRefresh = new System.Windows.Forms.Button();
        this.btnConnect = new System.Windows.Forms.Button();
        this.lblStatus = new System.Windows.Forms.Label();
        this.txtLog = new System.Windows.Forms.TextBox();
        this.tableLayoutPanel1.SuspendLayout();
        this.SuspendLayout();
        // 
        // tableLayoutPanel1
        // 
        this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(15)))));
        this.tableLayoutPanel1.ColumnCount = 2;
        this.tableLayoutPanel1.RowCount = 5;
        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tableLayoutPanel1.Name = "tableLayoutPanel1";
        this.tableLayoutPanel1.TabIndex = 0;
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.label1.Name = "label1";
        this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
        this.label1.TabIndex = 0;
        this.label1.Text = "Select EDL Port:";
        // 
        // comboEDLPorts
        // 
        this.comboEDLPorts.Dock = System.Windows.Forms.DockStyle.Fill;
        this.comboEDLPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.comboEDLPorts.FormattingEnabled = true;
        this.comboEDLPorts.Name = "comboEDLPorts";
        this.tableLayoutPanel1.SetColumnSpan(this.comboEDLPorts, 1);
        this.tableLayoutPanel1.SetRow(this.comboEDLPorts, 1);
        this.comboEDLPorts.TabIndex = 1;
        // 
        // btnRefresh
        // 
        this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Fill;
        this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(65)))));
        this.btnRefresh.FlatAppearance.BorderSize = 2;
        this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.btnRefresh.Name = "btnRefresh";
        this.tableLayoutPanel1.SetColumn(this.btnRefresh, 1);
        this.tableLayoutPanel1.SetRow(this.btnRefresh, 1);
        this.btnRefresh.TabIndex = 2;
        this.btnRefresh.Text = "Refresh";
        this.btnRefresh.UseVisualStyleBackColor = false;
        this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(15)))));
        this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(65)))));
        this.btnRefresh.MouseEnter += new System.EventHandler(this.btnRefresh_MouseEnter);
        this.btnRefresh.MouseLeave += new System.EventHandler(this.btnRefresh_MouseLeave);
        // 
        // btnConnect
        // 
        this.btnConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(15)))));
        this.btnConnect.Dock = System.Windows.Forms.DockStyle.Fill;
        this.btnConnect.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(65)))));
        this.btnConnect.FlatAppearance.BorderSize = 2;
        this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.btnConnect.Name = "btnConnect";
        this.tableLayoutPanel1.SetColumnSpan(this.btnConnect, 2);
        this.tableLayoutPanel1.SetRow(this.btnConnect, 2);
        this.btnConnect.TabIndex = 3;
        this.btnConnect.Text = "Connect to Device";
        this.btnConnect.UseVisualStyleBackColor = false;
        this.btnConnect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(65)))));
        this.btnConnect.MouseEnter += new System.EventHandler(this.btnConnect_MouseEnter);
        this.btnConnect.MouseLeave += new System.EventHandler(this.btnConnect_MouseLeave);
        // 
        // lblStatus
        // 
        this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.lblStatus.AutoSize = true;
        this.lblStatus.ForeColor = System.Drawing.Color.Gray;
        this.lblStatus.Name = "lblStatus";
        this.tableLayoutPanel1.SetColumnSpan(this.lblStatus, 2);
        this.tableLayoutPanel1.SetRow(this.lblStatus, 3);
        this.lblStatus.TabIndex = 4;
        this.lblStatus.Text = "Status: Ready";
        // 
        // txtLog
        // 
        this.txtLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(17)))), ((int)(((byte)(0)))));
        this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
        this.txtLog.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.txtLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(65)))));
        this.txtLog.Multiline = true;
        this.txtLog.Name = "txtLog";
        this.tableLayoutPanel1.SetColumnSpan(this.txtLog, 2);
        this.tableLayoutPanel1.SetRow(this.txtLog, 4);
        this.txtLog.ReadOnly = true;
        this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.txtLog.TabIndex = 5;
        // 
        // Form1
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(15)))));
        this.ClientSize = new System.Drawing.Size(650, 550);
        this.Controls.Add(this.tableLayoutPanel1);
        this.Name = "Form1";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "EmergencyDeviceLoader - Qualcomm EDL Tool";
        this.tableLayoutPanel1.ResumeLayout(false);
        this.tableLayoutPanel1.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion
}
