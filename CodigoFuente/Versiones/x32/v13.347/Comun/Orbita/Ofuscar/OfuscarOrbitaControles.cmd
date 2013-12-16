@echo off

@echo Orbita.Controles.Autenticacion...............................................
set /p resp="Desea ofuscar el ensamblado actual? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO Orbita.Controles.Combo
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Autenticacion.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Autenticacion.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Controles.Autenticacion32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Autenticacion.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2013"
xcopy ..\Orbita.Controles.Autenticacion.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

:Orbita.Controles.Combo
@echo Ofuscacion de Orbita.Controles.Combo..............................
IF %resp% == t GOTO Orbita.Controles.ComboEx
set /p resp="Desea ofuscar el ensamblado actual? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO Orbita.Controles.Comunes
:Orbita.Controles.ComboEx
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Combo.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Combo.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Controles.Combo32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Combo.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2013"
xcopy ..\Orbita.Controles.Combo.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

:Orbita.Controles.Comunes
@echo Ofuscacion de Orbita.Controles.Comunes.............
IF %resp% == t GOTO Orbita.Controles.ComunesEx
set /p resp="Desea ofuscar el ensamblado actual? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO Orbita.Controles.Comunicaciones
:Orbita.Controles.ComunesEx
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Comunes.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Comunes.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Controles.Comunes32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Comunes.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2013"
xcopy ..\Orbita.Controles.Comunes.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

:Orbita.Controles.Comunicaciones
@echo Ofuscacion de Orbita.Controles.Comunicaciones.............
IF %resp% == t GOTO Orbita.Controles.ComunicacionesEx
set /p resp="Desea ofuscar el ensamblado actual? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO Orbita.Controles.Contenedores
:Orbita.Controles.ComunicacionesEx
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Comunicaciones.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Comunicaciones.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Controles.Comunicaciones32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Comunicaciones.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2013"
xcopy ..\Orbita.Controles.Comunicaciones.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

:Orbita.Controles.Contenedores
@echo Ofuscacion de Orbita.Controles.Contenedores.............
IF %resp% == t GOTO Orbita.Controles.ContenedoresEx
set /p resp="Desea ofuscar el ensamblado actual? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO Orbita.Controles.Editor
:Orbita.Controles.ContenedoresEx
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Contenedores.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Contenedores.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Controles.Contenedores32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Contenedores.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2013"
xcopy ..\Orbita.Controles.Contenedores.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

:Orbita.Controles.Editor
@echo Ofuscacion de Orbita.Controles.Editor.............
IF %resp% == t GOTO Orbita.Controles.EditorEx
set /p resp="Desea ofuscar el ensamblado actual? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO Orbita.Controles.Estilos
:Orbita.Controles.EditorEx
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Editor.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Editor.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Controles.Editor32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Editor.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2013"
xcopy ..\Orbita.Controles.Editor.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

:Orbita.Controles.Estilos
@echo Ofuscacion de Orbita.Controles.Estilos.............
IF %resp% == t GOTO Orbita.Controles.EstilosEx
set /p resp="Desea ofuscar el ensamblado actual? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO Orbita.Controles.Gantt
:Orbita.Controles.EstilosEx
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Estilos.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Estilos.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Controles.Estilos32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Estilos.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2013"
xcopy ..\Orbita.Controles.Estilos.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

:Orbita.Controles.Gantt
@echo Ofuscacion de Orbita.Controles.Gantt.............
IF %resp% == t GOTO Orbita.Controles.GanttEx
set /p resp="Desea ofuscar el ensamblado actual? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO Orbita.Controles.Grid
:Orbita.Controles.GanttEx
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Gantt.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Gantt.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Controles.Gantt32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Gantt.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2013"
xcopy ..\Orbita.Controles.Gantt.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

:Orbita.Controles.Grid
@echo Ofuscacion de Orbita.Controles.Grid.............
IF %resp% == t GOTO Orbita.Controles.GridEx
set /p resp="Desea ofuscar el ensamblado actual? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO Orbita.Controles.Menu
:Orbita.Controles.GridEx
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Grid.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Grid.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Controles.Grid32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Grid.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2013"
xcopy ..\Orbita.Controles.Grid.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

:Orbita.Controles.Menu
@echo Ofuscacion de Orbita.Controles.Menu.............
IF %resp% == t GOTO Orbita.Controles.MenuEx
set /p resp="Desea ofuscar el ensamblado actual? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO Orbita.Controles.Shared
:Orbita.Controles.MenuEx
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Menu.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Menu.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Controles.Menu32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Menu.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2013"
xcopy ..\Orbita.Controles.Menu.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

:Orbita.Controles.Shared
@echo Ofuscacion de Orbita.Controles.Shared.............
IF %resp% == t GOTO Orbita.Controles.SharedEx
set /p resp="Desea ofuscar el ensamblado actual? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO Orbita.Controles.VA
:Orbita.Controles.SharedEx
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Shared.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Shared.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Controles.Shared32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Shared.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2013"
xcopy ..\Orbita.Controles.Shared.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

:Orbita.Controles.VA
@echo Ofuscacion de Orbita.Controles.VA.................
IF %resp% == t GOTO Orbita.Controles.VAEx
set /p resp="Desea ofuscar el ensamblado actual? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO teamfundation
:Orbita.Controles.VAEx
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.VA.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.VA.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Controles.VA32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.VA.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2013"
xcopy ..\Orbita.Controles.VA.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

:teamfundation
@echo Subida al TeamFundation ......................................
IF %resp% == t GOTO teamfundationEx
set /p resp="Desea subir los ficheros al teamfundation? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO fin
:teamfundationEx
%comspec% /c "".\tf.bat"" 

:fin
pause
