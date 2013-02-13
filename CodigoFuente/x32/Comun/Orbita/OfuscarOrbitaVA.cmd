@echo off
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.VA.Comun.dll /q/f
"C:\Archivos de programa\Red Gate\SmartAssembly 5\SmartAssembly.com" /build .\Orbita.VA.Comun32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.VA.Comun.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"

del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.VA.Funciones.dll /q/f
"C:\Archivos de programa\Red Gate\SmartAssembly 5\SmartAssembly.com" /build .\Orbita.VA.Funciones32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.VA.Funciones.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"

del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.VA.GeneradorEscenarios.exe /q/f
"C:\Archivos de programa\Red Gate\SmartAssembly 5\SmartAssembly.com" /build .\Orbita.VA.GeneradorEscenarios32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.VA.GeneradorEscenarios.exe /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"

del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.VA.Hardware.dll /q/f
"C:\Archivos de programa\Red Gate\SmartAssembly 5\SmartAssembly.com" /build .\Orbita.VA.Hardware32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.VA.Hardware.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"

del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.VA.MaquinasEstados.dll /q/f
"C:\Archivos de programa\Red Gate\SmartAssembly 5\SmartAssembly.com" /build .\Orbita.VA.MaquinasEstados32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.VA.MaquinasEstados.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"
pause
