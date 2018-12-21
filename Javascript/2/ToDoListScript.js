let tasks=new Array;
let tags=new Array;
let tab=document.createElement('TABLE');
let d=document.getElementById("TaskTable");
let Tasktags=new Array;

function Objtask(task,status){
    this.task=task;
    this.status=status;
    this.tags=Tasktags.slice();
}
document.getElementById("submit").addEventListener('click',listner);
function listner(){
    let taskname=document.getElementById("task").value;
    let status=document.getElementById("status").value;
    let obj=new Objtask(taskname,status);
    while(Tasktags.length){
        Tasktags.pop();
    }
    if(tasks.length){
        addTasks(obj);
    }
    else{
        createTable();
        addTasks(obj);
    }
}
function createTable(){
    document.createElement("hr");
    tab.setAttribute("border","2px");
    let tr=document.createElement('tr');
    td0=document.createElement('td');
    td1=document.createElement('td');
    td2=document.createElement('td');
    td3=document.createElement('td');
    td0.innerText="Completed";
    td1.innerText="TaskName";
    td2.innerText="Status";
    td3.innerText="Tags";
    tr.appendChild(td0);
    tr.appendChild(td1);
    tr.appendChild(td2);
    tr.appendChild(td3);
    tab.appendChild(tr);
}
function addTasks(object){
   tasks.push(object);
   updatetable();
   d.insertBefore(tab,d.childNodes[0]);
}
function updatetable(){
    document.getElementById("SearchText").value='';
    while(tab.firstChild){
       tab.removeChild(tab.firstChild);
    } 
    createTable();
    tasks.forEach(element => {
       let tr=document.createElement('tr');
         td0 = document.createElement('input');
         td0.type = 'checkbox';
         td1=document.createElement('td');
         td2=document.createElement('td');
         td3=document.createElement('td');
         if(element.status=="Completed"){
             td0.checked=true;
         }
         else{
             td0.checked=false;
         }
         td1.innerText=element.task;
         td2.innerText=element.status;
         td3.innerText=element.tags;
         tr.appendChild(td0);
         tr.appendChild(td1);
         tr.appendChild(td2);
         tr.appendChild(td3);
         tab.appendChild(tr);
   });   
}
function AddTags()
{
    tag=document.getElementById("tags").value;
    Tasktags.push(tag);
}
function RemoveCompleted()
{
    tasks=tasks.filter(x=>x.status!="Completed");
    updatetable();
}
function search(){
    let temp=tasks;
    let searchTask=document.getElementById("SearchText").value;
    tasks=tasks.filter(x=>x.task==searchTask);
    updatetable();
    tasks=temp;
}
