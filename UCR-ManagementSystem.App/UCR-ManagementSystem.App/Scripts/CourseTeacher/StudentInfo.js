
$("#StudentId").change(function () {
    //var departmentId = $("#DepartmentId").val();
    var studentId = $(this).val();
    //this ajax good for everything
    var params = { studentId: studentId };
    $.ajax({
        type: "POST",
        url: "/Student/GetStudentInfoByStudentId",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(params),
        success: function (rData) {
            if (rData != undefined && rData != null && rData != "") {
                $("#StudentName").empty();
                $("#StudentEmail").empty();
                $("#DepartmentName").empty();
                $("#CourseId").empty();
                $("#CourseId").append("<option value=''>Select...</option>");
                //$("#CreditTaken").append("<option value=''>View...</option>");
                $.each(rData, function (k, v) {
                    $("#StudentName").val(v.StudentName)
                    $("#StudentEmail").val(v.StudentEmail)
                    $("#DepartmentName").val(v.DepartmentName)
                    //$("#TeacherId").append("<option value='" + v.TeacherId + "'>" + v.TeacherName + "</option>");
                });
            }
        }
    });

    $.ajax({
        type: "POST",
        url: "/Student/GetCourseInfoByStudentId",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(params),
        success: function (rData) {
            if (rData != undefined && rData != null && rData != "") {       
                $.each(rData, function (k, v) {
                    $("#CourseId").append("<option value='" + v.CourseId + "'>" + v.CourseName + "</option>");
                });
            }
        }
    });
});