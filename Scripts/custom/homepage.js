//import { post } from "jquery";

function showAllPosts() {
    getUsers(function (users) {
        getPosts(function (posts) {
            displayPosts(posts);
        });
    });
}

function showPostsByEmail(email) {
    getUsers(function (users) {
        getPostByUserEmail(email, function (posts) {
            //alert(JSON.stringify(posts));
            displayPosts(posts);
        });
    });
}

function showPostsByTopic(topicId) {
    getPostByTopic(topicId, displayPosts);
}

function displayPosts(posts) {
    let aspBody = document.getElementsByClassName("body-content");
    for (let item of aspBody) {
        item.innerHTML = "";
    }

    let viewPanel = document.getElementById("view-panel");
    viewPanel.innerHTML = "";
    let postList = document.createElement("ul");
    viewPanel.appendChild(postList);
    posts.forEach(function (post) {
        let postElement = createPostElement(post);
        postList.appendChild(postElement);
    })
}

function createPostElement(post) {
    let container = document.createElement("li");
    let content = document.createElement("p");
    content.innerText = post.Content;
    container.appendChild(content);

    let topicName;
    TOPICS.forEach(function (topic) {
        if (topic.Id == post.TopicId) topicName = topic.Name;
    });
    if (topicName == "") topicName = "Miscellaneous";


    let topicHtml = '<br/><a onClick="showPostsByTopic(' + post.TopicId + ')">Topic: <b>' + topicName + '</b></a>';
    content.innerHTML += topicHtml;

    let userHtml = '<a onClick = "showPostsByEmail(\'' + post.UserEmail + '\')"><i>' + post.UserEmail + '</i></a><br/><hr/>';
    container.innerHTML += userHtml;
    container.style.margin = "0px";
    container.style.padding = "0px";
    return container;
}