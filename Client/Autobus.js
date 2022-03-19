export class Autobus
{
    constructor(registracija,nazivPrevoznika,destinacija,datum)
    {
        this.registracija = registracija
        this.nazivPrevoznika = nazivPrevoznika;
        this.destinacija = destinacija;
        this.datum = datum;

        this.listaSedista = new Array();

        //this.listaAutobusa = [];
    }

    crtajTabeluAutobusa(host)
    {
        var tr = document.createElement("tr")
        host.appendChild(tr);

        var el = document.createElement("td")
        el.innerHTML = this.registracija;
        tr.appendChild(el);

        el = document.createElement("td")
        el.innerHTML = this.nazivPrevoznika;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML = this.destinacija;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML = this.datum;
        tr.appendChild(el);
    }
    crtajBus(host)
    {
        var prviRed = document.createElement("div");
        prviRed.className = "busRed";
        host.appendChild(prviRed);

        var drugiRed = document.createElement("div");
        drugiRed.className = "busRed"
        host.appendChild(drugiRed);

        var kockica;

        for(let i = 1; i <= 16; i++)
        {
            kockica= document.createElement("div");
            kockica.className = "kockica";
            kockica.id = i;
            kockica.innerHTML = i;
            if(i % 2 == 0)
            {
                prviRed.appendChild(kockica);
            }
            else
            {
                drugiRed.appendChild(kockica);
            }
            if(this.listaSedista.includes(i))
            {
                this.zauzeto(kockica);
            }
            else
            {
                this.slobodno(kockica);
            }
            //alert(this.listaSedista);
            
        }
    }
    
    zauzeto(kockica)
    {
        kockica.style.backgroundColor = 'red';
    }
    slobodno(kockica)
    {
        kockica.style.backgroundColor = 'green';
    }
}