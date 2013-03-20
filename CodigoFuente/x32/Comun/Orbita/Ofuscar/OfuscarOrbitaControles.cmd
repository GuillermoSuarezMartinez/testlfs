@echo off

@echo Ofuscacion de Orbita.Controles.Combo................
set /p resp="Desea ofuscar el ensamblado actual? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO comunes
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Combo.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Combo.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Controles.Combo32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Combo.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"
xcopy ..\Orbita.Controles.Combo.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

:comunes
@echo Ofuscacion de Orbita.Controles.Comumes..............
IF %resp% == t GOTO comunesEx
set /p resp="Desea ofuscar el ensamblado actual? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO comunicaciones
:comunesEx
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Comunes.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Comunes.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Controles.Comunes32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Comunes.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"
xcopy ..\Orbita.Controles.Comunes.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

:comunicaciones
@echo Ofuscacion de Orbita.Controles.Comunicaciones.......
IF %resp% == t GOTO comunicacionesEx
set /p resp="Desea ofuscar el ensamblado actual? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO contenedores
:comunicacionesEx
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Comunicaciones.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Comunicaciones.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Controles.Comunicaciones32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Comunicaciones.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"
xcopy ..\Orbita.Controles.Comunicaciones.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

:contenedores
@echo Ofuscacion de Orbita.Controles.Contenedores.........
IF %resp% == t GOTO contenedoresEx
set /p resp="Desea ofuscar el ensamblado actual? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO editor
:contenedoresEx
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Contenedores.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Contenedores.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Controles.Contenedores32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Contenedores.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"
xcopy ..\Orbita.Controles.Contenedores.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

:editor
@echo Ofuscacion de Orbita.Controles.Editor...............
IF %resp% == t GOTO editorEx
set /p resp="Desea ofuscar el ensamblado actual? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO estilos
:editorEx
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Editor.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Editor.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Controles.Editor32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Editor.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"
xcopy ..\Orbita.Controles.Editor.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

:estilos
@echo Ofuscacion de Orbita.Controles.Estilos..............
IF %resp% == t GOTO estilosEx
set /p resp="Desea ofuscar el ensamblado actual? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO gant
:estilosEx
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Estilos.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Estilos.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Controles.Estilos32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Estilos.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"
xcopy ..\Orbita.Controles.Estilos.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

:gant
@echo Ofuscacion de Orbita.Controles.Gant.................
IF %resp% == t GOTO gantEx
set /p resp="Desea ofuscar el ensamblado actual? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO controles
:gantEx
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Gantt.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Gantt.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Controles.Gantt32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Gantt.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"
xcopy ..\Orbita.Controles.Gantt.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

:controles
@echo Ofuscacion de Orbita.Controles.Grid.................
IF %resp% == t GOTO controlesEx
set /p resp="Desea ofuscar el ensamblado actual? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO menu
:controlesEx
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Grid.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Grid.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Controles.Grid32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Grid.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"
xcopy ..\Orbita.Controles.Grid.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

:menu
@echo Ofuscacion de Orbita.Controles.Menu.................
IF %resp% == t GOTO menuEx
set /p resp="Desea ofuscar el ensamblado actual? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO shared
:menuEx
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Menu.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Menu.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Controles.Menu32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Menu.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"
xcopy ..\Orbita.Controles.Menu.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

:shared
@echo Ofuscacion de Orbita.Controles.Shared...............
IF %resp% == t GOTO sharedEx
set /p resp="Desea ofuscar el ensamblado actual? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO va
:sharedEx
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Shared.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Shared.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Controles.Shared32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Shared.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"
xcopy ..\Orbita.Controles.Shared.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

:va
@echo Ofuscacion de Orbita.Controles.VA..................
IF %resp% == t GOTO vaEx
set /p resp="Desea ofuscar el ensamblado actual? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO teamfundation
:vaEx
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.VA.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.VA.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Controles.VA32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.VA.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"
xcopy ..\Orbita.Controles.VA.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

:teamfundation
@echo Subida al TeamFundation ............................
IF %resp% == t GOTO teamfundationEx
set /p resp="Desea subir los ficheros al teamfundation? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO fin
:teamfundationEx
%comspec% /k "".\tf.bat"" 

:fin
pause

