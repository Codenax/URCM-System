$(document).ready(function () {
    $("#StudentId").change(function () {
  
        $('#resultTable tbody').empty();
        //$("#StudentName").text("");
        //$("#StudentEmail").text("");
        ////$("#DepartmentName").text("");
        $.ajax({
            type: 'GET',
            url: "/Student/GetStudentByResultStudentId",
            datatype: JSON,
            data: { 'studentId': $("#StudentId").val() },
            success: function (data) {

            $.each(data, function (i, item) {
                $("#StudentName").val(item.StudentName)
                $("#StudentEmail").val(item.StudentEmail)
                $("#DepartmentName").val(item.DepartmentName)

                    var rows = "<tr>"
            + "<td>" + item.CourseCode + "</td>"
            + "<td>" + item.CourseName + "</td>"
            + "<td>" + item.GradeLatter + "</td>"
            + "</tr>";
                    $('#resultTable tbody').append(rows);
                });
            },
            error: function (data) { }
        });
    });
});
