$(function () {
    $('#submit').click(function (e) {
        e.preventDefault();
        var data = {
            Name: $('#name').val(),
            Email: $('#email').val(),
            Password: $('#password').val(),
            Telephone: $('#telephone').val(),
            Address: $('#address').val()
        };

        $.ajax({
            type: 'POST',
            url: '/api/Accounts/RegisterEmployee',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(data),
            success: (function (data) {
                alert("Registration is succesfull");
            }),
            fail: (function (data) {
                alert("Error during registration");
            }),
        });
    })
});