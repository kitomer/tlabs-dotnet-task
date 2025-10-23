# Vorgehen

## Umgebung einrichten

- Alter Laptop mit Windows 7 (32bit) kann keine .NET 8.0 Projekte laden, weil das
  entspr. Framework nicht installierbar ist. Update auf Windows 10 nicht moeglich
  (HW zu schwach). Update auf Windows 11 nicht moeglich (kein 32bit).
- Mono unter Linux schmeisst Fehler, inkompatible Projekt/Solution Datei.
  - Manuelles Anpassen kurz probiert, aber nicht zielführend
- Windows 11 VM ging nicht wg. HW-Requirements (Host und Guest)
- Windows 10 VM ging: Visual Studio + Code eingerichtet, App geladen
        
## Server gestartet: läuft

### Swagger/Api Auffälligkeiten

- ggf. Versionierung in der api zB /api/v1/... 
- ggf. lieber PUT /api/task da nur einer gesendet wird
  + nullable key "title" ggf. nicht nullable
- ggf. lieber PUT /api/task/{id} da nur ein todo-item betroffen
  + dann ggf "id" Key im Body weglassen, da redundant (oder drinlassen als Konsistenzcheck)
- ggf. lieber DELETE /api/task/{id} da nur einer betroffen
  + Response ggf. Status-JSON zB { "status": <bool>, "info": <string> }
  
weitere Backend Tasks nicht bearbeitet, da Zeit abgelaufen
        
## Frontend gestartet (mit npm 22.12.0.)

- beim ersten Start Fehler: "Cannot assign to newTask because it is a constant"
- zweiter Start läuft

### Fix update/delete functionality

- neuen Task anlegen gefixt: ref() statt atomic Value
- Editieren gefixt
- Delete gefixt: CORS Richtlinie angepasst, damit DELETE Methode erlaubt ist
            
### PRIO-2 Add filter/sort functionality

- Frontend:
  - Textfeld fuer Suchanfrage, on-key-up Filtern (Live-Filter)
  - Filtern Api Endpunkt:
      GET /api/tasks mit body { "filter": <string> }
      Response ist Taskliste, aber gefiltert
    
- Backend: entspr. Request auswerten, Filter anwenden
            
### PRIO-2 (Bonus) Tags create/edit/delete functionality

- Tags einfach inline im title des Todo, Syntax: #<non-string-sequence> oder #"..."
- im Backend Tags extrahieren (aber im title belassen) und in simplen key-value-store schreiben
  (key = tag, value = Liste von Todo-IDs)
- im Frontend: Tags inline in Links umwandeln -> URL zu Filter nach Tag
            
### PRIO-1 (Bonus) Add a UI components library (e.g. Quasar) to the project

s. https://quasar.dev/start/vue-cli-plugin/
          
### PRIO-3 (Bonus) Use pagination/infinite scroll for the elements

- Endpunkt um "next n tasks after task x" erweitern:
    GET /api/tasks/<last-loaded-task-id> (oder /api/tasks/0 fuer erste "Seite")
          
### PRIO-2 (Bonus) Authentication

- Frontend:
  - Braucht Sessions, ggf. noch Localstorage fuer Speichern SID
    (bei onload Session-ID in localstorage suchen)
    -> alt. Cookie mit Ablaufzeit speichern
  - Wenn Session nicht auth.:
    - Loginseite anzeigen
    - Endpunkt fuer Auth. ansprechen
    - Status der Authentifizierung im Browser merken parallel zur Session
      (dies ist aber nicht der eigentl. Sicherheitsmechanismus, nur damit
       nicht staendig Loginseite angezeigt wird)
  - Sobald ein Endpunkt Auth.-Fehler ergibt, wird Auth. Status auf 0 gesetzt
      und erneuter Login versucht, s.o.
- Backend:
  - vorh. Microservice fuer Authentication ggf. einfach benutzen
  - jeder Endpunkt, der auth. zugreifbar sein soll, muss Session-ID im
    HTTP Header enthalten; diese wird dann geprueft
  - Endpunkte zur Authentifizierung:
      POST /api/session
        -> neue Session anlegen, gibt Session-ID zurueck
      GET /api/session/<sid>
        -> gibt, wenn existent, Session-Daten zurueck
      POST /api/login/<sid>
      POST /api/logout/<sid>

### PRIO-1 (Bonus) Do not reload the list on every update of an element

- nicht dazu gekommen
