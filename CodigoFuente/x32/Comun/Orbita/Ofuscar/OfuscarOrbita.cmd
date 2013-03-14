@echo Orbita.BBDD...............................................
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.BBDD.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.BBDD.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.BBDD32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.BBDD.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"
xcopy ..\Orbita.BBDD.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

@echo Orbita.Comunicaciones...............................................
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Comunicaciones.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Comunicaciones.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Comunicaciones32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Comunicaciones.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"
xcopy ..\Orbita.Comunicaciones.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

@echo Orbita.Winsock...............................................
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Winsock.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Winsock.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Winsock32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Winsock.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"
xcopy ..\Orbita.Winsock.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

@echo Orbita.Trazabilidad...............................................
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Trazabilidad.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Trazabilidad.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Trazabilidad32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Trazabilidad.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"
xcopy ..\Orbita.Trazabilidad.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

@echo Orbita.Utiles...............................................
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Utiles.dll /q/f
del C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Utiles.xml /q/f
"%PROGRAMFILES%\Red Gate\SmartAssembly 6\SmartAssembly.com" /build .\Orbita.Utiles32.saproj
verpatch C:\TFS\Orbita\General\Dlls\x32\Orbita\Orbita.Utiles.dll /s company "Orbita Software" /s copyright "Copyright © Orbita Ingenieria SW 2012"
xcopy ..\Orbita.Utiles.xml C:\TFS\Orbita\General\Dlls\x32\Orbita

%comspec% /k "".\tf.bat"" 

pause
