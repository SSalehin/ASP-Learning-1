
function showUsers(users) {
    let aspBody = document.getElementsByClassName("body-content");
    for (let item of aspBody) {
        item.innerHTML = "";
    }

    let viewPanel = document.getElementById("view-panel");
    viewPanel.innerHTML = "<h2>A list of current site users:";
    let list = document.createElement("ul");
    users.forEach(function (user) {
        //alert(JSON.stringify(user.Name));
        let userHtml = '<li><a onClick = "showPostsByEmail(\'' + user.Email + '\')"><i>' + user.Email + '</i></a></li>';
        list.innerHTML += userHtml;

    })
    viewPanel.appendChild(list);
}