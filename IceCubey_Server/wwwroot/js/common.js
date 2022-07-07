window.ShowToastr = (type, message) => {
    if (type == "success") {
        toastr.success(message, "Operation Successfull", { timeOut: 5000 });
    }
    if (type == "error") {
        toastr.error(message, "Operation Failed", { timeOut: 5000 });
    }
}