$(function () {
    var tokenKey = "tokenInfo";
    $('#submitLogin').click(function (e) {
        e.preventDefault();
        var loginData = {
            grant_type: 'password',
            username: $('#emailLogin').val(),
            password: $('#passwordLogin').val()
        };

        $.ajax({
            type: 'POST',
            url: '/Token',
            data: loginData,
            success: (function (data) {
                $('.userName').text(data.userName);
                $('.userInfo').css('display', 'block');
                $('.loginForm').css('display', 'none');
                sessionStorage.setItem(tokenKey, data.access_token);
                console.log(data.access_token);
            }),
            fail: (function (data) {
            alert('Login failed');
            })
    });

    $('#logOut').click(function (e) {
        e.preventDefault();
        sessionStorage.removeItem(tokenKey);
    });
})});