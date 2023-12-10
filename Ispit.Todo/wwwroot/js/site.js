$(function () {
  $('#myCheckbox').on('change',function () {
    if (this.checked) {
      var taskId = $(this).data('task-id');
      $.post('/TaskItems/UpdateTaskStatus', { id: taskId }, function (data) {
        // Handle the response here
      });
    }
  });
});