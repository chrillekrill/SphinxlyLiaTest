// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const modal = document.getElementById("loginModal");

const modalLoginButton = document.getElementById("btn");

const container = document.getElementById("container");
const header = document.getElementById("header");

const close = document.getElementsByClassName("closeButton")[0];

modalLoginButton.addEventListener("click", () => {
    modal.classList.toggle('visible');
    container.classList.toggle('blur');
    container.classList.toggle('open');
    header.classList.toggle('blur');
});

close.addEventListener("click", () => {
    modal.classList.toggle('visible');
    container.classList.toggle('blur');
    container.classList.toggle('open');
    header.classList.toggle('blur');
});