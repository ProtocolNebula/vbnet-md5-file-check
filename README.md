# vbnet-md5-file-check
Easy class to compare files and folders trhough MD5 in Visual Basic Net

You can download the exe from ```MD5Test/bin/Release/MD5Test.exe``` (require net framework)

## How to use:
 1. Import ```MD5Comparer``` to your project
 2. Create a new instance:
```Dim md5 As MD5Comparer = New MD5Comparer()```
 3. Compare the files or folders!
```d5.compare(PathToFile1, PathToFile2)```
 4. Maybe you want to compare an existent md5 with a file:
 ```d5.compareFile(MD5String, PathToFile)```

**View ```Form1.vb``` -> ```Button1_Click()``` for more information**


## TODO:
 
 - [X] Compare directly with Path Object

 - [ ] Unit tests
 
