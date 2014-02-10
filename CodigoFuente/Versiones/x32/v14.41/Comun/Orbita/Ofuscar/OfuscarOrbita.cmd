@echo off

@echo Orbita.BBDD...............................................
set /p resp="Desea ofuscar el ensamblado actual? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO Comunicaciones
del C:\TFS\Orbita\General\Dlls\Desarrollo\x32\Orbita\Orbita.BBDD.dll /q/f
del C:\TFS\Orbita\General\Dlls\Desarrollo\x32\Orbita\Orbita.BBDD.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.BBDD32.saproj
verpatch C:\TFS\Orbita\General\Dlls\Desarrollo\x32\Orbita\Orbita.BBDD.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2013"
xcopy ..\Orbita.BBDD.xml C:\TFS\Orbita\General\Dlls\Desarrollo\x32\Orbita

:Comunicaciones
@echo Ofuscacion de Orbita.Comunicaciones.............
IF %resp% == t GOTO comunesEx
set /p resp="Desea ofuscar el ensamblado actual? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO Winsock
:comunesEx
del C:\TFS\Orbita\General\Dlls\Desarrollo\x32\Orbita\Orbita.Comunicaciones.dll /q/f
del C:\TFS\Orbita\General\Dlls\Desarrollo\x32\Orbita\Orbita.Comunicaciones.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Comunicaciones32.saproj
verpatch C:\TFS\Orbita\General\Dlls\Desarrollo\x32\Orbita\Orbita.Comunicaciones.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2013"
xcopy ..\Orbita.Comunicaciones.xml C:\TFS\Orbita\General\Dlls\Desarrollo\x32\Orbita

:Winsock
@echo Ofuscacion de Orbita.Winsock....................
IF %resp% == t GOTO WinsockEx
set /p resp="Desea ofuscar el ensamblado actual? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO Trazabilidad
:WinsockEx
del C:\TFS\Orbita\General\Dlls\Desarrollo\x32\Orbita\Orbita.Winsock.dll /q/f
del C:\TFS\Orbita\General\Dlls\Desarrollo\x32\Orbita\Orbita.Winsock.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Winsock32.saproj
verpatch C:\TFS\Orbita\General\Dlls\Desarrollo\x32\Orbita\Orbita.Winsock.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2013"
xcopy ..\Orbita.Winsock.xml C:\TFS\Orbita\General\Dlls\Desarrollo\x32\Orbita

:Trazabilidad
@echo Ofuscacion de Orbita.Trazabilidad...............
IF %resp% == t GOTO TrazabilidadEx
set /p resp="Desea ofuscar el ensamblado actual? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO Utiles
:TrazabilidadEx
del C:\TFS\Orbita\General\Dlls\Desarrollo\x32\Orbita\Orbita.Trazabilidad.dll /q/f
del C:\TFS\Orbita\General\Dlls\Desarrollo\x32\Orbita\Orbita.Trazabilidad.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Trazabilidad32.saproj
verpatch C:\TFS\Orbita\General\Dlls\Desarrollo\x32\Orbita\Orbita.Trazabilidad.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2013"
xcopy ..\Orbita.Trazabilidad.xml C:\TFS\Orbita\General\Dlls\Desarrollo\x32\Orbita

:Utiles
@echo Ofuscacion de Orbita.Utiles.....................
IF %resp% == t GOTO UtilesEx
set /p resp="Desea ofuscar el ensamblado actual? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO MS
:UtilesEx
del C:\TFS\Orbita\General\Dlls\Desarrollo\x32\Orbita\Orbita.Utiles.dll /q/f
del C:\TFS\Orbita\General\Dlls\Desarrollo\x32\Orbita\Orbita.Utiles.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Utiles32.saproj
verpatch C:\TFS\Orbita\General\Dlls\Desarrollo\x32\Orbita\Orbita.Utiles.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2013"
xcopy ..\Orbita.Utiles.xml C:\TFS\Orbita\General\Dlls\Desarrollo\x32\Orbita

:MS
@echo Ofuscacion de Orbita.MS.........................
IF %resp% == t GOTO MSEx
set /p resp="Desea ofuscar el ensamblado actual? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO Xml
:MSEx
del C:\TFS\Orbita\General\Dlls\Desarrollo\x32\Orbita\Orbita.MS.dll /q/f
del C:\TFS\Orbita\General\Dlls\Desarrollo\x32\Orbita\Orbita.MS.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.MS32.saproj
verpatch C:\TFS\Orbita\General\Dlls\Desarrollo\x32\Orbita\Orbita.MS.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2013"
xcopy ..\Orbita.MS.xml C:\TFS\Orbita\General\Dlls\Desarrollo\x32\Orbita

:Xml
@echo Ofuscacion de Orbita.Xml........................
IF %resp% == t GOTO XmlEx
set /p resp="Desea ofuscar el ensamblado actual? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO Compresion
:XmlEx
del C:\TFS\Orbita\General\Dlls\Desarrollo\x32\Orbita\Orbita.Xml.dll /q/f
del C:\TFS\Orbita\General\Dlls\Desarrollo\x32\Orbita\Orbita.Xml.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Xml32.saproj
verpatch C:\TFS\Orbita\General\Dlls\Desarrollo\x32\Orbita\Orbita.Xml.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2013"
xcopy ..\Orbita.Xml.xml C:\TFS\Orbita\General\Dlls\Desarrollo\x32\Orbita

:Compresion
@echo Ofuscacion de Orbita.Compresion.................
IF %resp% == t GOTO CompresionEx
set /p resp="Desea ofuscar el ensamblado actual? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO teamfundation
:CompresionEx
del C:\TFS\Orbita\General\Dlls\Desarrollo\x32\Orbita\Orbita.Compresion.dll /q/f
del C:\TFS\Orbita\General\Dlls\Desarrollo\x32\Orbita\Orbita.Compresion.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Compresion32.saproj
verpatch C:\TFS\Orbita\General\Dlls\Desarrollo\x32\Orbita\Orbita.Compresion.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2013"
xcopy ..\Orbita.Compresion.xml C:\TFS\Orbita\General\Dlls\Desarrollo\x32\Orbita

:teamfundation
@echo Subida al TeamFundation ..................................
IF %resp% == t GOTO teamfundationEx
set /p resp="Desea subir los ficheros al teamfundation? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO fin
:teamfundationEx
%comspec% /c "".\tf.bat"" 

:fin
pause