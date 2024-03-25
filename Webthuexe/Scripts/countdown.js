var countdown = 300; // 5 minutes in seconds

var timer = setInterval(function () {
    var minutes = Math.floor(countdown / 60);
    var seconds = countdown % 60;

    document.getElementById('countdown').innerHTML = minutes + ':' + (seconds < 10 ? '0' : '') + seconds;

    countdown--;

    if (countdown < 0) {
        clearInterval(timer);
        alert("Thời gian thanh toán trực tuyến đã hết");
        document.getElementById('hidden').display.style = "none";
    }
}, 1000);