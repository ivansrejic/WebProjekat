import {Autobus} from './Autobus.js';
import {Putnik} from './Putnik.js';
import { Karta } from './Karta.js';

export class FrontPage
{
    constructor()
    {
        this.kont = null;
    }
    crtaj(host)
        {

            this.kont=document.createElement("div");
            this.kont.className="GlavniKontejner"; //naziv klase
            this.kont.classList.add("kont");
            host.appendChild(this.kont);

            var naslov = document.createElement("h1");
            naslov.innerHTML = "AUTOBUSKA STANICA NIS";
            this.kont.appendChild(naslov);

            var formaDugme = document.createElement("div");
            formaDugme.className = "Dugme"; //naziv klase
            this.kont.appendChild(formaDugme);

            var btn = document.createElement("button");
            btn.className = "btn"; //naziv klase
            btn.innerHTML = "Dodaj liniju";
            formaDugme.appendChild(btn);
            btn.onclick = (ev)=>{
                location.href = "http://127.0.0.1:5500/Client/BusPage.html";
            };

            btn = document.createElement("button");
            btn.className = "btn"; //naziv klase
            btn.innerHTML = "Kupovina karata";
            formaDugme.appendChild(btn);
            btn.onclick = (ev)=>{
                location.href = "http://127.0.0.1:5500/Client/KartaPage.html";
            };

        }
}  
// var a = new FrontPage();
// a.crtaj(document.body); 

