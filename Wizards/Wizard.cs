using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;

namespace PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Wizards
{
    /******                                                                                                 *****
      ***** How to use a wizard to allow custom parameters to be passed to your template                    *****
      ***** https://msdn.microsoft.com/en-us/library/ms185301.aspx                                          *****
      *****                                                                                                 ******/
    public class Wizard : IWizard
    {
        public static Dictionary<string, string> ReplacementsDictionary;

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            string runSilent;
            if (replacementsDictionary.TryGetValue("$runsilent$", out runSilent) && bool.TrueString.Equals(runSilent, StringComparison.OrdinalIgnoreCase)) return;

            string wizardData;
            if (!replacementsDictionary.TryGetValue("$wizarddata$", out wizardData)) return;

            if (string.IsNullOrWhiteSpace(wizardData)) return;

            var showInputForm = true;
            try
            {
                var document = XDocument.Parse(wizardData);
                showInputForm = bool.TrueString.Equals(document.Root.Value, StringComparison.OrdinalIgnoreCase);
            }
            catch (XmlException ex)
            {
                var error = new StringBuilder();
                error.AppendLine("Could not parse WizardData element.")
                     .AppendLine()
                     .Append(ex);
                MessageBox.Show(error.ToString());
            }

            if (showInputForm)
            {
                try
                {
                    ReplacementsDictionary = new Dictionary<string, string>();
                    var input = new InputForm();
                    input.ShowDialog();
                    var businessName = input.BusinessNameString;
                    var broadPurpose = input.BroadPurpose;
                    var broadConcept = input.BroadConceptString;
                    var exposure = input.Exposure;
                    var specificConcept = input.SpecificConceptString;
                    ReplacementsDictionary.Add("$template.businessname$", businessName);
                    ReplacementsDictionary.Add("$template.broadpurpose$", broadPurpose);
                    ReplacementsDictionary.Add("$template.broadconcept$", broadConcept);
                    ReplacementsDictionary.Add("$template.exposure$", exposure);
                    ReplacementsDictionary.Add("$template.specificconcept$", specificConcept);
                    ReplacementsDictionary.Add("$template.customnamespace$", CreateNamespace(new[] { businessName, broadPurpose, broadConcept, exposure, specificConcept }));
                    ReplacementsDictionary = CreateSpecificConceptVariations(specificConcept, ReplacementsDictionary);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString());
                }
            }

