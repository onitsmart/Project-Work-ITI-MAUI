# Project-Work-ITI-MAUI
Progetto di programmazione di un'applicazione mobile con l'utilizzo di .NET MAUI (architettura MVVM).

## Presentazione 
All'interno del repository è presente una (presentazione)[Presentazione-ITI-MAUI.pptx] che spiega le tecnologie utilizzate e fa una breve introduzione al mondo di .NET MAUI. 

## Descrizione dell'app
L'applicazione permette di ordinare diverse pizze e visualizzare il proprio ordine attraverso due pagine. 
All'apertura viene visualizzata la pagina contentente la lista di tutte le pizze ordinate, riportando i dettagli di ognuna. A destra di ogni pizza è presente un tasto di cancellazione ordine, mentre al click sull'ordine della pizza viene aperta la pagina di modifica ordine. Inoltre, in alto è presente un tasto "aggiungi" che permette di aprire la pagina di nuovo ordine.   
La seconda pagina permette di creare la propria pizza e salvarla nella lista ordini. Questa pagina è accessibile in due modi: al click sul bottone "aggiungi" oppure al click sull'ordine stesso. Nel secondo caso, ovvero il caso di modifica dell'ordine, nella pagina saranno già selezionati i dettagli dell'ordine in modo da facilitarne la modifica.

## Struttura del codice sorgente
Il codice sorgente dell'applicazione si trova all'interno della cartella (src)[src]. 

### files:

**_PizzaProject-MAUI.sln_**: clicca su questo file quando vuoi aprire la soluzione (l'intero progetto) su Visual Studio  

*PizzaProject-MAUI.csproj*: questo file è auto-generato e contiene tutte le specifiche del progetto (ad esempio i paccheti di dipendenze installati). **ATTENZIONE**: NON è ASSOLUTAMENTE da modificare!!! (Pro-tip: anche i altri progetti, è sempre buona regola essere cauti nel modificare file auto-generati.)

*MauiProgram.cs*: è il punto di ingresso dell'applicazione e ne contiene la configurazione generale 
*App.xaml*: definisce le risorse globali (ad esempio colori e stili dei controlli grafici) 
*App.xaml.cs*: gestisce la logica di avvio e il ciclo di vita dell’app, infatti qui viene chiamato il metodo che avvia la prima pagina dell'applicazione.

### cartelle:

**architettura MVVM:** 
*Models*: contiene i modelli di dati (le classi) nel file (Models)[src/Models/Models.cs]
*ViewModels*: contiene (ListViewModel)[src/ViewModels/ListViewModel.cs] e (OrderViewModel)[src/ViewModels/OrderViewModel.cs] (i "ponti" tra le viste e i modelli che gestiscono i dati)
*Views*: contiene (ListPage)[src/Views/ListPage.xaml] e (OrderPage)[src/OrderPage.xaml]

**altre cartelle utili:**
*Infrastructure*: contiene delle funzioni custom a cui è possibile accedere da qualunque punto dell'app 
*Resources*: è l'archivio di tutte le risorse grafiche, per esempio font, immagini o definizioni di stili e temi XAML (tra cui è bene tenere presente i file XAML (Styles)[src/Resources/Styles/Styles.xaml] e (Colors)[src/Resources/Styles/Colors.xaml])

**cartelle che NON verranno modificate per questo progetto:**
*Platforms*: contiene il codice specifico per ogni sistema operativo supportato (Android, iOS, Windows, macOS), possono risultare utili in caso sia necessario integrare funzionalità native come notifiche, permessi o impostazioni specifiche di sistema
*Properties*: archivia file di configurazione dell'app (ad esempio il file launchSettings.json, utile per definire parametri di avvio dell'applicazione in fase di sviluppo)




