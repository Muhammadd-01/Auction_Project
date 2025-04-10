document.addEventListener("DOMContentLoaded", () => {
    const loginForm = document.getElementById("loginForm");
    if (loginForm) {
        loginForm.addEventListener("submit", function (e) {
            e.preventDefault();  // Prevent default form submission

            const emailInput = document.getElementById("emailInput");
            const passwordInput = document.getElementById("passwordInput");
            const loginError = document.getElementById("loginError");

            const email = emailInput.value.trim();
            const password = passwordInput.value.trim();

            // Simple validation
            if (!email || !password) {
                loginError.classList.remove("d-none");
                return;
            }

            // Hide error message
            loginError.classList.add("d-none");

            // Disable the login button and show loading state
            const loginBtn = this.querySelector(".login-btn");
            loginBtn.disabled = true;
            loginBtn.innerHTML = '<i class="fas fa-spinner fa-spin me-2"></i>Logging in...';

            // Send POST request to backend
            fetch('/User/Login', {  // This should be the correct path for your backend login action
                method: 'POST',
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded',  // Standard form submission
                },
                body: new URLSearchParams({
                    email: email,
                    password: password
                })
            })
                .then(response => response.json())  // Expect JSON response from the backend
                .then(data => {
                    if (data.success) {
                        window.location.href = data.redirectUrl;  // Redirect if successful
                    } else {
                        // Show error if login failed
                        loginError.classList.remove("d-none");
                        loginBtn.disabled = false;
                        loginBtn.innerHTML = '<i class="fas fa-sign-in-alt me-2"></i>Login';

                        //// Shake effect for error
                        //loginForm.classList.add("shake");
                        //setTimeout(() => {
                        //    loginForm.classList.remove("shake");
                        //}, 500);
                    }
                })
                .catch(error => {
                    console.error('Error during login:', error);
                    loginError.classList.remove("d-none");
                    loginBtn.disabled = false;
                    loginBtn.innerHTML = '<i class="fas fa-sign-in-alt me-2"></i>Login';
                });
        });
    }
});
