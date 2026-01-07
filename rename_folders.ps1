# Script to rename folders based on parent folder type
# - In "Starter" folders: remove '_begin' suffix from child folders
# - In "Solution" folders: remove '_end' suffix from child folders

$rootPath = "."

Write-Host "Starting folder rename process..." -ForegroundColor Green
Write-Host "Root path: $rootPath" -ForegroundColor Cyan
Write-Host ""

# Counter for renamed folders
$renamedCount = 0

# Find all "Starter" folders
$starterFolders = Get-ChildItem -Path $rootPath -Directory -Recurse | Where-Object { $_.Name -eq "Starter" }

Write-Host "Processing Starter folders..." -ForegroundColor Yellow
foreach ($starterFolder in $starterFolders) {
    Write-Host "  Checking: $($starterFolder.FullName)" -ForegroundColor Gray
    
    # Find child folders ending with '_begin'
    $childFolders = Get-ChildItem -Path $starterFolder.FullName -Directory | Where-Object { $_.Name -match '_begin$' }
    
    foreach ($folder in $childFolders) {
        $newName = $folder.Name -replace '_begin$', ''
        $newPath = Join-Path $folder.Parent.FullName $newName
        
        # Check if target folder already exists
        if (Test-Path $newPath) {
            Write-Host "    [SKIPPED] $($folder.Name) -> $newName (target already exists)" -ForegroundColor Red
        } else {
            Rename-Item -Path $folder.FullName -NewName $newName
            Write-Host "    [RENAMED] $($folder.Name) -> $newName" -ForegroundColor Green
            $renamedCount++
        }
    }
}

Write-Host ""
Write-Host "Processing Solution folders..." -ForegroundColor Yellow

# Find all "Solution" folders
$solutionFolders = Get-ChildItem -Path $rootPath -Directory -Recurse | Where-Object { $_.Name -eq "Solution" }

foreach ($solutionFolder in $solutionFolders) {
    Write-Host "  Checking: $($solutionFolder.FullName)" -ForegroundColor Gray
    
    # Find child folders ending with '_end'
    $childFolders = Get-ChildItem -Path $solutionFolder.FullName -Directory | Where-Object { $_.Name -match '_end$' }
    
    foreach ($folder in $childFolders) {
        $newName = $folder.Name -replace '_end$', ''
        $newPath = Join-Path $folder.Parent.FullName $newName
        
        # Check if target folder already exists
        if (Test-Path $newPath) {
            Write-Host "    [SKIPPED] $($folder.Name) -> $newName (target already exists)" -ForegroundColor Red
        } else {
            Rename-Item -Path $folder.FullName -NewName $newName
            Write-Host "    [RENAMED] $($folder.Name) -> $newName" -ForegroundColor Green
            $renamedCount++
        }
    }
}

Write-Host ""
Write-Host "Process complete!" -ForegroundColor Green
Write-Host "Total folders renamed: $renamedCount" -ForegroundColor Cyan
