# vbnet-md5-file-check
Easy class to compare files trhough MD5

## How to use:
 - Import ```MD5Test/MD5File.vb``` to your project
 - Create a new instance:
```Dim md5 As MD5File = New MD5File()```
 - Compare the files!
```vb
d5.compareFiles(PathToFile1, PathToFile2)
```
 - Maybe you want to compare an existent md5 with a file:
 ```vb
 d5.compareFile(MD5String, PathToFile)
 ```


## TODO:
 - [ ] Compare directly with path