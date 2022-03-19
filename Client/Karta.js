import {Putnik} from './Putnik.js';

export class Karta
{
    constructor(prevoznik,destinacija,datum,brSedista,cena,)
    {
        this.prevoznik = prevoznik;
        this.destinacija = destinacija;
        this.datum = datum;
        this.brSedista = brSedista;
        this.cena = cena;

        this.ime = null;
        this.prezime = null;
        this.jmbg = null;

        this.registracija == null;
    }

        crtajTabeluKarata(host) 
        {
            var tr = document.createElement("tr");
            host.appendChild(tr);

            var td = document.createElement("td");
            td.innerHTML = this.ime;
            tr.appendChild(td);

            td = document.createElement("td");
            td.innerHTML = this.prezime;
            tr.appendChild(td);

            td = document.createElement("td");
            td.innerHTML = this.jmbg;
            tr.appendChild(td);

            td = document.createElement("td");
            td.innerHTML = this.prevoznik;
            tr.appendChild(td);


            td = document.createElement("td");
            td.innerHTML = this.destinacija;
            tr.appendChild(td);

            td = document.createElement("td");
            td.innerHTML = this.registracija;
            tr.appendChild(td);

            td = document.createElement("td");
            td.innerHTML = this.brSedista;
            tr.appendChild(td);

            td = document.createElement("td");
            td.innerHTML = this.datum;
            tr.appendChild(td);

            td = document.createElement("td");
            td.innerHTML = this.cena;
            tr.appendChild(td);

        }
}