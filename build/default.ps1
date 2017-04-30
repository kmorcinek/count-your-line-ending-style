Framework "4.6"

Properties {
    
    $build_dir = Split-Path $psake.build_script_file
    
    $nugets_directory = "$build_dir\..\src\packages"
    
    $xunit = "$nugets_directory\xunit.runner.console.2.2.0\tools\xunit.console.exe"
        
    # Custom
    $bin_test_dir = "$build_dir\..\src\CountYourLineEndingStyle\bin\Debug"
}

FormatTaskName (("-"*25) + "[{0}]" + ("-"*25))

Task Default -Depends Test

Task Test {
    Write-Host "..."
    Write-Host $bin_test_dir

    assert(Test-Path($xunit)) "xUnit must be available."

    $testFolders = gci $bin_test_dir/*CountYourLineEndingStyle.exe

    foreach($testFolder in $testFolders) { 
        
        $testFolderPath = $testFolder.FullName
     
        $test_name = $testFolder.Name
        $test_output_path = "$bin_test_dir\$test_name.xml"
        write-host "****** found tests: $testFolderPath, output: $test_output_path"

        Exec {
            & $xunit $testFolderPath -xml $test_output_path
        }

        write-host "****** finished testing: $testFolderPath"
    }
}
