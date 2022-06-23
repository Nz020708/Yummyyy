let menu=document.querySelector(".dropdown-menu");
let deepmenu=document.querySelector(".deep-menu");
let dropdown=document.querySelector(".dropdown")
let dropdownli=document.querySelector(".dropdown-li")
dropdown.onmouseover=function() {
    menu.style.display="block";
}
dropdown.onmouseout=function() {
    menu.style.display="none";
}
dropdownli.onmouseover=function() {
    deepmenu.style.display="block";
    deepmenu.style.color="red";
}
dropdownli.onmouseout=function() {
    deepmenu.style.display="none";
}