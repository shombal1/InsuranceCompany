document.addEventListener('DOMContentLoaded', () => {
    console.log(state);
    const premium_elem = document.querySelector('.for-js-premium__value');
    const calculate = () => {
        let parsedFormula = state.calculate.formula;
        for (const key in state.key) {
            const value = state.key[key];
            const regex = new RegExp(`\\b${key}\\b`, 'g');
            parsedFormula = parsedFormula.replace(regex, value);
        };
        try {
            console.log(parsedFormula);
            const result = eval(parsedFormula);
            premium_elem.textContent = String(result.toFixed(2));
        } catch (error) {
            premium_elem.textContent = 'Ошибка в формуле';
        };
    };
    calculate();

    const handler_key = event => {
        const key = event.target.getAttribute('data-key');
        const type = event.target.getAttribute('data-type');
        switch (type) {
            case "checkbox-risk":
                if (event.target.checked) {
                        state.key[key] = state.key[`${key}-old`];
                } else {
                    state.key[key] = 0;
                };
                break;
            case "input-risk":
                if (state.calculate[key].changeable) {
                    const value_ir = parseFloat(event.target.value.replace(',', '.'))
                    if (value_ir > state.calculate[key].compensation) {
                        state.key[key] = state.calculate[key].tarif*(value_ir / state.calculate[key].compensation);                        
                    } else {
                        state.key[key] = state.calculate[key].tarif;
                    };
                    state.key[`${key}-old`] = state.key[key];
                };
                break;
            case "input-meta":
                const value_im = parseFloat(event.target.value.replace(',', '.'))
                state.key[key] = event.target.value ? value_im : 0;
                break;
            case "select-meta":
                state.key[key] = parseFloat(event.target.value.replace(',', '.'));
                break;
        };
        calculate();
    }

    // Получаем все чекбоксы рисков
    const checkboxes_risk = document.querySelectorAll('.risk__elem .elem__checkbox input');
    checkboxes_risk.forEach((checkbox) => {
        checkbox.addEventListener('change', event => handler_key(event));
    });
    // Получаем все инпуты рисков
    const inputs_risk = document.querySelectorAll('.risk__elem .calc__risk-compensation input');
    inputs_risk.forEach((input) => {
        input.addEventListener('input', event => handler_key(event));
    });
    // Получаем все инпуты метаданных
    const inputs_meta = document.querySelectorAll('.details__elem input');
    inputs_meta.forEach((input) => {
        input.addEventListener('input', event => handler_key(event));
    });
    // Получаем все селекты метаданных
    const selects = document.querySelectorAll('.details__elem select');
    selects.forEach((select) => {
        select.addEventListener('change', event => handler_key(event));
    });
});