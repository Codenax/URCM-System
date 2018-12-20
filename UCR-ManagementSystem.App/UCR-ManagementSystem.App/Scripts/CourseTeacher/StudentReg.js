//$("#SubmitButton").click(function () {
//    alert("Sorry.....");
//    alert(v.RegistrationNumber + " - " + v.StudentName + " - " + v.StudentEmail);
//    $.ajax({
//        type: "POST",
//        url: "/Student/StudentLastRegInfo",
//        contentType: "application/json; charset=utf-8",
//        data: JSON.stringify(params),
//        success: function (rData) {
//            if (rData != undefined && rData != null && rData != "") {               
//                $.each(rData, function (k, v) {

//                    alert(v.RegistrationNumber + " - " + v.StudentName + " - " + v.StudentEmail);

//                    //$("#EmployeeId").append("<option value='" + v.Id + "'>" + v.Name + "</option>");
//                });
//            }
//        }

//    });
//});




//<button onclick="myFunction()">Try it</button>

//<p id="demo"></p>

////<script>
//function myFunction() {
//    var txt;
//    if (confirm("Press a button!")) {
//        txt = "You pressed OK!";
//    } else {
//        txt = "You pressed Cancel!";
//    }
//    document.getElementById("demo").innerHTML = txt;
//}
////</script>











//    if (!isValid) {
//        alert("Sorry.....");
//        return false;
//    }

//    //this is for validation with logic
//    if (!isMale) {

//        var address = $("#Address").val();
//        if (address != undefined && address != "") {
//            $("#AddressValidationMsg").text("");
//            return true;
//        }

//        $("#AddressValidationMsg").text("Kichu Paini");
//        return false;
//    }


//});



//$("#SubmitButton").cleck(function () {

//    alert("Sorry.....");

    
//    $.ajax({
//        type: "POST",
//        url: "/Student/StudentCountbyDepartmentId",
//        contentType: "application/json charset:utf-8",
//        data: JSON.stringify(params),
//        success: function (rData) {
              


//            //if (rData == undefined && rData == null && rData == "" && rData == 0) {
//            //    var serial = 1;
//            //    var currentYear = (new Date).getFullYear();
//            //    var valuef = valueD + "-" + currentYear + "-" + serial;
//            //    $("#RegistrationNumber").val(valuef);
//            //}

//                if (rData != undefined && rData != null && rData != "") {
//                var serial = rData + 1;
//                var currentYear = (new Date).getFullYear();
//                if (serial < 10) valuef = valueD + "-" + currentYear + "-0000" + serial;
//                else if (serial >= 10 && serial < 100) valuef = valueD + "-" + currentYear + "-000" + serial;
//                else if (serial >= 100 && serial < 1000) valuef = valueD + "-" + currentYear + "-00" + serial;
//                else if (serial >= 1000 && serial < 10000) valuef = valueD + "-" + currentYear + "-0" + serial;
//                else valuef = valueD + "-" + currentYear + "-" + serial;
//                $("#RegistrationNumber").val(valuef);
//            }
//        }
//    });
//});