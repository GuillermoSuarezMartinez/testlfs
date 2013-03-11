@echo off
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Combo.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Combo.xml /q/f
"C:\Archivos de programa\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Controles.Combo32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Combo.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"
xcopy ..\Orbita.Controles.Combo.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Comunes.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Comunes.xml /q/f
"C:\Archivos de programa\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Controles.Comunes32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Comunes.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"
xcopy ..\Orbita.Controles.Comunes.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Comunicaciones.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Comunicaciones.xml /q/f
"C:\Archivos de programa\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Controles.Comunicaciones32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Comunicaciones.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"
xcopy ..\Orbita.Controles.Comunicaciones.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Contenedores.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Contenedores.xml /q/f
"C:\Archivos de programa\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Controles.Contenedores32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Contenedores.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"
xcopy ..\Orbita.Controles.Contenedores.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Editor.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Editor.xml /q/f
"C:\Archivos de programa\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Controles.Editor32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Editor.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"
xcopy ..\Orbita.Controles.Editor.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Estilos.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Estilos.xml /q/f
"C:\Archivos de programa\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Controles.Estilos32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Estilos.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"
xcopy ..\Orbita.Controles.Estilos.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Gantt.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Gantt.xml /q/f
"C:\Archivos de programa\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Controles.Gantt32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Gantt.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"
xcopy ..\Orbita.Controles.Gantt.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Grid.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Grid.xml /q/f
"C:\Archivos de programa\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Controles.Grid32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Grid.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"
xcopy ..\Orbita.Controles.Grid.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Menu.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Menu.xml /q/f
"C:\Archivos de programa\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Controles.Menu32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Menu.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"
xcopy ..\Orbita.Controles.Menu.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Shared.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Shared.xml /q/f
"C:\Archivos de programa\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Controles.Shared32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.Shared.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"
xcopy ..\Orbita.Controles.Shared.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.VA.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.VA.xml /q/f
"C:\Archivos de programa\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Controles.VA32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Controles.VA.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"
xcopy ..\Orbita.Controles.VA.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

pause

