/**
 * notifications.js - Handles notification badge updates
 */
document.addEventListener('DOMContentLoaded', function() {
    // Update notification badges
    function updateNotificationBadges(count) {
        const badges = document.querySelectorAll('.notification-badge');
        badges.forEach(badge => {
            badge.textContent = count;
            if (count > 0) {
                badge.style.display = 'inline-block';
            } else {
                badge.style.display = 'none';
            }
        });
    }
    
    // Example: Set notification count (you can replace this with actual data)
    updateNotificationBadges(3);
});