#Requires -Version 5.0

$CurrentDir = $PSScriptRoot
$SourcePath = Resolve-Path -Path "..\Projects"
$DestinationPath = "Templates"

$TargetDestination = "$($CurrentDir)\$($DestinationPath)"

Function GetDirectories
{
  $Collection = {}.Invoke()
  $ExcludeList = @($DestinationPath, "bin*", "obj*")
  Get-ChildItem $SourcePath -Recurse -Directory | % {
    $PathParts = $_.FullName.substring($SourcePath.Length + 1).split("\");
    If(!($ExcludeList | Where { $PathParts -like $_ }))
    {
      $Collection.Add($_)
    }
  }

  Return $Collection
}

Function GetDirectoryFiles($Directory)
{
  $Collection = {}.Invoke()
  $ExcludeList = @($DestinationPath, "bin*", "obj*", "*.user", "*.DotSettings", "*.lock.json", "*.nuget.props")
  Get-ChildItem $Directory -Recurse -File | % {
      $PathParts = $_.FullName.substring($SourcePath.Length + 1).split("\");
      If(!($ExcludeList | Where { $PathParts -like $_ }))
      {
        $Collection.Add($_)
      }
  }

  Return $Collection
}

Function EnsureDirectoryExists($Path)
{
  If (!(Test-Path -Path $Path))
  {
    New-Item -ItemType directory -Path $Path
  }
}

Function CreateReplacementString($String, $Replacements)
{
  foreach($key in $Replacements.keys)
  {
    $String = $String.replace($key, $Replacements[$key])
  }

  Return $String
}

Function GetTemplateReplacements()
{
  $TemplateReplacements = New-Object -TypeName System.Collections.Specialized.OrderedDictionary
  $TemplateReplacements.Add($SourcePath, '')
  $TemplateReplacements.Add('PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Projects', '$customnamespace$')
  $TemplateReplacements.Add('PeinearyDevelopment', '$businessname$')
  $TemplateReplacements.Add('$businessname$.', 'PeinearyDevelopment.')
  $TemplateReplacements.Add('BusinessComponents', '$specificconcept$')
  $TemplateReplacements.Add('BusinessComponent', '$specificconceptsingularized$')
  $TemplateReplacements.Add('businessComponents', '$pascalspecificconcept$')
  $TemplateReplacements.Add('businessComponent', '$pascalspecificconceptsingularized$')
  $TemplateReplacements.Add('business components', '$humanizedspecificconcept$')
  $TemplateReplacements.Add('business component', '$humanizedspecificconceptsingularized$')

  Return $TemplateReplacements
}

Function MakeTemplateFile($OriginalFile)
{
  $TemplateReplacements = GetTemplateReplacements
  $LocalPath = CreateReplacementString $OriginalFile.FullName $TemplateReplacements
  $TempPath = "$($DestinationPath)$($LocalPath)"
  $Reader = [System.IO.StreamReader] $OriginalFile.FullName
  $Writer = [System.IO.StreamWriter] "$($CurrentDir)\$($TempPath)"
  While($null -ne ($Line = $Reader.ReadLine()))
  {
    $Writer.WriteLine((CreateReplacementString $Line $TemplateReplacements))
  }
  $Writer.close()
  $Reader.close()
}

Function CreateTempFiles()
{
  Foreach ($Directory In GetDirectories)
  {
    $LocalPath = $Directory.FullName.replace($SourcePath, '')
    EnsureDirectoryExists "$($CurrentDir)\$($DestinationPath)$($LocalPath)"
  }

  Foreach ($Directory In GetDirectories)
  {
    Foreach ($File In (GetDirectoryFiles "$($SourcePath)\$($Directory)"))
    {
      MakeTemplateFile $File
    }
  }
}

Function CreateMultiProjectVsTemplateFile()
{
  $Writer = [System.IO.StreamWriter] "$($TargetDestination)\ApiProjectTemplate.vstemplate"
  $Writer.WriteLine('<VSTemplate Version="3.0.0" Type="ProjectGroup" xmlns="http://schemas.microsoft.com/developer/vstemplate/2005">')
  $Writer.WriteLine('    <TemplateData>')
  $Writer.WriteLine('        <Name>Api Project Template</Name>')
  $Writer.WriteLine('        <Description>An template for quickly creating an api project</Description>')
  $Writer.WriteLine('        <Icon>PeinearyDevelopment.ico</Icon>')
  $Writer.WriteLine('        <ProjectType>CSharp</ProjectType>')
  $Writer.WriteLine('        <CreateNewFolder>true</CreateNewFolder>')
  $Writer.WriteLine('    </TemplateData>')
  $Writer.WriteLine('    <TemplateContent>')
  $Writer.WriteLine('        <ProjectCollection>')
  Foreach ($Directory In (Get-ChildItem $TargetDestination -Directory))
  {
    $Writer.WriteLine("            <ProjectTemplateLink ProjectName=`"$($Directory.Name)`" CopyParameters=`"true`">")
    $Writer.WriteLine("                $($Directory.Name)\$($Directory.Name).vstemplate")
    $Writer.WriteLine('            </ProjectTemplateLink>')
  }
  $Writer.WriteLine('        </ProjectCollection>')
  $Writer.WriteLine('    </TemplateContent>')
  $Writer.WriteLine('    <WizardExtension>')
  $Writer.WriteLine('      <Assembly>PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Wizards, Version=1.0.0.0, Culture=Neutral, PublicKeyToken=167e463fe9f95a97</Assembly>')
  $Writer.WriteLine('      <FullClassName>PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Wizards.ChildProjectWizard</FullClassName>')
  $Writer.WriteLine('    </WizardExtension>')
  $Writer.WriteLine('    <WizardData>')
  $Writer.WriteLine('      <ShowInputForm>True</ShowInputForm>')
  $Writer.WriteLine('    </WizardData>')
  $Writer.WriteLine('</VSTemplate>')
  $Writer.close()
}

Function CreateSingleProjectVsTemplateFile($Directory)
{
  $Writer = [System.IO.StreamWriter] "$($TargetDestination)\$($Directory.Name)\$($Directory.Name).vstemplate"
  $Writer.WriteLine('<VSTemplate Version="3.0.0" xmlns="http://schemas.microsoft.com/developer/vstemplate/2005" Type="Project">')
  $Writer.WriteLine('  <TemplateData>')
  $Writer.WriteLine("    <Name>$($Directory.Name)</Name>")
  $Writer.WriteLine('    <Description>&lt;No description available&gt;</Description>')
  $Writer.WriteLine('    <ProjectType>CSharp</ProjectType>')
  $Writer.WriteLine('    <ProjectSubType>')
  $Writer.WriteLine('    </ProjectSubType>')
  $Writer.WriteLine('    <SortOrder>1000</SortOrder>')
  $Writer.WriteLine('    <CreateNewFolder>true</CreateNewFolder>')
  $Writer.WriteLine("    <DefaultName>$($Directory.Name)</DefaultName>")
  $Writer.WriteLine('    <ProvideDefaultName>true</ProvideDefaultName>')
  $Writer.WriteLine('    <LocationField>Enabled</LocationField>')
  $Writer.WriteLine('    <EnableLocationBrowseButton>true</EnableLocationBrowseButton>')
  $Writer.WriteLine('    <Icon>PeinearyDevelopment.ico</Icon>')
  $Writer.WriteLine('  </TemplateData>')
  $Writer.WriteLine('  <TemplateContent>')
  $Writer.WriteLine("    <Project TargetFileName=`"$($Directory.Name).csproj`" File=`"$($Directory.Name).csproj`" ReplaceParameters=`"true`">")
  Foreach ($File In (Get-ChildItem "$($DestinationPath)\$($Directory.Name)" -File))
  {
    $Writer.WriteLine("      <ProjectItem ReplaceParameters=`"true`" TargetFileName=`"$($File.Name)`">$($File.Name)</ProjectItem>")
  }
  Foreach ($NestedDirectory In (Get-ChildItem "$($DestinationPath)\$($Directory.Name)" -Recurse -Directory))
  {
    $Writer.WriteLine("      <Folder Name=`"$($NestedDirectory.Name)`" TargetFolderName=`"$($NestedDirectory.Name)`">")
    Foreach ($File In  (Get-ChildItem "$($DestinationPath)\$($Directory.Name)\$($NestedDirectory.Name)" -File))
    {
      $Writer.WriteLine("        <ProjectItem ReplaceParameters=`"true`" TargetFileName=`"$($File.Name)`">$($File.Name)</ProjectItem>")
    }
    $Writer.WriteLine('      </Folder>')
  }
  $Writer.WriteLine('    </Project>')
  $Writer.WriteLine('  </TemplateContent>')
  $Writer.WriteLine('    <WizardExtension>')
  $Writer.WriteLine('      <Assembly>PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Wizards, Version=1.0.0.0, Culture=Neutral, PublicKeyToken=167e463fe9f95a97</Assembly>')
  $Writer.WriteLine('      <FullClassName>PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Wizards.ChildProjectWizard</FullClassName>')
  $Writer.WriteLine('    </WizardExtension>')
  $Writer.WriteLine('    <WizardData>')
  $Writer.WriteLine('      <ShowInputForm>False</ShowInputForm>')
  $Writer.WriteLine('    </WizardData>')
  $Writer.WriteLine('</VSTemplate>')
  $Writer.close()
}

Function CreateVsTemplateFiles()
{
  CreateMultiProjectVsTemplateFile

  Foreach ($Directory In (Get-ChildItem $DestinationPath -Directory))
  {
    CreateSingleProjectVsTemplateFile $Directory
  }
}

Function CopyTemplateIcon()
{
  Copy-Item "$($CurrentDir)\PeinearyDevelopment.ico" "$($DestinationPath)\PeinearyDevelopment.ico"

  Foreach ($Directory In (Get-ChildItem "$($DestinationPath)" -Directory))
  {
    Copy-Item "$($CurrentDir)\PeinearyDevelopment.ico" "$($DestinationPath)\$($Directory.Name)\PeinearyDevelopment.ico"
  }
}

Function CreateZip()
{
  Compress-Archive -Path (Get-ChildItem $TargetDestination | Select -ExpandProperty FullName) -Force -DestinationPath "$($CurrentDir)\ProjectTemplates\Template.zip"
}

Function GenerateTemplate()
{
  EnsureDirectoryExists $DestinationPath
  CreateTempFiles
  CreateVsTemplateFiles
  CopyTemplateIcon
  CreateZip
  Remove-Item -Recurse -Force $TargetDestination
}

GenerateTemplate