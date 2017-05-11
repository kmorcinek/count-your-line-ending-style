Console Application checks line endings in all files (checks for *.cs at first version) in folder (and subfolders).
Use case: some repositories have problems with it so we need a fast way to determine "if" and "where" our repo need to be fixed.

Output:
number of files with CRLF
number of files with LF
number of files with Mixed line endings

As the CRLF is our default and desired line ending, write out all path that are LF or "Mixed"

Improvements: think about extensions, should there be predefined extension set of files to check (*.cs, *.ps1, *.config, *.json, *.txt etc)? How would you check if from command line.

Think about Unit Testing. And by UT I mean test first TDD.