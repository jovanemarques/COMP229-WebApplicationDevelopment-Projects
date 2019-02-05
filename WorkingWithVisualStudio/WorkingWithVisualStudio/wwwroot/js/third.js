document.addEventListener("DOMContentLoad", function () {
    var element = document.createElement("p");
    element.textContent = "This a paragraph from third.js";
    document.querySelector("body").appendChild(element);
});