            foreach (var replacementKeyValuePair in ReplacementsDictionary)
            {
                replacementsDictionary.Add(replacementKeyValuePair.Key, replacementKeyValuePair.Value);
            }
        }

        public void ProjectFinishedGenerating(Project project)
        {
        }

        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
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

        private static string CreateNamespace(string[] namespaceParts)
        {
            var sb = new StringBuilder();
            foreach (var namespacePart in namespaceParts.Where(namespacePart => !string.IsNullOrWhiteSpace(namespacePart)))
            {
                sb.Append(namespacePart).Append(".");
            }
            var str = sb.ToString();
            return str.Substring(0, str.Length - 1);
        }

        private static Dictionary<string, string> CreateSpecificConceptVariations(string specificConcept, Dictionary<string, string> replacementsDictionary)
        {
            var vocabulary = Vocabularies.BuildDefault();
            var specificConceptSingularized = vocabulary.Singularize(specificConcept);

            replacementsDictionary.Add("$template.pascalspecificconcept$", char.ToLower(specificConcept[0]) + specificConcept.Substring(1));
            replacementsDictionary.Add("$template.pascalspecificconceptsingularized$", char.ToLower(specificConceptSingularized[0]) + specificConceptSingularized.Substring(1));
            replacementsDictionary.Add("$template.specificconceptsingularized$", specificConceptSingularized);
            replacementsDictionary.Add("$template.humanizedspecificconcept$", specificConcept.Humanize().ToLower());
            replacementsDictionary.Add("$template.humanizedspecificconceptsingularized$", specificConceptSingularized.Humanize().ToLower());

            return replacementsDictionary;
        }
    }

    #region Humanizer
    /******                                                                                                 *****
      ***** Easier to take code from solution that was made to help 'humanize' programming language idioms  *****
      ***** than to figure out how to get NuGet package to work with this solution because the dll from     *****
      ***** this wizard needs to be added to the GAC for the wizard to work properly with the VS template   *****
      ***** https://github.com/Humanizr/Humanizer                                                           *****
      *****                                                                                                 ******/
    internal class Vocabulary
    {
        private readonly List<Rule> _plurals = new List<Rule>();
        private readonly List<Rule> _singulars = new List<Rule>();
        private readonly List<string> _uncountables = new List<string>();

        public void AddIrregular(string singular, string plural)
        {
            AddPlural("(" + singular[0] + ")" + singular.Substring(1) + "$", "$1" + plural.Substring(1));
            AddSingular("(" + plural[0] + ")" + plural.Substring(1) + "$", "$1" + singular.Substring(1));
        }

        public void AddUncountable(string word)
        {
            _uncountables.Add(word.ToLower());
        }

        public void AddPlural(string rule, string replacement)
        {
            _plurals.Add(new Rule(rule, replacement));
        }

        public void AddSingular(string rule, string replacement)
        {
            _singulars.Add(new Rule(rule, replacement));
        }

        public string Pluralize(string word, bool inputIsKnownToBeSingular = true)
        {
            var result = ApplyRules(_plurals, word);

            if (inputIsKnownToBeSingular)
                return result;

            var asSingular = ApplyRules(_singulars, word);
            var asSingularAsPlural = ApplyRules(_plurals, asSingular);
            if (asSingular != null && asSingular != word && asSingular + "s" != word && asSingularAsPlural == word && result != word)
                return word;

            return result;
        }

        public string Singularize(string word, bool inputIsKnownToBePlural = true)
        {
            var result = ApplyRules(_singulars, word);

            if (inputIsKnownToBePlural)
                return result;

            var asPlural = ApplyRules(_plurals, word);
            var asPluralAsSingular = ApplyRules(_singulars, asPlural);
            if (asPlural != word && word + "s" != asPlural && asPluralAsSingular == word && result != word)
                return word;

            return result ?? word;
        }

        private string ApplyRules(IList<Rule> rules, string word)
        {
            if (word == null)
                return null;

            if (IsUncountable(word))
                return word;

            var result = word;
            for (var i = rules.Count - 1; i >= 0; i--)
            {
                if ((result = rules[i].Apply(word)) != null)
                    break;
            }
            return result;
        }

        private bool IsUncountable(string word)
        {
            return _uncountables.Contains(word.ToLower());
        }

        private class Rule
        {
            private readonly Regex _regex;
            private readonly string _replacement;

            public Rule(string pattern, string replacement)
            {
                _regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptionsUtil.Compiled);
                _replacement = replacement;
            }

            public string Apply(string word)
            {
                if (!_regex.IsMatch(word))
                    return null;

                return _regex.Replace(word, _replacement);
            }
        }
    }

    internal static class Vocabularies
    {
        public static Vocabulary BuildDefault()
        {
            var _default = new Vocabulary();

            _default.AddPlural("$", "s");
            _default.AddPlural("s$", "s");
            _default.AddPlural("(ax|test)is$", "$1es");
            _default.AddPlural("(octop|vir|alumn|fung)us$", "$1i");
            _default.AddPlural("(alias|status)$", "$1es");
            _default.AddPlural("(bu)s$", "$1ses");
            _default.AddPlural("(buffal|tomat|volcan)o$", "$1oes");
            _default.AddPlural("([ti])um$", "$1a");
            _default.AddPlural("sis$", "ses");
            _default.AddPlural("(?:([^f])fe|([lr])f)$", "$1$2ves");
            _default.AddPlural("(hive)$", "$1s");
            _default.AddPlural("([^aeiouy]|qu)y$", "$1ies");
            _default.AddPlural("(x|ch|ss|sh)$", "$1es");
            _default.AddPlural("(matr|vert|ind)ix|ex$", "$1ices");
            _default.AddPlural("([m|l])ouse$", "$1ice");
            _default.AddPlural("^(ox)$", "$1en");
            _default.AddPlural("(quiz)$", "$1zes");
            _default.AddPlural("(campus)$", "$1es");
            _default.AddPlural("^is$", "are");

            _default.AddSingular("s$", "");
            _default.AddSingular("(n)ews$", "$1ews");
            _default.AddSingular("([ti])a$", "$1um");
            _default.AddSingular("((a)naly|(b)a|(d)iagno|(p)arenthe|(p)rogno|(s)ynop|(t)he)ses$", "$1$2sis");
            _default.AddSingular("(^analy)ses$", "$1sis");
            _default.AddSingular("([^f])ves$", "$1fe");
            _default.AddSingular("(hive)s$", "$1");
            _default.AddSingular("(tive)s$", "$1");
            _default.AddSingular("([lr])ves$", "$1f");
            _default.AddSingular("([^aeiouy]|qu)ies$", "$1y");
            _default.AddSingular("(s)eries$", "$1eries");
            _default.AddSingular("(m)ovies$", "$1ovie");
            _default.AddSingular("(x|ch|ss|sh)es$", "$1");
            _default.AddSingular("([m|l])ice$", "$1ouse");
            _default.AddSingular("(bus)es$", "$1");
            _default.AddSingular("(o)es$", "$1");
            _default.AddSingular("(shoe)s$", "$1");
            _default.AddSingular("(cris|ax|test)es$", "$1is");
            _default.AddSingular("(octop|vir|alumn|fung)i$", "$1us");
            _default.AddSingular("(alias|status)es$", "$1");
            _default.AddSingular("^(ox)en", "$1");
            _default.AddSingular("(vert|ind)ices$", "$1ex");
            _default.AddSingular("(matr)ices$", "$1ix");
            _default.AddSingular("(quiz)zes$", "$1");
            _default.AddSingular("(campus)es$", "$1");
            _default.AddSingular("^are$", "is");

            _default.AddIrregular("person", "people");
            _default.AddIrregular("man", "men");
            _default.AddIrregular("child", "children");
            _default.AddIrregular("sex", "sexes");
            _default.AddIrregular("move", "moves");
            _default.AddIrregular("goose", "geese");
            _default.AddIrregular("alumna", "alumnae");
            _default.AddIrregular("criterion", "criteria");
            _default.AddIrregular("wave", "waves");

            _default.AddUncountable("equipment");
            _default.AddUncountable("information");
            _default.AddUncountable("rice");
            _default.AddUncountable("money");
            _default.AddUncountable("species");
            _default.AddUncountable("series");
            _default.AddUncountable("fish");
            _default.AddUncountable("sheep");
            _default.AddUncountable("deer");
            _default.AddUncountable("aircraft");
            _default.AddUncountable("oz");
            _default.AddUncountable("tsp");
            _default.AddUncountable("tbsp");
            _default.AddUncountable("ml");
            _default.AddUncountable("l");
            _default.AddUncountable("water");
            _default.AddUncountable("waters");
            _default.AddUncountable("semen");
            _default.AddUncountable("sperm");

            return _default;
        }
    }

    public static class RegexOptionsUtil
    {
        static RegexOptionsUtil()
        {
            RegexOptions compiled;
            Compiled = Enum.TryParse("Compiled", out compiled) ? compiled : RegexOptions.None;
        }

        public static RegexOptions Compiled { get; }
    }

    public static class Humanizer
    {
        private static readonly Regex PascalCaseWordPartsRegex = new Regex(@"[A-Z]?[a-z]+|[0-9]+[a-z]*|[A-Z]+(?=[A-Z][a-z]|[0-9]|\b)", RegexOptions.IgnorePatternWhitespace | RegexOptions.ExplicitCapture | RegexOptionsUtil.Compiled);
        private static readonly Regex FreestandingSpacingCharRegex = new Regex(@"\s[-_]|[-_]\s", RegexOptionsUtil.Compiled);

        public static string Humanize(this string input)
        {
            if (input.ToCharArray().All(char.IsUpper))
                return input;

            if (FreestandingSpacingCharRegex.IsMatch(input))
                return FromPascalCase(FromUnderscoreDashSeparatedWords(input));

            if (input.Contains("_") || input.Contains("-"))
                return FromUnderscoreDashSeparatedWords(input);

            return FromPascalCase(input);
        }

        private static string FromPascalCase(string input)
        {
            var result = string.Join(" ", PascalCaseWordPartsRegex
                .Matches(input).Cast<Match>()
                .Select(match => match.Value.ToCharArray().All(char.IsUpper) &&
                    (match.Value.Length > 1 || (match.Index > 0 && input[match.Index - 1] == ' ') || match.Value == "I")
                    ? match.Value
                    : match.Value.ToLower()));

            return result.Length > 0 ? char.ToUpper(result[0]) +
                result.Substring(1, result.Length - 1) : result;
        }

        private static string FromUnderscoreDashSeparatedWords(string input)
        {
            return string.Join(" ", input.Split(new[] { '_', '-' }));
        }
    }
    #endregion
}
