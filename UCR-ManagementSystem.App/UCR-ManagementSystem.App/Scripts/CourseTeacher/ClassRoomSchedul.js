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

   