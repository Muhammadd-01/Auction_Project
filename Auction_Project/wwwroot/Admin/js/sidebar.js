/**
 * sidebar.js - Handles sidebar toggle functionality
 */
document.addEventListener('DOMContentLoaded', function() {
    // Sidebar toggle functionality
    const sidebar = document.getElementById('sidebar');
    const content = document.getElementById('content');
    const sidebarCollapse = document.getElementById('sidebarCollapse');
    const sidebarCollapseBtn = document.getElementById('sidebarCollapseBtn');
    
    // Check if sidebar state is saved in localStorage
    const sidebarState = localStorage.getItem('sidebarState');
    if (sidebarState === 'collapsed') {
        if (sidebar) sidebar.classList.add('active');
        if (content) content.classList.add('active');
    }
    
    // Toggle sidebar when the main button is clicked
    if (sidebarCollapse) {
        sidebarCollapse.addEventListener('click', function() {
            if (sidebar) sidebar.classList.toggle('active');
            if (content) content.classList.toggle('active');
            
            // Save state to localStorage
            if (sidebar && sidebar.classList.contains('active')) {
                localStorage.setItem('sidebarState', 'collapsed');
            } else {
                localStorage.setItem('sidebarState', 'expanded');
            }
        });
    }
    
    // Toggle sidebar when the sidebar button is clicked
    if (sidebarCollapseBtn) {
        sidebarCollapseBtn.addEventListener('click', function() {
            if (sidebar) sidebar.classList.toggle('active');
            if (content) content.classList.toggle('active');
            
            // Save state to localStorage
            if (sidebar && sidebar.classList.contains('active')) {
                localStorage.setItem('sidebarState', 'collapsed');
            } else {
                localStorage.setItem('sidebarState', 'expanded');
            }
        });
    }
});