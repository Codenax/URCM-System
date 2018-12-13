$(document).ready(function () {
    $("#DepartmentId").change(function () {
        $('#SchedulTable tbody').empty();
        $.ajax({
            type: 'GET',
            url: "/ClassRoomSchedule/viewCourseScheduleByDepartmentId",
            //url: '@Url.Action("GetCourseInfo")',
            datatype: JSON,
            data: { 'departmentId': $("#DepartmentId").val() },
            success: function (data) {
                //$('#blogTable tbody').empty();

                $.each(data, function (i, item) {
                    var rows = "<tr>"
            + "<td>" + item.CourseCode + "</td>"
            + "<td>" + item.CourseName + "</td>"
            + "<td>" + item.Schedule + "</td>"
            + "</tr>";
                    $('#SchedulTable tbody').append(rows);
                });
            },
            error: function (data) { }
        });
    });
});
