@echo off
setlocal enabledelayedexpansion

rem Leggi la versione dal file VERSION
set "version="
if exist "..\VERSION" (
    set /p version=<..\VERSION
) else (
    echo File VERSION non trovato.
    exit /b 1
)

if "!version!"=="" (
    echo Il file VERSION è vuoto. Per favore, specifica una versione.
    exit /b 1
)

echo Pubblicazione di Sirstrap con versione !version!...

rem Pulisci la cartella di pubblicazione precedente
set "publish_dir=..\out\Build"
if exist "%publish_dir%" (
    echo Pulizia della cartella di pubblicazione precedente...
    rmdir /s /q "%publish_dir%"
)

rem Esegui MSBuild per pubblicare la soluzione con FolderProfile
dotnet publish ..\Sirstrap.sln -p:PublishProfile=FolderProfile -p:Version=!version! -c Release

if %ERRORLEVEL% neq 0 (
    echo Errore: Pubblicazione fallita.
    exit /b %ERRORLEVEL%
)

echo Sirstrap pubblicato con successo con versione !version!.
echo Pubblicato in: ..\out\Build\

endlocal