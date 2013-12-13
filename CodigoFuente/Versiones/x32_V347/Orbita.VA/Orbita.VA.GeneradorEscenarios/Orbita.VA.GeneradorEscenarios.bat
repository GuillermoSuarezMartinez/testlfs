@echo off
title COPING FILES
echo -- GENERANDO MÁQUINAS DE ESTADOS ------------------------------------------ 

echo Ayuda de Línea de comandos:
echo Parámetro 1: Espacio de nombres (namespace).
echo    Ejemplo: "OrbitaVAPersonalizacion "
echo Parámetro 1: Ruta completa del fichero xml de configuración.
echo    Ejemplo: "C:\Orbita\ProyectoVision\.....\ConfiguracionOrbita.VA.xml"
echo Parámetro 2: Nombre del fichero cs a generar.
echo    Ejemplo: "C:\Orbita\ProyectoVision\.....\OrbitaVAPersonalizacion.cs"
echo Parámetro 3: Si se escribe Vars indica que se han de incluir las variables
echo    utilizadas por la máquina de estados
echo Parámetro 4: Si se escribe Hard indica que se han de incluir el hardware
echo    utilizado por la máquina de estados
echo
echo Ejemplo de llamada:
echo Orbita.VA.GeneradorEscenarios.exe OrbitaVAPersonalizacion "C:\Orbita\ProyectoVision\ConfiguracionOrbita.VA.xml" "C:\Orbita\ProyectoVision\StateMachinePersonalizacion.cs" Vars Hard

Orbita.VA.GeneradorEscenarios.exe PlantillaProyectoVA "C:\TFS\Orbita\General\Plantillas\x32\PlantillaProyectoVA\Bin\ConfiguracionOrbitaVA.xml" "C:\TFS\Orbita\General\Plantillas\x32\PlantillaProyectoVA\PlantillaProyectoVA\Clases\MaquinaEstadosGenerada.cs" Vars Hard

title CÓDIGO GENERADO
echo -- CÓDIGO GENERADO --------------------------------------- 
pause
