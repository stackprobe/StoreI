CALL C:\Factory\SetEnv.bat
CALL Clean.bat
cx **
IF ERRORLEVEL 1 C:\app\MsgBox\MsgBox.exe E "BUILD ERROR"

C:\apps\MakeResourceCluster\MakeResourceCluster.exe Resource out\Resource.dat

COPY /B C:\Dat\DxLibDotNet\DxLibDotNet3_24b\DxLib.dll out
COPY /B C:\Dat\DxLibDotNet\DxLibDotNet3_24b\DxLibDotNet.dll out

C:\apps\CheersToGimlet\CheersToGimlet.exe Silvia20200001 Silvia20200001 out\Game.exe
xcp doc out

C:\apps\GameSetSourceOfResource\GameSetSourceOfResource.exe Resource out\Readme.txt *

C:\Factory\SubTools\zip.exe /PE- /O out *P
