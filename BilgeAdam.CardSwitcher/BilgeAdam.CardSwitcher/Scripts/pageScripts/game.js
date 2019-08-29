var gs = null;
$(document).ready(function () {
    //Burası GameHub class'ının çağırdığı client methodlarıdır
    gs = $.connection.gameHub;
    gs.client.switchCard = function (loc) {
        //LINQ
        //cards.First(i => i.location == loc);

        //(Underscore)
        var card = _.find(game.cards, function (c) {
            return c.location === loc;
        });
        if (card) {
            card.isActive = true;
        }
    };

    gs.client.setCardDesign = function (designJson) {
        var cards = JSON.parse(designJson);
        var unsortedCards = [];
        for (var i = 1; i <= 18; i++) {
            unsortedCards.push({
                cardName: i,
                location: cards[i].Point1,
                path: "/Images/cards/" + i + ".jfif",
                isMatched: false,
                isActive: false
            });
            unsortedCards.push({
                cardName: i,
                location: cards[i].Point2,
                path: "/Images/cards/" + i + ".jfif",
                isMatched: false,
                isActive : false
            });
        }
        //unsortedCards.OrderBy(i => i.location).ToList();
        game.cards = _.sortBy(unsortedCards, function (c) { return c.location });
        game.gameIdle = false;
    };

    gs.client.matchCards = function (location1, location2) {
        console.log(location1 + " - " + location2);
    };

    gs.client.getTurn = function () {
        game.canPlay = true;
    };

    gs.client.turnBackCards = function (l1, l2) {
        //cards.Where(i => i.location == l1 || i.location == l2).ToList();

        var cards = _.filter(game.cards, function (c) {
            return c.location === l1 || c.location == l2;
        });

        cards.forEach(function (c) {
            c.isActive = false;
        });
    }

    $.connection.hub.start().done(function () {
        console.log("Bağlantı sağlandı");
    });

    $.connection.hub.disconnected(function () {
        gs.server.disconnect(userName);
    });
});

var game = new Vue({
    el: "#ctx",
    data: {
        clickCount: 0,
        status: true,
        canFlip: true,
        switched: [],
        points: [],
        cards: [],
        canPlay: false,
        gameIdle : true
    },
    methods: {
        boxClick: function (card) {
            if (!this.canPlay) {
                return;
            }
            if (card.isMatched) {
                return;
            }
            gs.server.switchCard(card.location);
            this.switched.push(card);
            card.isActive = true;
            this.clickCount++;
            if (this.clickCount === 2) {
                if (this.switched[0].cardName === this.switched[1].cardName &&
                    this.switched[0].location !== this.switched[1].location) {
                    this.switched[0].isMatched = true;
                    this.switched[1].isMatched = true;
                    this.points.push(this.switched[0]);
                    this.points.push(this.switched[1]);
                    this.clickCount = 0;
                    gs.server.match(this.switched[0].location, this.switched[1].location);
                    this.switched = [];
                }
                else {
                    this.clickCount = 0;
                    this.canPlay = false;
                    var self = this;
                    setTimeout(function () {
                        self.switched[0].isActive = false;
                        self.switched[1].isActive = false;
                        gs.server.turnBackCards(self.switched[0].location, self.switched[1].location);
                        self.switched = [];
                    }, 1000);
                    
                    gs.server.changeTurn();
                }
                
            }
        },
        start: function () {
            gs.server.getDesign(userName);
            this.canPlay = true;
            this.gameIdle = false;
        }
    }
});