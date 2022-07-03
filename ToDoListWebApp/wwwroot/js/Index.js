'use strict'

document.addEventListener("DOMContentLoaded", () => {
    const taskInfoPanel = document.querySelectorAll('div[id*="TaskInfo"]');
    taskInfoPanel.forEach(g => g.addEventListener("mouseover", showTaskBtnGroup));
    taskInfoPanel.forEach(g => g.addEventListener("mouseout", hideTaskBtnGroup));

    const taskDoneButtons = document.querySelectorAll('button[id*="TaskDone"]');
    taskDoneButtons.forEach(n => n.addEventListener("click", taskDone));

    const editBtn = document.querySelectorAll('button[id*="EditTask"]');
    editBtn.forEach(btn => btn.addEventListener("click", showTaskEditForm));

    const closeEditBtn = document.querySelectorAll('button[id*="Cancel"]');
    closeEditBtn.forEach(btn => btn.addEventListener("click", hideTaskEditForm));

    const saveChangesBtn = document.querySelectorAll('button[id*="SaveChanges"]');
    saveChangesBtn.forEach(btn => btn.addEventListener("click", saveChanges));
});

function taskDone(e) {
    const taskId = e.currentTarget.attributes.taskId.value;
    fetch(`Home/TaskDone?taskId=${taskId}`, {method: 'POST'})
        .then(response => console.log(response));
}

function showTaskBtnGroup(e) {
    e.currentTarget.querySelector('div[id*="TaskBtnGroup"]').style.visibility = "visible";
}

function hideTaskBtnGroup(e) {
    e.currentTarget.querySelector('div[id*="TaskBtnGroup"]').style.visibility = "hidden";
}

function showTaskEditForm(e) {
    const taskId = e.currentTarget.attributes.taskId.value;
    const taskEditPanel = document.querySelector(`div[id="{${taskId}}_TaskEditPanel"]`);
    taskEditPanel.style.display = "block";

    const taskInfo = document.querySelector(`div[id="{${taskId}}_TaskInfo"]`);
    taskInfo.style.display = "none";

    fillTaskEditFormWithData(taskEditPanel, taskInfo);
}

function fillTaskEditFormWithData(taskEditPanel, taskInfo) {
    let taskId = parseInt(/.*\{(.*)\}./gm.exec(taskInfo.id)[1]);
    let taskText = taskInfo.querySelector(`p[id="{${taskId}}_TaskName"]`).textContent;
    taskEditPanel.querySelector(`input[id="{${taskId}}_EditInput"]`).value = taskText;
}

function hideTaskEditForm(e) {
    const taskId = e.currentTarget.attributes.taskId.value;
    const taskEditPanel = document.querySelector(`div[id="{${taskId}}_TaskEditPanel"]`);
    taskEditPanel.style.display = "none";

    changeInputShowValidationMessage(taskId, false);
    
    const taskInfo = document.querySelector(`div[id="{${taskId}}_TaskInfo"]`);
    taskInfo.style.display = "flex";
}

function saveChanges(e) {
    const taskId = parseInt(e.currentTarget.attributes.taskId.value);
    const text = document.querySelector(`input[id="{${taskId}}_EditInput"]`).value;

    if(!text.trim()){
        changeInputShowValidationMessage(taskId, true);
        return;
    }
    changeInputShowValidationMessage(taskId, false);
    
    fetch(`Home/UpdateTask?id=${taskId}&name=${text}`, {method: 'POST'})
        .then(response => response.ok ? location.reload(): _);
}

function changeInputShowValidationMessage(taskId, isVisible) {
    let display = 'none';
    if(isVisible){
        display = 'block';
    }
    
    document.querySelector(`div[id="{${taskId}}_TaskEditPanel"]`).querySelector('span.text-danger').style.display = display;
}