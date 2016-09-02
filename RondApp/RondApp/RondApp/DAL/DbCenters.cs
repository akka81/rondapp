using RondApp.Models;
using SQLite;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RondApp.DAL
{
    public class DbCenters
    {
        SQLiteConnection Database;
        object locker = new object();
        public DbCenters()
        {
            Database = DependencyService.Get<ISQlite>().GetConnection();

            //dropping tables
            Database.Execute("DROP TABLE IF EXISTS TB_OPENING_HOURS");
            Database.Execute("DROP TABLE IF EXISTS TB_TYPES");
            Database.Execute("DROP TABLE IF EXISTS TB_CENTERS");
            Database.Execute("DROP TABLE IF EXISTS TB_OPENING_HOURS");

            //create tables       
            Database.CreateTable<Hours>();
            Database.CreateTable<CenterType>();
            Database.CreateTable<OpeningHours>();
            Database.CreateTable<Center>();          
        }

        public void LoadDbData()
        {
            #region CenterType
            if (Database.Table<CenterType>().Count() == 0)
            {
                Database.Insert(new CenterType {
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
                    Label = "Mesa"
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
                    Label="8.30-19.30"
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
            }
            #endregion

            #region centers and openings
            int ID = AddCenter(new Center { IDType = 0, Address = "Via Ferranti Apporti, 3 - 20124 MILANO", Latitude = 45.489192,Longitude = 9.209655, Name = "Centro d'aiuto Stazione Centrale", Notes="",PhoneNumber="", Reference="Silvia Fiore", Services= "Coordina l'attività delle unità mobili notturne e diurne. Servizio sociale a bassa soglia. Gestisce la presa in carico di soggetti gravemente emarginati sia italiani sia stranieri. L'ufficio dispone di interpreti e mediatori culturali"});
            AddHours(new OpeningHours { IDCenter = ID, IDHours = 0, Monday=true, Tuesday=true, Wednesday=true, Thursday=true, Friday=true, Saturday=false, Sunday=false});
            AddHours(new OpeningHours { IDCenter = ID, IDHours = 0, Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false, Saturday = true, Sunday = true });

            ID = AddCenter(new Center { IDType = 1, Address = "Via Bergamini, 10 - 20122 MILANO", Latitude = 45.461074, Longitude = 9.194207, Name = "S.A.M.- Servizio Accoglienza Milanese", Notes = "", PhoneNumber = "", Reference = "Mimmo Indraccolo, Elisabetta Ditroia", Services= "Ascolto, orientamento e accompagnamento" });
            AddHours(new OpeningHours { IDCenter = ID, IDHours = 1, Monday = true, Tuesday = true, Wednesday = false, Thursday = true, Friday = true, Saturday = false, Sunday = false });

            ID = AddCenter(new Center { IDType = 1, Address = "Via Galvani, 16 - 20124 MILANO", Latitude = 45.486531, Longitude = 9.199242, Name = " S.A.I. - Servizio Accoglienza Immigrati - Caritas Ambrosiana", Notes = "sai.ambrosiana@caritas.it 02.67.38.02.61 / 02.67.38.22.30", PhoneNumber = "", Reference = " Pedro Di Iorio", Services= " Servizio della Caritas Ambrosiana rivolgo agli immigrati: primo ascolto, orientamento alla ricerca lavorativa, prima accoglienza notturna temporanea e su progetto, consulenza e orientamento legale, orientamento ai Servizi Sociali." });
            AddHours(new OpeningHours { IDCenter = ID, IDHours = 2, Monday = true, Tuesday = true, Wednesday = true, Thursday = true, Friday = true, Saturday = false, Sunday = false, Notes="Consulenza telefonica al pubblico" });
            AddHours(new OpeningHours { IDCenter = ID, IDHours = 4, Monday = true, Tuesday = true, Wednesday = true, Thursday = false, Friday = false, Saturday = false, Sunday = false });
            AddHours(new OpeningHours { IDCenter = ID, IDHours = 29, Monday = true, Tuesday = true, Wednesday = true, Thursday = false, Friday = false, Saturday = false, Sunday = false });
            AddHours(new OpeningHours { IDCenter = ID, IDHours = 4, Monday = false, Tuesday = true, Wednesday = false, Thursday = true, Friday = false, Saturday = false, Sunday = false, Notes="Consulenza telefonica specifica ai centri di ascolto" });
            AddHours(new OpeningHours { IDCenter = ID, IDHours = 39, Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = true, Saturday = false, Sunday = false });

            ID = AddCenter(new Center { IDType = 2, Address = "Viale Famagosta, 2 - 20142 MILANO", Latitude = 45.436845, Longitude = 9.155069, Name = "Centro diurno la piazzetta", Notes = "Il centro è aperto a tutti, uomini e donne, italiani e stranieri purchè maggiorenni. Accesso diretto o su invito di servizi.", PhoneNumber = "", Reference = "Vincenzo Gravina",Services= "Attività educative e ricreative"});
            AddHours(new OpeningHours { IDCenter = ID, IDHours = 3, Monday = true, Tuesday = true, Wednesday = false, Thursday = true, Friday = false, Saturday = false, Sunday = false });
            AddHours(new OpeningHours { IDCenter = ID, IDHours = 4, Monday = false, Tuesday = false, Wednesday = true, Thursday = false, Friday = false, Saturday = false, Sunday = false });
            AddHours(new OpeningHours { IDCenter = ID, IDHours = 40, Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = true, Saturday = false, Sunday = false });
             
            ID = AddCenter(new Center { IDType =2 , Address = " Via Boeri, 3 - 20141 MILANO", Latitude = 45.44263, Longitude = 9.186072, Name = "Opera Cardinal Ferrari", Notes = "Accesso a persone anziane sopra i 55 anni con reddito minimo, o per persone con totale inabilità di età superiore ai 50 anni.Offre servizio sociale, ambulatorio, gardarobba, docce, parrucchiere, pedicure, mensa a pranzo.Occorre una tessera che viene rilasciata dopo il colloquio con l'Assistente Sociale. Chiuso nei giorni: 24 Dic. 1 Mag., Vigilia di Pasqua, 14 Ago.", PhoneNumber = "", Reference = "A.S.Loredana Rossetti", Services= "Attività animative, servizio sociale." });
            AddHours(new OpeningHours { IDCenter = ID, IDHours = 3, Monday = true, Tuesday = true, Wednesday = true, Thursday = true, Friday = true, Saturday = true, Sunday = true });

            ID = AddCenter(new Center { IDType = 2, Address = "ia Miramare angolo via Viserba -MILANO", Latitude = 45.521629, Longitude = 9.224877, Name = "Drop in Miramare", Notes = "Il servizio è gratuito e l'accesso è assolutamente libero senza richiesta di documenti. Viene richiesto un colloqui con gli operatori.", PhoneNumber = "", Reference = "",Services= "Accoglienza di persone con problematiche di dipendenza da sostanze stupefacenti e / o alcool, senza dimora." });
            AddHours(new OpeningHours { IDCenter = ID, IDHours = 4, Monday = true, Tuesday = false, Wednesday = false, Thursday = true, Friday = true, Saturday = false, Sunday = false });
            AddHours(new OpeningHours { IDCenter = ID, IDHours = 41, Monday = false, Tuesday = true, Wednesday = true, Thursday = false, Friday = false, Saturday = false, Sunday = false });

            ID = AddCenter(new Center { IDType = 2, Address = "Piazza XXV Aprile, 2 - MILANO", Latitude = 45.480141, Longitude = 9.187138, Name = " Drop in XXV Aprile", Notes = "Il servizio è gratuito e l'accesso è assolutamente libero senza richiesta di documenti. Viene richiesto un colloqui con gli operatori.", PhoneNumber = "", Reference = "",Services= "Accoglienza di persone con problematiche di dipendenza da sostanze stupefacenti e / o alcool, senza dimora." });
            AddHours(new OpeningHours { IDCenter = ID, IDHours = 5, Monday = true, Tuesday = false, Wednesday = false, Thursday = false, Friday = false, Saturday = false, Sunday = false });
            AddHours(new OpeningHours { IDCenter = ID, IDHours = 42, Monday = false, Tuesday = true, Wednesday = false, Thursday = false, Friday = false, Saturday = false, Sunday = false, Notes="Per donne" });
            AddHours(new OpeningHours { IDCenter = ID, IDHours = 41, Monday = false, Tuesday = false, Wednesday = true, Thursday = false, Friday = false, Saturday = false, Sunday = false });
            AddHours(new OpeningHours { IDCenter = ID, IDHours = 43, Monday = false, Tuesday = false, Wednesday = false, Thursday = true, Friday = false, Saturday = false, Sunday = false });
            AddHours(new OpeningHours { IDCenter = ID, IDHours = 26, Monday = false, Tuesday = false, Wednesday =false, Thursday = true, Friday = false, Saturday = false, Sunday = false });
            AddHours(new OpeningHours { IDCenter = ID, IDHours = 4, Monday = false, Tuesday = false, Wednesday =false, Thursday = false, Friday = true, Saturday = false, Sunday = false });
            AddHours(new OpeningHours { IDCenter = ID, IDHours = 4, Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false, Saturday = true, Sunday = true });

            ID = AddCenter(new Center { IDType = 3, Address = "Via Settala, 25 / 27 - MILANO", Latitude = 45.480108, Longitude = 9.205628, Name = "S.Gregorio Magno", Notes = "Il servizio è gratuito, per italiani e stranieri con documenti di identità. Chiuso in luglio e agosto. Verificare sempre disponibilità posti.", PhoneNumber = "", Reference = "Aldo Perathoner",Services= "Deposito bagagli per italiani e stranieri con documenti di identità."});
            AddHours(new OpeningHours { IDCenter = ID, IDHours = 6, Monday = false, Tuesday = true, Wednesday = false, Thursday = false, Friday = false, Saturday = false, Sunday = false });
            
            ID = AddCenter(new Center { IDType = 3, Address = "Via Maffucci(lato oratorio) - MILANO", Latitude = 45.498411, Longitude = 9.171833, Name = "SS.Giovanni e Paolo", Notes = "Il servizio è offerto sia agli stranieri che algi italiani. Non occorre lettera di presetnazione.Vengono accettati al massimo 2 colli a persone.Il servizio è gratuito. In estate è chiuso.", PhoneNumber = "", Reference = "Liliana Lastella",Services= "Deposito bagagli per italiani e stranieri con documenti di identità." });
            AddHours(new OpeningHours { IDCenter = ID, IDHours = 7, Monday = true, Tuesday = true, Wednesday = true, Thursday = true, Friday = true, Saturday = false, Sunday = false });

            ID = AddCenter(new Center { IDType = 4, Address = "Via Ponzio, 75 - MILANO", Latitude = 45.481444, Longitude = 9.229794, Name = "Centro Francescano Maria della Passione", Notes = "Uomini e donne con tessera da richiedere al segretariato sociale (Mar/Sab 9.30/13.00 - Dom 10.30/12.30) in via Fossati 2 con documento valido.", PhoneNumber = "", Reference = "Suor Rossella Vella",Services= "Pranzo per uomini, donne e bambini." });
            AddHours(new OpeningHours { IDCenter = ID, IDHours = 8, Monday = false, Tuesday = true, Wednesday = true, Thursday = true, Friday = true, Saturday = true, Sunday = false });
            AddHours(new OpeningHours { IDCenter = ID, IDHours = 44, Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false, Saturday = false, Sunday = true });

            ID = AddCenter(new Center { IDType = 4, Address = " Via Maroncelli, 19 - MILANO", Latitude = 45.483806, Longitude = 9.182681, Name = "Centro S. Antonio", Notes = "Per accedere alla mensa è indispensabile avere la tessera che ha valenza bimestrale e si ritira presso il Centro di Ascolto l'ultimo giorno lavorativo del mese per i due mesi successivi. Non è necessaria l afoto, meglio se in possesso di un documento originale.", PhoneNumber = "", Reference = "Fra Massimo Cocchetti", Services="Pranzo" });
            AddHours(new OpeningHours { IDCenter = ID, IDHours = 9, Monday = true, Tuesday = true, Wednesday = true, Thursday = true, Friday = true, Saturday = true, Sunday = false, Notes="Escluso i festivi" });

            ID = AddCenter(new Center { IDType = 4, Address = "Corso Concordia, 3 - MILANO", Latitude = 45.468012, Longitude = 9.208597, Name = "Opera S. Francesco per i Poveri", Notes = "L'accesso alla mensa avviene tramite tessera da ritirare presso il Servizio Accoglienza (Lun/Ven 10.30/15.00 - 17.30/19.30 - Sab 11.30/14.00) in Via Kramer, 1. E' necessario un documento d'identità valido.", PhoneNumber = "", Reference = "Padre Maurizio Annoni", Services= "Pranzo e cena." });
            AddHours(new OpeningHours { IDCenter = ID, IDHours = 10, Monday = true, Tuesday = true, Wednesday = true, Thursday = true, Friday = true, Saturday = true, Sunday = false});
            AddHours(new OpeningHours { IDCenter = ID, IDHours = 11, Monday = true, Tuesday = true, Wednesday = true, Thursday = true, Friday = true, Saturday = true, Sunday = false});


            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });

            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });

            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });

            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });

            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });

            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });

            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });

            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });

            List<Center> centers = Database.Table<Center>().ToList();
            #endregion

        }

        private int AddCenter(Center newCenter)
        {
           return Database.Insert(newCenter);
        }

        private void AddHours(OpeningHours newOpening)
        {
            Database.Insert(newOpening);
        }

    }
}
