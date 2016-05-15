function StaffControl() {
}

StaffControl.prototype.runAjaxSearchRequest = function (isInit, requestData) {
    $.ajax(
    {
        url: "/api/StaffData/SearchStaff",
        type: "POST",
        contentType: "application/json",
        data: requestData,
        success: function (result) {
            if (isInit) {
                $("#staffTable").bootstrapTable({
                    data: result
                });
            } else {
                $('#staffTable').bootstrapTable('load', result);
            }
        },
        error: function (xhr, status, p) {
            var err = "Error " + " " + status + " " + p;
            if (xhr.responseText && xhr.responseText[0] == "{")
                err = JSON.parse(xhr.responseText).message;
            console.log(err);
        }
    });
}

StaffControl.prototype.runSearch = function () {
    var firstName = $('#firstNameInput').val();
    var lastName = $('#lastNameInput').val();
    var middleName = $('#middleNameInput').val();
    var birthday = $('#birthdayInput').val();

    StaffControl.prototype.runAjaxSearchRequest(false, JSON.stringify({ FirstName: firstName, LastName: lastName, MiddleName: middleName, Birthday: birthday }));
}

StaffControl.prototype.init = function () {
    StaffControl.prototype.runAjaxSearchRequest(true, null);

    $(document).on('click', '#searchButton', this.runSearch);
}

$(document).ready(function () {
    var staffCtrl = new StaffControl();
    staffCtrl.init();
});


