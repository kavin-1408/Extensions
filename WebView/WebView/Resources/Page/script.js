document.addEventListener('DOMContentLoaded', function () {
    // Define validation patterns
    var usernamePattern = /^.{3,}$/; // At least 3 characters
    var passwordPattern = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;

    // Get the password input field and message div
    var passwordInput = document.getElementById('password');
    var messageDiv = document.getElementById('message');

    // Validate password in real-time
    passwordInput.addEventListener('input', function () {
        var password = passwordInput.value;
        if (!passwordPattern.test(password)) {
            displayMessage('Password must be at least 8 characters long, contain both uppercase and lowercase letters, include at least one numerical digit, and have at least one special character.', 'red');
        } else {
            displayMessage('Password is valid.', 'green');
        }
    });

    // Handle form submission
    document.getElementById('loginForm').addEventListener('submit', function (event) {
        event.preventDefault(); // Prevent the form from submitting normally

        // Get the values from the input fields
        var username = document.getElementById('username').value;
        var password = document.getElementById('password').value;
        var fileLocation = document.getElementById('file').value;

        // Validate username
        if (!usernamePattern.test(username)) {
            displayMessage('Username must be at least 3 characters long.', 'red');
            return;
        }

        // Validate password
        if (!passwordPattern.test(password)) {
            displayMessage('Password must be at least 8 characters long, contain both uppercase and lowercase letters, include at least one numerical digit, and have at least one special character.', 'red');
            return;
        }

        // Display the values in the message div
        displayMessage('<p>Username: ' + username + '</p>' +
            '<p>Password: ' + password + '</p>' +
            '<p>File Location: ' + fileLocation + '</p>', 'green');
    });

    // Function to display a message
    function displayMessage(message, color) {
        messageDiv.innerHTML = '<p style="color: ' + color + ';">' + message + '</p>';
    }
});
