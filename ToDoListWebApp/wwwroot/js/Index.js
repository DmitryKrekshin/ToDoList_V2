'use strict'

document.addEventListener("DOMContentLoaded", () => {
    const taskDoneButtons = document.querySelectorAll('button[id*="TaskDone"]');
    taskDoneButtons.forEach(n =>
        n.addEventListener("click", taskDone)
    );
});

function taskDone(e) {
    const taskId = e.currentTarget.attributes.taskId.value;
    fetch(`Home/TaskDone?taskId=${taskId}`, {method: 'POST'})
        .then(response => console.log(response));
}