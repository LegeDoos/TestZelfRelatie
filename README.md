# TestZelfRelatie
In deze code staan twee voorbeelden om een ralatie tussen nodes op te slaan in de database met .net core en Entity Framework.

1. RoutePoint is een model met een veel op veel relatie naar zichzelf. Kan gebruikt worden voor de opslag van een graaf (nodes die onderling naar elkaar verwijzen)
2. RoutePointV2 en RoutePointRelatieV2 is hetzelfde concept, echter hier is de relatie een specifieke tabel zodat je er extra attributen over kunt opslaan, zoals de afstand of een naa, voor de relatie.


In beide gevallen wordt data gevuld met dataseed. In de RoutePointController staat wat code om te testen of het werkt.
