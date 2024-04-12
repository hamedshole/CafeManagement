export function MakeActive(id) {
    debugger
    var all = document.getElementsByClassName("nav-link active")
    var t = all.item(0).classList
    all.item(0).classList.remove("active")
    var t = document.getElementById(id)
    t.classList.add("active");
}