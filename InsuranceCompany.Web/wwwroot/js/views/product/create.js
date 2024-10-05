document.addEventListener('DOMContentLoaded', () => {
    // Отмена
    document.querySelector('.button--cancel').addEventListener('click', () => {
        window.location.href = `/product/`
    });

    const form = document.querySelector('.form--create-product');
    const collectFormData = () => {
        const formData = {
            Name: form.querySelector('input[name="product-title"]').value,
            Description: form.querySelector('textarea[name="product-descr"]').value,
            LOBId: Number(form.querySelector('select[name="business-line"]').value),
            Active: form.querySelector('input[name="status"]').checked,
            Risks: [],
            Items: [],
            Formula: form.querySelector('input[name="formula"]').value
        };    
        // Собираем данные рисков
        const risksBody = form.querySelector('#risks-body');
        risksBody.querySelectorAll('tr').forEach(row => {
            const risk = {
                Key: row.querySelector('textarea[name="risk-key"]').value,
                Name: row.querySelector('textarea[name="risk-description"]').value,
                Premium: parseFloat(row.querySelector('input[name="start-tarif"]').value.replace(',', '.')),
                InsuranceSum: parseFloat(row.querySelector('input[name="basic compensation"]').value.replace(',', '.')),
                Active: row.querySelector('input[name="can-change"]').checked
            };
            formData.Risks.push(risk);
        });    
        // Собираем данные метаданных
        const metadataTables = form.querySelectorAll('.form__metadata-tables .table-wrapper');
        metadataTables.forEach(table => {
            const metadata = {};
            if (table.classList.contains('table-wrapper-type-input')) {
                metadata.type = 1;
                metadata.Index = Number(table.getAttribute('data-id'));
                metadata.Key = table.querySelector('textarea[name="metadata-key"]').value;
                metadata.Description = table.querySelector('textarea[name="metadata-description"]').value;
            } else if (table.classList.contains('table-wrapper-type-select')) {
                metadata.type = 0;
                metadata.Index = Number(table.getAttribute('data-id'));
                metadata.Values = [];
                table.querySelectorAll('tr').forEach((row, index) => {
                    if (index) {
                        if (index===1) {
                            metadata.Key = row.querySelector('textarea[name="metadata-key"]').value;
                            metadata.Description = row.querySelector('textarea[name="metadata-description"]').value;
                        };
                        const value = {
                            Name: row.querySelector('input[name="metadata-meaning"]').value,
                            Value: parseFloat(row.querySelector('input[name="metadata-value"]').value.replace(',', '.'))
                        };
                        metadata.Values.push(value);
                    };
                });
            };
            formData.Items.push(metadata);
        });    
        return formData;
    };
    form.addEventListener("submit", async event => {
        event.preventDefault();
        const formData = collectFormData();
        console.log(formData);

        let url = '';
        let method = '';
        const path = window.location.pathname;
        if (path.startsWith('/product/edit/')) {
            const parts = path.split('/');
            url = `/product/update/${parts[3]}`;
            method = 'PUT';
        } else {
            url = `/product/save`;
            method = 'POST';
        };
        try {
            const response = await fetch(url, {
                method: method,
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(formData),
            });
            if (response.ok) {
                window.location.href = '/product';
            };
            console.log(response);
        } catch (error) {
            console.log(error);
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
    let riskKeyIndex = 0;
    document.querySelectorAll('#risks-body textarea[name="risk-key"]').forEach(item => riskKeyIndex = Number(item.getAttribute('data-id')));
    // Функция для добавления новой строки
    addButton.addEventListener('click', () => {
        const newRow = document.createElement('tr');

        riskKeyIndex++; // Увеличиваем индекс для следующей строки
        newRow.classList.add('risk-row');
        newRow.innerHTML = `
            <td><textarea class="form__table-input" name="risk-key" disabled data-id="${riskKeyIndex}">P${riskKeyIndex}</textarea></td>
            <td><textarea class="form__table-input" name="risk-description" required></textarea></td>
            <td><input class="form__table-input" type="number" name="start-tarif" required></td>
            <td><input class="form__table-input" type="number" name="basic compensation"></td>
            <td><input type="checkbox" value="can-change" name="can-change" class="form__table-input"></td>
        `;
        risksBody.appendChild(newRow); // Добавляем новую строку в тело таблицы

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

    let metadataCountIndexTable = 0;
    let availableIndices = []; // Массив для хранения доступных индексов
    const formMetadataTables = document.querySelectorAll('.form__metadata-tables .table-wrapper');
    if (formMetadataTables.length) {
        const curentMetadataCountIndexTables = Array.from(formMetadataTables).map(item => Number(item.getAttribute('data-id')));
        metadataCountIndexTable = Math.max(...curentMetadataCountIndexTables);
        const allIndices = Array.from({ length: metadataCountIndexTable }, (_, i) => i + 1);
        availableIndices = allIndices.filter(index => !curentMetadataCountIndexTables.includes(index));
    };
    function getNextAvailableIndex() {
        // Если есть освобождённые индексы, используем их
        if (availableIndices.length > 0) {
            return availableIndices.shift(); // Забираем первый доступный индекс
        };
        metadataCountIndexTable++;
        return metadataCountIndexTable;
    }

    const tableContainer = document.querySelector('.form__metadata-tables');
    function renderMetadataTable(selectValue) {
        const tableId = getNextAvailableIndex(); // Получаем следующий доступный индекс
        const keyPrefix = selectValue === 'select' ? 'S' : 'I'; // Префикс для ключа

        const tableHTML = `
            <div class="table-wrapper ${selectValue === 'select' ? 'table-wrapper-type-select' : 'table-wrapper-type-input'}" id="metadata-table-${tableId}" data-id="${tableId}">
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
                            <td><textarea class="form__table-input" name="metadata-key" disabled>M${tableId}${keyPrefix}</textarea></td>
                            <td><textarea class="form__table-input" name="metadata-description" required></textarea></td>
                            ${selectValue === 'select' ? 
                                `<td><input class="form__table-input" name="metadata-meaning" required></td>
                                <td><input class="form__table-input" name="metadata-value" required></td>` 
                            : ''}
                        </tr>
                    </tbody>
                </table>
                <div class="buttons-under-table__container">
                    ${selectValue === 'select' ? 
                        `<button class="form__add-row" data-table-id="${tableId}" type="button">Добавить</button>` 
                    : ''}
                    <button class="form__remove-row" data-table-id="${tableId}" type="button">Удалить</button>
                </div>
            </div>`;

        tableContainer.insertAdjacentHTML('beforeend', tableHTML);
        closeModal();
    }

    // Делегирование событий для добавления и удаления строк
    document.addEventListener('click', event => {
        if (event.target.matches('.form__metadata-tables .table-wrapper-type-select .form__add-row')) {
            // Добавление новой строки только в селект
            const tableId = event.target.getAttribute('data-table-id');
            const tableBody = document.getElementById(`${tableId}-body`);

            const newRow = document.createElement('tr');
            newRow.innerHTML = `
                <td style="background: cornsilk;"><textarea class="form__table-input" name="metadata-key" disabled></textarea></td>
                <td style="background: cornsilk;"><textarea class="form__table-input" name="metadata-description" disabled></textarea></td>
                <td><input class="form__table-input" name="metadata-meaning"></td>
                <td><input class="form__table-input" name="metadata-value"></td>`;
            tableBody.appendChild(newRow);
        }

        if (event.target.matches('.form__metadata-tables .form__remove-row')) {
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
