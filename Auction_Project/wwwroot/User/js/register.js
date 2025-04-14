// Register Page JavaScript for AuctionHub

document.addEventListener("DOMContentLoaded", () => {
    // Register Form Submission
    const registerForm = document.getElementById("registerForm")
    if (registerForm) {
        registerForm.addEventListener("submit", function (e) {
            e.preventDefault()

            const firstNameInput = document.getElementById("firstNameInput")
            const lastNameInput = document.getElementById("lastNameInput")
            const usernameInput = document.getElementById("usernameInput")
            const emailInput = document.getElementById("emailInput")
            const passwordInput = document.getElementById("passwordInput")
            const confirmPasswordInput = document.getElementById("confirmPasswordInput")
            const termsCheck = document.getElementById("termsCheck")

            const firstName = firstNameInput.value.trim()
            const lastName = lastNameInput.value.trim()
            const username = usernameInput.value.trim()
            const email = emailInput.value.trim()
            const password = passwordInput.value.trim()
            const confirmPassword = confirmPasswordInput.value.trim()

            // Simple validation
            let isValid = true

            if (!firstName || !lastName || !username || !email || !password || !confirmPassword) {
                isValid = false
            }

            if (password !== confirmPassword) {
                confirmPasswordInput.classList.add("is-invalid")
                isValid = false
            } else {
                confirmPasswordInput.classList.remove("is-invalid")
            }

            if (!termsCheck.checked) {
                termsCheck.classList.add("is-invalid")
                isValid = false
            } else {
                termsCheck.classList.remove("is-invalid")
            }

            if (!isValid) {
                registerForm.classList.add("shake")
                setTimeout(() => {
                    registerForm.classList.remove("shake")
                }, 500)
                return
            }

            // No fake delay, instant success
            const successMessage = document.createElement("div")
            successMessage.className = "alert alert-success mt-3"
            successMessage.innerHTML = `
        <h4 class="alert-heading"><i class="fas fa-check-circle me-2"></i>Registration Successful!</h4>
        <p>Your account has been created successfully. Please proceed to <a href="login.html">Login</a>.</p>
      `

            registerForm.parentNode.replaceChild(successMessage, registerForm)
        })
    }

    // Password Strength Meter
    const passwordInput = document.getElementById("passwordInput")
    const passwordStrength = document.getElementById("passwordStrength")
    const passwordProgress = document.querySelector(".password-strength .progress-bar")

    if (passwordInput && passwordStrength && passwordProgress) {
        passwordInput.addEventListener("input", function () {
            const password = this.value
            let strength = 0
            let status = ""

            if (password.length >= 8) strength += 25
            if (password.match(/[a-z]/)) strength += 25
            if (password.match(/[A-Z]/)) strength += 25
            if (password.match(/[0-9]/) || password.match(/[^a-zA-Z0-9]/)) strength += 25

            passwordProgress.style.width = strength + "%"

            if (strength <= 25) {
                status = "Weak"
                passwordProgress.className = "progress-bar bg-danger"
            } else if (strength <= 50) {
                status = "Fair"
                passwordProgress.className = "progress-bar bg-warning"
            } else if (strength <= 75) {
                status = "Good"
                passwordProgress.className = "progress-bar bg-info"
            } else {
                status = "Strong"
                passwordProgress.className = "progress-bar bg-success"
            }

            passwordStrength.textContent = status
        })
    }

    // Username Availability Check (Instant + Local Only)
    const usernameInput = document.getElementById("usernameInput")
    if (usernameInput) {
        usernameInput.addEventListener("blur", function () {
            const username = this.value.trim()
            if (username.length < 3) return

            const takenUsernames = ["admin", "user", "test", "johndoe", "janedoe"]
            if (takenUsernames.includes(username.toLowerCase())) {
                this.classList.add("is-invalid")
            } else {
                this.classList.remove("is-invalid")
                this.classList.add("is-valid")
            }
        })
    }

    // Social Register Buttons (No Timeout, Just Instant Message)
    const socialButtons = document.querySelectorAll(".social-btn")
    socialButtons.forEach((button) => {
        button.addEventListener("click", function (e) {
            e.preventDefault()

            const message = document.createElement("div")
            message.className = "alert alert-info mt-3"
            message.innerHTML = '<i class="fas fa-info-circle me-2"></i> Social registration is not available in this demo.'

            const form = document.getElementById("registerForm")
            if (form) {
                form.before(message)
                // No timeout = user closes manually or it stays
            }
        })
    })

    // Confirm Password Real-Time Validation
    const confirmPasswordInput = document.getElementById("confirmPasswordInput")
    if (passwordInput && confirmPasswordInput) {
        confirmPasswordInput.addEventListener("input", function () {
            if (passwordInput.value !== this.value) {
                this.classList.add("is-invalid")
            } else {
                this.classList.remove("is-invalid")
                this.classList.add("is-valid")
            }
        })
    }
})
