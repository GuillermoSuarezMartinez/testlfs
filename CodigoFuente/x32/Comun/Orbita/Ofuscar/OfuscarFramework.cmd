@echo off

@echo Orbita.Framework...............................................
set /p resp="Desea ofuscar el ensamblado actual? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO Comunicaciones
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Framework.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Framework.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Framework32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Framework.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2013"

:Core
@echo Ofuscacion de Orbita.Framework.Core.............
IF %resp% == t GOTO coreEx
set /p resp="Desea ofuscar el ensamblado actual? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO Extensiones
:coreEx
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Framework.Core.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Framework.Core.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Framework.Core32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Framework.Core.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2013"
xcopy ..\Orbita.Framework.Core.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

:Extensiones
@echo Ofuscacion de Orbita.Framework.Extensiones....................
IF %resp% == t GOTO ExtensionesEx
set /p resp="Desea ofuscar el ensamblado actual? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO PluginManager
:ExtensionesEx
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Framework.Extensiones.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Framework.Extensiones.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Framework.Extensiones32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Framework.Extensiones.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2013"
xcopy ..\Orbita.Winsock.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

:PluginManager
@echo Ofuscacion de Orbita.Framework.PluginManager...............
IF %resp% == t GOTO PluginManagerEx
set /p resp="Desea ofuscar el ensamblado actual? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO teamfundation
:PluginManagerEx
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Framework.PluginManager.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Framework.PluginManager.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Framework.PluginManager32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Framework.PluginManager.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2013"
xcopy ..\Orbita.Framework.PluginManager.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

:teamfundation
@echo Subida al TeamFundation ..................................
IF %resp% == t GOTO teamfundationEx
set /p resp="Desea subir los ficheros al teamfundation? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO fin
:teamfundationEx
%comspec% /c "".\tf.bat"" 

:fin
pause