window.scrollToBottom = (elementId) => {
    const element = document.getElementById(elementId);
    if (element) {
        element.scrollTop = element.scrollHeight;
    }
};

// Add these functions to your JavaScript
function scrollToBottom(elementId) {
    const element = document.getElementById(elementId);
    if (element) {
        element.scrollTop = element.scrollHeight;
    }
}

function focusElement(className) {
    const element = document.querySelector('.' + className + ' input');
    if (element) {
        element.focus();
    }
}