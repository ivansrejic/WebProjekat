export class Autobus
{
    constructor(registracija,nazivPrevoznika,destinacija,datum)
    {
        this.registracija = registracija
        this.nazivPrevoznika = nazivPrevoznika;
        this.destinacija = destinacija;
        this.datum = datum;

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
}