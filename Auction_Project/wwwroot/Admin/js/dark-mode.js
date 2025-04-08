/**
 * dark-mode.js - Handles theme switching functionality
 */
document.addEventListener('DOMContentLoaded', function() {
    // Dark mode toggle functionality
    const themeSwitch = document.getElementById('themeSwitch');
    
    // Check if theme preference is saved in localStorage
    const currentTheme = localStorage.getItem('theme');
    if (currentTheme === 'dark') {
        document.body.classList.add('dark-mode');
        if (themeSwitch) {
            themeSwitch.checked = true;
        }
    }
    
    // Toggle dark mode when the switch is clicked
    if (themeSwitch) {
        themeSwitch.addEventListener('change', function() {
            if (this.checked) {
                document.body.classList.add('dark-mode');
                localStorage.setItem('theme', 'dark');
            } else {
                document.body.classList.remove('dark-mode');
                localStorage.setItem('theme', 'light');
            }
        });
    }
});