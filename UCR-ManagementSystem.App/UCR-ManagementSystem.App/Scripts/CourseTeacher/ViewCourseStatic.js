//$("#DepartmentId").change(function () {
//    //var departmentId = $("#DepartmentId").val();
//    var departmentId = $(this).val();
//    //alert("Sorry!! Name Already Exist");
//    //this ajax good for everything
//    //var params = { departmentId: departmentId };
//    url: "/CourseTeacher/GetCourseInfo",
//    //var url = "/Employee/OnDDLChange/?pId=" + deptSelectedValue;
//    $.ajax({
//        type: "POST",
//        url: '@Url.Action("GetCourseInfo")',
//        //url: "/CourseTeacher/GetCourseInfo",
//        //contentType: "application/json; charset=utf-8",
//        //data: JSON.stringify(params),
//        data: { departmentId: departmentId },
//        //success: function (data) {
//        //    $("#ViewCourseInfoList").val(data.jsonData);
//        //},
//        //error: function () {
//        //    alert("error");
//        //}

//        success: function (result) {
//            //alert(result);
//        //$("#gridTbl").empty();
//        $("#gridTbl").append(result);

//        },
//        error:function()
//        {
//          alert("No Records Found");
//        }
//        //success: function (rData) {
//        //    if (rData != undefined && rData != null && rData != "") {
//        //        //$("#TeacherId").empty();
//        //        //$("#CreditTaken").empty();
//        //        //$("#TeacherId").append("<option value=''>Select...</option>");
//        //        //$("#CreditTaken").append("<option value=''>View...</option>");

//        //        $.each(rData, function (k, v) {
//        //            $("#CourseCode").val(v.CourseCode, v.CourseName, v.Semester, v.AssignTo)
//        //            //$("#TeacherId").append("<option value='" + v.TeacherId + "'>" + v.TeacherName + "</option>");
//        //        });
//        //    }
//        //}
//    });
//});