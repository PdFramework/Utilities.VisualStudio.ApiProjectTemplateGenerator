namespace PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Wizards
{
  partial class InputForm
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
            this.components = new System.ComponentModel.Container();
            this.BusinessNameLabel = new System.Windows.Forms.Label();
            this.BroadPurposeOptionsLabel = new System.Windows.Forms.Label();
            this.BroadPurposeOptions = new System.Windows.Forms.ComboBox();
            this.HasBroadConceptLabel = new System.Windows.Forms.Label();
            this.BroadConceptLabel = new System.Windows.Forms.Label();
            this.BroadConcept = new System.Windows.Forms.TextBox();
            this.HasMultipleExposuresLabel = new System.Windows.Forms.Label();
            this.ExposuresPanelLabel = new System.Windows.Forms.Label();
            this.SpecificConceptLabel = new System.Windows.Forms.Label();
            this.SpecificConcept = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.HasBroadConcept = new System.Windows.Forms.CheckBox();
            this.BusinessName = new System.Windows.Forms.TextBox();
            this.HasMultipleExposures = new System.Windows.Forms.CheckBox();
            this.GenerateProjectButton = new System.Windows.Forms.Button();
            this.ExposuresPanel = new System.Windows.Forms.Panel();
            this.IsInternallyExposedImplementation = new System.Windows.Forms.RadioButton();
            this.IsExternallyExposedImplementation = new System.Windows.Forms.RadioButton();
            this.ExposuresPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BusinessNameLabel
            // 
            this.BusinessNameLabel.AutoSize = true;
            this.BusinessNameLabel.Location = new System.Drawing.Point(13, 29);
            this.BusinessNameLabel.Name = "BusinessNameLabel";
            this.BusinessNameLabel.Size = new System.Drawing.Size(237, 13);
            this.BusinessNameLabel.TabIndex = 0;
            this.BusinessNameLabel.Text = "What business entity is this being developed for?";
            // 
            // BroadPurposeOptionsLabel
            // 
            this.BroadPurposeOptionsLabel.AutoSize = true;
            this.BroadPurposeOptionsLabel.Location = new System.Drawing.Point(13, 65);
            this.BroadPurposeOptionsLabel.Name = "BroadPurposeOptionsLabel";
            this.BroadPurposeOptionsLabel.Size = new System.Drawing.Size(285, 13);
            this.BroadPurposeOptionsLabel.TabIndex = 2;
            this.BroadPurposeOptionsLabel.Text = "What is the broad purpose that this is being developed for?";
            // 
            // BroadPurposeOptions
            // 
            this.BroadPurposeOptions.FormattingEnabled = true;
            this.BroadPurposeOptions.Location = new System.Drawing.Point(490, 62);
            this.BroadPurposeOptions.Name = "BroadPurposeOptions";
            this.BroadPurposeOptions.Size = new System.Drawing.Size(121, 21);
            this.BroadPurposeOptions.TabIndex = 3;
            this.toolTip1.SetToolTip(this.BroadPurposeOptions, "Examples: Framework, User Interface, Applications, BusinessComponents");
            // 
            // HasBroadConceptLabel
            // 
            this.HasBroadConceptLabel.AutoSize = true;
            this.HasBroadConceptLabel.Location = new System.Drawing.Point(13, 100);
            this.HasBroadConceptLabel.Name = "HasBroadConceptLabel";
            this.HasBroadConceptLabel.Size = new System.Drawing.Size(389, 13);
            this.HasBroadConceptLabel.TabIndex = 4;
            this.HasBroadConceptLabel.Text = "Is there a broad umbrella concept in which the code under development can fall?";
            // 
            // BroadConceptLabel
            // 
            this.BroadConceptLabel.AutoSize = true;
            this.BroadConceptLabel.Enabled = false;
            this.BroadConceptLabel.Location = new System.Drawing.Point(58, 135);
            this.BroadConceptLabel.Name = "BroadConceptLabel";
            this.BroadConceptLabel.Size = new System.Drawing.Size(198, 13);
            this.BroadConceptLabel.TabIndex = 7;
            this.BroadConceptLabel.Text = "What is it (please pluralize the concept)?";
            // 
            // BroadConcept
            // 
            this.BroadConcept.Enabled = false;
            this.BroadConcept.Location = new System.Drawing.Point(490, 132);
            this.BroadConcept.Name = "BroadConcept";
            this.BroadConcept.Size = new System.Drawing.Size(121, 20);
            this.BroadConcept.TabIndex = 8;
            this.toolTip1.SetToolTip(this.BroadConcept, "Examples: Addresses could be on its own, but is a concept that is tied directly t" +
        "o the broader concept of Locations");
            // 
            // HasMultipleExposuresLabel
            // 
            this.HasMultipleExposuresLabel.AutoSize = true;
            this.HasMultipleExposuresLabel.Enabled = false;
            this.HasMultipleExposuresLabel.Location = new System.Drawing.Point(13, 169);
            this.HasMultipleExposuresLabel.Name = "HasMultipleExposuresLabel";
            this.HasMultipleExposuresLabel.Size = new System.Drawing.Size(411, 13);
            this.HasMultipleExposuresLabel.TabIndex = 9;
            this.HasMultipleExposuresLabel.Text = "Will {this concept} potentially be exposed inside our network and outside of the " +
    "DMZ?";
            // 
            // ExposuresPanelLabel
            // 
            this.ExposuresPanelLabel.AutoSize = true;
            this.ExposuresPanelLabel.Enabled = false;
            this.ExposuresPanelLabel.Location = new System.Drawing.Point(58, 203);
            this.ExposuresPanelLabel.Name = "ExposuresPanelLabel";
            this.ExposuresPanelLabel.Size = new System.Drawing.Size(144, 13);
            this.ExposuresPanelLabel.TabIndex = 12;
            this.ExposuresPanelLabel.Text = "Which one is this project for?";
            // 
            // SpecificConceptLabel
            // 
            this.SpecificConceptLabel.AutoSize = true;
            this.SpecificConceptLabel.Location = new System.Drawing.Point(13, 234);
            this.SpecificConceptLabel.Name = "SpecificConceptLabel";
            this.SpecificConceptLabel.Size = new System.Drawing.Size(451, 13);
            this.SpecificConceptLabel.TabIndex = 15;
            this.SpecificConceptLabel.Text = "What is the specific concept you are developing this project for (please pluraliz" +
    "e the concept)?";
            // 
            // SpecificConcept
            // 
            this.SpecificConcept.Location = new System.Drawing.Point(490, 231);
            this.SpecificConcept.Name = "SpecificConcept";
            this.SpecificConcept.Size = new System.Drawing.Size(121, 20);
            this.SpecificConcept.TabIndex = 16;
            this.toolTip1.SetToolTip(this.SpecificConcept, "Examples: Logging, Addresses, Individuals, BlogPosts");
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // HasBroadConcept
            // 
            this.HasBroadConcept.AutoSize = true;
            this.HasBroadConcept.Location = new System.Drawing.Point(490, 99);
            this.HasBroadConcept.Name = "HasBroadConcept";
            this.HasBroadConcept.Size = new System.Drawing.Size(42, 17);
            this.HasBroadConcept.TabIndex = 12;
            this.HasBroadConcept.Text = "yes";
            this.toolTip1.SetToolTip(this.HasBroadConcept, "Examples: Addresses could be on its own, but is a concept that is tied directly t" +
        "o the broader concept of Locations");
            this.HasBroadConcept.UseVisualStyleBackColor = true;
            // 
            // BusinessName
            // 
            this.BusinessName.Location = new System.Drawing.Point(493, 29);
            this.BusinessName.Name = "BusinessName";
            this.BusinessName.Size = new System.Drawing.Size(118, 20);
            this.BusinessName.TabIndex = 21;
            this.toolTip1.SetToolTip(this.BusinessName, "Examples: PeinearyDevelopment, ThirdPartyContractingVendor");
            // 
            // HasMultipleExposures
            // 
            this.HasMultipleExposures.AutoSize = true;
            this.HasMultipleExposures.Enabled = false;
            this.HasMultipleExposures.Location = new System.Drawing.Point(490, 165);
            this.HasMultipleExposures.Name = "HasMultipleExposures";
            this.HasMultipleExposures.Size = new System.Drawing.Size(42, 17);
            this.HasMultipleExposures.TabIndex = 20;
            this.HasMultipleExposures.Text = "yes";
            this.HasMultipleExposures.UseVisualStyleBackColor = true;
            // 
            // GenerateProjectButton
            // 
            this.GenerateProjectButton.Location = new System.Drawing.Point(490, 269);
            this.GenerateProjectButton.Name = "GenerateProjectButton";
            this.GenerateProjectButton.Size = new System.Drawing.Size(121, 23);
            this.GenerateProjectButton.TabIndex = 17;
            this.GenerateProjectButton.Text = "Generate Project";
            this.GenerateProjectButton.UseVisualStyleBackColor = true;
            this.GenerateProjectButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // ExposuresPanel
            // 
            this.ExposuresPanel.Controls.Add(this.IsInternallyExposedImplementation);
            this.ExposuresPanel.Controls.Add(this.IsExternallyExposedImplementation);
            this.ExposuresPanel.Location = new System.Drawing.Point(490, 194);
            this.ExposuresPanel.Name = "ExposuresPanel";
            this.ExposuresPanel.Size = new System.Drawing.Size(121, 30);
            this.ExposuresPanel.TabIndex = 19;
            // 
            // IsInternallyExposedImplementation
            // 
            this.IsInternallyExposedImplementation.AutoSize = true;
            this.IsInternallyExposedImplementation.Enabled = false;
            this.IsInternallyExposedImplementation.Location = new System.Drawing.Point(3, 7);
            this.IsInternallyExposedImplementation.Name = "IsInternallyExposedImplementation";
            this.IsInternallyExposedImplementation.Size = new System.Drawing.Size(59, 17);
            this.IsInternallyExposedImplementation.TabIndex = 10;
            this.IsInternallyExposedImplementation.TabStop = true;
            this.IsInternallyExposedImplementation.Text = "internal";
            this.IsInternallyExposedImplementation.UseVisualStyleBackColor = true;
            // 
            // IsExternallyExposedImplementation
            // 
            this.IsExternallyExposedImplementation.AutoSize = true;
            this.IsExternallyExposedImplementation.Enabled = false;
            this.IsExternallyExposedImplementation.Location = new System.Drawing.Point(62, 7);
            this.IsExternallyExposedImplementation.Name = "IsExternallyExposedImplementation";
            this.IsExternallyExposedImplementation.Size = new System.Drawing.Size(62, 17);
            this.IsExternallyExposedImplementation.TabIndex = 11;
            this.IsExternallyExposedImplementation.TabStop = true;
            this.IsExternallyExposedImplementation.Text = "external";
            this.IsExternallyExposedImplementation.UseVisualStyleBackColor = true;
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 304);
            this.Controls.Add(this.BusinessName);
            this.Controls.Add(this.HasMultipleExposures);
            this.Controls.Add(this.HasBroadConcept);
            this.Controls.Add(this.ExposuresPanel);
            this.Controls.Add(this.GenerateProjectButton);
            this.Controls.Add(this.SpecificConcept);
            this.Controls.Add(this.SpecificConceptLabel);
            this.Controls.Add(this.ExposuresPanelLabel);
            this.Controls.Add(this.HasMultipleExposuresLabel);
            this.Controls.Add(this.BroadConcept);
            this.Controls.Add(this.BroadConceptLabel);
            this.Controls.Add(this.HasBroadConceptLabel);
            this.Controls.Add(this.BroadPurposeOptions);
            this.Controls.Add(this.BroadPurposeOptionsLabel);
            this.Controls.Add(this.BusinessNameLabel);
            this.Name = "InputForm";
            this.Text = "ApiTemplateInput";
            this.ExposuresPanel.ResumeLayout(false);
            this.ExposuresPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label BusinessNameLabel;
    private System.Windows.Forms.Label BroadPurposeOptionsLabel;
    public System.Windows.Forms.ComboBox BroadPurposeOptions;
    private System.Windows.Forms.Label HasBroadConceptLabel;
    private System.Windows.Forms.Label BroadConceptLabel;
    public System.Windows.Forms.TextBox BroadConcept;
    private System.Windows.Forms.Label HasMultipleExposuresLabel;
    private System.Windows.Forms.Label ExposuresPanelLabel;
    private System.Windows.Forms.Label SpecificConceptLabel;
    public System.Windows.Forms.TextBox SpecificConcept;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.Button GenerateProjectButton;
    private System.Windows.Forms.Panel ExposuresPanel;
    public System.Windows.Forms.RadioButton IsInternallyExposedImplementation;
    public System.Windows.Forms.RadioButton IsExternallyExposedImplementation;
    private System.Windows.Forms.CheckBox HasBroadConcept;
    private System.Windows.Forms.CheckBox HasMultipleExposures;
        private System.Windows.Forms.TextBox BusinessName;
    }
}