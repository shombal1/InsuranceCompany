document.addEventListener('DOMContentLoaded', () => {
    // Отмена
    document.querySelector('.button--cancel').addEventListener('click', () => {
        window.location.href = `/product/`
    });

    // Создать
    const getLastId = async () => {
        // Код для запроса к серверу
    };

    const form = document.querySelector(".form--create-product");

    form.addEventListener("submit", async function (event) {
        event.preventDefault();
        const lastId = await getLastId(); // Получаем последний ID
        const formData = new FormData(form);
        const saveProductDto = {
            Id: lastId + 1, // Добавляем уникальный идентификатор
            Name: formData.get('product-title'),
            Description: formData.get('product-descr'),
            LOBId: parseInt(formData.get('business-line')),
            Active: formData.get('status') === 'on',
            Items: [], // Здесь будут метаданные
            Risks: [],
            Formula: formData.get('formula'),
        };

        // Собираем риски из таблицы
        const risksRows = document.querySelectorAll("#risks-body tr");
        risksRows.forEach(row => {
            const risk = {
                Key: row.querySelector("textarea[name='risk-key']").value,
                Description: row.querySelector("textarea[name='risk-description']").value,
                StartTarif: parseFloat(row.querySelector("input[name='start-tarif']").value),
                BasicCompensation: parseFloat(row.querySelector("input[name='basic compensation']").value),
                CanChange: row.querySelector("input[name='can-change']").checked
            };
            saveProductDto.Risks.push(risk);
        });

        // Собираем метаданные из всех таблиц
        const metadataTables = document.querySelectorAll('.table-wrapper');
        metadataTables.forEach(table => {
            const tableId = table.id.replace('metadata-table-', ''); // Извлекаем ID таблицы
            const tableBody = table.querySelector('tbody');
            const rows = tableBody.querySelectorAll('tr');
            rows.forEach(row => {
                const item = {
                    Key: row.querySelector("textarea[name='metadata-key']").value,
                    Description: row.querySelector("textarea[name='metadata-description']").value,
                    Meaning: selectValue === 'select' ? row.querySelector("input[name='metadata-meaning']").value : null,
                    Value: selectValue === 'select' ? row.querySelector("input[name='metadata-value']").value : null,
                };
                saveProductDto.Items.push(item);
            });
        });

        try {
            const response = await fetch('/product/save', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(saveProductDto),
            });

            if (!response.ok) {
                const errorText = await response.text();
                throw new Error('Ошибка при создании продукта: ' + errorText);
            }

            const data = await response.json();
            console.log('Успешно создано:', data);
            window.location.href = '/product/';
        } catch (error) {
            console.error('Ошибка:', error.message);
        }
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
    let availableIndices = []; // Массив для хранения доступных индексов

    function getNextAvailableIndex() {
        // Если есть освобождённые индексы, используем их
        if (availableIndices.length > 0) {
            return availableIndices.shift(); // Забираем первый доступный индекс
        }
        // Если свободных индексов нет, возвращаем текущий и увеличиваем его
        return metadataCountIndexTable++;
    }

    function renderMetadataTable(selectValue) {
        const tableContainer = document.querySelector(selectValue === 'input' ? '.table-input' : '.table-select');
        const tableId = getNextAvailableIndex(); // Получаем следующий доступный индекс
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
                    <tbody id="${tableId}-body" data-id="${tableId}" data-key-prefix="${keyPrefix}">
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
                    <button class="form__add-row" data-table-id="${tableId}" type="button">Добавить строку</button>
                    <button class="form__remove-row" data-table-id="${tableId}" type="button">Удалить строку</button>
                </div>
            </div>`;

        tableContainer.innerHTML += tableHTML;
        closeModal();
    }

    // Делегирование событий для добавления и удаления строк
    document.addEventListener('click', function (event) {
        if (event.target.matches('.form__add-row')) {
            // Добавление новой строки
            const tableId = event.target.getAttribute('data-table-id');
            const tableBody = document.getElementById(`${tableId}-body`);
            const keyPrefix = tableBody.getAttribute('data-key-prefix'); // Получаем префикс для ключа
            const rowCount = tableBody.querySelectorAll('tr').length + 1; // Считаем количество строк

            const newRow = document.createElement('tr');
            newRow.innerHTML = `
                <td><textarea class="form__table-input" name="metadata-key">M${tableId}${keyPrefix}</textarea></td>
                <td><textarea class="form__table-input" name="metadata-description"></textarea></td>
                ${keyPrefix === 'S' ? 
                    `<td><input class="form__table-input" name="metadata-meaning"></td>
                    <td><input class="form__table-input" name="metadata-value"></td>` 
                : ''}`;
            
            tableBody.appendChild(newRow);
        }

        if (event.target.matches('.form__remove-row')) {
            // Удаление последней строки или всей таблицы
            const tableId = event.target.getAttribute('data-table-id');
            const tableBody = document.getElementById(`${tableId}-body`);
            const rows = tableBody.querySelectorAll('tr');
            
            if (rows.length > 1) {
                // Удаляем последнюю строку
                tableBody.removeChild(rows[rows.length - 1]);
            } else {
                // Удаляем всю таблицу
                const tableWrapper = document.getElementById(`metadata-table-${tableId}`);
                if (tableWrapper) {
                    tableWrapper.remove(); // Удаляем таблицу
                    availableIndices.push(tableId); // Добавляем индекс в доступные
                }
            }
        }
    });

    // Обработчики событий для открытия/закрытия модального окна
    document.querySelector('.form__metadata-button').addEventListener('click', openModal);
    document.querySelector('.overlay').addEventListener('click', closeModal);
    document.querySelector('.button-add-metadata').addEventListener('click', () => {
        renderMetadataTable(document.getElementById("metadata-type").value);
    });

});
