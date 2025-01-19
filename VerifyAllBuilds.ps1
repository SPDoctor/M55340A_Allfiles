param (
    [string]$rootPath = "."
)

$startPath = Get-Location
$global:failedCount = 0

# Function to build a project
function Build-Project {
    param (
        [string]$path
    )

    Write-Host "Building: $path"

    # Navigate to the project directory
    $directory = Split-Path -Path $path
    Set-Location -Path $directory

    # Restore the project dependencies
    dotnet restore $path

    # Build the project
    dotnet build $path

    # Check if the build was successful
    if ($LASTEXITCODE -eq 0) {
        Write-Host "Build succeeded for $path."
    } else {
        Write-Host "Build failed for $path."
        $global:failedCount++
    }
}

# Get all .csproj files in the subdirectories
$projectFiles = Get-ChildItem -Path $rootPath -Recurse -Include *.csproj

# Build each project or solution
foreach ($projectFile in $projectFiles) {
    # call Build-ProjectOrSolution function and save return value
    Build-Project -path $projectFile.FullName
}

if($global:failedCount -gt 0) { Write-Host "All builds completed but $failedCount failed." }
else { Write-Host "All builds completed successfully." }
Set-Location -Path $startPath

exit 0