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
        ExposuresPanel.Enabled = true;

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
        ExposuresPanel.Enabled = false;

        SpecificConceptLabel.Enabled = true;
        SpecificConcept.Enabled = true;
      }
    }

    private void InitializeOptions()
    {
      BusinessName.Text = "PeinearyDevelopment";
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

    private void GenerateProjectButton_Click(object sender, EventArgs e)
    {
        if (!ValidateForm()) return;

        BusinessNameString = BusinessName.Text;
        BroadPurpose = ((Tuple<string, string>)BroadPurposeOptions.SelectedItem).Item2;
        BroadConceptString = HasBroadConcept.Checked ? BroadConcept.Text : string.Empty;

        if (HasMultipleExposures.Enabled && HasMultipleExposures.Checked)
        {
            if (IsInternallyExposedImplementation.Checked) Exposure = "Internal";
            if (IsExternallyExposedImplementation.Checked) Exposure = "External";
            if ((IsInternallyExposedImplementation.Checked && IsExternallyExposedImplementation.Checked) || (!IsInternallyExposedImplementation.Checked && !IsExternallyExposedImplementation.Checked)) throw new Exception();
        }
        else
        {
            Exposure = string.Empty;
        }

        SpecificConceptString = SpecificConcept.Text;

        Dispose();
    }

    /// <summary>
    /// Validates the user's input from the form.
    /// </summary>
    /// <returns>boolean: Indicating whether or not the form is valid.</returns>
    private bool ValidateForm()
    {
        var formIsValid = true;
        if (string.IsNullOrWhiteSpace(BusinessName.Text))
        {
            BusinessName.BackColor = Color.LightPink;
            formIsValid = false;
        }
        else
        {
            BusinessName.BackColor = default(Color);
        }

        if (HasBroadConcept.Checked && string.IsNullOrWhiteSpace(BroadConcept.Text))
        {
            BroadConcept.BackColor = Color.LightPink;
            formIsValid = false;
        }
        else
        {
            BroadConcept.BackColor = default(Color);
        }

        if (HasMultipleExposures.Enabled && HasMultipleExposures.Checked && !IsInternallyExposedImplementation.Checked && !IsExternallyExposedImplementation.Checked)
        {
            ExposuresPanel.BackColor = Color.LightPink;
            formIsValid = false;
        }
        else
        {
            ExposuresPanel.BackColor = default(Color);
        }

        if (SpecificConcept.Enabled && string.IsNullOrWhiteSpace(SpecificConcept.Text))
        {
            SpecificConcept.BackColor = Color.LightPink;
            formIsValid = false;
        }
        else
        {
            SpecificConcept.BackColor = default(Color);
        }

        return formIsValid;
    }
  }
}
