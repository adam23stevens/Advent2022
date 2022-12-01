window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, "Successful!", { timeout: 5000 });
    }
    if (type === "error") {
        toastr.error(message, "Error!", { timeout: 5000 });
    }
}

window.ShowSweetAlert = (type, message) => {
    if (type === "success") {
        Swal.fire(message, "", "success");
    }
    if (type === "error") {
        Swal.fire(message, "", "error");
    }
}

function ShowConfirmationModal() {
    $('#deleteConfirmationModal').modal('show');
}

function HideConfirmationModal() {
    $('#deleteConfirmationModal').modal('hide');
}