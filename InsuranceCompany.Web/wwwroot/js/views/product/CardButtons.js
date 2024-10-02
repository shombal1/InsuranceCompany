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
    document.querySelectorAll('.button-copy').forEach(button => {
        button.addEventListener('click', () => {
            const card = button.closest('.card');
            const id = card.getAttribute('data-id');
    
            // Выполняем POST-запрос на /product/create/{id}
            fetch(`/product/create/${id}`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                }
            })
            .then(response => response.json())
            .then(data => {
                if (data.redirect) {
                    // Перенаправляем на /product/edit/{new_id} после успешного запроса
                    window.location.href = `/product/edit/${data.redirect}`;
                }
            })
            .catch(error => {
                console.error('Error:', error);
            });
        });
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
