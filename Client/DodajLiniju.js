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
                
                //alert(destinacija);
                let datum = document.querySelector("input[type = 'date']").value;
                alert(datum.toString());

                    fetch("https://localhost:5001/Autobus/DodajBus/",
                        {
                            method:"POST",
                            headers: { "Content-Type": "application/json" },
                            body: JSON.stringify({
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