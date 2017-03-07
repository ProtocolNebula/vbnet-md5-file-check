# vbnet-md5-file-check
Easy class to compare files trhough MD5

## How to use:
 1. Import ```MD5Test/MD5File.vb``` to your project
 2. Create a new instance:
```Dim md5 As MD5File = New MD5File()```
 3. Compare the files!
```d5.compareFiles(PathToFile1, PathToFile2)```
 4. Maybe you want to compare an existent md5 with a file:
 ```d5.compareFile(MD5String, PathToFile)```


## TODO:
 - [ ] Compare directly with Path Object
