$(document).ready(function () {

    //slider
    $(function () {
        $('.bxslider').bxSlider({
            mode: 'fade',
            captions: true,
            slideWidth: 1200,
            response: true

        });
    });

    //posts con JSON

    var posts = [

        {
            title: 'Test 1',
            date: "Publicado el dia " + moment().format("dddd") + " de " + moment().format("MMMM") + " del " + moment().format("YYYY"),
            content: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec at pharetra tortor. Phasellus tincidunt blandit volutpat. Proin nec tortor varius metus semper convallis eu eget ante.'

        },
        {
            title: 'Test 2',
            date: 'Publicado el dia ' + moment().format("dddd") + " de " + moment().format("MMMM") + " del " + moment().format("YYYY"),
            content: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec at pharetra tortor. Phasellus tincidunt blandit volutpat. Proin nec tortor varius metus semper convallis eu eget ante.'

        },
        {
            title: 'Test 3',
            date: 'Publicado el dia ' + moment().format("dddd") + " de " + moment().format("MMMM") + " del " + moment().format("YYYY"),
            content: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec at pharetra tortor. Phasellus tincidunt blandit volutpat. Proin nec tortor varius metus semper convallis eu eget ante.'

        },
        {
            title: 'Test 4',
            date: 'Publicado el dia ' + moment().format("dddd") + " de " + moment().format("MMMM") + " del " + moment().format("YYYY"),
            content: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec at pharetra tortor. Phasellus tincidunt blandit volutpat. Proin nec tortor varius metus semper convallis eu eget ante.'

        }



    ];

    posts.forEach((item, index) => {

        var post = `
        
        <article class="post">

        <h2>${item.title}</h2>
        <span class="date">${item.date}</span>

        <p>

            ${item.content}
            
        </p>

        <a href="#" class="button-more"> Leer mas! </a>

        </article>
        
        
        `;

        $("#posts").append(post);



    });

    var theme = $("#theme");

    $("#to-green").click(function () {

        theme.attr("href", "css/green.css");

    });

    $("#to-blue").click(function () {

        theme.attr("href", "css/blue.css");

    });

    $("#to-black").click(function () {

        theme.attr("href", "css/black.css");

    });





});


