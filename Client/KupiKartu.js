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
        this.crtajTrecuFormu(kontejner);
        this.crtajDruguFormu(kontejner);
        
        
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

        this.crtajDivZaTabelu(drugaForma);
        

        //this.crtajTabeluKarata(drugaForma);
    }
    crtajTrecuFormu(host)
    {
        var trecaForma = document.createElement("div");
        trecaForma.className = "trecaForma"; //naziv klase
        host.appendChild(trecaForma);

        var registracijaSlobodnaMesta = document.createElement("input");
        registracijaSlobodnaMesta.type = "text";
        registracijaSlobodnaMesta.placeholder = "REGISTRACIJA";
        registracijaSlobodnaMesta.className = "registracijaSlobodnaMesta";
        trecaForma.appendChild(registracijaSlobodnaMesta);

        var prikaziSlobodnaMestaDestinacija = document.createElement("input");
        prikaziSlobodnaMestaDestinacija.type = "text";
        prikaziSlobodnaMestaDestinacija.className = "prikaziSlobodnaMestaDestinacija";
        prikaziSlobodnaMestaDestinacija.placeholder = "DESTINACIJA";
        trecaForma.appendChild(prikaziSlobodnaMestaDestinacija);

        var prikaziSlobodnaMestaDatum = document.createElement("input");
        prikaziSlobodnaMestaDatum.className = "prikaziSlobodnaMestaDatum";
        prikaziSlobodnaMestaDatum.type = "date";
        trecaForma.appendChild(prikaziSlobodnaMestaDatum);
     
        var prikaziSlobodnaMesta = document.createElement("button");
        prikaziSlobodnaMesta.className = "prikaziSlobodnaMesta"; //naziv klase
        prikaziSlobodnaMesta.id = "prikaziSlobodnaMestaID"; // ----------- ID ------------
        prikaziSlobodnaMesta.innerHTML = "PRIKAZI SLOBODNA MESTA";
        trecaForma.appendChild(prikaziSlobodnaMesta);

        var autobusDiv = document.createElement("div");
        autobusDiv.className = "autobusDiv";
        trecaForma.appendChild(autobusDiv);

        prikaziSlobodnaMesta.onclick = (ev) => this.prikaziSlobodnaMestaUAutobusu();

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
                input.type = "text";
                input.className = "ProzorZaKucanje"; //naziv klase
                input.id = x; // ----------- ID ------------
                input.placeholder = x;
                formularZaKartu.appendChild(input);
            })

      
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
        dugmeZaKupovinuKarte.innerHTML = "KUPI KARTU";
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
        dugmeZaIzmenu.innerHTML = "IZMENI";
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
        jmbgZaBrisanje.id = "jmbgZaBrisanjeID"; // ----------- ID ------------
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
        dugmeZaPrikazAutobusa.innerHTML = "PRIKAZI AUTOBUSKE LINIJE";
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
        var kolone = ["registracija","prevozoznik","datum","destinacija"];
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
        
        
        let datum = document.querySelector("input[type = 'date']").value;

        // DODAJ VALIDACIJU ZA UNETE INFORMACIJE, da li su prazna polja, da li je jmbg == 13

        if(ime === "")
        {
            alert("Unesite ime");
        }
        else if(prezime === "")
        {
            alert("Unesite prezime");
        }
        else if(jmbg == null || jmbg.length != 13)
        {
            alert("Neispravan jmbg");
        }
        else if(brSedista < 1 || brSedista > 16)
        {
            alert("Neispravno polje za odabir sedista");
        }
        else if(registracija === "")
        {
            alert("Unesite registraciju");
        }
        else if(cena == null || cena > 2000 || cena < 100)
        {
            alert("Unesite ispravnu cenu ");
        }
        else if(datum == "")
        {
            alert("Popunite polje za datuym");
        }
        else
        {
            fetch("https://localhost:5001/AutobuskaStanica/kupiKartuFromBody/"+registracija+"/"+datum+"/"+cena+"/"+brSedista,
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
                                    alert("Greska. Proverite ponovo polja");
                            })
        }

    }
        
    izmeniBrojSedista()
        {
            var jmbg = document.querySelector(".jmbgZaPromenu").value;
            var noviBrSedista = document.querySelector(".brSedistaZaPromenu").value;

            if(jmbg == null || jmbg.length != 13)
            {
                alert("Neispravan jmbg");
            }
            else if(noviBrSedista < 1 || noviBrSedista > 16)
            {
                alert("Neispravno polje za odabir sedista");
            }
            else
            {
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

    }

    izbrisiKartu()
        {
            var jmbg = document.querySelector(".jmbgZaBrisanje").value;

            if(jmbg == null || jmbg.length != 13)
            {
                alert("Neispravan jmbg");
            }
            else
            {
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
                            alert("Doslo je do greske, ili ne postoji putnik sa tim jmbgom");
                        }
                    })
            }
            
    }
    prikaziAutobuseZaDatum()
        {
            var datum = document.querySelector(".datumZaAutobus").value;

            if (datum == "")
            {
                alert ("Popunite polje za datum");
            }
            else
            {
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
            
    }

    obrisiPrethodnuTabelu()
        {
            var body = document.querySelector(".tableBody");
            var parent = body.parentNode;
            parent.removeChild(body);

            body = document.createElement("tbody");
            body.className="tableBody";
            parent.appendChild(body);

        }

    crtajDivZaTabelu(host)
    {
        var divZaDugmice = document.createElement("div");
        divZaDugmice.className = "divZaDugmice";
        host.appendChild(divZaDugmice);

        var divZaTabelu = document.createElement("div");
        divZaTabelu.className = "divZaTabelu";
        host.appendChild(divZaTabelu);

        var selectDestinacija = document.createElement("select");
        selectDestinacija.className = "selectDestinacija2";
        divZaDugmice.appendChild(selectDestinacija);
    
        let op;
        let destinacije = ["Beograd","Novi Sad"];
        destinacije.forEach(x=>
        {
            op = document.createElement("option");
            op.innerHTML = x;
            selectDestinacija.appendChild(op);
        }
        )

        var prikaziKarteDugme = document.createElement("button");
        prikaziKarteDugme.className = "prikaziKarteDugme"; //naziv klase
        prikaziKarteDugme.id = "prikaziKarteDugmeID"; // ----------- ID ------------
        prikaziKarteDugme.innerHTML = "PRIKAZI KUPLJENE KARTE";
        divZaDugmice.appendChild(prikaziKarteDugme);
        prikaziKarteDugme.onclick = (ev) => this.prikaziKarteZaDestinaciju();

        var tabela = document.createElement("table");
        divZaTabelu.appendChild(tabela);

        var tableHead = document.createElement("thead");
        tabela.appendChild(tableHead);

        var tableRow = document.createElement("tr");
        tabela.appendChild(tableRow);

        var tableBody = document.createElement("tbody");
        tableBody.className = "tableBody2";
        tabela.appendChild(tableBody);

        let th;
        var kolone = ["ime","prezime","jmbg","prev.","dest.","reg.","br sedista","datum","cena"];
        kolone.forEach(x=>
            {
                th = document.createElement("th");
                th.innerHTML = x;
                tableRow.appendChild(th);
            })
    }
        prikaziKarteZaDestinaciju()
        {
            var destinacija = document.querySelector(".selectDestinacija2").value;

            fetch("https://localhost:5001/AutobuskaStanica/PreuzmiKarteZaDestinaciju"+"/"+destinacija,
            {
                method:"GET"
            }).then(p=>
                {
                    if(p.ok)
                    {
                        this.obrisiPrethodnuTabelu2();

                        p.json().then(data => {
                            var body = document.querySelector(".tableBody2");

                            data.forEach(x => 
                                {
                                    var ticket = new Karta(x.prevoznik,x.destinacija,x.datum,x.brojSedista,x.cena);
                                    ticket.ime = x.ime;
                                    ticket.prezime = x.prezime;
                                    ticket.jmbg = x.jmbg;
                                    ticket.registracija = x.registracija;
                                    //console.log(ticket);
                                    ticket.crtajTabeluKarata(body);
                                })
                        })
                    }
                    else
                    {
                        alert("NIje uspesno");
                    }
                })
        }

        obrisiPrethodnuTabelu2()
        {
            var body = document.querySelector(".tableBody2");
            var parent = body.parentNode;
            parent.removeChild(body);

            body = document.createElement("tbody");
            body.className="tableBody2";
            parent.appendChild(body);

            //return body; 
        }

        prikaziSlobodnaMestaUAutobusu(host)
        {
            var registracija = document.querySelector(".registracijaSlobodnaMesta").value;
            var destinacija = document.querySelector(".prikaziSlobodnaMestaDestinacija").value;
            var datum = document.querySelector(".prikaziSlobodnaMestaDatum").value;

            if(registracija == "")
            {
                alert("Unesite registraciju autobusa");
            }
            else if(destinacija == "")
            {
                alert("Unesite destinaciju");
            }
            else if(datum == "")
            {
                alert("Popunite polje za datum");
            }
            else
            {
                    fetch("https://localhost:5001/AutobuskaStanica/VratiSedista"+"/"+registracija+"/"+destinacija+"/"+datum,
                    {
                        method:"GET"
                    }).then(p=>
                        {
                            if(p.ok)
                                {
                                    var bus = new Autobus();
                                    
                                    p.json().then(data => 
                                        {
                                            data.forEach(x=>{
                                                bus.listaSedista.push(x);
                                            })
                                            
                                            this.obrisiAutobus();
                                            var busDiv = document.querySelector(".autobusDiv");
                                            
                                            bus.crtajBus(busDiv);
                                            //alert(bus.listaSedista);
                                        })
                                }
                            else
                                {
                                    alert("Ne postoji autobus sa unetim podacima,pokusajte ponovo");
                                }
                        })
            }
        }
        obrisiAutobus()
        {
            var busDiv = document.querySelector(".autobusDiv");
            var parent = busDiv.parentNode;
            parent.removeChild(busDiv);

            busDiv = document.createElement("div");
            busDiv.className = "autobusDiv";
            parent.appendChild(busDiv);
        }
    }
