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
    document.querySelectorAll('.button-copy').forEach( async button => {
        button.addEventListener('click', async event => {
            const id = event.target.getAttribute('data-id');
            const response = await fetch(`/product/copy/${id}`, {
                method: 'POST'
            });
            console.log(response)
    
            if (response.ok) {
                const newId = await response.text();
                window.location.href = `/product/edit/${newId}`;
            };
        });
    });    
});
