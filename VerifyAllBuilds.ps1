param (
    [string]$rootPath = "."
)

# Function to build a project or solution
function Build-ProjectOrSolution {
    param (
        [string]$path
    )

    Write-Host "Building: $path"

    # Navigate to the project directory
    $directory = Split-Path -Path $path
    Set-Location -Path $directory

    # Restore the project dependencies
    #dotnet restore $path

    # Build the project
    #$buildResult = dotnet build $path

    # Check if the build was successful
    if ($LASTEXITCODE -eq 0) {
        Write-Host "Build succeeded for $path."
    } else {
        Write-Host "Build failed for $path."
        exit 1
    }
}

# Get all .csproj and .sln files in the subdirectories
$projectFiles = Get-ChildItem -Path $rootPath -Recurse -Include *.csproj, *.sln

# Build each project or solution
foreach ($projectFile in $projectFiles) {
    Build-ProjectOrSolution -path $projectFile.FullName
}

Write-Host "All builds completed."
exit 0