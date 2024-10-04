document.addEventListener('DOMContentLoaded', () => {
    // Кнопка "Создать"
    const createButton = document.querySelector('.main__commencement--button');
    createButton.addEventListener('click', () => {
        window.location.href = '/product/create';
    });

    // Обработчик для кнопок "Перейти"
    document.querySelectorAll('.button-redirection').forEach(button => {
        button.addEventListener('click', event => {
            const id = event.target.getAttribute('data-id');
            window.location.href = `/product/edit/${id}`;
        });
    });

    // Обработчик для кнопок "Создать новое копированием"
    const form = document.querySelector('.form--create-product');
    const createProductButton = document.querySelector('.button--submit');

    createProductButton.addEventListener('click', async (event) => {
        event.preventDefault(); // предотвращаем отправку формы по умолчанию

        // Получаем данные из формы
        const formData = new FormData(form);

        // Конвертируем FormData в объект
        const data = {};
        formData.forEach((value, key) => {
            data[key] = value;
        });

        try {
            // Выполняем POST запрос
            const response = await fetch('/api/products', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(data),
            });

            if (response.ok) {
                // Обработка успешного ответа
                const result = await response.json();
                console.log('Созданный продукт:', result);
                // Вы можете добавить редирект или показать сообщение об успешном создании
            } else {
                // Обработка ошибок
                const error = await response.json();
                console.error('Ошибка:', error);
                alert('Ошибка при создании продукта: ' + error.message);
            }
        } catch (error) {
            console.error('Ошибка сети:', error);
            alert('Ошибка сети. Пожалуйста, попробуйте позже.');
        }
    });
    


    //Проверка запроса
    // document.querySelectorAll('.button-copy').forEach(button => {
    //     button.addEventListener('click', () => {
    //         const card = button.closest('.card');
    //         const id = card.getAttribute('data-id');
    
    //         // Имитируем POST-запрос с использованием setTimeout
    //         setTimeout(() => {
    //             const fakeResponse = { redirect: 5 };  // Пример ответа сервера
    
    //             if (fakeResponse.redirect) {
    //                 window.location.href = `/product/edit/${fakeResponse.redirect}`;
    //             }
    //         }, 1000); // задержка для имитации запроса
    //     });
    // });    
});
