// "Class" which realizes staffPage logic
function StaffControl() {
}

// True if searchTable have been filled
StaffControl.prototype.searchTableCreated = false;

// Executes POST Ajax request.
StaffControl.prototype.executeAjaxPostRequest = function(url, requestData, successFunc) {
    $.ajax(
      {
          url: url,
          type: "POST",
          contentType: "application/json",
          data: requestData,
          success: successFunc,
          error: function (xhr, status, p) {
              var err = "Error " + " " + status + " " + p;
              if (xhr.responseText && xhr.responseText[0] == "{")
                  err = JSON.parse(xhr.responseText).message;
              console.log(err);
          }
      });
}

// Populates a data into searchTable.
StaffControl.prototype.populateSearchTable = function (result) {
    if (!StaffControl.prototype.searchTableCreated) {
        StaffControl.prototype.searchTableCreated = true;
        $("#staffTable").bootstrapTable({
            data: result
        });
    } else {
        $("#staffTable").bootstrapTable("load", result);
    }
}

// Executes search staff Ajax request.
StaffControl.prototype.runAjaxSearchRequest = function (requestData) {
    StaffControl.prototype.executeAjaxPostRequest("/api/StaffData/SearchStaff", requestData, StaffControl.prototype.populateSearchTable);
}

// Executes Ajax request which takes departments from api and fill select control.
StaffControl.prototype.runAjaxDepartmentsRequest = function () {
    $.getJSON("/api/DepartmentData", null, function(data) {
        $("#departmentInput option").remove();
        $("#departmentInput").append( 
                $("<option></option>") 
                    .text("Отдел")
                    .val(0)
            );
        $.each(data, function (index, item) { 
            $("#departmentInput").append( 
                $("<option></option>")
                    .text(item.Name)
                    .val(item.ID)
            );
        });
    });
}

// Executes after click to search button.
StaffControl.prototype.runSearch = function () {
    var firstName = $("#firstNameInput").val();
    var lastName = $("#lastNameInput").val();
    var middleName = $("#middleNameInput").val();
    var birthday = $("#birthdayInput").val();
    var departmentID = $("#departmentInput").val();

    StaffControl.prototype.runAjaxSearchRequest(JSON.stringify({ FirstName: firstName, LastName: lastName, MiddleName: middleName, Birthday: birthday, DepartmentID: departmentID }));
}

// Inits an instance of the "class".
StaffControl.prototype.init = function () {
    StaffControl.prototype.runAjaxSearchRequest(null);
    StaffControl.prototype.runAjaxDepartmentsRequest();

    $(document).on("click", "#searchButton", this.runSearch);
}

$(document).ready(function () {
    var staffCtrl = new StaffControl();
    staffCtrl.init();
});