function showTopics(topicList) {
    let aspBody = document.getElementsByClassName("body-content");
    for (let item of aspBody) {
        item.innerHTML = "";
    }

    let viewPanel = document.getElementById("view-panel");
    viewPanel.innerHTML = "";
    let list = document.createElement("ul");
    viewPanel.appendChild(list);

    topicList.forEach(function (topic) {
        let topicHtml = '<li><a onClick="showPostsByTopic(' + topic.Id + ')"><b>' + topic.Name + '</b></a></li>';
        list.innerHTML += topicHtml;
    })
}