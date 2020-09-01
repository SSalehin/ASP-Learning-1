function createPostForm(event) {
    event.preventDefault();
    let viewPanel = document.getElementById("view-panel");
    viewPanel.innerHTML = "";
    let form = document.createElement("form");
    form.id = "post-creation";
    viewPanel.appendChild(form);
    let inputField = document.createElement("textarea");
    inputField.type = "text";
    inputField.id = "written-post";
    inputField.style.width = "200%";
    inputField.style.height = "150px";
    form.appendChild(inputField);

    getTopics(createDropDown)
}

function createDropDown(data) {
    let form = document.getElementById("post-creation");

    let dropDownList = document.createElement("select");
    dropDownList.id = "topic-id";
    form.appendChild(dropDownList);

    data.forEach(function (topic) {
        let option = document.createElement("option");
        option.innerText = topic.Name;
        option.value = topic.Id;
        dropDownList.appendChild(option);
    })

    let submitButton = document.createElement("button");
    submitButton.type = "Submit";
    submitButton.textContent = "Create post";
    form.appendChild(submitButton);

    form.onsubmit = submitPost;
}

function submitPost() {
    let content = document.getElementById("written-post").value;
    let typeId = document.getElementById("topic-id").value;
    createPost(content, typeId);
}