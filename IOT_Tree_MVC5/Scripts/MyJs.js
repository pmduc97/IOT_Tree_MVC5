var map, infoWindow;

function initMap() {
    map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: 16.0801734924316, lng: 108.219017028809 },
        zoom: 8
    });
}
function getHinhVuong() {
    var databaseName = $('#databaseName').val()
    var tableName = $('#tableName').val()
    var lat = $('#lat').val()
    var lng = $('#lng').val()
    var banKinh = $('#banKinh').val()

    map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: Number(lat), lng: Number(lng) },
        zoom: 19
    });



    $.ajax({
        url: '/Tree/GetHinhVuong',
        data: { databaseName: databaseName, tableName: tableName, lat: lat, lng: lng, banKinh: banKinh },
        type: 'post',
        dataType: 'json',
        success: function (res) {
            if (res.code == -1) {
                alert("Chưa đăng nhập");
                return false;
            }
            if (res.code == -2) {
                alert("Thông tin nhập vào không đầy đủ");
                return false;
            }
            if (res.code == -101) {
                alert("Dữ liệu không hợp lệ");
                return false;
            }
            var html = '';
            var i = 0;
            $.each(res.data, function (key, item) {
                
                var marker = new google.maps.Marker({
                    position: { lat: item.Lat, lng: item.Lng },
                    map: map,
                    label : item.Lat == res.lat && item.Lng == res.lng ? "Gốc":""
                });
                
                html += '<tr><td>' + item.CayXanh + '</td><td>' + item.Lat + '</td><td>' + item.Lng + '</td></tr>';
                i = i + 1;
            });
            $('#msg').html('<span>Hình Vuông: ' + i + ' Item' + '</span>');
            $('#table_body').html(html);

        }

    });
    return false;
}

function getHinhTron() {
    var databaseName = $('#databaseName').val()
    var tableName = $('#tableName').val()
    var lat = $('#lat').val()
    var lng = $('#lng').val()
    var banKinh = $('#banKinh').val()

    map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: Number(lat), lng: Number(lng) },
        zoom: 19
    });


    $.ajax({
        url: '/Tree/GetHinhTron',
        data: { databaseName: databaseName, tableName: tableName, lat: lat, lng: lng, banKinh: banKinh },
        type: 'post',
        dataType: 'json',
        success: function (res) {
            if (res.code == -1) {
                alert("Chưa đăng nhập");
                return false;
            }
            if (res.code == -2) {
                alert("Thông tin nhập vào không đầy đủ");
                return false;
            }
            if (res.code == -101) {
                alert("Dữ liệu không hợp lệ");
                return false;
            }
            var html = '';
            var i = 0;
            $.each(res.data, function (key, item) {
                var marker = new google.maps.Marker({
                    position: { lat: item.Lat, lng: item.Lng },
                    map: map,
                    label: item.Lat == res.lat && item.Lng == res.lng ? "Gốc" : ""
                });

                html += '<tr><td>' + item.CayXanh + '</td><td>' + item.Lat + '</td><td>' + item.Lng + '</td></tr>';
                i = i + 1;
            });
            $('#msg').html('<span>Hình Tròn: ' + i + ' Item' + '</span>');
            $('#table_body').html(html);

        }

    });
    return false;
}