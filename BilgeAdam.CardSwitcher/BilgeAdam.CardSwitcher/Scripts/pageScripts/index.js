var gs = null;
$(document).ready(function () {
    gs = $.connection.gameHub;
    gs.client.refreshPlayers = function (users) {
        game.users = users;
    };
    $.connection.hub.start();
});

var game = new Vue({
    el: "#gamearea",
    data: {
        users : []
    }
})