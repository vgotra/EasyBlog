// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

function togglePublishOnDate() {
    const isPublished = document.getElementById('IsPublished').checked;
    const publishOnDate = document.getElementById('PublishOnDate');
    publishOnDate.value = isPublished ? "" : publishOnDate.value;
    publishOnDate.disabled = isPublished;
}
