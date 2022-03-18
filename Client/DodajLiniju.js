import {Autobus} from './Autobus.js';
import {Putnik} from './Putnik.js';
import { Karta } from './Karta.js';

export class DodajLiniju
{
    constructor()
    {
        this.kont = null;
    }
    crtaj(host)
        {

            this.kont = document.createElement("div");
            this.kont.className = "BusKontejner"; //naziv klase
            host.appendChild(this.kont);

            var naslov = document.createElement("h1");
            naslov.innerHTML = "Kreirajte novu autobusku liniju";
            this.kont.appendChild(naslov);

            var prevoznici = ["Litas","Lasta","NisExpress"];
            var destinacije = ["Beograd","Novi Sad"];

            
            
            
            var formaBus = document.createElement("div");
            formaBus.className = "formaBus"; //naziv klase
            this.kont.appendChild(formaBus);

            var labelPrevoznik = document.createElement("label");
            labelPrevoznik.innerHTML = "Prevoznik";
            labelPrevoznik.className = "labelPrevoznik";
            formaBus.appendChild(labelPrevoznik);

            var selectPrevoznik = document.createElement("select");
            selectPrevoznik.className = "busDugme"; //naziv klase
            selectPrevoznik.id = "prevoznikSelect"; // ----------- ID ------------
            formaBus.appendChild(selectPrevoznik);
            let op;
            prevoznici.forEach(x=>
                {
                    op = document.createElement("option");
                    op.innerHTML = x;
                    selectPrevoznik.appendChild(op);
                })
           
            var labelDestinacija = document.createElement("label");
            labelDestinacija.innerHTML = "Destinacija";
            labelDestinacija.className = "labelDestinacija";
            formaBus.appendChild(labelDestinacija);
            
            var selectDestinacija = document.createElement("select");
            selectDestinacija.className = "busDugme"; //naziv klase
            selectDestinacija.id = "destinacijaSelect"; // ----------- ID ------------
            formaBus.appendChild(selectDestinacija);
            destinacije.forEach(x=>
            {
                op = document.createElement("option");
                op.innerHTML = x;
                selectDestinacija.appendChild(op);
            })
        
            var registracija = document.createElement("input");
            registracija.className = "registracijaInput"; //naziv klase
            registracija.type = "text";
            registracija.placeholder = "REGISTRACIJA";
            formaBus.appendChild(registracija);

            var labelDatum = document.createElement("label");
            labelDatum.innerHTML = "Datum";
            labelDatum.className = "labelDatum";
            formaBus.appendChild(labelDatum);

            var datum = document.createElement("input");
            datum.className = "busDugme"; //naziv klase
            datum.type = "date";
            formaBus.appendChild(datum);

            var btn = document.createElement("button");
            btn.innerHTML = "Dodaj liniju";
            formaBus.appendChild(btn);

            btn.onclick =(ev)=> this.dodajLiniju();
        }
        dodajLiniju()
        {
                
                let prevoznik = document.getElementById("prevoznikSelect").value;
                //alert(prevoznik);

                let destinacija = document.getElementById("destinacijaSelect").value;
                
                //alert(destinacija); //dodaj validaciju da li su uneti svi podaci
                let datum = document.querySelector("input[type = 'date']").value;

                let registracija = document.querySelector(".registracijaInput").value;

                if(registracija === null || registracija ===undefined || registracija==="")
                {
                    alert("Unesite ispravnu registraciju");
                }
                else if(datum === "")
                {
                    alert("Uneesite datum");
                }
                else
                {
                    fetch("https://localhost:5001/Autobus/DodajBus/",
                        {
                            method:"POST",
                            headers: { "Content-Type": "application/json" },
                            body: JSON.stringify({
                                "registracija":registracija,
                                "nazivPrevoznika": prevoznik,
                                "datumm": datum,
                                "destinacija": destinacija,
                            })
                        }).then(p=>
                            {
                                if(p.ok)
                                {
                                    alert("Uspeno dodata linija");
                                }
                                else
                                    alert("Greska.");
                            })
                        }
                }
              
}  