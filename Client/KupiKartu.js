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
        this.crtajFormularZaAutobus(prvaForma);
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

        // var prevoznikOptions = ["Litas","NisExpess","Lasta"];
        // var destinacijaOptions = ["Beograd","Novi Sad"];

        // var prevoznikSelect = document.createElement("select");
        // prevoznikSelect.className = "prevoznikSelect"; //naziv klase
        // prevoznikSelect.id = "prevoznikSelectID"; // ----------- ID ------------
        // formularZaKartu.appendChild(prevoznikSelect);

        // var destinacijaSelect = document.createElement("select");
        // destinacijaSelect.className = "destinacijaSelect"; //naziv klase
        // destinacijaSelect.id = "destinacijaSelectID"; // ----------- ID ------------
        // formularZaKartu.appendChild(destinacijaSelect);

        // let op;
        
        // prevoznikOptions.forEach(x=>
        //     {
        //         op = document.createElement("option");
        //         op.innerHTML = x;
        //         prevoznikSelect.appendChild(op);
        //     })
        // destinacijaOptions.forEach(x=>
        //     {
        //         op = document.createElement("option");
        //         op.innerHTML = x;
        //         destinacijaSelect.appendChild(op);
        //     })
        var brSedistaInput = document.createElement("input");
        brSedistaInput.type = "number";
        brSedistaInput.className = "brSedistaInput"; //naziv klase
        brSedistaInput.id = "brSedistaInputID"; // ----------- ID ------------
        brSedistaInput.placeholder = "broj sedista";
        formularZaKartu.appendChild(brSedistaInput);

        var registracija = document.createElement("input");
        registracija.type = "text";
        registracija.className = "registracijaInput";
        registracija.placeholder = "registracija";
        formularZaKartu.appendChild(registracija);

        var cena = document.createElement("input");
        cena.placeholder = "cena";
        cena.className = "cenaInput";
        cena.type = "number";
        formularZaKartu.appendChild(cena);

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
        dugmeZaKupovinuKarte.onclick = (ev) => this.kupiKartu();

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
        brSedistaInput.className = "brSedistaZaPromenu"; //naziv klase
        brSedistaInput.id = "brSedistaZaPromenuID"; // ----------- ID ------------
        formularZaIzmenu.appendChild(brSedistaInput);

        var dugmeZaIzmenu = document.createElement("button");
        dugmeZaIzmenu.className = "dugmeZaIzmenu"; //naziv klase
        dugmeZaIzmenu.id = "dugmeZaIzmenuID"; // ----------- ID ------------
        dugmeZaIzmenu.innerHTML = "Izmeni";
        formularZaIzmenu.appendChild(dugmeZaIzmenu);
        dugmeZaIzmenu.onclick = (ev)=>this.izmeniBrojSedista();
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
        dugmeZaBrisanje.onclick = (ev) => this.izbrisiKartu();
    }

    crtajFormularZaAutobus(host)
    {
        var formularZaAutobus = document.createElement("div");
        formularZaAutobus.className = "FormularZaAutobus";
        host.appendChild(formularZaAutobus);

        var datum = document.createElement("input");
        datum.className = "datumZaAutobus";
        datum.type = "date";
        formularZaAutobus.appendChild(datum);

        var dugmeZaPrikazAutobusa = document.createElement("button");
        dugmeZaPrikazAutobusa.className = "dugmeZaProveruAutobusa";
        dugmeZaPrikazAutobusa.innerHTML = "Proveri autobuse za taj i taj datum";
        formularZaAutobus.appendChild(dugmeZaPrikazAutobusa);
        dugmeZaPrikazAutobusa.onclick = (ev) => this.prikaziAutobuseZaDatum(tableBody);

        var tabela = document.createElement("table");
        formularZaAutobus.appendChild(tabela);

        var tableHead = document.createElement("thead");
        tabela.appendChild(tableHead);
        
        var tableRow = document.createElement("tr");
        tabela.appendChild(tableRow);

        var tableBody = document.createElement("tbody");
        tableBody.className = "tableBody";
        tabela.appendChild(tableBody);

        let th;
        var kolone = ["REGISTRACIJA","PREVOZNIK","DATUM","DESTINACIJA"];
        kolone.forEach(x=>
            {
                th = document.createElement("th");
                th.innerHTML = x;
                tableRow.appendChild(th);
            })

    }

    kupiKartu()
    {
        let ime = document.getElementById("ime").value;
        let prezime = document.getElementById("prezime").value;
        let jmbg = document.getElementById("jmbg").value;
        let registracija = document.querySelector(".registracijaInput").value; 
        let brSedista = document.querySelector(".brSedistaInput").value;
        let cena = document.querySelector(".cenaInput").value;
        //var datum = document.querySelector("input[type = 'date']").value;

        // DODAJ VALIDACIJU ZA UNETE INFORMACIJE, da li su prazna polja, da li je jmbg == 13


        fetch("https://localhost:5001/AutobuskaStanica/kupiKartuFromBody/"+registracija+"/"+cena+"/"+brSedista,
                        {
                            method:"POST",
                            headers: { "Content-Type": "application/json" },
                            body: JSON.stringify({
                                "ime":ime,
                                "prezime": prezime,
                                "jmbg": jmbg,
                            })
                        }).then(p=>
                            {
                                if(p.ok)
                                {
                                    alert("Uspeno");
                                }
                                else
                                    alert("Greska.");
                            })
        }
        
        izmeniBrojSedista()
        {
            var jmbg = document.querySelector(".jmbgZaPromenu").value;
            var noviBrSedista = document.querySelector(".brSedistaZaPromenu").value;

            fetch("https://localhost:5001/AutobuskaStanica/IzmeniBrojSedista/"+jmbg+"/"+noviBrSedista,
                        {
                            method:"PUT"

                        }).then(p=>
                            {
                                if(p.ok)
                                {
                                    alert("Uspesno promenjeno sediste");
                                }
                                else
                                    alert("Greska.");
                            })
        }

        izbrisiKartu()
        {
            var jmbg = document.querySelector(".jmbgZaBrisanje").value;

            fetch("https://localhost:5001/AutobuskaStanica/IzbrisiKupljenuKartu/"+jmbg,
                {
                    method:"DELETE"
                }).then(p=>
                    {
                        if(p.ok)
                        {
                            alert("USPESNO IZBRISANA KARTA");
                        }
                        else
                        {
                            alert("greskica");
                        }
                    })
            
        }
        prikaziAutobuseZaDatum(host)
        {
            var datum = document.querySelector(".datumZaAutobus").value;
            
            fetch("https://localhost:5001/Autobus/PreuzmiAutobuse/"+datum,
            {
                method:"GET"
            }).then(p=>
                {
                    if(p.ok)
                    {
                        this.obrisiPrethodnuTabelu();

                        p.json().then(data => {
                            var body = document.querySelector(".tableBody");

                            data.forEach(bus => 
                                {
                                    
                                    const busko = new Autobus(bus.registracija,bus.nazivPrevoznika,bus.datumm,bus.destinacija);
                                    //console.log(busko);
                                    busko.crtajTabeluAutobusa(body); // definise se funkcija u Autobus.js 
                                })
                        })
                    }
                    else
                    {
                        alert("NIje uspesno");
                    }
                })
        }

        obrisiPrethodnuTabelu()
        {
            var body = document.querySelector(".tableBody");
            var parent = body.parentNode;
            parent.removeChild(body);

            body = document.createElement("tbody");
            body.className="tableBody";
            parent.appendChild(body);

            //return body; 
        }
    }
