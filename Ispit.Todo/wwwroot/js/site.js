$(function () {
  window.$('#myCheckbox').on("change",function () {
    if (this.checked) {
      var taskId = window.$(this).data('task-id');
      window.$("#myCheckbox").hide();
      window.$.post("/TaskItems/UpdateTaskStatus", { id: taskId }, function (data) {
       
      });
    }
  });
});