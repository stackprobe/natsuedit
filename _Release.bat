C:\Factory\Tools\RDMD.exe /RC out

COPY /B natsuedit\natsuedit\bin\Release\natsuedit.exe out
COPY /B Tools\CTools.exe out

C:\Factory\Tools\xcp.exe doc out

C:\Factory\SubTools\EmbedConfig.exe --factory-dir-disabled out\CTools.exe

C:\Factory\SubTools\zip.exe /O out natsuedit

PAUSE
