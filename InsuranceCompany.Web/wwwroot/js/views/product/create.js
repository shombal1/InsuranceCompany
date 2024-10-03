document.addEventListener('DOMContentLoaded', () => {
    // Отмена
    document.querySelector('.button--cancel').addEventListener('click', () => {
        window.location.href = `/product/`
    });

    // Создать
    const form = document.querySelector(".form--create-product");
    
    form.addEventListener("submit", function (event) {
        event.preventDefault(); // предотвращаем стандартное поведение отправки формы

        // Собираем данные из формы
        const formData = new FormData(form);

        // Выполняем POST запрос
        fetch('/api/products/create', { // Тут надо поменять урл
            method: 'POST',
            body: formData,
        })
        .then(response => {
            if (!response.ok) {
                throw new Error('Ошибка сети');
            }
            return response.json();
        })
        .then(data => {
            // Обработка успешного ответа
            console.log('Успешно создано:', data);
            window.location.href = '/product/'
        })
        .catch(error => {
            // Обработка ошибок
            console.error('Ошибка при создании продукта:', error);
        });
    });
    
    // Тумблер
    document.querySelector('.form__radio-container').addEventListener('click', function(event) {
        const toggleButton = document.querySelector('.form__radio-input');
        if (event.target.closest('.form__toggle-label') || event.target.closest('.form__toggle-button')) {
            toggleButton.checked = !toggleButton.checked;
        }
    });

    // Селект
    const select = document.querySelectorAll('.form__select');
    const icon = document.querySelectorAll('.form__select-icon');
    let isOpen = false;
    
    for (let i = 0; i < select.length; i++){
        select[i].onclick = function () {
            isOpen = !isOpen; // Переключаем флаг состояния
            if (isOpen) {
                icon[i].classList.add('rotate-icon');
            } else {
                icon[i].classList.remove('rotate-icon');
            }
        };
        
        select.onblur = function () {
            isOpen = false; // Закрываем select при потере фокуса
            icon[i].classList.remove('rotate-icon');
        };
    };

    // Автоматическое изменение высоты текстовых полей при вводе
    document.querySelectorAll('.form__table-input').forEach(textarea => {
        textarea.addEventListener('input', () => {
            textarea.style.height = 'auto'; // Сначала сбрасываем высоту
            textarea.style.height = textarea.scrollHeight + 'px'; // Устанавливаем новую высоту
        });
    });

    // Получаем кнопки добавления и удаления строк
    const addButton = document.getElementById('add-row');
    const removeButton = document.getElementById('remove-row');
    const risksBody = document.getElementById('risks-body');
    let riskKeyIndex = 1; // Начальное значение для идентификатора KEY (изменено на 1, так как первая строка будет Р1)

    // Функция для добавления новой строки
    addButton.addEventListener('click', () => {
        const newRow = document.createElement('tr');

        newRow.classList.add('risk-row');
        newRow.innerHTML = `
            <td><textarea class="form__table-input" name="risk-key">Р${riskKeyIndex + 1}</textarea></td>
            <td><textarea class="form__table-input" name="risk-description"></textarea></td>
            <td><input class="form__table-input" type="number" name="start-tarif"></td>
            <td><input class="form__table-input" type="number" name="basic compensation"></td>
            <td><input type="checkbox" value="can-change" name="can-change" class="form__table-input"></td>
        `;

        risksBody.appendChild(newRow); // Добавляем новую строку в тело таблицы
        riskKeyIndex++; // Увеличиваем индекс для следующей строки

        // Обрабатываем textarea в новой строке для автоувеличения высоты
        newRow.querySelectorAll('.form__table-input').forEach(textarea => {
            textarea.addEventListener('input', () => {
                textarea.style.height = 'auto'; // Сначала сбрасываем высоту
                textarea.style.height = textarea.scrollHeight + 'px'; // Устанавливаем новую высоту
            });
        });
    });

    // Функция для удаления последней добавленной строки
    removeButton.addEventListener('click', () => {
        const lastRow = risksBody.querySelector('tr:last-child');

        // Проверяем, есть ли строки для удаления, кроме thead
        if (lastRow && risksBody.childElementCount > 1) {
            risksBody.removeChild(lastRow); // Удаляем последнюю строку
            riskKeyIndex--; // Уменьшаем индекс, чтобы корректно обновить KEY
        }
    });

    // Метаданные
    const openModal = () => {
        document.getElementById('modal').style.display = 'block';
        document.getElementById('overlay').style.display = 'block';
    };

    const closeModal = () => {
        document.getElementById('modal').style.display = 'none';
        document.getElementById('overlay').style.display = 'none';
    };

    let metadataCountIndexTable = 1;

    function renderMetadataTable(selectValue) {
        const tableContainer = document.querySelector(selectValue === 'input' ? '.table-input' : '.table-select');
        const tableId = metadataCountIndexTable; // Прямое использование метаданных
        const keyPrefix = selectValue === 'select' ? 'S' : 'I'; // Префикс для ключа

        const tableHTML = `
            <div class="table-wrapper" id="metadata-table-${tableId}">
                <table class="create-table">
                    <thead>
                        <tr>
                            <th><label for="metadata-key">KEY</label></th>
                            <th><label for="metadata-description">Описание</label></th>
                            ${selectValue === 'select' ? 
                                `<th><label for="metadata-meaning">Значение</label></th>
                                <th><label for="metadata-value">value</label></th>`
                            : ''}
                        </tr>
                    </thead>
                    <tbody id="${tableId}-body" data-id="${metadataCountIndexTable}">
                        <tr class="row-table-with-buttons">
                            <td><textarea class="form__table-input" name="metadata-key">M${tableId}${keyPrefix}</textarea></td>
                            <td><textarea class="form__table-input" name="metadata-description"></textarea></td>
                            ${selectValue === 'select' ? 
                                `<td><input class="form__table-input" name="metadata-meaning"></td>
                                <td><input class="form__table-input" name="metadata-value"></td>`
                            : ''}
                        </tr>
                    </tbody>
                </table>
                <div class="buttons-under-table__container">
                    <button class="form__add-row" type="button">Добавить строку</button>
                    <button class="form__remove-row" type="button">Удалить строку</button>
                </div>
            </div>`;

        tableContainer.innerHTML += tableHTML;
        closeModal();
        metadataCountIndexTable++; // Увеличиваем индекс для следующей таблицы

        // Получаем кнопки добавления и удаления
        const addRowButton = document.querySelector(`#metadata-table-${tableId} .form__add-row`);
        const removeRowButton = document.querySelector(`#metadata-table-${tableId} .form__remove-row`);
        
        let rowCount = 1; // Изначально одна строка

        // Добавление новой строки
        addRowButton.addEventListener('click', () => {
            const tableBody = document.getElementById(`${tableId}-body`);
            const newRow = document.createElement('tr');
            newRow.innerHTML = `
                <td><textarea class="form__table-input" name="metadata-key">M${tableId}${keyPrefix}</textarea></td>
                <td><textarea class="form__table-input" name="metadata-description"></textarea></td>
                ${selectValue === 'select' ? 
                    `<td><input class="form__table-input" name="metadata-meaning"></td>
                    <td><input class="form__table-input" name="metadata-value"></td>`
                : ''}`;
            
            tableBody.appendChild(newRow);
            rowCount++;
        });

        // Удаление последней строки или всей таблицы
        removeRowButton.addEventListener('click', () => {
            const tableBody = document.getElementById(`${tableId}-body`);
            if (rowCount > 1) {
                const lastRow = tableBody.querySelector('tr:last-child');
                if (lastRow) {
                    tableBody.removeChild(lastRow); // Удаляем последнюю строку
                    rowCount--;
                }
            } else {
                const tableWrapper = document.getElementById(`metadata-table-${tableId}`);
                if (tableWrapper) {
                    tableWrapper.remove(); // Удаляем всю таблицу
                    metadataCountIndexTable--;
                }
            }
        });
    }

    // Обработчики событий
    document.querySelector('.form__metadata-button').addEventListener('click', openModal);
    document.querySelector('.overlay').addEventListener('click', closeModal);
    document.querySelector('.button-add-metadata').addEventListener('click', () => {
        renderMetadataTable(document.getElementById("metadata-type").value);
    });

});
