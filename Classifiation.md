# Ziel
Hilfestellung bei der Einteilung der von Logik-Komponenten in die vier Bereiche **Business**, **Domain**,**Foundation** und **Integration**.
# Definitionen
## Business
Hier werden alle Komponenten gelistet, die sich um Workflows k�mmern. Diese verwenden meist verschiedene Komponenten aus dem Domain Bereich.
## Domain
Hier werden alle Komponenten gelistet, die sich um die Kern-Dom�nen-Funktionalit�ten k�mmern. Die einzelnen Komponenten d�rften im Normalfall untereinander keinerlei Kopplung haben.
## Foundation
Hier werden alle Komponenten gelistet, die (Low-Level)-Funktionalit�ten bereitstellen, aber nichts mit der Dom�ne zu tun haben. 
Beispielsweise eine Localization-Komponente oder Security-Komponente.
## Integration
Hier werden alle Komponenten gelistet, deren Zweck die Kommunikation/Verwendung mit anderen (Legacy-)Anwendungen ist. 

# Quelle
Klassifizierung grob �bernommen aus: https://www.youtube.com/watch?v=dNKOo_bd17M&t=2715s
