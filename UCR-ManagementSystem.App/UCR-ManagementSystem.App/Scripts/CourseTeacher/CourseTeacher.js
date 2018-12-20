$("#DepartmentId").change(function () {
    //var departmentId = $("#DepartmentId").val();
    var departmentId = $(this).val();
    //this ajax good for everything
    var params = { departmentId: departmentId };
    $.ajax({
        type: "POST",
        url: "/CourseTeacher/GetTeacherByDepartmentId",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(params),
        success: function (rData) {
            if (rData != undefined && rData != null && rData != "") {
                $("#TeacherId").empty();
                $("#CreditTaken").empty();
                $("#TeacherId").append("<option value=''>Select...</option>");
                $("#CreditTaken").append("<option value=''>View...</option>");

                $.each(rData, function (k, v) {

                    $("#TeacherId").append("<option value='" + v.TeacherId + "'>" + v.TeacherName + "</option>");
                });
            }
        }
    });

    $.ajax({
        type: "POST",
        url: "/CourseTeacher/GetCourseByDepartmentId",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(params),
        success: function (rData) {
            if (rData != undefined && rData != null && rData != "") {
                $("#CourseId").empty();

                $("#CourseId").append("<option value=''>Select...</option>");
  

                $.each(rData, function (k, v) {

                    $("#CourseId").append("<option value='" + v.CourseId + "'>" + v.CourseCode + "</option>");
                });
            }
        }
    });
});


$(document.body).on("change", "#TeacherId", function () {
    var teacherTd = $(this).val();
    var url = "/CourseTeacher/GetTeacherInfoByTeacherId";
    var params = { teacherTd: teacherTd };
    //this ajax good for element/page nodata
    $.post(url, params, function (rData) {
        $("#CreditTaken").empty();
        $("#RemainingCredit").empty();

        $.each(rData, function (k, v) {
            $("#CreditTaken").val(v.CreditTeken)
            $("#RemainingCredit").val(v.RemainingCredit)
            //$("#RemainingCredit").append("<option value='" + v.CreditTaken + "'>" + v.CreditTaken + "</option>");
        });
    });
});

$("#CourseId").change(function () {
    //var departmentId = $("#DepartmentId").val();
    var courseId = $(this).val();
    //this ajax good for everything
    var params = { courseId: courseId };
    $.ajax({
        type: "POST",
        url: "/CourseTeacher/GetCourseCourseId",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(params),
        success: function (rData) {
            if (rData != undefined && rData != null && rData != "") {
                $("#CourseName").empty();
                $("#CourseCredit").empty();

                $.each(rData, function (k, v) {
                    $("#CourseName").val(v.CourseName)
                    $("#AssignCourseCredit").val(v.CourseCredit)
                    //$("#CourseName").append("<option value='" + v.CourseName + "'>" + v.CourseName + "</option>");
                    //$("#CourseCredit").append("<option value='" + v.CourseCredit + "'>" + v.CourseCredit + "</option>");
                });
            }
        }
    });
});





//$("#SubmitButton").click(function () {
//    function calc() {
//        var Ct = parseFloat(document.getElementById('CreditTaken').value);
//        var Rm = parseFloat(document.getElementById('RemainingCredit').value);
//        var Nct = parseFloat(document.getElementById('AssignCourseCredit').value);

//        var oper = document.getElementById('operators').value;

//        if (Rm < Nct) {
//            alert("ok");  
//        }
//        else{
//            alert("no");
//        }
//    }

//});