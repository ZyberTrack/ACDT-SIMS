# ACDT-SIMS
[Link zur GitHub Repo:](https://badgen.net/badge/icon/github?icon=github&label) https://github.com/ZyberTrack/ACDT-SIMS
## System Voraussetzungen
Die Applikation verwendet .NET 7.0. Für die Docker Container benötigt man ein Windows System.

# Funktionen
## Login
Das ACDT-SIMS verfügt über ein einfaches Authentifizierungssystem mit Benutzernamen und Passwort. Benutzerdaten werden auf einer SQL Datenbank gespeichert und beim Anmeldeversuch abgeglichen. 
## Benutzer
Das System kennt zwei Benutzer Arten: Administratoren und Standartbenutzer.
Nur Benutzer mit Administrator Rechten haben Zugriff auf die Benutzerverwaltung.

## Hauptmenü
im Hauptmenü finden sich vier Auswahlmöglichkeiten.
Diese sind mithilfe der Pfeiltasten wählbar: 
### Event Management
Diese Funktion ist für alle Benutzer verfügbar. Hier lassen sich manuelle Log Einträge unter dem Menüpunkt 'Einen Vorfall erfassen' tätigen oder bereits Erfasste Log Einträge unter 'Alle Vorfälle' anzeigen.
Mit dem Menüpunkt 'Offene Vorfälle' kann man alle geöffneten Log Einträge sehen.
Darüberhinaus ist es möglich eine Notifizierung via E-Mail oder SMS unter dem Menüpunkt 'Notifizierung' tätigen. 

### Benutzerverwaltung
In der Benutzerverwaltung lassen sich neue Benutzer mit der Option 'Benutzer Hinzufügen' erstellen und mit der Option 'Benutzer Entfernen' entfernen. Mit der Option 'Alle Benutzer Anzeigen' werden alle Vorhandenen Benutzer mit Benutzernamen und Rolle angezeigt.

Wenn der aktuelle Benutzer in der Benutzerverwaltung gelöscht wird, hat er ab dem Moment keinen Zugriff mehr auf alle Menü Optionen außer 'Ausloggen' und 'Programm Beenden'


![Klassendiagramm](https://github.com/ZyberTrack/ACDT-SIMS/assets/115556179/97428d3e-ad73-4285-a889-2b90d8b77cbb)

