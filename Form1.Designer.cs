namespace VTFeter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            shaderKind = new ComboBox();
            vmtPath = new TextBox();
            checkBM = new CheckBox();
            checkAdd = new CheckBox();
            checkAlpha = new CheckBox();
            bumpMap = new TextBox();
            checkColor = new CheckBox();
            flowLayout = new FlowLayoutPanel();
            addField = new Button();
            exportButton = new Button();
            copyButton = new Button();
            vtexSelector = new OpenFileDialog();
            shellCheck = new CheckBox();
            SuspendLayout();
            // 
            // shaderKind
            // 
            shaderKind.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            shaderKind.DisplayMember = "UnlitGeneric";
            shaderKind.FormattingEnabled = true;
            shaderKind.Items.AddRange(new object[] { "UnlitGeneric", "VertexLitGeneric", "LightmappedGeneric" });
            shaderKind.Location = new Point(12, 41);
            shaderKind.Name = "shaderKind";
            shaderKind.Size = new Size(307, 23);
            shaderKind.TabIndex = 0;
            shaderKind.Text = "UnlitGeneric";
            shaderKind.SelectedIndexChanged += shaderKind_SelectedIndexChanged;
            // 
            // vmtPath
            // 
            vmtPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            vmtPath.Location = new Point(12, 12);
            vmtPath.Name = "vmtPath";
            vmtPath.Size = new Size(307, 23);
            vmtPath.TabIndex = 1;
            vmtPath.Text = "basepath";
            vmtPath.TextChanged += vmtPath_TextChanged;
            // 
            // checkBM
            // 
            checkBM.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            checkBM.AutoSize = true;
            checkBM.Location = new Point(12, 74);
            checkBM.Name = "checkBM";
            checkBM.Size = new Size(88, 19);
            checkBM.TabIndex = 3;
            checkBM.Text = "$bumpmap";
            checkBM.UseVisualStyleBackColor = true;
            // 
            // checkAdd
            // 
            checkAdd.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            checkAdd.AutoSize = true;
            checkAdd.Location = new Point(12, 99);
            checkAdd.Name = "checkAdd";
            checkAdd.Size = new Size(74, 19);
            checkAdd.TabIndex = 4;
            checkAdd.Text = "$additive";
            checkAdd.UseVisualStyleBackColor = true;
            // 
            // checkAlpha
            // 
            checkAlpha.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            checkAlpha.AutoSize = true;
            checkAlpha.Checked = true;
            checkAlpha.CheckState = CheckState.Checked;
            checkAlpha.Location = new Point(103, 99);
            checkAlpha.Name = "checkAlpha";
            checkAlpha.Size = new Size(93, 19);
            checkAlpha.TabIndex = 5;
            checkAlpha.Text = "$vertexalpha";
            checkAlpha.UseVisualStyleBackColor = true;
            // 
            // bumpMap
            // 
            bumpMap.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            bumpMap.Location = new Point(101, 70);
            bumpMap.Name = "bumpMap";
            bumpMap.Size = new Size(218, 23);
            bumpMap.TabIndex = 6;
            bumpMap.TextChanged += bumpMap_TextChanged;
            // 
            // checkColor
            // 
            checkColor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            checkColor.AutoSize = true;
            checkColor.Checked = true;
            checkColor.CheckState = CheckState.Checked;
            checkColor.Location = new Point(211, 99);
            checkColor.Name = "checkColor";
            checkColor.Size = new Size(91, 19);
            checkColor.TabIndex = 8;
            checkColor.Text = "$vertexcolor";
            checkColor.UseVisualStyleBackColor = true;
            // 
            // flowLayout
            // 
            flowLayout.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayout.AutoScroll = true;
            flowLayout.Location = new Point(12, 124);
            flowLayout.Name = "flowLayout";
            flowLayout.Size = new Size(307, 151);
            flowLayout.TabIndex = 9;
            // 
            // addField
            // 
            addField.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            addField.Location = new Point(10, 281);
            addField.Name = "addField";
            addField.Size = new Size(312, 23);
            addField.TabIndex = 10;
            addField.Text = "Add Field";
            addField.UseVisualStyleBackColor = true;
            addField.Click += addField_Click;
            // 
            // exportButton
            // 
            exportButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            exportButton.Location = new Point(11, 310);
            exportButton.Name = "exportButton";
            exportButton.Size = new Size(193, 43);
            exportButton.TabIndex = 11;
            exportButton.Text = "Export";
            exportButton.UseVisualStyleBackColor = true;
            exportButton.Click += exportButton_Click;
            // 
            // copyButton
            // 
            copyButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            copyButton.Location = new Point(210, 310);
            copyButton.Name = "copyButton";
            copyButton.Size = new Size(112, 43);
            copyButton.TabIndex = 12;
            copyButton.Text = "Copy";
            copyButton.UseVisualStyleBackColor = true;
            copyButton.Click += copyButton_Click;
            // 
            // vtexSelector
            // 
            vtexSelector.DefaultExt = "exe";
            vtexSelector.FileName = "Select VTEX";
            vtexSelector.Filter = "|vtex.exe";
            vtexSelector.Title = "Select VTEX.exe";
            // 
            // shellCheck
            // 
            shellCheck.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            shellCheck.AutoSize = true;
            shellCheck.Location = new Point(10, 359);
            shellCheck.Name = "shellCheck";
            shellCheck.Size = new Size(106, 19);
            shellCheck.TabIndex = 13;
            shellCheck.Text = "Add to Send To";
            shellCheck.UseVisualStyleBackColor = true;
            shellCheck.CheckedChanged += shellCheck_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 390);
            Controls.Add(shellCheck);
            Controls.Add(copyButton);
            Controls.Add(exportButton);
            Controls.Add(addField);
            Controls.Add(flowLayout);
            Controls.Add(checkColor);
            Controls.Add(bumpMap);
            Controls.Add(checkAlpha);
            Controls.Add(checkAdd);
            Controls.Add(checkBM);
            Controls.Add(vmtPath);
            Controls.Add(shaderKind);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(350, 800);
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            MinimumSize = new Size(350, 320);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterParent;
            Text = "VTFeter";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox shaderKind;
        private TextBox vmtPath;
        private CheckBox checkBM;
        private CheckBox checkAdd;
        private CheckBox checkAlpha;
        private TextBox bumpMap;
        private CheckBox checkColor;
        private FlowLayoutPanel flowLayout;
        private Button addField;
        private Button exportButton;
        private Button copyButton;
        private OpenFileDialog vtexSelector;
        private CheckBox shellCheck;
    }
}