				Dizajn i arhitektura projekta

Arhitektura ovog projekta je component-based. Projekat sadrži 6 komponenata, te svaka komponenata radi zaseban posao.

	1.Model - Komponenta Model inicijalizuje entitete koji će se koristiti u radu samog web client-a.
	
	2. Web client - Inicijalna komponenata i entry point projekta. Ova komponenata omogućuje korisniku da unese zahtev, koji se nakon toga parsira
	u JSON format. Ova komponenata predaje zahtev komponenati JSONToXMLAdapter i nakon izvršavanja daljeg toka programa dobija odgovor nazad.
	Ova komponenta poziva metode unosa, obrade i ispisa.
	
	3. Services - Komponenta services ima za zadatak da obradi korisnički zahtev. Ukoliko je zahtev traženog formata, zahtev se prosleđuje daljem 
	toku izvršavanja programa. U suprotnom, ispisuje korisniku poruku o grešci. 
	
	4. JSONToXMLAdapter - Prosleđuje JSON format komponenati CommunicationBus u prioritetnom pravcu, a nakon obrađivanja zahteva dobija odgovor iz baze podataka 
	kog serializuje u JSON objekat.
	
	5.CommunicationBus - Prosleđuje odgovor dobijen od JSONToXMLAdapter komponenate komponenati XMLToDBAdapter.
	
	6.XMLToDBAdapter - Ova komponenata u zavisnoti od dobijenog zahteva(koja je metoda u pitanju: get, post, patch, delete; koji je entitet u pitanju) prosleđuje 
	informacije Repository komponenati. Kada dobije odgovor nazad od Repository komponenate serializuje XML objekat sa potrebnim poljima(STATUS, STATUS_CODE, PAYLOAD).
	
	7.Repository - Sve upite nad bazom vrši Repository komponenata. U zavisnoti od zahteva poseduje klase za izvršavanje svake od ponuđenih metoda(get, post, patch, delete)
	kao i metoda dodatnih filtera. Svaka metoda vraća informaciju o tome da li je upit uspešno izvršen nad bazom ili ne.
	
	8.Database - Jedini zadatak ove komponenate je da inicijalizuje tabele u bazi na osnovu Modela podataka.
	
	9.DodatniFilter - Sva implementacija i logika dodatnih filtera connectedTo i connectedType nalazi se u ovoj komponenati.
	
	10.IspisStrategy - Hendluje sve ispise na Web Client-u.
	

				Način rada


Zahtev koji korisnik unosi mora da zadovoljava sledeće kriterijume:
	
	1. prva reč u zahtevu mora biti neka od metoda(get, post, patch, delete)
	
	2. druga reč u zahtevu mora biti neki od entiteta(resurs, tip, veza, tipveze)
	
Sve ostale reči zavise od metode koja je upisana i to po sledećim pravilima za metodu:

	1. Get metoda je ista za svaki entitet: get/entitet/id_entiteta.
	
	2. Post metoda se razlikuje za svaki entitet.
			
			Resurs: post/resurs/ime_resursa/opis_resursa/id_tipa
			
			Tip: post/tip/naziv_tipa
			
			Veza: post/veza/id_prvog_resursa/id_drugog_resursa/id_tipa_veze
			
			TipVeze: post/tipveze/naziv_tipa_veze
			
	3. Patch metoda se razlikuje za svaki entitet.
	
			Resurs: patch/resurs/id_resursa/ime_resursa/opis_resursa/id_tipa
			
			Tip: patch/tip/id_tipa/naziv_tipa
			
			Veza: patch/veza/id_veze/id_prvog_resursa/id_drugog_resursa/id_tipa_veze
			
			TipVeze: patch/tipveze/id_tipa_veze/novi_naziv_tipa_veze
			
	4. Delete metoda je ista za svaki entitet: delete/entitet/id_entiteta
	
Dodatni filteri mogu da se koriste samo ako je korisnik uneo metodu GET.
	
	1. ConnectedTo - ova metoda vraća id-jeve svih povezanih resursa sa traženim resursom
	
	2. ConnectedType - korisnik unosi naziv Resursa i id tipa veze. Ukoliko postoji u bazi detalji resursa će se prikazati.
	
	
	
