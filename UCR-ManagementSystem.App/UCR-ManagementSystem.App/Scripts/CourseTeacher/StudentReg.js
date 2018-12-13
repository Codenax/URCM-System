$("#DepartmentId").change(function () {
    var departmentId = $(this).val();
    var valueD = $("#DepartmentId option:selected").text();
    var params = { departmentId: departmentId }
    
    $.ajax({
        type: "POST",
        url: "/Student/StudentCountbyDepartmentId",
        contentType: "application/json charset:utf-8",
        data: JSON.stringify(params),
        success: function (rData) {
              


            //if (rData == undefined && rData == null && rData == "" && rData == 0) {
            //    var serial = 1;
            //    var currentYear = (new Date).getFullYear();
            //    var valuef = valueD + "-" + currentYear + "-" + serial;
            //    $("#RegistrationNumber").val(valuef);
            //}

                if (rData != undefined && rData != null && rData != "") {
                var serial = rData + 1;
                var currentYear = (new Date).getFullYear();
                if (serial < 10) valuef = valueD + "-" + currentYear + "-0000" + serial;
                else if (serial >= 10 && serial < 100) valuef = valueD + "-" + currentYear + "-000" + serial;
                else if (serial >= 100 && serial < 1000) valuef = valueD + "-" + currentYear + "-00" + serial;
                else if (serial >= 1000 && serial < 10000) valuef = valueD + "-" + currentYear + "-0" + serial;
                else valuef = valueD + "-" + currentYear + "-" + serial;
                $("#RegistrationNumber").val(valuef);
            }
        }
    });
});