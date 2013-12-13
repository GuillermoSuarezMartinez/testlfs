@echo off
title COPING FILES
echo -- GENERANDO M�QUINAS DE ESTADOS ------------------------------------------ 

echo Ayuda de L�nea de comandos:
echo Par�metro 1: Espacio de nombres (namespace).
echo    Ejemplo: "OrbitaVAPersonalizacion "
echo Par�metro 1: Ruta completa del fichero xml de configuraci�n.
echo    Ejemplo: "C:\Orbita\ProyectoVision\.....\ConfiguracionOrbita.VA.xml"
echo Par�metro 2: Nombre del fichero cs a generar.
echo    Ejemplo: "C:\Orbita\ProyectoVision\.....\OrbitaVAPersonalizacion.cs"
echo Par�metro 3: Si se escribe Vars indica que se han de incluir las variables
echo    utilizadas por la m�quina de estados
echo Par�metro 4: Si se escribe Hard indica que se han de incluir el hardware
echo    utilizado por la m�quina de estados
echo
echo Ejemplo de llamada:
echo Orbita.VA.GeneradorEscenarios.exe OrbitaVAPersonalizacion "C:\Orbita\ProyectoVision\ConfiguracionOrbita.VA.xml" "C:\Orbita\ProyectoVision\StateMachinePersonalizacion.cs" Vars Hard

Orbita.VA.GeneradorEscenarios.exe PlantillaProyectoVA "C:\TFS\Orbita\General\Plantillas\x32\PlantillaProyectoVA\Bin\ConfiguracionOrbitaVA.xml" "C:\TFS\Orbita\General\Plantillas\x32\PlantillaProyectoVA\PlantillaProyectoVA\Clases\MaquinaEstadosGenerada.cs" Vars Hard

title C�DIGO GENERADO
echo -- C�DIGO GENERADO --------------------------------------- 
pause
