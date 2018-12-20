$("#DepartmentId").change(function () {
    //var departmentId = $("#DepartmentId").val();
    var departmentId = $(this).val();
    //this ajax good for everything
    var params = { departmentId: departmentId };
    $.ajax({
        type: "POST",
        url: "/ClassRoomSchedule/GetCourseByDepartmentId",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(params),
        success: function (rData) {
            if (rData != undefined && rData != null && rData != "") {
                $("#CourseId").empty();
                $("#CourseId").append("<option value=''>Select...</option>");
                $.each(rData, function (k, v) {
                    $("#CourseId").append("<option value='" + v.CourseId+ "'>" + v.CourseName + "</option>");
                });
            }
        }
    });
});

//var isValid = true;
//$("#SubmitButton").click(function () {
//    //alert("Sorry.....");
//    if (!isValid) {
//        alert("Sorry.....");
//        return false;
//    }
  
//        var Fromtime = $("#FromTime").timepicker();
//        var ToTime = $("#ToTime").timepicker();
       
//        if (Fromtime >= ToTime) {
//            isValid = false;
//            //return;
//        }


//        //var address = $("#Address").val();
//        //if (address != undefined && address != "") {
//        //    $("#AddressValidationMsg").text("");
//        //    return true;
//        //}

//        //$("#AddressValidationMsg").text("Kichu Paini");
//        //return false;

//});
 

//var isValid = true;
//$("#Name").change(function () {
//    var name = $(this).val();
//    var url = "/Employee/IsNameExist";
//    var params = { name: name };
//    $.post(url, params, function (rData) {
//        if (rData === true) {
//            alert("Sorry!! Name Already Exist");
//            isValid = false;
//            return;
//        }
//    });
//});