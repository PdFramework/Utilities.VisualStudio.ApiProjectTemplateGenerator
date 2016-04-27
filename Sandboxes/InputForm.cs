using System;
using System.Drawing;
using System.Windows.Forms;

namespace PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Sandboxes.InputForms
{
  public partial class InputForm : Form
  {
    public string BusinessNameString { get; set; }
    public string BroadPurpose { get; set; }
    public string BroadConceptString { get; set; }
    public string Exposure { get; set; }
    public string SpecificConceptString { get; set; }

    public InputForm()
    {
      InitializeComponent();
      InitializeEvents();
      InitializeOptions();
    }

    private void InitializeEvents()
    {
      HasBroadConcept.CheckedChanged += HasBroadConceptOnCheckedChanged;
      HasMultipleExposures.CheckedChanged += ExposureOnCheckedChangedOnCheckedChanged;
      IsExternallyExposedImplementation.CheckedChanged += ExposureOnCheckedChanged;
      IsInternallyExposedImplementation.CheckedChanged += ExposureOnCheckedChanged;
    }

    private void ExposureOnCheckedChangedOnCheckedChanged(object sender, EventArgs e)
    {
      if (!HasMultipleExposures.Checked)
      {
        SpecificConceptLabel.Enabled = false;
        SpecificConcept.Enabled = false;
      }
    }

    private void ExposureOnCheckedChanged(object sender, EventArgs e)
    {
      if (IsInternallyExposedImplementation.Checked || IsExternallyExposedImplementation.Checked)
      {
        SpecificConceptLabel.Enabled = true;
        SpecificConcept.Enabled = true;
      }
      else
      {
        SpecificConceptLabel.Enabled = false;
        SpecificConcept.Enabled = false;
      }
    }

    private void HasBroadConceptOnCheckedChanged(object sender, EventArgs eventArgs)
    {
      if (HasBroadConcept.Checked)
      {
        BroadConceptLabel.Enabled = true;
        BroadConcept.Enabled = true;

        HasMultipleExposuresLabel.Enabled = true;
        HasMultipleExposures.Enabled = true;

        ExposuresPanelLabel.Enabled = true;
        IsInternallyExposedImplementation.Enabled = true;
        IsExternallyExposedImplementation.Enabled = true;

        SpecificConceptLabel.Enabled = false;
        SpecificConcept.Enabled = false;
      }
      else
      {
        BroadConceptLabel.Enabled = false;
        BroadConcept.Enabled = false;

        HasMultipleExposuresLabel.Enabled = false;
        HasMultipleExposures.Enabled = false;

        ExposuresPanelLabel.Enabled = false;
        IsInternallyExposedImplementation.Enabled = false;
        IsExternallyExposedImplementation.Enabled = false;

        SpecificConceptLabel.Enabled = true;
        SpecificConcept.Enabled = true;
      }
    }

    private void InitializeOptions()
    {
      BroadPurposeOptions.DisplayMember = "Item1";
      BroadPurposeOptions.ValueMember = "Item2";
      BroadPurposeOptions.DataSource = new[]
      {
        new Tuple<string, string>("Business Component", "BusinessComponents"),
        new Tuple<string, string>("Application", "Applications"),
        new Tuple<string, string>("Framework", "Framework"),
        new Tuple<string, string>("Utilities", "Utilities")
      };
      BroadPurposeOptions.SelectedIndex = 0;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      BusinessNameString = BusinessName.Text;
      BroadPurpose = ((Tuple<string, string>)BroadPurposeOptions.SelectedItem).Item2;

      if (HasBroadConcept.Checked)
      {
        var broadConcept = BroadConcept.Text;
        if (string.IsNullOrWhiteSpace(broadConcept))
        {
          BroadConcept.BackColor = Color.LightPink;
          return;
        }
        BroadConceptString = broadConcept;
        BroadConcept.BackColor = Color.White;
      }
      else
      {
        BroadConceptString = string.Empty;
        BroadConcept.BackColor = Color.White;
      }

      if (HasMultipleExposures.Checked)
      {
        if (!IsInternallyExposedImplementation.Checked && !IsExternallyExposedImplementation.Checked)
        {
          ExposuresPanel.BackColor = Color.LightPink;
          return;
        }
        if (IsInternallyExposedImplementation.Checked)
        {
          Exposure = "Internal";
        }

        if (IsExternallyExposedImplementation.Checked)
        {
          Exposure = "External";
        }
        ExposuresPanel.BackColor = Color.White;
      }
      else
      {
        Exposure = string.Empty;
        ExposuresPanel.BackColor = Color.White;
      }

      SpecificConceptString = SpecificConcept.Text;
      Dispose();
    }
  }
}
