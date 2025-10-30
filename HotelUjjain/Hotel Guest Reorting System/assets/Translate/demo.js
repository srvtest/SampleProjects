let translations = {};

const fetchContent = () => {

    return fetch(`lang/hi.json`)

        .then((response) => {

            return response.json();

        })

        .then((data) => {

            translations = data;

            translatePage();

        });

};

fetchContent();

const translatePage = () => {

    document.querySelectorAll('[localization-key]').forEach((element) => {

        let key = element.getAttribute('localization-key');

        let translation = translations[key];

        element.innerText = translation;

    });

};