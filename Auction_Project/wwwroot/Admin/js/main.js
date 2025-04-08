// Main JavaScript file for common functionality across all pages

// Import necessary modules or declare variables
// Assuming loadData and bootstrap are defined elsewhere or imported
// Example:
// import { loadData } from './data.js'; // If loadData is in data.js
// import * as bootstrap from 'bootstrap'; // If using Bootstrap's JS as a module

// Declare loadData and bootstrap if not imported
const loadData = () => {
  // Replace this with actual data loading logic if needed
  console.warn("loadData() is a placeholder. Implement actual data loading.")
  return { notifications: [] } // Return a default object to prevent errors
}

const bootstrap = window.bootstrap // Assuming bootstrap is loaded globally

// Toggle sidebar
const sidebarCollapse = document.getElementById("sidebarCollapse")
const sidebar = document.getElementById("sidebar")
const content = document.getElementById("content")

if (sidebarCollapse) {
  sidebarCollapse.addEventListener("click", () => {
    sidebar.classList.toggle("active")
    content.classList.toggle("active")
  })
}

// Toggle collapsed sidebar with button in header
const sidebarCollapseBtn = document.getElementById("sidebarCollapseBtn")
if (sidebarCollapseBtn) {
  sidebarCollapseBtn.addEventListener("click", () => {
    sidebar.classList.toggle("collapsed")

    // Store sidebar state in localStorage
    if (sidebar.classList.contains("collapsed")) {
      localStorage.setItem("sidebarCollapsed", "true")
    } else {
      localStorage.setItem("sidebarCollapsed", "false")
    }
  })
}

// Check sidebar collapsed state on page load
document.addEventListener("DOMContentLoaded", () => {
  // Check sidebar state
  if (localStorage.getItem("sidebarCollapsed") === "true") {
    sidebar.classList.add("collapsed")
  }

  // Theme toggle
  const themeSwitch = document.getElementById("themeSwitch")
  if (themeSwitch) {
    // Check if dark mode is enabled in localStorage
    if (localStorage.getItem("darkMode") === "enabled") {
      document.body.classList.add("dark-mode")
      themeSwitch.checked = true
    }

    themeSwitch.addEventListener("change", function () {
      if (this.checked) {
        document.body.classList.add("dark-mode")
        localStorage.setItem("darkMode", "enabled")
      } else {
        document.body.classList.remove("dark-mode")
        localStorage.setItem("darkMode", "disabled")
      }
    })
  }

  // Update notification badge
  updateNotificationBadge()
})

// Function to update notification badge
function updateNotificationBadge() {
  const data = loadData()
  const unreadCount = data.notifications.filter((notification) => notification.status === "unread").length

  const badges = document.querySelectorAll(".notification-badge")
  badges.forEach((badge) => {
    badge.textContent = unreadCount
    if (unreadCount > 0) {
      badge.style.display = "inline-block"
    } else {
      badge.style.display = "none"
    }
  })
}

// Function to format date
function formatDate(dateString) {
  const options = { year: "numeric", month: "short", day: "numeric" }
  return new Date(dateString).toLocaleDateString(undefined, options)
}

// Function to format date and time
function formatDateTime(dateString) {
  const options = {
    year: "numeric",
    month: "short",
    day: "numeric",
    hour: "2-digit",
    minute: "2-digit",
  }
  return new Date(dateString).toLocaleString(undefined, options)
}

// Function to get time ago
function timeAgo(dateString) {
  const date = new Date(dateString)
  const now = new Date()
  const seconds = Math.floor((now - date) / 1000)

  let interval = Math.floor(seconds / 31536000)
  if (interval >= 1) {
    return interval + " year" + (interval === 1 ? "" : "s") + " ago"
  }

  interval = Math.floor(seconds / 2592000)
  if (interval >= 1) {
    return interval + " month" + (interval === 1 ? "" : "s") + " ago"
  }

  interval = Math.floor(seconds / 86400)
  if (interval >= 1) {
    return interval + " day" + (interval === 1 ? "" : "s") + " ago"
  }

  interval = Math.floor(seconds / 3600)
  if (interval >= 1) {
    return interval + " hour" + (interval === 1 ? "" : "s") + " ago"
  }

  interval = Math.floor(seconds / 60)
  if (interval >= 1) {
    return interval + " minute" + (interval === 1 ? "" : "s") + " ago"
  }

  return "Just now"
}

// Function to generate a random ID
function generateId() {
  return Math.floor(Math.random() * 1000000)
}

// Function to show toast notification
function showToast(message, type = "success") {
  const toastContainer = document.getElementById("toastContainer")

  // Create toast container if it doesn't exist
  if (!toastContainer) {
    const container = document.createElement("div")
    container.id = "toastContainer"
    container.className = "toast-container position-fixed bottom-0 end-0 p-3"
    document.body.appendChild(container)
  }

  const toastId = "toast-" + Date.now()
  const toastHTML = `
        <div id="${toastId}" class="toast" role="alert" aria-live="assertive" aria-atomic="true">
            <div class="toast-header bg-${type} text-white">
                <strong class="me-auto">${type === "success" ? "Success" : type === "danger" ? "Error" : "Notification"}</strong>
                <button type="button" class="btn-close btn-close-white" data-bs-dismiss="toast" aria-label="Close"></button>
            </div>
            <div class="toast-body">
                ${message}
            </div>
        </div>
    `

  document.getElementById("toastContainer").innerHTML += toastHTML

  const toastElement = document.getElementById(toastId)
  const toast = new bootstrap.Toast(toastElement, { delay: 5000 })
  toast.show()

  // Remove toast after it's hidden
  toastElement.addEventListener("hidden.bs.toast", () => {
    toastElement.remove()
  })
}
