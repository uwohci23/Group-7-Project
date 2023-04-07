"use strict"

class CoinBox extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            max: 7,
            min: 3,
            coins: [],
            coinPositions: [],
            floorboxCoins: [],
            floorboxValue: 0,
            count: 0,
            total: 0,
            win: false,
            tooltipsOn: this.props.isTutorial,
        };

        this.setUpCoins = this.setUpCoins.bind(this);
        this.setUpFloor = this.setUpFloor.bind(this);
        this.setUpFloorBox = this.setUpFloorBox.bind(this);
        this.setUpTooltips = this.setUpTooltips.bind(this);

        this.restart = this.restart.bind(this);

        this.handleAnswerEnter = this.handleAnswerEnter.bind(this);
        this.handleAnswer = this.handleAnswer.bind(this);
        this.handleCloseWinPopup = this.handleCloseWinPopup.bind(this);

        this.spawnCoins = this.spawnCoin.bind(this);
        this.despawnCoins = this.despawnCoins.bind(this);


        this.toggleTooltips = this.toggleTooltips.bind(this);

        this.exchangeCoins = this.exchangeCoins.bind(this);

        this.despawn2 = this.despawn2.bind(this);
    }

    // TODO: Make closing the WIN and LOSE popups nicer on esc and enter

    setUpCoins() {
        console.log("SETTING UP COINS");

        // Generate random number of coins
        const numCoins = Math.floor(Math.random() * (this.state.max - this.state.min + 1) + this.state.min);
        console.log("random: ", numCoins);

        // store values in temp
        let temp = [];
        for (let i = 0; i < numCoins; i++) {
            temp.push(i);
        }

        console.log("temp ", temp)

        // set state of coins to temp
        this.setState({
            coins: this.state.coins.concat(temp)
        });

        let floor = this.floorDiv;
        let width = floor.offsetWidth - 100;
        let height = floor.offsetHeight - 100;

        console.log("FLORR: ", floor)

        // this doesnt do anything its just for testing
        var $this = $(ReactDOM.findDOMNode(this));
        console.log($this[0])

        let tempPos = [];
        let tempTotal = 0;

        for (let id of temp) {
            console.log("#" + "coin" + id);

            let randWidth = Math.floor(Math.random() * width);
            let randHeight = Math.floor(Math.random() * height);

            // Store position of coin as array of tuples [[top1, left1], [top2, left2], ...]
            tempPos.push([[(height - randHeight), (width - randWidth)]]);


            // Generate random coin
            let randomizeCoin = Math.floor(Math.random() * (4 - 1 + 1) + 1);
            let randomCoin = "";
            let dollarValue = "";
            if (randomizeCoin === 4) {
                randomCoin = "quarter";
                dollarValue = "25";
            } else if (randomizeCoin === 3) {
                randomCoin = "dime";
                dollarValue = "10";
            } else if (randomizeCoin === 2) {
                randomCoin = "nickel";
                dollarValue = "5";
            } else {
                randomCoin = "penny";
                dollarValue = "1";
            }

            tempTotal += parseInt(dollarValue);


            // makes the coin with that id draggable
            $(function () {
                $("#" + "coin" + id).mouseover(
                    function () {
                        $(this).css("cursor", "grab");
                    },

                );
                $("#" + "coin" + id).draggable({
                    cursor: "grabbing",
                    containment: "#playable-area"
                });
                $("#" + "coin" + id).addClass(randomCoin);
                $("#" + "coin" + id).attr("dollarValue", dollarValue);
                $("#" + "coin" + id).attr("title", dollarValue);

                // x is left, y is top
                $("#" + "coin" + id).css("top", `+=${(height - randHeight)}`);
                $("#" + "coin" + id).css("left", `+=${(width - randWidth)}`);

            });
        }

        this.setState({ total: tempTotal });

        this.setState({
            coinPositions: tempPos
        });

        console.log(tempPos)
    }

    setUpFloor() {
        let floor = document.getElementById("floor");
        var droppedCoin = "";


        $("#floor").droppable({
            drop: function (event, ui) {
                droppedCoin = ui.draggable[0].id;
                $('#floor').attr("data-coin", droppedCoin);
                console.log("DROPPED: ", droppedCoin)
                // check for collisions with other draggable elements
                var draggable = ui.draggable;
                var draggableOffset = draggable.offset();
                var draggableWidth = draggable.outerWidth();
                var draggableHeight = draggable.outerHeight();
                $(".coin").each(function (index, element) {
                    if (draggable[0] !== element) { // ignore self
                        var elementOffset = $(element).offset();
                        var elementWidth = $(element).outerWidth();
                        var elementHeight = $(element).outerHeight();
                        if (draggableOffset.left + draggableWidth > elementOffset.left &&
                            draggableOffset.top + draggableHeight > elementOffset.top &&
                            draggableOffset.left < elementOffset.left + elementWidth &&
                            draggableOffset.top < elementOffset.top + elementHeight) {
                            // overlapping detected, prevent drop
                            draggable.draggable("option", "revert", true);
                            return false;
                        } else {
                            draggable.draggable("option", "revert", false);
                            return true;
                        }
                    }
                });
            }
        });
    }

    setUpFloorBox() {
        // makes the floorbox droppable (things can be dropped into it so it can trigger other things)
        let floor1 = document.getElementById("floorbox");
        let ball2 = floor1.getAttribute("data-coin");
        console.log(ball2);

        let droppedCoin = "";

        $("#floorbox").droppable({
            accept: ".coin",
            classes: {
                "ui-droppable-active": "ui-state-active"
            },
            drop: function (event, ui) {
                droppedCoin = ui.draggable[0].id;
                $('#floor').attr("data-coin", droppedCoin);
                console.log("DROPPED: ", droppedCoin)
                // check for collisions with other draggable elements
                var draggable = ui.draggable;
                var draggableOffset = draggable.offset();
                var draggableWidth = draggable.outerWidth();
                var draggableHeight = draggable.outerHeight();
                $(".coin").each(function (index, element) {
                    if (draggable[0] !== element) { // ignore self
                        var elementOffset = $(element).offset();
                        var elementWidth = $(element).outerWidth();
                        var elementHeight = $(element).outerHeight();
                        if (draggableOffset.left + draggableWidth > elementOffset.left &&
                            draggableOffset.top + draggableHeight > elementOffset.top &&
                            draggableOffset.left < elementOffset.left + elementWidth &&
                            draggableOffset.top < elementOffset.top + elementHeight) {
                            // overlapping detected, prevent drop
                            draggable.draggable("option", "revert", true);
                            return false;
                        } else {
                            draggable.draggable("option", "revert", false);
                            return true;
                        }
                    }
                });
            }
        });

    }



    setUpTooltips() {

        if (this.props.isTutorial) {
            document.onkeyup = (event) => {
                if (event.key === "t") {
                    document.getElementById("toggle").checked = !document.getElementById("toggle").checked;
                    this.setState(prevState => ({
                        tooltipsOn: !prevState.tooltipsOn
                    }))
                }
            }

            $("#answer").tooltip();
            $("#check-answer").tooltip();
            $(".coin").tooltip({
                show: { effect: "blind", duration: 200, delay: 500 },
                hide: { effect: "blind", duration: 200 }
            });
            $("#floor").tooltip();
            $("#floorbox").tooltip();
            $("#exchanger").tooltip();
            $("#instructions-button").tooltip();
        }
    }



    toggleTooltips() {

        console.log("TOOLTIPS?: ", this.state.tooltipsOn)

        if (this.state.tooltipsOn) {
            $("#answer").tooltip("enable");
            $("#check-answer").tooltip("enable");
            $(".coin").tooltip("enable");
            $("#floor").tooltip("enable");
            $("#floorbox").tooltip("enable");
            $("#exchanger").tooltip("enable");
            $("#instructions-button").tooltip("enable");
            console.log("ENABLED!")
        } else {
            $("#answer").tooltip("disable");
            $("#check-answer").tooltip("disable");
            $(".coin").tooltip("disable");
            $("#floor").tooltip("disable");
            $("#floorbox").tooltip("disable");
            $("#exchanger").tooltip("disable");
            $("#instructions-button").tooltip("disable");
            console.log("DISABLED!")
        }
    }

    // Triggers on intial render
    componentDidMount() {
        console.log("MOUNT")


        this.setUpCoins();
        this.setUpFloor();
        this.setUpFloorBox();
        this.setUpTooltips();


    }

    // Triggers on every render (including initial render)
    componentDidUpdate(prevProps, prevState) {
        console.log("UPDATE")

        // Setup everything again on restart
        if (this.state.count !== prevState.count || this.state.win) {
            this.setState({ win: false });
            this.setUpCoins();
        } else if (this.state.coins !== prevState.coins) {
            this.setUpTooltips();
        } else if (this.state.tooltipsOn !== prevState.tooltipsOn) {
            this.toggleTooltips();
        }
    }

    restart() {
        let empty = [];
        this.setState({
            coins: empty,
            total: 0,
            count: this.state.count + 1
        });
    }

    handleAnswerEnter(event) {
        if (event.key === "Enter") {
            this.handleAnswer();
        }
    }

    handleAnswer() {
        let answer = document.getElementById("answer").value;
        if (parseInt(answer) === this.state.total) {
            console.log("WIN")
            document.getElementById('win-popup').style.display = "grid";
            const popup = document.querySelector('#win-popup');
            popup.showModal();

            let empty = [];
            this.setState({
                coins: empty,
                total: 0,
                win: true
            });

        } else {
            console.log("WRONG")
            document.getElementById('lose-popup').style.display = "grid";
            const popup = document.querySelector('#lose-popup');
            popup.showModal();
        }
    }

    handleCloseWinPopup() {
        document.getElementById('win-popup').style.display = "none";
        const popup = document.querySelector('#win-popup');
        popup.close();
    }

    handleCloseLosePopup() {
        document.getElementById('lose-popup').style.display = "none";
        const popup = document.querySelector('#lose-popup');
        popup.close();
    }

    handleCoinDrop(index) {
        const coin = document.getElementById("coin" + index);
        const coinValue = parseInt(coin.getAttribute("dollarValue"));
        const coinRect = coin.getBoundingClientRect();

        console.log(`${coinRect.x}, ${coinRect.y}`)

        let tempPos = this.state.coinPositions;
        tempPos[index] = [coinRect.x, coinRect.y];
        this.setState({
            coinPositions: tempPos
        });

        const fromFloorBox = document.getElementById("floorbox");
        const rect = fromFloorBox.getBoundingClientRect();
        console.log(rect.x, rect.y);
        if (coinRect.x > rect.left && coinRect.x < rect.right && coinRect.y > rect.top && coinRect.y < rect.bottom) {
            //fromFloorBox.innerHTML = `Coin ${index} here!`;
            if (!this.state.floorboxCoins.includes(index)) {
                this.setState(prevState => ({
                    floorboxCoins: [...prevState.floorboxCoins, index],
                    floorboxValue: prevState.floorboxValue + coinValue
                }));
            }
        } else {
            //fromFloorBox.innerHTML = "nothing";
            if (this.state.floorboxCoins.includes(index)) {
                this.setState({
                    floorboxCoins: this.state.floorboxCoins.filter((coin) => {
                        return coin !== index;
                    }),
                    floorboxValue: this.state.floorboxValue - coinValue
                });
            }
        }
    }

    spawnCoin(dollarValue, numberOfCoins) {
        console.log("SPAWNING A COIN");
        // Setting id as length is same as adding new coin 
        let id = this.state.coins.length;

        this.setState({
            coins: [...this.state.coins, id]
        });

        // Generate coin with value
        let coin = "";

        if (dollarValue === 25) {
            coin = "quarter";
        } else if (dollarValue === 10) {
            coin = "dime";
        } else if (dollarValue === 5) {
            coin = "nickel";
        } else {
            coin = "penny";
        }

        let floor = this.floorboxDiv;
        let width = floor.offsetWidth - 20;
        let height = floor.offsetHeight - 20;

        let randWidth = Math.floor(Math.random() * width);
        let randHeight = Math.floor(Math.random() * height);

        // makes the coin with that id draggable
        $(function () {
            $("#" + "coin" + id).mouseover(
                function () {
                    $(this).css("cursor", "grab");
                },

            );
            $("#" + "coin" + id).draggable({
                cursor: "grabbing",
                containment: "#playable-area"
            });
            $("#" + "coin" + id).addClass(coin);
            $("#" + "coin" + id).attr("dollarValue", dollarValue);
            $("#" + "coin" + id).attr("title", dollarValue);

            // x is left, y is top
            $("#" + "coin" + id).css("top", `+=${(height - randHeight)}`);
            $("#" + "coin" + id).css("left", `+=${(width - randWidth)}`);

        });

        this.setState({
            coins: [...this.state.coins, id],
            floorboxCoins: [...this.state.floorboxCoins, id],
            coinPositions: [...this.state.coinPositions, [[(height - randHeight), (width - randWidth)]]]
        });
    }

    despawnCoins() {
        /* const deleter = document.getElementById("deleter");
        const index = parseInt(deleter.value); */
        console.log("DESPAWNING");

        this.setState({
            coins: this.state.coins.filter((coin) => {
                return !this.state.floorboxCoins.includes(coin);
            }),

            floorboxCoins: [],

            // maybe uncessary because positions of coins can be retrieved at any time
            /* coinPositions: this.state.coinPositions.filter((_, index) => {
                return this.state.floorboxCoins.includes(coin);
            }) */
        });
    }

    despawn2() {
        console.log("SECOND DESPAWNER");
        const deleter = document.getElementById("deleter");
        const index = parseInt(deleter.value);

        const coin = document.getElementById("coin" + index);
        $("coin" + index).remove();

        if (this.state.coins.includes(index)) {
            this.setState({
                coins: this.state.coins.filter((coin) => {
                    return coin !== index;
                })
            });
        }

    }



    exchangeCoins() {
        const quarters = document.getElementById("exchange-quarters").value;
        const dimes = document.getElementById("exchange-dimes").value;
        const nickels = document.getElementById("exchange-nickels").value;
        const pennies = document.getElementById("exchange-pennies").value;

        const total = (quarters * 25) + (dimes * 10) + (nickels * 5) + (pennies * 1);

        console.log("FLOOR VALUE: ", this.state.floorboxValue, "TOTAL: ", total);

        if (this.state.floorboxValue === total) {
            console.log("good coins")
            // exchange coins
            this.despawnCoins();

            /* if (quarters !== 0) {
                this.spawnCoin(25, quarters);
                console.log("SPAWNING QUARTERS");
            }
            
            if (dimes !== 0) {
                this.spawnCoin(10, dimes);
                console.log("SPAWNING DIMES: ");
            }

            if (nickels !== 0) {
                this.spawnCoin(5, nickels);
                console.log("SPAWNING NICKELS: ");
            }

            if (pennies !== 0) {
                this.spawnCoin(1, pennies);
                console.log("SPAWNING PENNIES: ");
            } */

        } else {
            console.log("bad coins")
            // throw an error with a popup explaining why coins couldn't be exchanged
        }

    }

    handleShowInstructions() {
        document.getElementById('instructions-popup').style.display = "grid";
        const popup = document.querySelector('#instructions-popup');
        popup.showModal();
    }

    handleCloseInstructions() {
        document.getElementById('instructions-popup').style.display = "none";
        const popup = document.querySelector('#instructions-popup');
        popup.close();
    }


    render() {
        return (
            <div className="main-container">
                <div id="game-container" className="game-container">
                    <PopupMenu name="Coin Box" onClick={this.props.onClick} restart={this.restart} />
                    <dialog id="win-popup" className="win-popup">WIN!
                        <button onClick={this.handleCloseWinPopup}>OK</button>
                    </dialog>

                    <dialog id="lose-popup" className="lose-popup">Wrong Amount
                        <button onClick={this.handleCloseLosePopup}>OK</button>
                    </dialog>

                    <div className="coin-box-container">
                        <div className="buttons-area">

                            <input id="answer" className="answer" type="text" placeholder="Enter value" title="Type into the box the total value of the coins on the floor!" onKeyUp={this.handleAnswerEnter}></input>
                            <button id="check-answer" className="check-answer" title="Click this to submit your answer!" onClick={this.handleAnswer}>Check</button>

                            <button id="instructions-button" className="instructions-button" title="Click this to show instructions!" onClick={this.handleShowInstructions}>Instructions</button>
                            <dialog id="instructions-popup" className="instructions-popup">
                                <p>Step 1:
                                Count the coins on the floor. What is their total value?</p>

                                <p>Step 2:
                                Type your answer into the answer box then click the button or press enter. If your answer is correct, then you win and then you get a different set of coins to play with. If your answer is incorrect, then you need to count the coins again.</p>

                                <p>Exchange:
                                Drop coins into the left box. Then choose how many coins you want to exchange using the table. Then click exchange to replace the coins in the box with the coins you chose in the table. </p>
                                <button onClick={this.handleCloseInstructions}>OK</button>
                            </dialog>
                            
                            {/* <label className="switch1">Slider
                                <input type="checkbox" id="toggle"
                                    onChange={
                                        () => {
                                            this.setState(prevState => ({
                                                tooltipsOn: !prevState.tooltipsOn,
                                            })
                                            )
                                        }
                                    }
                                    checked={this.state.tooltipsOn}
                                />
                                <span className="slider1 round1"></span>
                            </label> */}

                            {/* <input id="deleter" placeholder="delete something"></input>
                            <button onClick={this.despawn2}>Button</button> */}

                        </div>

                        <div id="playable-area" className="playable-area">
                            <div className="from-floor-area">Exchange coins from floor
                                <div id="floorbox" className="a-coin-box" data-coin="" title="Put the coins you want to exchange over here!">
                                    {/* {this.state.floorboxCoins.map((coin, index) => {
                                        console.log("coin" + coin.toString());
                                        return (
                                            <div
                                                key={index}
                                                id={"coin" + coin.toString()}
                                                className="coin"
                                                onMouseUp={() => { this.handleCoinDrop(index) }}
                                            >
                                            </div>
                                        );
                                    })} */}
                                </div>
                            </div>

                            <div className="from-bank-area" ref={(div) => { this.floorboxDiv = div; }}>Exchange coins from bank
                                <image className="cash-register"></image>
                                <button id="exchange-coins" onClick={this.exchangeCoins} >Exhange coins</button>
                                <div id="exchanger" className="exchange-container" title={`Choose a number of coins then press the exchange button`}>
                                    <div className="exchange-banner">Exchange Coins</div>

                                    <div className="exchange-card">
                                        <h3>Quarters</h3>
                                        <input id="exchange-quarters" type="number" />
                                    </div>

                                    <div className="exchange-card">
                                        <h3>Dimes</h3>
                                        <input id="exchange-dimes" type="number" />
                                    </div>

                                    <div className="exchange-card">
                                        <h3>Nickels</h3>
                                        <input id="exchange-nickels" type="number" />
                                    </div>

                                    <div className="exchange-card">
                                        <h3>Pennies</h3>
                                        <input id="exchange-pennies" type="number" />
                                    </div>



                                </div>

                            </div>

                            <div id="floor" className="floor" ref={(div) => { this.floorDiv = div; }} title="You can move around coins by clicking and dragging with the mouse!">Floor
                                {this.state.coins.map((coin, index) => {
                                    console.log("coin" + coin.toString());
                                    return (
                                        <div
                                            key={index}
                                            id={"coin" + coin.toString()}
                                            className="coin"
                                            onMouseUp={() => { this.handleCoinDrop(index) }}
                                        >
                                        </div>
                                    );
                                })}
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        )
    }

}
