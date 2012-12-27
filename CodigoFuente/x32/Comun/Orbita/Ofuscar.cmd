@echo off
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.BBDD.dll /q/f
"C:\Archivos de programa\Red Gate\SmartAssembly 5\SmartAssembly.com" /build .\Orbita.BBDD32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.BBDD.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"

del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Comunicaciones.dll /q/f
"C:\Archivos de programa\Red Gate\SmartAssembly 5\SmartAssembly.com" /build .\Orbita.Comunicaciones32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Comunicaciones.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"

del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Winsock.dll /q/f
"C:\Archivos de programa\Red Gate\SmartAssembly 5\SmartAssembly.com" /build .\Orbita.Winsock32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Winsock.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"

del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Trazabilidad.dll /q/f
"C:\Archivos de programa\Red Gate\SmartAssembly 5\SmartAssembly.com" /build .\Orbita.Trazabilidad32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Trazabilidad.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"

del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Utiles.dll /q/f
"C:\Archivos de programa\Red Gate\SmartAssembly 5\SmartAssembly.com" /build .\Orbita.Utiles32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Utiles.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"
pause
