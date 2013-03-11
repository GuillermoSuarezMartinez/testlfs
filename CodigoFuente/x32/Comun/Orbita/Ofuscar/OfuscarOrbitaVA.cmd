@echo off
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.VA.Comun.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.VA.Comun.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.VA.Comun32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.VA.Comun.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"
xcopy ..\Orbita.VA.Comun.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.VA.Funciones.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.VA.Funciones.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.VA.Funciones32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.VA.Funciones.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"
xcopy ..\Orbita.VA.Funciones.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.VA.Hardware.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.VA.Hardware.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.VA.Hardware32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.VA.Hardware.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"
xcopy ..\Orbita.VA.Hardware.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.VA.MaquinasEstados.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.VA.MaquinasEstados.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.VA.MaquinasEstados32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.VA.MaquinasEstados.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"
xcopy ..\Orbita.VA.MaquinasEstados.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.VA.GeneradorEscenarios.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.VA.GeneradorEscenarios.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.VA.GeneradorEscenarios32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.VA.GeneradorEscenarios.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"
xcopy ..\Orbita.VA.GeneradorEscenarios.xml C:\TFS\Orbita\General\Dlls\x32\Orbita