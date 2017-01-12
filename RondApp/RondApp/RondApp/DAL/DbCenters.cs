using RondApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace RondApp.DAL
{
    public class DbCenters
    {
        SQLiteConnection Database;
        object locker = new object();
        ISQlite db;
        static int dbVersion = 1;

        public DbCenters()
        {
           db = DependencyService.Get<ISQlite>();
           Database = db.GetConnection();
        }

        public void LoadDbData()
        {
            if (RecreateDB())
            {
                //dropping tables
                Database.Execute("DROP TABLE IF EXISTS TB_DBVERSION");
                Database.Execute("DROP TABLE IF EXISTS TB_OPENING_HOURS");
                Database.Execute("DROP TABLE IF EXISTS TB_TYPES");
                Database.Execute("DROP TABLE IF EXISTS TB_CENTERS");
                Database.Execute("DROP TABLE IF EXISTS TB_OPENING_HOURS");

                //create tables       
                Database.CreateTable<DBVersion>();
                Database.CreateTable<Hours>();
                Database.CreateTable<CenterType>();
                Database.CreateTable<OpeningHours>();
                Database.CreateTable<Center>();

                #region DBVersion
                if (Database.Table<CenterType>().Count() == 0)
                {
                    Database.Insert(new DBVersion
                    {
                        ID = dbVersion
                    });
                }
                #endregion

                #region CenterType
                if (Database.Table<CenterType>().Count() == 0)
                {
                    Database.Insert(new CenterType
                    {
                        ID = 0,
                        Label = "Centro Aiuto"
                    });
                    Database.Insert(new CenterType
                    {
                        ID = 1,
                        Label = "Centro Ascolto"
                    });
                    Database.Insert(new CenterType
                    {
                        ID = 2,
                        Label = "Centro Diurno"
                    });
                    Database.Insert(new CenterType
                    {
                        ID = 3,
                        Label = "Deposito Bagagli"
                    });
                    Database.Insert(new CenterType
                    {
                        ID = 4,
                        Label = "Mensa"
                    });
                    Database.Insert(new CenterType
                    {
                        ID = 5,
                        Label = "Guardaroba"
                    });
                    Database.Insert(new CenterType
                    {
                        ID = 6,
                        Label = "Servizio Sanitario"
                    });
                    Database.Insert(new CenterType
                    {
                        ID = 7,
                        Label = "Servizi di Igiene Personale"
                    });
                    Database.Insert(new CenterType
                    {
                        ID = 8,
                        Label = "Servizi Legali"
                    });
                    Database.Insert(new CenterType
                    {
                        ID = 9,
                        Label = "Servizi Sociali Comune Milano"
                    });
                }
                #endregion

                #region hours
                if (Database.Table<Hours>().Count() == 0)
                {
                    Database.Insert(new Hours
                    {
                        ID = 0,
                        Label = "8.30-19.30"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 1,
                        Label = "9.00-11.30"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 2,
                        Label = "9.00-12.00"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 3,
                        Label = "9.00-17.00"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 4,
                        Label = "9.00-13.00"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 5,
                        Label = "9.00-14.00"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 6,
                        Label = "8.30-11.00"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 7,
                        Label = "17.00-18.30"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 8,
                        Label = "11.30-13.00"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 9,
                        Label = "11.30"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 10,
                        Label = "11.30-14.30"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 11,
                        Label = "17.30-19.30"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 12,
                        Label = "18.30-20.30"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 13,
                        Label = "10.30-11.30"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 14,
                        Label = "9.00-11.00"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 15,
                        Label = "17.30-19.00"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 16,
                        Label = "8.00"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 17,
                        Label = "14.30-16.30"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 18,
                        Label = "11.00-14.00"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 19,
                        Label = "17.30-20.00"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 20,
                        Label = "15.00-16.00"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 21,
                        Label = "15.30"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 22,
                        Label = "8.00-12.00"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 23,
                        Label = "13.45-16.00"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 24,
                        Label = "15.00-18.30"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 25,
                        Label = "9.30-12.00"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 26,
                        Label = "14.30-18.30"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 27,
                        Label = "8.30-12.30"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 28,
                        Label = "9.00-12.30"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 29,
                        Label = "14.00-17.00"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 30,
                        Label = "9.15-12.00"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 31,
                        Label = "11.00-13.00"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 32,
                        Label = "14.00-19.00"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 33,
                        Label = "9.00-15.30"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 34,
                        Label = "8.00-11.00"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 35,
                        Label = "7.30"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 36,
                        Label = "10.00-19.00"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 37,
                        Label = "14.00-16.00"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 38,
                        Label = "8.30-11.30"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 39,
                        Label = "14.00-15.00"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 40,
                        Label = "9.00-15.00"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 41,
                        Label = "14.00-18.00"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 42,
                        Label = "10.00-13.00"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 43,
                        Label = "8.00-13.00"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 44,
                        Label = "11.15-13.00"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 45,
                        Label = "18.30-20.00"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 46,
                        Label = "11.00-12.30"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 47,
                        Label = "18.00-19.30"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 48,
                        Label = "11.00"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 49,
                        Label = "10.30"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 50,
                        Label = "09.30-15.30"
                    });
                    Database.Insert(new Hours
                    {
                        ID = 51,
                        Label = "19.00-21.00"
                    });
                }
                #endregion

                #region centers and openings
                int ID = AddCenter(new Center { IDType = 0, Address = "Via Ferranti Apporti, 3 - 20124 MILANO", Latitude = 45.489192, Longitude = 9.209655, Name = "Centro d'aiuto Stazione Centrale", Notes = "", PhoneNumber = "+390288447649", Reference = "Silvia Fiore", Services = "Coordina l'attività delle unità mobili notturne e diurne. Servizio sociale a bassa soglia. Gestisce la presa in carico di soggetti gravemente emarginati sia italiani sia stranieri. L'ufficio dispone di interpreti e mediatori culturali", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 0, Monday = true, Tuesday = true, Wednesday = true, Thursday = true, Friday = true, Saturday = false, Sunday = false });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 0, Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false, Saturday = true, Sunday = true });

                ID = AddCenter(new Center { IDType = 1, Address = "Via Bergamini, 10 - 20122 MILANO", Latitude = 45.461074, Longitude = 9.194207, Name = "S.A.M.- Servizio Accoglienza Milanese", Notes = "", PhoneNumber = "+390258391582", Reference = "Mimmo Indraccolo, Elisabetta Ditroia", Services = "Ascolto, orientamento e accompagnamento", Origin = "I", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 1, Monday = true, Tuesday = true, Wednesday = false, Thursday = true, Friday = true, Saturday = false, Sunday = false });

                ID = AddCenter(new Center { IDType = 1, Address = "Via Galvani, 16 - 20124 MILANO", Latitude = 45.4865312, Longitude = 9.1970483, Name = "S.A.I. - Servizio Accoglienza Immigrati - Caritas Ambrosiana", Notes = "sai.ambrosiana@caritas.it 02.67.38.02.61 / 02.67.38.22.30", PhoneNumber = "+0267380261 ", Reference = "Pedro Di Iorio", Services = "Servizio della Caritas Ambrosiana rivolgo agli immigrati: primo ascolto, orientamento alla ricerca lavorativa, prima accoglienza notturna temporanea e su progetto, consulenza e orientamento legale, orientamento ai Servizi Sociali.", Origin = "S", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 2, Monday = true, Tuesday = true, Wednesday = true, Thursday = true, Friday = true, Saturday = false, Sunday = false, Notes = "Consulenza telefonica al pubblico" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 4, Monday = true, Tuesday = true, Wednesday = true, Thursday = false, Friday = false, Saturday = false, Sunday = false });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 29, Monday = true, Tuesday = true, Wednesday = true, Thursday = false, Friday = false, Saturday = false, Sunday = false });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 4, Monday = false, Tuesday = true, Wednesday = false, Thursday = true, Friday = false, Saturday = false, Sunday = false, Notes = "Consulenza telefonica specifica ai centri di ascolto" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 39, Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = true, Saturday = false, Sunday = false });

                ID = AddCenter(new Center { IDType = 2, Address = "Viale Famagosta, 2 - 20142 MILANO", Latitude = 45.436845, Longitude = 9.155069, Name = "Centro diurno la piazzetta", Notes = "Il centro è aperto a tutti, uomini e donne, italiani e stranieri purchè maggiorenni. Accesso diretto o su invito di servizi.", PhoneNumber = "", Reference = "Vincenzo Gravina", Services = "Attività educative e ricreative", Origin = "E", Gender = "E", MinAge = 18, MaxAge = 100, Hygiene = "N", Health = "N" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 3, Monday = true, Tuesday = true, Wednesday = false, Thursday = true, Friday = false, Saturday = false, Sunday = false });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 4, Monday = false, Tuesday = false, Wednesday = true, Thursday = false, Friday = false, Saturday = false, Sunday = false });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 40, Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = true, Saturday = false, Sunday = false });

                ID = AddCenter(new Center { IDType = 2, Address = " Via Boeri, 3 - 20141 MILANO", Latitude = 45.44263, Longitude = 9.186072, Name = "Opera Cardinal Ferrari", Notes = "Accesso a persone anziane sopra i 55 anni con reddito minimo, o per persone con totale inabilità di età superiore ai 50 anni.Offre servizio sociale, ambulatorio, gardarobba, docce, parrucchiere, pedicure, mensa a pranzo.Occorre una tessera che viene rilasciata dopo il colloquio con l'Assistente Sociale. Chiuso nei giorni: 24 Dic. 1 Mag., Vigilia di Pasqua, 14 Ago.", PhoneNumber = "", Reference = "A.S.Loredana Rossetti", Services = "Attività animative, servizio sociale.", Origin = "E", Gender = "E", MinAge = 55, MaxAge = 100, Hygiene = "N", Health = "N" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 3, Monday = true, Tuesday = true, Wednesday = true, Thursday = true, Friday = true, Saturday = true, Sunday = true });

                ID = AddCenter(new Center { IDType = 2, Address = "ia Miramare angolo via Viserba -MILANO", Latitude = 45.521629, Longitude = 9.224877, Name = "Drop in Miramare", Notes = "Il servizio è gratuito e l'accesso è assolutamente libero senza richiesta di documenti. Viene richiesto un colloqui con gli operatori.", PhoneNumber = "", Reference = "", Services = "Accoglienza di persone con problematiche di dipendenza da sostanze stupefacenti e / o alcool, senza dimora.", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 4, Monday = true, Tuesday = false, Wednesday = false, Thursday = true, Friday = true, Saturday = false, Sunday = false });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 41, Monday = false, Tuesday = true, Wednesday = true, Thursday = false, Friday = false, Saturday = false, Sunday = false });

                ID = AddCenter(new Center { IDType = 2, Address = "Piazza XXV Aprile, 2 - MILANO", Latitude = 45.480141, Longitude = 9.187138, Name = " Drop in XXV Aprile", Notes = "Il servizio è gratuito e l'accesso è assolutamente libero senza richiesta di documenti. Viene richiesto un colloqui con gli operatori.", PhoneNumber = "", Reference = "", Services = "Accoglienza di persone con problematiche di dipendenza da sostanze stupefacenti e / o alcool, senza dimora.", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 5, Monday = true, Tuesday = false, Wednesday = false, Thursday = false, Friday = false, Saturday = false, Sunday = false });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 42, Monday = false, Tuesday = true, Wednesday = false, Thursday = false, Friday = false, Saturday = false, Sunday = false, Notes = "Per donne" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 41, Monday = false, Tuesday = false, Wednesday = true, Thursday = false, Friday = false, Saturday = false, Sunday = false });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 43, Monday = false, Tuesday = false, Wednesday = false, Thursday = true, Friday = false, Saturday = false, Sunday = false });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 26, Monday = false, Tuesday = false, Wednesday = false, Thursday = true, Friday = false, Saturday = false, Sunday = false });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 4, Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = true, Saturday = false, Sunday = false });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 4, Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false, Saturday = true, Sunday = true });

                ID = AddCenter(new Center { IDType = 3, Address = "Via Settala, 25 / 27 - MILANO", Latitude = 45.480108, Longitude = 9.205628, Name = "S.Gregorio Magno", Notes = "Il servizio è gratuito, per italiani e stranieri con documenti di identità. Chiuso in luglio e agosto. Verificare sempre disponibilità posti.", PhoneNumber = "", Reference = "Aldo Perathoner", Services = "Deposito bagagli per italiani e stranieri con documenti di identità.", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "S", Health = "N" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 6, Monday = false, Tuesday = true, Wednesday = false, Thursday = false, Friday = false, Saturday = false, Sunday = false });

                ID = AddCenter(new Center { IDType = 3, Address = "Via Maffucci(lato oratorio) - MILANO", Latitude = 45.498411, Longitude = 9.171833, Name = "SS.Giovanni e Paolo", Notes = "Il servizio è offerto sia agli stranieri che algi italiani. Non occorre lettera di presetnazione.Vengono accettati al massimo 2 colli a persone.Il servizio è gratuito. In estate è chiuso.", PhoneNumber = "", Reference = "Liliana Lastella", Services = "Deposito bagagli per italiani e stranieri con documenti di identità.", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "S", Health = "N" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 7, Monday = true, Tuesday = true, Wednesday = true, Thursday = true, Friday = true, Saturday = false, Sunday = false });

                ID = AddCenter(new Center { IDType = 4, Address = "Via Ponzio, 75 - MILANO", Latitude = 45.481444, Longitude = 9.229794, Name = "Centro Francescano Maria della Passione", Notes = "Uomini e donne con tessera da richiedere al segretariato sociale (Mar/Sab 9.30/13.00 - Dom 10.30/12.30) in via Fossati 2 con documento valido.", PhoneNumber = "", Reference = "Suor Rossella Vella", Services = "Pranzo per uomini, donne e bambini.", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 8, Monday = false, Tuesday = true, Wednesday = true, Thursday = true, Friday = true, Saturday = true, Sunday = false });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 44, Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false, Saturday = false, Sunday = true });

                ID = AddCenter(new Center { IDType = 4, Address = " Via Maroncelli, 19 - MILANO", Latitude = 45.483806, Longitude = 9.182681, Name = "Centro S. Antonio", Notes = "Per accedere alla mensa è indispensabile avere la tessera che ha valenza bimestrale e si ritira presso il Centro di Ascolto l'ultimo giorno lavorativo del mese per i due mesi successivi. Non è necessaria l afoto, meglio se in possesso di un documento originale.", PhoneNumber = "", Reference = "Fra Massimo Cocchetti", Services = "Pranzo", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 9, Monday = true, Tuesday = true, Wednesday = true, Thursday = true, Friday = true, Saturday = true, Sunday = false, Notes = "Escluso i festivi" });

                ID = AddCenter(new Center { IDType = 4, Address = "Corso Concordia, 3 - MILANO", Latitude = 45.468012, Longitude = 9.208597, Name = "Opera S. Francesco per i Poveri", Notes = "L'accesso alla mensa avviene tramite tessera da ritirare presso il Servizio Accoglienza (Lun/Ven 10.30/15.00 - 17.30/19.30 - Sab 11.30/14.00) in Via Kramer, 1. E' necessario un documento d'identità valido.", PhoneNumber = "", Reference = "Padre Maurizio Annoni", Services = "Pranzo e cena.", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 10, Monday = true, Tuesday = true, Wednesday = true, Thursday = true, Friday = true, Saturday = true, Sunday = false });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 11, Monday = true, Tuesday = true, Wednesday = true, Thursday = true, Friday = true, Saturday = true, Sunday = false });

                ID = AddCenter(new Center { IDType = 4, Address = "Vai Saponaro, 40 - MILANO", Latitude = 45.405488, Longitude = 9.173662, Name = "Fondazione / Associazione Fratelli di San Francesco", Notes = "Accesso alla mensa tramite tessera da ritirare Lun/Ven 8.30/13.00 - 14.30/17.00 - Sab 9.00/11.30 in via Bertoni, 9 - c/o il Segretariato Sociale - validità 2 mesi - al costo di € 6,00 rinnovabili.", PhoneNumber = "", Reference = "Fr.Clemente Moriggi", Services = "Pranzo e cena.", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 8, Monday = true, Tuesday = true, Wednesday = true, Thursday = true, Friday = true, Saturday = true, Sunday = false });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 45, Monday = true, Tuesday = true, Wednesday = true, Thursday = true, Friday = true, Saturday = true, Sunday = false });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 46, Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false, Saturday = false, Sunday = true });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 47, Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false, Saturday = false, Sunday = true });

                ID = AddCenter(new Center { IDType = 4, Address = "Via Canova, 4 - MILANO", Latitude = 45.475079, Longitude = 9.168739, Name = "Opera messa della carità - Carmelitani Scalzi", Notes = "", PhoneNumber = "", Reference = "Padre Giulio Pozzi", Services = "Pranzo", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 13, Monday = true, Tuesday = true, Wednesday = true, Thursday = true, Friday = true, Saturday = true, Sunday = true });

                ID = AddCenter(new Center { IDType = 4, Address = "P.za Velasquez, 1 - MILANO", Latitude = 45.46731, Longitude = 9.141514, Name = "Opera Pane S.Antonio", Notes = "Accettazione mediante ritiro biglietto dalle 10.00 alle 11.30.", PhoneNumber = "", Reference = " Fra Giampaolo Gabossi", Services = "Pranzo", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 9, Monday = true, Tuesday = true, Wednesday = true, Thursday = true, Friday = true, Saturday = false, Sunday = true, Notes = "Chiuso il sabato" });

                ID = AddCenter(new Center { IDType = 4, Address = "Viale Toscana, 28 - MILANO", Latitude = 45.44591, Longitude = 9.18777, Name = "Opera Pia Pane Quotidiano", Notes = "Distribuzione pane, latte freddo e altro a tutti quelli che si presentano. Altra sede di distribuzione: viale Monza, 335.", PhoneNumber = "", Reference = "Pier Maria Ferrario", Services = "Distribuzione generi alimentari da asporto.", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 14, Monday = true, Tuesday = true, Wednesday = true, Thursday = true, Friday = true, Saturday = true, Sunday = false, Notes = "Escluso i festivi" });

                ID = AddCenter(new Center { IDType = 4, Address = "Via Forze Armate, 379 - MILANO", Latitude = 45.460807, Longitude = 9.093056, Name = "Suore Missionarie Della Carità", Notes = "Conosciuta come Mensa delle Suore di Madre Teresa di Calcutta.", PhoneNumber = "", Reference = "Suor Maria Xavier", Services = "Solo cena - Pranzo alla domenica.", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 15, Monday = true, Tuesday = true, Wednesday = true, Thursday = false, Friday = true, Saturday = true, Sunday = false });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 48, Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false, Saturday = false, Sunday = true });

                ID = AddCenter(new Center { IDType = 5, Address = "Via Ponzio, 75 - MILANO", Latitude = 45.481444, Longitude = 9.229794, Name = "Centro Francescano Maria della Passione", Notes = "Uomini con tessera da richiedere al segretariato sociale da Mar/ Dom 9.30 / 12.30 in via Fossati 2 con documento valido.", PhoneNumber = "", Reference = "Suor Rossella Vella", Services = "Guardaroba", Origin = "E", Gender = "M", MinAge = 0, MaxAge = 100, Hygiene = "S", Health = "N" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 16, Monday = false, Tuesday = true, Wednesday = true, Thursday = false, Friday = false, Saturday = false, Sunday = false });

                ID = AddCenter(new Center { IDType = 5, Address = "Via Maroncelli, 19 - MILANO", Latitude = 45.483806, Longitude = 9.182681, Name = "Centro S. Antonio", Notes = "Presso il Centro di Ascolto si ritira la tessera in gennaio,aprile, luglio e ottobre per il guardaroba che ha valenza trimestrale e consente di usufruire del guardaroba una volta al mese.Viene fissato l'apputamento per ritirare i vestiti.", PhoneNumber = "", Reference = "Adua Catranbone", Services = "Guardaroba", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "S", Health = "N" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 17, Monday = false, Tuesday = true, Wednesday = true, Thursday = true, Friday = true, Saturday = false, Sunday = false, Notes = "Chiuso ad Agosto" });

                ID = AddCenter(new Center { IDType = 5, Address = "Via Kramer, 1 - MILANO", Latitude = 45.468048, Longitude = 9.208649, Name = "Opera S. Francesco per i Poveri", Notes = "Accesso tramite tessera da ritirare presso il Servizio Accoglienza(Lun / Ven 10.30 / 15.00 - 17.30 / 19.30 - Sab 11.30 / 14.00) in Via Kramer, 1.E' necessario un documento d'identità valido.", PhoneNumber = "", Reference = "Fra Domenico Lucchini, Padre Maurizio Annoni", Services = "Guardaroba", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "S", Health = "N" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 18, Monday = true, Tuesday = true, Wednesday = true, Thursday = true, Friday = true, Saturday = false, Sunday = false });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 19, Monday = true, Tuesday = true, Wednesday = true, Thursday = true, Friday = true, Saturday = false, Sunday = false });

                ID = AddCenter(new Center { IDType = 5, Address = "Via Canova, 4 - MILANO", Latitude = 45.475079, Longitude = 9.168739, Name = "Opera messa della carità - Carmelitani Scalzi", Notes = "Solo uomini.Presentarsi al mattino dalle 8.00 alle 9.00 per il biglietto.Solo 30 persone.", PhoneNumber = "", Reference = "Padre Giulio Pozzi", Services = "Guardaroba", Origin = "E", Gender = "M", MinAge = 0, MaxAge = 100, Hygiene = "S", Health = "N" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 20, Monday = false, Tuesday = false, Wednesday = false, Thursday = true, Friday = false, Saturday = false, Sunday = false, Notes = "Chiuso ad Agosto" });

                ID = AddCenter(new Center { IDType = 5, Address = "P.za Velasquez, 1 - MILANO", Latitude = 45.46731, Longitude = 9.141514, Name = "Opera Pane S.Antonio", Notes = "Presentarsi con documento di riconoscimenti. Chiuso luglio, agosto, settembre.", PhoneNumber = "", Reference = "Fra Giampaolo Gabossi", Services = "Guardaroba", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "S", Health = "N" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 21, Monday = true, Tuesday = false, Wednesday = false, Thursday = true, Friday = false, Saturday = false, Sunday = false, Notes = "Uomini con prenotazione il martedì precedente 10.00/11.00" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 49, Monday = false, Tuesday = false, Wednesday = true, Thursday = true, Friday = true, Saturday = false, Sunday = false, Notes = "Donne e Bambini con prenotazione il mercoledì precedente 9.00 / 10.30" });

                ID = AddCenter(new Center { IDType = 6, Address = "Via Antonello da Messina, 4 - MILANO", Latitude = 45.467008, Longitude = 9.141565, Name = "Opera S. Francesco per i Poveri", Notes = "Il servizio si rivolge a italiani ed extracomunitari, che non hanno accesso alle normali prestazioni del servizio sanitario nazionale. Alle visite specialistiche si accede con richiesta del medico generico. E' indispensabile posseder eun documento valido originale.", PhoneNumber = "", Reference = " Sr.Anna Maria Villa", Services = "Visite mediche di base e specialistiche. Servizio dentistico", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "S", Health = "N" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 22, Monday = true, Tuesday = true, Wednesday = true, Thursday = true, Friday = true, Saturday = false, Sunday = false });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 23, Monday = true, Tuesday = true, Wednesday = true, Thursday = true, Friday = true, Saturday = false, Sunday = false });

                ID = AddCenter(new Center { IDType = 6, Address = "Via Padova, 104 - MILANO", Latitude = 45.49492, Longitude = 9.22837, Name = "Poliambulatorio Medici Volontari Italiani", Notes = "Il Poliambulatorio è dedicato agli immigrati irregolari, ma anche alle persone senza tetto e in grave stato di emarginazione. Prestazioni specialistiche (dermatologia, ginecologia, psichiatria, psicologia, ortopedia, consulenza chirurgica): su appuntamento, previa verifica da parte di un medico di MVI. Medicina di base", PhoneNumber = "", Reference = "", Services = " Visite mediche di base e specialistiche.", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "S" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 24, Monday = true, Tuesday = false, Wednesday = true, Thursday = false, Friday = false, Saturday = false, Sunday = false });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 25, Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = true, Saturday = false, Sunday = false });

                ID = AddCenter(new Center { IDType = 6, Address = "", Name = "Unità mobile sanitaria Medici Volontari Italiani", Notes = "Tutti i mercoledì dalle ore 21 alle 23 in Duomo vicino al Camper della Ronda.", PhoneNumber = "", Reference = "", Services = "Unità Mobili di Soccorso: in piazza Duca d'Aosta turni serali luned',martedì, giovedì e venerdì dalle ore 21 alle 22 circa, nel piazzale antistante la Stazione Centrale di Milano. La seconda Unità Mobile opera in collaborazione con l'Associazione 'Il pane quotidiano' nell'area sud di Milano, in viale Toscana.Offre assistenza sanitaria gratuita e distribuzione altrettanto gratuita di farmaci a persone in grave stato di difficoltà economica, sia italiani, che immigrati.", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "S" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 14, Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false, Saturday = true, Sunday = false });

                ID = AddCenter(new Center { IDType = 6, Address = "Via Zamenhof, 7 - MILANO", Latitude = 45.445194, Longitude = 9.179641, Name = "NAGA", Notes = "Il servizio è rivolto a extracomunitari senza permesso di soggiorno, ai nomadi e a chi non ah diritto all'assistenza sanitaria. Visite su appuntamento. Danno gratuitamente anche medicinali. Sono presenti medici di base. Per esami di laboratorio e visite specialistiche si utilizzano strutture ospedaliere. Altre iniziative: interventi di segretariato soaciale ed educazione sanitaria presso il Carcere di San Vittore. Progetto CABIRIA: servizio rivolto a persone sfruttate a fini sessuali, che vogliono affrancarsi dalla prostituzione coatta; offre sostegno nel percorso di uscita dalla tratta e nel reinserimento sociale. Medicina di strada: interventi di strada rivolti ai gruppi di immigrati più emarginati, a rischio, o difficilmente contattabili nell'ambulatorio, che vengono quindi raggiunti con il camper attrezzato sulla strada e negli insediamenti abusivi o precari in cui vivono.", PhoneNumber = "", Reference = " Luca Cusani", Services = "Visite mediche.", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "S" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 27, Monday = true, Tuesday = true, Wednesday = true, Thursday = true, Friday = true, Saturday = false, Sunday = false });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 26, Monday = true, Tuesday = true, Wednesday = true, Thursday = true, Friday = true, Saturday = false, Sunday = false });

                ID = AddCenter(new Center { IDType = 6, Address = "Via Bertoni, 9 - MILANO", Latitude = 45.475412, Longitude = 9.193058, Name = "Fondazione Fratelli di S. Francesco", Notes = "Si accede attraverso iscrizione presso il Segretariato Sociale. Per le prime visite c/o ambulatorio dentistico ogni lunedì verranno distribuiti 15 numeri alle ore 12.30. Successivamente, alle ore 14.00, verrà dato l'appuntamento a tutti coloro che avranno il numero.", PhoneNumber = "", Reference = "Padre Clemente Moriggi", Services = " Poliambulatorio e studio odontoiatrico.L'accesso alle visite del emdico di base è libero. Per accedere alle visite specialistiche è necessaria la visita del emdico di base e la successiva prenotazione per la rirchiesta della visita specialistica.", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "S" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 28, Monday = true, Tuesday = true, Wednesday = true, Thursday = true, Friday = true, Saturday = false, Sunday = false });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 29, Monday = true, Tuesday = true, Wednesday = true, Thursday = true, Friday = true, Saturday = false, Sunday = false });

                ID = AddCenter(new Center { IDType = 6, Address = "Piazza San Fedele, 4 - MILANO", Latitude = 45.466398, Longitude = 9.191535, Name = "Assistenza Sanitaria San Fedele - Opera Padre Maino", Notes = "Per accedere a tutti i servizi è necessaria una lettera di presentaazione del Centro che invia la persona. Distribuzione di medicinali solo con ricetta medica valida.", PhoneNumber = "", Reference = "Padre Giuseppe Trotta, Tomomasso De Filippo", Services = "Visite mediche specialistiche (pediatra il martedì - fisiatra il giovedì) su appuntamento.", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "S" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 30, Monday = true, Tuesday = false, Wednesday = true, Thursday = false, Friday = false, Saturday = false, Sunday = false, Notes = "Sportello Farmaceutico" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 29, Monday = false, Tuesday = false, Wednesday = false, Thursday = true, Friday = false, Saturday = false, Sunday = false, Notes = "Sportello Farmaceutico" });

                ID = AddCenter(new Center { IDType = 6, Address = " Via Wildt, 27 - MILANO", Latitude = 45.488083, Longitude = 9.233341, Name = "C.A.D. - Centro Accoglienza e Trattamento Dipendenze", Notes = "Servizio accreditato dalla Regione Lombardia con ASL Milano. Offre lo stesso programma di attività e prestaizoni erogati dal SERT.Consulenza legale su appuntamento il Mar pomeriggio.", PhoneNumber = "", Reference = " Vito Malcangi", Services = "Assistenza socio sanitaria integrata per tossicodipendenti e alcooldipendenti sia italiani che stranieri (anche senza permesso di soggiorno) e anche per operatori dei servizi. Gestisce la prevensione, la cura e la riabilitazione.", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "S" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 31, Monday = true, Tuesday = true, Wednesday = true, Thursday = true, Friday = true, Saturday = false, Sunday = false });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 32, Monday = true, Tuesday = true, Wednesday = true, Thursday = true, Friday = true, Saturday = false, Sunday = false });

                ID = AddCenter(new Center { IDType = 7, Address = "Via Pucci, 3 - MILANO", Latitude = 45.478104, Longitude = 9.166627, Name = "Docce pubbliche comunali ", Notes = "Il servizio fornisce, a costo sociale: una confezione con shampoo e una saponetta o un bagnoschiuma monouso, una confezione con un rasoio e schiuma da barba, un asciugamano, una confezione con spazzolino e dentifricio, servizio lavatrici e asciugatrici a prezzo contenuto", PhoneNumber = "", Reference = "", Services = "E' un servizio gratuito di docce pubbliche dislocate in diverse zone della città che il Comune offre per la cure e l'igiene personale, di aiuto principalmente ai cittadini in difficoltà per condizioni personali o abitative.", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "S", Health = "N" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 33, Monday = true, Tuesday = true, Wednesday = true, Thursday = true, Friday = true, Saturday = false, Sunday = false });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 50, Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false, Saturday = true, Sunday = false });

                ID = AddCenter(new Center { IDType = 7, Address = "Via Anselmo da Baggio, 50 - MILANO", Latitude = 45.46446, Longitude = 9.089171, Name = "Docce pubbliche comunali ", Notes = "Il servizio fornisce, a costo sociale: una confezione con shampoo e una saponetta o un bagnoschiuma monouso, una confezione con un rasoio e schiuma da barba, un asciugamano, una confezione con spazzolino e dentifricio, servizio lavatrici e asciugatrici a prezzo contenuto", PhoneNumber = "", Reference = "", Services = "E' un servizio gratuito di docce pubbliche dislocate in diverse zone della città che il Comune offre per la cure e l'igiene personale, di aiuto principalmente ai cittadini in difficoltà per condizioni personali o abitative.", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "S", Health = "N" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 33, Monday = true, Tuesday = true, Wednesday = true, Thursday = true, Friday = true, Saturday = false, Sunday = false });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 50, Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false, Saturday = true, Sunday = false });


                ID = AddCenter(new Center { IDType = 7, Address = "Via Bertoni, 9 - MILANO", Latitude = 45.475412, Longitude = 9.193058, Name = " Fondazione Fratelli di S. Francesco", Notes = "Per la doccia gratuita si accede con tessera rilasciata Lun/ Ven 8.30 / 12.30 14.00 / 18.00 in via Bertoni, 9 c / o il Segretariato Sociale che ha validità 2 mesi e costa € 1,00.Solo per uomini. Si può fare la doccia 1 volta alla settimana.SI fornisce shampoo, asciugamano e biancheria.", PhoneNumber = "", Reference = "", Services = " Igiene personale.", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "s", Health = "N" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 34, Monday = true, Tuesday = true, Wednesday = true, Thursday = true, Friday = true, Saturday = false, Sunday = false });


                ID = AddCenter(new Center { IDType = 7, Address = "Via Piave, 2 - MILANO", Latitude = 45.541872, Longitude = 9.116839, Name = "Opera S. Francesco", Notes = "Si accede con la tessera rilasciata presso il Servizio Accoglienza, Via Kramer, 1(Lun / Ven 10.30 / 15.00 - 17.30 / 19.30 - Sab 11.30 / 14.00).Solo uomini, una doccia gratuita a settimana.A chi fa la doccia vengono dati rasoio, shampoo, sapone, asciugamano oltre a un cambio di biancheria nuovo.E' necessario un documento valido.", PhoneNumber = "", Reference = "Fra Domenico Lucchini", Services = "Igiene personale.", Origin = "E", Gender = "M", MinAge = 0, MaxAge = 100, Hygiene = "S", Health = "N" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 18, Monday = true, Tuesday = true, Wednesday = true, Thursday = true, Friday = true, Saturday = false, Sunday = false });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 19, Monday = true, Tuesday = true, Wednesday = true, Thursday = true, Friday = true, Saturday = false, Sunday = false });

                ID = AddCenter(new Center { IDType = 7, Address = " Via Ponzio, 75 - MILANO", Latitude = 45.481444, Longitude = 9.229794, Name = "Centro Francescano Maria della Passione", Notes = "Si accede con la tessera rilasciata dal Centro stesso.Si può fare la doccia una volta ogni 15 giorni per gli uomini e una volta alla settimana per le donne. il Segretariato per la distribuzione delle tessere è aperto Mar/ Sab ore 9.30 / 12.30 e Dom 10.30 / 12.30 in via Fossati, 2. La tessera permette l'accesso anche agli altri servizi (guardaroba, mense, suola di italiano e centro di ascolto).", PhoneNumber = "", Reference = " Suor Rossella Vella", Services = "Igiene Personale.", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "S", Health = "N" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 35, Monday = false, Tuesday = false, Wednesday = false, Thursday = true, Friday = false, Saturday = true, Sunday = false, Notes = "Uomini" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 35, Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = true, Saturday = false, Sunday = false, Notes = "Donne" });

                ID = AddCenter(new Center { IDType = 8, Address = "Via Galvani, 16 - MILANO", Latitude = 45.486531, Longitude = 9.99242, Name = "S.A.I. - Servizio Accoglienza Immigrati - Caritas Ambrosiana", Notes = "sai.ambrosiana @caritas.it 02.67.38.02.61 / 02.67.38.22.30", PhoneNumber = "+390267380261", Reference = "Pedro di Iorio", Services = "Servizio della Caritas Ambrosiana rivolgo agli immigrati: primo ascolto, orientamento alla ricerca lavorativa, prima accoglienza notturna temporanea e su progetto, consulenza e orientamento legale, orientamento ai Servizi Sociali.", Origin = "S", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 2, Monday = true, Tuesday = true, Wednesday = true, Thursday = true, Friday = true, Saturday = false, Sunday = false, Notes = "Consulenza telefonica al pubblico" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 4, Monday = true, Tuesday = true, Wednesday = true, Thursday = false, Friday = false, Saturday = false, Sunday = false });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 29, Monday = true, Tuesday = true, Wednesday = true, Thursday = false, Friday = false, Saturday = false, Sunday = false });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 4, Monday = false, Tuesday = true, Wednesday = false, Thursday = true, Friday = false, Saturday = false, Sunday = false, Notes = "Consulenza telefonica specifica ai centri di ascolto" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 39, Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = true, Saturday = false, Sunday = false });

                ID = AddCenter(new Center { IDType = 8, Address = "Via Zamenhof, 7 - MILANO", Latitude = 45.445194, Longitude = 9.179641, Name = "NAGA", Notes = " Aperto uno sportello dove si occupano di espulsioni, e uno sportello immigrazione (permessi di soggiorno, ricongiungimenti, ecc.) tel. 02.58.10.77.91", PhoneNumber = "", Reference = "Fabio Forfori", Services = "Assistenza legale per stranieri in particolare senza permesso di soggiorno.", Origin = "S", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 51, Monday = true, Tuesday = true, Wednesday = true, Thursday = true, Friday = true, Saturday = false, Sunday = false });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 37, Monday = false, Tuesday = true, Wednesday = false, Thursday = true, Friday = false, Saturday = false, Sunday = false, Notes = "presentarsi alle 12.30 per ritirare i biglietti" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 2, Monday = false, Tuesday = false, Wednesday = true, Thursday = false, Friday = false, Saturday = false, Sunday = false, Notes = "presentarsi alle 8.30 per ritirare i biglietti" });

                ID = AddCenter(new Center { IDType = 8, Address = "Via Wildt, 27 - MILANO", Latitude = 45.488083, Longitude = 9.233341, Name = "C.A.D. - Centro Accoglienza e Trattamento Dipendenze", Notes = "", PhoneNumber = "", Reference = "Vito Malcangi", Services = "Assistenza legale per tossidocipendenti, alcooldipendenti e dipendenti da gioco sia italiani (anche senza dimora) che stranieri (anche senza permesso di soggiorno), inviati da parte dei servizi.", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 36, Monday = true, Tuesday = true, Wednesday = true, Thursday = true, Friday = true, Saturday = false, Sunday = false, Notes = "Telefonare in segreteria per fissare appuntamento per i Martedì successivi." });

                ID = AddCenter(new Center { IDType = 8, Address = "Via San Giovanni alla Paglia, 7 - MILANO", Latitude = 45.479791, Longitude = 9.202729, Name = "Avvocato di Strada, Fondazione Progetto Arca Onlus ", Notes = "", PhoneNumber = "", Reference = "Avv.Elena Rossi, Avv.Anna Spadoni", Services = "Assistenza legale per persone senza dimora sia italiani che stranieri.", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 37, Monday = false, Tuesday = false, Wednesday = true, Thursday = false, Friday = false, Saturday = false, Sunday = false });

                ID = AddCenter(new Center { IDType = 8, Address = "Piazza San Fedele, 4 - MILANO", Latitude = 45.466398, Longitude = 9.191535, Name = "Avvocato di Strada", Notes = "", PhoneNumber = "", Reference = "Avv.Elena Rossi, Avv.Anna Spadoni", Services = "Assistenza legale per persone senza dimora sia italiani che stranieri", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 37, Monday = false, Tuesday = false, Wednesday = false, Thursday = true, Friday = false, Saturday = false, Sunday = false });

                ID = AddCenter(new Center { IDType = 9, Address = "Via Monte Grappa n. 8/a - MILANO", Latitude = 45.545765, Longitude = 9.080173, Name = "Sede zonale S.S.P.T.Zona 1", Notes = "I servizi si rivolgono ai residenti nella Città di Milano ed hanno compentenza per zona. Su Appuntamento tel. 02.884.48298 / 9", PhoneNumber = "+390288448298", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });

                ID = AddCenter(new Center { IDType = 9, Address = "Via Ugo Foscolo, 5 - MILANO Scala C, 5° piano", Latitude = 45.465518, Longitude = 9.190621, Name = "Sede zonale S.S.P.T.Zona 1", Notes = "Su Appuntamento Tel. 02.884.41665 / 6  I servizi si rivolgono ai residenti nella Città di Milano ed hanno compentenza per zona.", PhoneNumber = "+390288441665", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });

                ID = AddCenter(new Center { IDType = 9, Address = "Via S. Elembardo, 4 - MILANO", Latitude = 45.505526, Longitude = 9.220451, Name = "Sede zonale S.S.P.T.Zona 2", Notes = " Su Appuntamento Tel. 02.884.46612/13/14/15 I servizi si rivolgono ai residenti nella Città di Milano ed hanno compentenza per zona.", PhoneNumber = "+390288446612", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });

                ID = AddCenter(new Center { IDType = 9, Address = "Via degli Assereto, 19 - MILANO angolo via Delle Abbadesse, 18", Latitude = 45.48933, Longitude = 9.19564, Name = "Sede zonale S.S.P.T.Zona 2", Notes = "Su Appuntamento	Tel. 02.884.45915 I servizi si rivolgono ai residenti nella Città di Milano ed hanno compentenza per zona.", PhoneNumber = "+390288445915", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });

                ID = AddCenter(new Center { IDType = 9, Address = "Via Pini, 1 - MILANO", Latitude = 45.484232, Longitude = 9.240862, Name = " Sede zonale S.S.P.T.Zona 3 ", Notes = " Su Appuntamento Tel. 02.884.7925 / 6 / 7 / 8 I servizi si rivolgono ai residenti nella Città di Milano ed hanno compentenza per zona.", PhoneNumber = "+39028847925", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });

                ID = AddCenter(new Center { IDType = 9, Address = "Via Monteverdi, 8 - MILANO", Latitude = 45.482462, Longitude = 9.214785, Name = "Sede zonale S.S.P.T.Zona 3", Notes = "Su Appuntamento 02.884.47438 Tel.I servizi si rivolgono ai residenti nella Città di Milano ed hanno compentenza per zona.", PhoneNumber = "+390288447438", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });

                ID = AddCenter(new Center { IDType = 9, Address = "Viale Puglia, 33 - MILANO", Latitude = 45.450073, Longitude = 9.22373, Name = " Sede zonale S.S.P.T.Zona 4", Notes = "Su Appuntamento 02.48438/9/40/41 Tel. I servizi si rivolgono ai residenti nella Città di Milano ed hanno compentenza per zona.", PhoneNumber = "+390248438", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });

                ID = AddCenter(new Center { IDType = 9, Address = "Via dei Cinquecento, 7 - MILANO", Latitude = 45.435944, Longitude = 9.222056, Name = "Sede zonale S.S.P.T.Zona 4", Notes = "Su Appuntamento Tel. 02.884.54231/32/33 I servizi si rivolgono ai residenti nella Città di Milano ed hanno compentenza per zona.", PhoneNumber = "+390288454231", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });

                ID = AddCenter(new Center { IDType = 9, Address = "Via Barabino, 8 - MILANO", Latitude = 45.43362, Longitude = 9.22203, Name = "Sede zonale S.S.P.T.Zona 4 - 5", Notes = "Su Appuntamento Tel. 02.884.45446 / 02.884.45433 I servizi si rivolgono ai residenti nella Città di Milano ed hanno compentenza per zona.", PhoneNumber = "+390288445446", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });

                ID = AddCenter(new Center { IDType = 9, Address = "Via Don Carlo San Martino, 10 - MILANO", Latitude = 45.468026, Longitude = 9.235397, Name = "Sede zonale S.S.P.T.Zona 4", Notes = "Su Appuntamento Tel. 02.884.48455/6 I servizi si rivolgono ai residenti nella Città di Milano ed hanno compentenza per zona.", PhoneNumber = "+390288448455", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });

                ID = AddCenter(new Center { IDType = 9, Address = "Viale Tibaldi, 41 - MILANO", Latitude = 45.444555, Longitude = 9.183285, Name = "Sede zonale S.S.P.T.Zona 5 - 6", Notes = "Su Appuntamento Tel. 02.884.48435 / 02.884.62887  I servizi si rivolgono ai residenti nella Città di Milano ed hanno compentenza per zona.", PhoneNumber = "+390288448435", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });

                ID = AddCenter(new Center { IDType = 9, Address = "Via Boifava, 17 - MILANO", Latitude = 45.427082, Longitude = 9.174865, Name = "Sede zonale S.S.P.T.Zona 5", Notes = "Su Appuntamento Tel. 02.884.58553/5/6/7/9 I servizi si rivolgono ai residenti nella Città di Milano ed hanno compentenza per zona.", PhoneNumber = "+390288458553", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });

                ID = AddCenter(new Center { IDType = 9, Address = "Via Legioni Romane, 54 - MILANO", Latitude = 45.459649, Longitude = 9.12765, Name = "Sede zonale S.S.P.T.Zona 6", Notes = "Su Appuntamento Tel. 02.884.63570 I servizi si rivolgono ai residenti nella Città di Milano ed hanno compentenza per zona.", PhoneNumber = "+390288463570", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });

                ID = AddCenter(new Center { IDType = 9, Address = "Via Gonin, 28 - MILANO", Latitude = 45.442977, Longitude = 9.125629, Name = "Sede zonale S.S.P.T.Zona 6", Notes = "Su Appuntamento Tel.02.884.51319 I servizi si rivolgono ai residenti nella Città di Milano ed hanno compentenza per zona.", PhoneNumber = "+390288451319", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });

                ID = AddCenter(new Center { IDType = 9, Address = "Via Anselmo da Baggio, 54 - MILANO", Latitude = 45.464334, Longitude = 9.088639, Name = "Sede zonale S.S.P.T.Zona 7", Notes = "Tel. 02.884.65171 I servizi si rivolgono ai residenti nella Città di Milano ed hanno compentenza per zona.", PhoneNumber = "+390288465882", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });
                AddHours(new OpeningHours { IDCenter = ID, IDHours = 38, Monday = true, Tuesday = true, Wednesday = false, Thursday = true, Friday = false, Saturday = false, Sunday = false });

                ID = AddCenter(new Center { IDType = 9, Address = "Piazzale Segesta, 11 - MILANO", Latitude = 45.47567, Longitude = 9.136941, Name = "Sede zonale S.S.P.T.Zona 7", Notes = "Su Appuntamento Tel. 02.884.65882 I servizi si rivolgono ai residenti nella Città di Milano ed hanno compentenza per zona.", PhoneNumber = "+390288465882", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });

                ID = AddCenter(new Center { IDType = 9, Address = "Via Colleoni, 8 - MILANO", Latitude = 45.483164, Longitude = 9.154303, Name = "Sede zonale S.S.P.T.Zona 8", Notes = "Su Appuntamento Tel.02.884.47083/5/6 I servizi si rivolgono ai residenti nella Città di Milano ed hanno compentenza per zona.", PhoneNumber = "+390288447083", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });

                ID = AddCenter(new Center { IDType = 9, Address = "Via Aldini, 72 - MILANO", Latitude = 45.511849, Longitude = 9.13163, Name = " Sede zonale S.S.P.T.Zona 8", Notes = "Su Appuntamento Tel. 02.884.44240/1/2/3/4 I servizi si rivolgono ai residenti nella Città di Milano ed hanno compentenza per zona.", PhoneNumber = "+390288444240", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });

                ID = AddCenter(new Center { IDType = 9, Address = "Piazzale Accursio, 5 - MILANO", Latitude = 45.491369, Longitude = 9.14622, Name = "Sede zonale S.S.P.T.Zona 8", Notes = "Su Appuntamento Tel. 02.884.64293/4/5 I servizi si rivolgono ai residenti nella Città di Milano ed hanno compentenza per zona.", PhoneNumber = "+390288464293", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });

                ID = AddCenter(new Center { IDType = 9, Address = "Via Ojetti, 20 - MILANO", Latitude = 45.49485, Longitude = 9.113138, Name = "Sede zonale S.S.P.T.Zona 8", Notes = "Su Appuntamento Tel. 02.884.41288 I servizi si rivolgono ai residenti nella Città di Milano ed hanno compentenza per zona.", PhoneNumber = "+390288441288", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });

                ID = AddCenter(new Center { IDType = 9, Address = "Via Brivio, 4 - MILANO", Latitude = 45.503798, Longitude = 9.177276, Name = "Sede zonale S.S.P.T.Zona 9", Notes = "Su Appuntamento Tel. 02.884.48439/1 I servizi si rivolgono ai residenti nella Città di Milano ed hanno compentenza per zona.", PhoneNumber = "+390288448439", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });

                ID = AddCenter(new Center { IDType = 9, Address = "Via Giolli, 29 - MILANO", Latitude = 45.526862, Longitude = 9.210527, Name = "Sede zonale S.S.P.T.Zona 9", Notes = "Su Appuntamento Tel.02.884.46430/1/2/3/4/5 I servizi si rivolgono ai residenti nella Città di Milano ed hanno compentenza per zona.", PhoneNumber = "+390288446430", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });

                ID = AddCenter(new Center { IDType = 9, Address = "Via Sant'Arnaldo, 17 - MILANO", Latitude = 45.525392, Longitude = 9.176776, Name = "Sede zonale S.S.P.T.Zona 9", Notes = "Su Appuntamento	Tel. 02.884.45773/4/5/7 I servizi si rivolgono ai residenti nella Città di Milano ed hanno compentenza per zona.", PhoneNumber = "+390288445773", Origin = "E", Gender = "E", MinAge = 0, MaxAge = 100, Hygiene = "N", Health = "N" });

                List<Center> centers = Database.Table<Center>().ToList();
                #endregion
            }
        }

        public SQLiteConnection GetDatabaseConn()
        {
            return this.Database;
        }

        #region Private methods
        private Boolean RecreateDB()
        {
            try
            {
                if (Database.Table<Center>().ToList().Count <= 0 || Database.Table<DBVersion>().ToList().Count <= 0)
                {
                    // No center in DB or no DBVersion registered
                    return true;
                }

                // check version
                foreach (DBVersion curVersion in Database.Table<DBVersion>().ToList())
                {
                    if (curVersion.ID == dbVersion)
                    {
                        // Current DB version in DBVersion table
                        return false;
                    }
                }

                // The current DB version is not foundin DBVersion table
                return true;
            }
            catch (Exception)
            {
                // If exception DB not existent
                return true;
            }
        }

        private int AddCenter(Center newCenter)
        {
            Database.Insert(newCenter);
            return newCenter.ID;
        }

        private void AddHours(OpeningHours newOpening)
        {
            Database.Insert(newOpening);
        }
        #endregion

    }
}
