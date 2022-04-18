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
    
});

function taskDone(e) {
    const taskId = e.currentTarget.attributes.taskId.value;
    fetch(`Home/TaskDone?taskId=${taskId}`, {method: 'POST'});
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
}

function hideTaskEditForm(e) {
    const taskId = e.currentTarget.attributes.taskId.value;
    const taskEditPanel = document.querySelector(`div[id="{${taskId}}_TaskEditPanel"]`);
    taskEditPanel.style.display = "none";
    
    const taskInfo = document.querySelector(`div[id="{${taskId}}_TaskInfo"]`);
    taskInfo.style.display = "flex";
}