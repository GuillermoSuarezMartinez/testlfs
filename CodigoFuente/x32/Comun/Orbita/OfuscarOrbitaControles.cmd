@echo off
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Comunicaciones.dll /q/f
"C:\Archivos de programa\Red Gate\SmartAssembly 5\SmartAssembly.com" /build .\Orbita.Controles.Comunicaciones32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Comunicaciones.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"

del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Combo.dll /q/f
"C:\Archivos de programa\Red Gate\SmartAssembly 5\SmartAssembly.com" /build .\Orbita.Controles.Combo32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Combo.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"

del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Contenedores.dll /q/f
"C:\Archivos de programa\Red Gate\SmartAssembly 5\SmartAssembly.com" /build .\Orbita.Controles.Contenedores32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Contenedores.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"

del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Editor.dll /q/f
"C:\Archivos de programa\Red Gate\SmartAssembly 5\SmartAssembly.com" /build .\Orbita.Controles.Editor32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Editor.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"

del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Estilos.dll /q/f
"C:\Archivos de programa\Red Gate\SmartAssembly 5\SmartAssembly.com" /build .\Orbita.Controles.Estilos32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Estilos.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"

del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Gantt.dll /q/f
"C:\Archivos de programa\Red Gate\SmartAssembly 5\SmartAssembly.com" /build .\Orbita.Controles.Gantt32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Gantt.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"


del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Menu.dll /q/f
"C:\Archivos de programa\Red Gate\SmartAssembly 5\SmartAssembly.com" /build .\Orbita.Controles.Menu32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Menu.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"

del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Shared.dll /q/f
"C:\Archivos de programa\Red Gate\SmartAssembly 5\SmartAssembly.com" /build .\Orbita.Controles.Shared32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Shared.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"

pause