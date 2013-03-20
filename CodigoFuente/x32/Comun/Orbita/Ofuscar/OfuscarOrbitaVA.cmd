@echo off

@echo Orbita.VA.Comun...............................................
set /p resp="Desea ofuscar el ensamblado actual? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO Funciones
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.VA.Comun.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.VA.Comun.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.VA.Comun32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.VA.Comun.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"
xcopy ..\Orbita.VA.Comun.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

:Funciones
@echo Orbita.VA.Funciones...........................................
IF %resp% == t GOTO FuncionesEx
set /p resp="Desea ofuscar el ensamblado actual? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO Hardware
:FuncionesEx
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.VA.Funciones.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.VA.Funciones.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.VA.Funciones32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.VA.Funciones.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"
xcopy ..\Orbita.VA.Funciones.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

:Hardware
@echo Orbita.VA.Hardware............................................
IF %resp% == t GOTO HardwareEx
set /p resp="Desea ofuscar el ensamblado actual? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO MaquinasEstados
:HardwareEx
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.VA.Hardware.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.VA.Hardware.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.VA.Hardware32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.VA.Hardware.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"
xcopy ..\Orbita.VA.Hardware.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

:MaquinasEstados
@echo Orbita.VA.MaquinasEstados.....................................
IF %resp% == t GOTO MaquinasEstadosEx
set /p resp="Desea ofuscar el ensamblado actual? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO GeneradorEscenarios
:MaquinasEstadosEx
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.VA.MaquinasEstados.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.VA.MaquinasEstados.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.VA.MaquinasEstados32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.VA.MaquinasEstados.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"
xcopy ..\Orbita.VA.MaquinasEstados.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

:GeneradorEscenarios
@echo Orbita.VA.GeneradorEscenarios.................................
IF %resp% == t GOTO GeneradorEscenariosEx
set /p resp="Desea ofuscar el ensamblado actual? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO teamfundation
:GeneradorEscenariosEx
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.VA.GeneradorEscenarios.exe /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.VA.GeneradorEscenarios.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.VA.GeneradorEscenarios32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.VA.GeneradorEscenarios.exe /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"
xcopy ..\Orbita.VA.GeneradorEscenarios.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

:teamfundation
@echo Subida al TeamFundation ......................................
IF %resp% == t GOTO teamfundationEx
set /p resp="Desea subir los ficheros al teamfundation? (s=si, n=no, t=si a todo): " %=%
IF %resp% == n GOTO fin
:teamfundationEx
%comspec% /c "".\tf.bat"" 

:fin
pause