document.addEventListener('DOMContentLoaded', () => {
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

    document.querySelectorAll('.form__table-input').forEach(textarea => {
        textarea.addEventListener('input', () => {
            textarea.style.height = 'auto'; // Сначала сбрасываем высоту
            textarea.style.height = textarea.scrollHeight + 'px'; // Устанавливаем новую высоту
        });
    });
    
    const addButton = document.querySelector('.form__add-row');
    const risksBody = document.getElementById('risks-body');
    
    // Функция для добавления новой строки
    addButton.addEventListener('click', () => {
        const lastRow = risksBody.querySelector('tr:last-child'); // Последняя строка
        const newRow = document.createElement('tr');
    
        // Копируем данные из предыдущей строки
        const lastTextareas = lastRow.querySelectorAll('textarea');
        const lastInputs = lastRow.querySelectorAll('input[type="number"]');
        const lastCheckbox = lastRow.querySelector('input[type="checkbox"]');
    
        newRow.innerHTML = `
            <td><textarea class="form__table-input">${lastTextareas[0].value}</textarea></td>
            <td><textarea class="form__table-input">${lastTextareas[1].value}</textarea></td>
            <td><input class="form__table-input" type="number" value="${lastInputs[0].value}"></td>
            <td><input class="form__table-input" type="number" value="${lastInputs[1].value}"></td>
            <td><input type="checkbox" class="form__table-input" ${lastCheckbox.checked ? 'checked' : ''}></td>
            <td class="form__td-remove-button"><button class="form__remove-row">-</button></td>
        `;
    
        risksBody.appendChild(newRow);
    
        // Обработчик для textarea в новой строке
        const newTextareas = newRow.querySelectorAll('.form__table-input');
        newTextareas.forEach(textarea => {
            textarea.addEventListener('input', () => {
                textarea.style.height = 'auto'; // Сбрасываем высоту
                textarea.style.height = textarea.scrollHeight + 'px'; // Устанавливаем новую высоту
            });
        });
    
        // Добавляем событие для удаления строки при клике на кнопку
        const removeButton = newRow.querySelector('.form__remove-row');
        removeButton.addEventListener('click', () => {
            newRow.remove();
        });
    });
    
    // Обработчик для удаления существующих строк
    document.querySelectorAll('.form__td-remove-button').forEach(cell => {
        cell.addEventListener('click', () => {
            cell.closest('tr').remove();
        });
    });

    // Селект метаданные
    const formMetadataContainer = document.querySelector('.form__metadata-container .form__select-container');
    formMetadataContainer.style.display = "none";
    document.querySelector('.form__metadata-button').addEventListener('click', () => {
        formMetadataContainer.style.display = "inline-flex";
    });
    
});
