(function () {
    $(document).ready(function () {
        $("#Province").change(function () {
            var id = $(this).val();
            $("#district").empty();
            $.get("/Local/District_Bind", { provinceId: id }, function (data) {
                var v = "<option>---Quận Huyện---</option>";
                $.each(data, function (i, v1) {
                    v += "<option value=" + v1.id + ">" + v1.type + " " + v1.name + "</option>";
                });
                $("#district").html(v);
            });
        });
        $("#district").change(function () {
            var id = $(this).val();
            $("#ward").empty();
            $.get("/Local/Ward_Bind", { districtId: id }, function (data) {
                var v = "<option>---Xã Phường---</option>";
                $.each(data, function (i, v1) {
                    v += '<option value=' + v1.id + '>' + v1.type + " " + v1.name + '</option>';
                });
                $("#ward").html(v);
            });
        });
    });
})();
