$scriptPath = Split-Path $PSCommandPath
Write-Host "Script is running on root: "$scriptPath

if((Get-Module psake) -eq $null) {
    "Importing psake"
    Import-Module (Join-Path $scriptPath psake-4.6.0/psake.psm1)
}

Invoke-psake (Join-Path $scriptPath ./default.ps1)