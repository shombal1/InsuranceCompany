document.querySelectorAll('.form__input-container').forEach(container => {
    const label = container.querySelector('.form__label');
    const input = container.querySelector('.form__input');

    const labelWidth = label.offsetWidth;
    const paddingLeft = labelWidth + 25;

    input.style.paddingLeft = `${paddingLeft}px`;
});