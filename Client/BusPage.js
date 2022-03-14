import {Autobus} from './Autobus.js';
import {Putnik} from './Putnik.js';
import { Karta } from './Karta.js';

export class BusPage
{
    constructor()
    {
        this.kont = null;
    }
    crtaj(host)
        {

            this.kont = document.createElement("div");
            this.kont.className = "BusKontejner";
            host.appendChild(this.kont);

            var naslov = document.createElement("h1");
            naslov.innerHTML = "Kreirajte novu autobusku liniju";
            this.kont.appendChild(naslov);

            var prevoznici = ["Litas","Lasta","NisExpress"];
            var destinacije = ["Beograd","Novi Sad"];
            
            var formaBus = document.createElement("div");
            formaBus.className = "formaBus";
            this.kont.appendChild(formaBus);

            var selectPrevoznik = document.createElement("select");
            selectPrevoznik.className = "busDugme";
            selectPrevoznik.id = "prevoznikSelect";
            formaBus.appendChild(selectPrevoznik);
            let op;
            prevoznici.forEach(x=>
                {
                    op = document.createElement("option");
                    op.innerHTML = x;
                    selectPrevoznik.appendChild(op);
                })
           
                var selectDestinacija = document.createElement("select");
                selectDestinacija.className = "busDugme";
                selectDestinacija.id = "destinacijaSelect";
                formaBus.appendChild(selectDestinacija);
            destinacije.forEach(x=>
                {
                    op = document.createElement("option");
                    op.innerHTML = x;
                    selectDestinacija.appendChild(op);
                })
            
                var datum = document.createElement("input");
                datum.className = "busDugme";
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
                alert(datum);
            
                fetch("https://localhost:5001/Autobus/DodajBus/"+prevoznik+"/"+destinacija+"/"+datum,
                    {
                         method:"POST"

                         }).then(s => {
                            if(s.ok){
                                s.json().then(data => {
                                    
                            })
                        }
                                
                    })
        }
}  