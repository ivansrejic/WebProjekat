import {Autobus} from './Autobus.js';
import {Putnik} from './Putnik.js';
import { Karta } from './Karta.js';

export class KupiKartu
{
    constructor()
    {
        this.kont = null;
    }
    crtaj(host)
    {
        var kontejner = document.createElement("div");
        kontejner.className = "GlavniKontejnerKupiKartuPage"; //naziv klase
        host.appendChild(kontejner);

        
        this.crtajPrvuFormu(kontejner);
        this.crtajDruguFormu(kontejner);
        this.crtajTrecuFormu(kontejner);
        
    }
    crtajPrvuFormu(host)
    {
        var prvaForma = document.createElement("div");
        prvaForma.className = "prvaForma"; //naziv klase
        host.appendChild(prvaForma);

        this.crtajFormularZaKartu(prvaForma);
        this.crtajFormularZaIzmenu(prvaForma);
        this.crtajFormularZaBrisanje(prvaForma);
    }
    crtajDruguFormu(host)
    {
        var drugaForma = document.createElement("div");
        drugaForma.className = "drugaForma"; //naziv klase
        host.appendChild(drugaForma);

        var prikaziKarteZaBg = document.createElement("button");
        prikaziKarteZaBg.className = "prikaziKarteZaBg"; //naziv klase
        prikaziKarteZaBg.id = "prikaziKarteZaBgID"; // ----------- ID ------------
        prikaziKarteZaBg.innerHTML = "PRIKAZI KARTE ZA BGGG";
        drugaForma.appendChild(prikaziKarteZaBg);
    }
    crtajTrecuFormu(host)
    {
        var trecaForma = document.createElement("div");
        trecaForma.className = "trecaForma"; //naziv klase
        host.appendChild(trecaForma);

        var prikaziKarteZaNS = document.createElement("button");
        prikaziKarteZaNS.className = "prikaziKarteZaNS"; //naziv klase
        prikaziKarteZaNS.id = "prikaziKarteZaNSID"; // ----------- ID ------------
        prikaziKarteZaNS.innerHTML = "PRIKAZI KARTE ZA NOVI SAD";
        trecaForma.appendChild(prikaziKarteZaNS);
    }

    crtajFormularZaKartu(host)
    {
        var formularZaKartu = document.createElement("div");
        formularZaKartu.className = "FormularZaKartu"; //naziv klase
        host.appendChild(formularZaKartu);

        var inputs = ["ime","prezime","jmbg"];
        inputs.forEach(x=>
            {
                var input = document.createElement("input");
                input.className = "ProzorZaKucanje"; //naziv klase
                input.id = x; // ----------- ID ------------
                input.placeholder = x;
                formularZaKartu.appendChild(input);
            })

        var prevoznikOptions = ["Litas","NisExpess","Lasta"];
        var destinacijaOptions = ["Beograd","Novi Sad"];

        var prevoznikSelect = document.createElement("select");
        prevoznikSelect.className = "prevoznikSelect"; //naziv klase
        prevoznikSelect.id = "prevoznikSelectID"; // ----------- ID ------------
        formularZaKartu.appendChild(prevoznikSelect);

        var destinacijaSelect = document.createElement("select");
        destinacijaSelect.className = "destinacijaSelect"; //naziv klase
        destinacijaSelect.id = "destinacijaSelectID"; // ----------- ID ------------
        formularZaKartu.appendChild(destinacijaSelect);

        let op;
        
        prevoznikOptions.forEach(x=>
            {
                op = document.createElement("option");
                op.innerHTML = x;
                prevoznikSelect.appendChild(op);
            })
        destinacijaOptions.forEach(x=>
            {
                op = document.createElement("option");
                op.innerHTML = x;
                destinacijaSelect.appendChild(op);
            })
        var brSedistaInput = document.createElement("input");
        brSedistaInput.type = "number";
        brSedistaInput.className = "brSedistaInput"; //naziv klase
        brSedistaInput.id = "brSedistaInputID"; // ----------- ID ------------
        formularZaKartu.appendChild(brSedistaInput);

        var datum = document.createElement("input");
        datum.type = "date";
        datum.className = "datumInput"; //naziv klase
        datum.id = "datumInputID"; // ----------- ID ------------
        formularZaKartu.appendChild(datum);

        var dugmeZaKupovinuKarte = document.createElement("button");
        dugmeZaKupovinuKarte.className = "dugmeZaKupovinuKarte"; //naziv klase
        dugmeZaKupovinuKarte.id = "dugmeZaKupovinuKarteID"; // ----------- ID ------------
        dugmeZaKupovinuKarte.innerHTML = "KUPI KARTU BATOOO";
        formularZaKartu.appendChild(dugmeZaKupovinuKarte);

    }
    
    crtajFormularZaIzmenu(host)
    {
        var formularZaIzmenu = document.createElement("div");
        formularZaIzmenu.className = "FormularZaIzmenu"; //naziv klase
        host.appendChild(formularZaIzmenu);

        var jmbg = document.createElement("input");
        jmbg.type = "text";
        jmbg.placeholder = "JMBG";
        jmbg.className = "jmbgZaPromenu"; //naziv klase
        jmbg.id ="jmbgZaPromenuID"; // ----------- ID ------------
        formularZaIzmenu.appendChild(jmbg);

        var brSedistaInput = document.createElement("input");
        brSedistaInput.type = "number";
        brSedistaInput.placeholder = "novi broj sedista";
        brSedistaInput.className = "brSedistaInput"; //naziv klase
        brSedistaInput.id = "brSedistaInputID"; // ----------- ID ------------
        formularZaIzmenu.appendChild(brSedistaInput);

        var dugmeZaIzmenu = document.createElement("button");
        dugmeZaIzmenu.className = "dugmeZaIzmenu"; //naziv klase
        dugmeZaIzmenu.id = "dugmeZaIzmenuID"; // ----------- ID ------------
        dugmeZaIzmenu.innerHTML = "Izmeni";
        formularZaIzmenu.appendChild(dugmeZaIzmenu);
    }

    crtajFormularZaBrisanje(host)
    {
        var formularZaBrisanje = document.createElement("div");
        formularZaBrisanje.className = "FormularZaBrisanje"; //naziv klase
        host.appendChild(formularZaBrisanje);

        var jmbgZaBrisanje = document.createElement("input");
        jmbgZaBrisanje.type = "text";
        jmbgZaBrisanje.className = "jmbgZaBrisanje"; //naziv klase
        jmbgZaBrisanje.id = "dugmeZaBrisanjeID"; // ----------- ID ------------
        jmbgZaBrisanje.placeholder = "JMBG";
        formularZaBrisanje.appendChild(jmbgZaBrisanje);

        var dugmeZaBrisanje = document.createElement("button");
        dugmeZaBrisanje.className = "dugmeZaBrisanje"; //naziv klase
        dugmeZaBrisanje.id = "dugmeZaBrisanjeID"; // ----------- ID ------------
        dugmeZaBrisanje.innerHTML = "IZBRISI";
        formularZaBrisanje.appendChild(dugmeZaBrisanje);
    }
}


//on button posle this.CrtajTabelnuNaPrimer() koja ce da se definise posle dole