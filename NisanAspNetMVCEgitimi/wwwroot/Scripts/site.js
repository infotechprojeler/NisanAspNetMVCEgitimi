$("#getir").click(function () {
    $.ajax({
        url: "/Ajaxicerik.txt", // ajax isteğini göndereceğimiz adres
        success: function (sonuc) { // işlem başarılı olursa çalışacak kod bloğu
            $("#ajax").html(sonuc)
        },
        error: function () { // işlem başarısız olursa çalışacak kod bloğu
            $("#ajax").html("Hata oluştu!")
            console.error("hata oluştu")
        }
    })
})