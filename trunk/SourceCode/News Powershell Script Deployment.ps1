<#
.SYNOPSIS
   <A brief description of the script>
.DESCRIPTION
   <A detailed description of the script>
.PARAMETER <paramName>
   <Description of script parameter>
.EXAMPLE
   <An example of using the script>
#>
function WaitForJobToFinish ([string]$solutionName) # This function waits for the deployment job to finish before doing the next command.
{
	$JobName = "*solution-deployment*$solutionName*"
	$job = Get-SPTimerJob | ?{ $_.Name -like $JobName }
	if ($job -eq $null) 
	{
		Write-Host "Timer job not found"
	}
	else
	{
		$JobFullName = $job.Name
		Write-Host -NoNewLine "Waiting to finish job $JobFullName"

		while ((Get-SPTimerJob $JobFullName) -ne $null) 
		{
			Write-Host -NoNewLine .
			Start-Sleep -Seconds 2
		}
		Write-Host "Finished waiting for job.."
	}
}


$solutionName = 'NewsAnnouncementWebPart.wsp'
$solution = Get-SPSolution -Identity $solutionName -ErrorAction:SilentlyContinue
if ($solution -ne $null)
{
	if ($solution.Deployed)
	{
		if ($solution.ContainsWebApplicationResource) # If the solution contains Web Application Resource, use this command.
		{
			Uninstall-SPSolution -identity $solutionName -allwebapplication -confirm:$false
		}
		else # Otherwise, use this command.
		{
			Uninstall-SPSolution -identity $solutionName -confirm:$false
		}

		Write-Host "Waiting for job to finish" 
		WaitForJobToFinish $solutionName
	}
	Write-Host 'Removing' $solutionName # Remove solution from store.
	Remove-SPSolution –Identity $solutionName -confirm:$false

	Write-Host 'Adding' $solutionName 'to the Solutions Store'
	$solutionPath = 'C:\Users\Administrator\Desktop\Powershell Deploy Script\NewsAnnouncementWebPart.wsp'
	Add-SPSolution -LiteralPath $solutionPath

	$solution = Get-SPSolution -Identity $solutionName

	Write-Host 'Deploying' $solutionName
	if ($solution.ContainsWebApplicationResource)
	{
		Install-SPSolution –Identity $solutionName –allwebapplication –GACDeployment -CASPolicies
	}
	else
	{
		Install-SPSolution –Identity $solutionName –GACDeployment -CASPolicies
	} 
	Write-Host "Waiting for job to finish" 
	WaitForJobToFinish $solutionName
}
