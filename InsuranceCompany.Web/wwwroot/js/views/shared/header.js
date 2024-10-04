document.addEventListener('DOMContentLoaded', function () {
    const menuToggle = document.querySelector('.menu-toggle');
    const navMenu = document.querySelector('.nav-menu');

    // Функция для отображения меню
    function toggleMenu() {
        if (window.innerWidth <= 1263) {
            navMenu.classList.toggle('visible');
        }
    }

    menuToggle.addEventListener('click', function (event) {
        toggleMenu();
        event.stopPropagation();
    });

    // Закрыть меню при клике на область
    document.addEventListener('click', function () {
        if (navMenu.classList.contains('visible')) {
            navMenu.classList.remove('visible');
        }
    });

    navMenu.addEventListener('click', function (event) {
        event.stopPropagation();
    });

    // Обновление отображения меню при изменении размера окна
    window.addEventListener('resize', function () {
        if (window.innerWidth > 1263) {
            navMenu.classList.add('visible'); // Показать меню на десктопе
        } else {
            navMenu.classList.remove('visible'); // Скрыть меню на мобильных
        }
    });
});
