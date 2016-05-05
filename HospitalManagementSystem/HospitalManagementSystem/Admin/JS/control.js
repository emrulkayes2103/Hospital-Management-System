
function showHide() {
    var div = document.getElementById("addDept");
   
    if (div.style.display !== "none") {
        div.style.display = "none";
        
    }
    else {
        div.style.display = "block";
        
    }

}

function showHideEditProfilepass()
{
   
    var div2 = document.getElementById("updateProBlock");
    
    var div = document.getElementById("UpdatePasswordblock");
    if (div.style.display !== "none") {
        div.style.display = "none";
        
    }
    else {
        div.style.display = "block";
        div2.style.display = "none";
    }
    document.getElementById("updatePass").focus();
}
function showHideEditProfileUpdate() {
    var div = document.getElementById("updateProBlock");
    var div2 = document.getElementById("UpdatePasswordblock");
    if (div.style.display !== "none") {
        div.style.display = "none";
        //div2.style.display = "block";
    }
    else {
        div.style.display = "block";
        div2.style.display = "none";
    }
    document.getElementById("btnSubmit").focus();
}
