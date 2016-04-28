using System.Collections.Generic;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;

namespace PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Wizards
{
    public class ChildProjectWizard : IWizard
    {
        /******                                                                                                                                             *****
          ***** How to use a wizard to allow custom parameters to be passed to your child template                                                          *****
          ***** http://blogs.msmvps.com/kevinmcneish/2010/09/22/multi-project-visual-studio-template-tricks/                                                *****
          *****                                                                                                                                             *****
          ***** Code sample project referenced in comments with a way to make this work                                                                     *****
          ***** http://vsix.codeplex.com/SourceControl/latest#Multi-Project%20Templates%20Sample%20Solution/ProjectTemplate1/ProjectTemplateRoot.vstemplate *****
          *****                                                                                                                                             ******/
        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            replacementsDictionary.Add("$businessname$", Wizard.GlobalDictionary["$businessname$"]);
            replacementsDictionary.Add("$broadpurpose$", Wizard.GlobalDictionary["$broadpurpose$"]);
            replacementsDictionary.Add("$broadconcept$", Wizard.GlobalDictionary["$broadconcept$"]);
            replacementsDictionary.Add("$exposure$", Wizard.GlobalDictionary["$exposure$"]);
            replacementsDictionary.Add("$specificconcept$", Wizard.GlobalDictionary["$specificconcept$"]);
            replacementsDictionary.Add("$customnamespace$", Wizard.GlobalDictionary["$customnamespace$"]);
            replacementsDictionary.Add("$pascalspecificconcept$", Wizard.GlobalDictionary["$pascalspecificconcept$"]);
            replacementsDictionary.Add("$pascalspecificconceptsingularized$", Wizard.GlobalDictionary["$pascalspecificconceptsingularized$"]);
            replacementsDictionary.Add("$specificconceptsingularized$", Wizard.GlobalDictionary["$specificconceptsingularized$"]);
            replacementsDictionary.Add("$humanizedspecificconcept$", Wizard.GlobalDictionary["$humanizedspecificconcept$"]);
            replacementsDictionary.Add("$humanizedspecificconceptsingularized$", Wizard.GlobalDictionary["$humanizedspecificconceptsingularized$"]);
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }

        public void RunFinished()
        {
        }

        public void BeforeOpeningFile(ProjectItem projectItem)
        {
        }

        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
        }

        public void ProjectFinishedGenerating(Project project)
        {
        }
    }
}
