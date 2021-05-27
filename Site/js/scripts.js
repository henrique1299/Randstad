/*!
* Start Bootstrap - Grayscale v7.0.0 (https://startbootstrap.com/theme/grayscale)
* Copyright 2013-2021 Start Bootstrap
* Licensed under MIT (https://github.com/StartBootstrap/startbootstrap-grayscale/blob/master/LICENSE)
*/
//
// Scripts
// 
function Converter()
{
    var btn = document.getElementById("btnConverter");
    btn.disabled = true;
    btn.innerText = "Carregando";

    var coin1 = document.getElementById('coin1');
    var coin2 = document.getElementById('coin2');

    coin1 = coin1.options[coin1.selectedIndex].text;
    coin2 = coin2.options[coin2.selectedIndex].text;

    var idCoin1 = getCoinId(coin1);
    var idCcoin2 = getCoinId(coin2);

    var valor = document.getElementById("valorInicial").value;
    if (valor.length < 1) {
        alert("Valor Inválido");
        btn.disabled = false;
        btn.innerText = "Converter";
        return null;
    }

    const url = "https://localhost:44327/api/Convert/" + idCoin1 + "-" + idCcoin2 + "-" + valor;

    var xhttp = new XMLHttpRequest();
    xhttp.open("GET", url, true);

    xhttp.setRequestHeader;

    xhttp.onreadystatechange = function(){
        if ( xhttp.readyState == 4 && xhttp.status == 200 ) {
            console.log(xhttp.responseText);
            document.getElementById('valorFinal').value = xhttp.responseText;
            btn.disabled = false;
            btn.innerText = "Converter";
        }
    }

    xhttp.send();
}

function getCoinId(coin) {
    if (coin == "Bitcoin")
    {
        return "90";
    }
    if (coin == "Ethereum") {
        return "80";
    }
    if (coin == "Monero") {
        return "28";
    }
    if (coin == "Zcash") {
        return "134";
    }
    if (coin == "Ethereum Classic") {
        return "118";
    }
    if (coin == "Bitcoin Cash") {
        return "33234";
    }

}

async function fetchAsync (url) {
    let response = await fetch(url);
    let data = await response.json();
    return data;
  }

window.addEventListener('DOMContentLoaded', event => {

    // Navbar shrink function
    var navbarShrink = function () {
        const navbarCollapsible = document.body.querySelector('#mainNav');
        if (!navbarCollapsible) {
            return;
        }
        if (window.scrollY === 0) {
            navbarCollapsible.classList.remove('navbar-shrink')
        } else {
            navbarCollapsible.classList.add('navbar-shrink')
        }

    };

    // Shrink the navbar 
    navbarShrink();

    // Shrink the navbar when page is scrolled
    document.addEventListener('scroll', navbarShrink);

    // Activate Bootstrap scrollspy on the main nav element
    const mainNav = document.body.querySelector('#mainNav');
    if (mainNav) {
        new bootstrap.ScrollSpy(document.body, {
            target: '#mainNav',
            offset: 74,
        });
    };

    // Collapse responsive navbar when toggler is visible
    const navbarToggler = document.body.querySelector('.navbar-toggler');
    const responsiveNavItems = [].slice.call(
        document.querySelectorAll('#navbarResponsive .nav-link')
    );
    responsiveNavItems.map(function (responsiveNavItem) {
        responsiveNavItem.addEventListener('click', () => {
            if (window.getComputedStyle(navbarToggler).display !== 'none') {
                navbarToggler.click();
            }
        });
    });

});