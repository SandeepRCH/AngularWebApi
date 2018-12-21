let tasks=new Array;
let tags=new Array;
let tab=document.createElement('TABLE');
let d=document.getElementById("TaskTable");
let Tasktags=new Array;


var xhttp=new XMLHttpRequest();
xhttp.onreadystatechange=function(){
    if (this.readyState == 4 && this.status == 200)
    {
        tasks=this.response;
        createTable();
        updatetable();
    }
};

xhttp.open("GET","http://localhost:3000/tasks",true);
xhttp.responseType="json";
xhttp.send();






function Objtask(task,status){
    this.name=task;
    this.isCompleted=status;
    this.tags=Tasktags.slice();
}
document.getElementById("submit").addEventListener('click',listner);
function listner(){
    let taskname=document.getElementById("task").value;
    let status;
    if(document.getElementById("status").value=="Completed"){
         status=true;
    }
    else{
        status=false;
    }
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
   var xhr=new XMLHttpRequest();
   xhr.onreadystatechange=function(){
    console.log(this.readyState);
   }
   object=JSON.stringify(object);
   xhr.open("POST","http://localhost:3000/tasks",true);
   xhr.setRequestHeader("Content-type","application/json");
   xhr.send(object);
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
         if(element.isCompleted==true){
             td0.checked=true;
         }
         else{
             td0.checked=false;
         }
         td1.innerText=element.name;
         if(element.isCompleted==true){
            td2.innerText="Completed";
         }
         else{
             td2.innerText="Pending";
         }
         
         td3.innerText=element.tags;
         tr.appendChild(td0);
         tr.appendChild(td1);
         tr.appendChild(td2);
         tr.appendChild(td3);
         tab.appendChild(tr);
   }); 
   d.insertBefore(tab,d.childNodes[0]);  
}
function AddTags()
{
    tag=document.getElementById("tags").value;
    Tasktags.push(tag);
}
function RemoveCompleted()
{
    tasks=tasks.filter(x=>x.isCompleted!="Completed");
    updatetable();
}
function search(){
    let temp=tasks;
    let searchTask=document.getElementById("SearchText").value;
    tasks=tasks.filter(x=>x.name==searchTask);
    updatetable();
    tasks=temp;
}