
 $(document).ready(function () {
     $("#DepartmentId").change(function () {
           $('#blogTable tbody').empty();
            $.ajax({
                type: 'GET',
                url: "/CourseTeacher/GetCourseInfo",
                //url: '@Url.Action("GetCourseInfo")',
                datatype: JSON,
                data: { 'departmentId': $("#DepartmentId").val() },
                success: function (data) {
                    //$('#blogTable tbody').empty();

                    $.each(data, function (i, item) {
                        var rows = "<tr>"
                + "<td>" + item.CourseCode + "</td>"
                + "<td>" + item.CourseName + "</td>"
                + "<td>" + item.Semester + "</td>"
                + "<td>" + item.AssignTo + "</td>"
                + "</tr>";
                        $('#blogTable tbody').append(rows);
                    });
                },
                error: function (data) { }
            });
        });
    });
