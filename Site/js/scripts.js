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
    var coin1 = document.getElementById('coin1');
    var coin2 = document.getElementById('coin2');
    var coin1 = coin1.options[coin1.selectedIndex];
    var coin2 = coin2.options[coin2.selectedIndex];
    //alert(opt.text);
    const url = "https://localhost:44327/api/Convert/90-70";
    
    //var url = document.getElementById('url').value;

    var xhttp = new XMLHttpRequest();
    xhttp.open("GET", url, true);

    xhttp.setRequestHeader

    xhttp.onreadystatechange = function(){//Função a ser chamada quando a requisição retornar do servidor
        if ( xhttp.readyState == 4 && xhttp.status == 200 ) {//Verifica se o retorno do servidor deu certo
            console.log(xhttp.responseText);
            document.getElementById('valorFinal').innerHTML = xhttp.responseText;
        }
    }

    xhttp.send();

    alert("Fim");
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