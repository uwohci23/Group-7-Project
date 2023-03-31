"use strict"

class CoinBox extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            max: 7,
            min: 3,
            coins: [],
            lefts: [],
            tops: [],
            floorboxCoins: [],
            count: 0,
            total: 0,
            win: false
        };

        this.setUpCoins = this.setUpCoins.bind(this);
        this.setUpFloor = this.setUpFloor.bind(this);
        this.setUpFloorBox = this.setUpFloorBox.bind(this);
        this.setUpTooltips = this.setUpTooltips.bind(this);

        this.restart = this.restart.bind(this);

        this.handleAnswer = this.handleAnswer.bind(this);
    }

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
        let width = floor.offsetWidth - 20;
        let height = floor.offsetHeight - 20;

        console.log("FLORR: ", floor)

        // this doesnt do anything its just for testing
        var $this = $(ReactDOM.findDOMNode(this));
        console.log($this[0])

        let tempLefts = []
        let tempTops = []
        let tempTotal = 0;

        for (let id of temp) {
            console.log("#" + "coin" + id);

            let randWidth = Math.floor(Math.random() * width);
            let randHeight = Math.floor(Math.random() * height);
            tempLefts.push((width - randWidth));
            tempTops.push((height - randHeight));

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
                $("#" + "coin" + id).draggable();
                $("#" + "coin" + id).addClass(randomCoin);
                $("#" + "coin" + id).attr("dollarValue", dollarValue);
                $("#" + "coin" + id).css("top", `+=${(height - randHeight)}`);
                $("#" + "coin" + id).css("left", `+=${(width - randWidth)}`);
                //$("#" + "coin" + id).attr("onClick", function() { $(this).css("cursor", "grabbing")});
                //$("#" + "coin" + id).css("content", "url(../art/coinbox/penny.png");
            });
        }

        this.setState({ total: tempTotal });

    }

    setUpFloor() {
        let floor = document.getElementById("floor");
        var droppedCoin = "";
        
            $("#floor").droppable({
                drop: function (event, ui) {
                    droppedCoin = ui.draggable[0].id;
                    $('#floor').attr("data-coin", droppedCoin);
                    
                },
            });
        

        console.log("DROPPED: ", droppedCoin)
    }

    setUpFloorBox() {
        // makes the floorbox droppable (things can be dropped into it so it can trigger other things)
        let floor1 = document.getElementById("floorbox");
        let ball2 = floor1.getAttribute("data-coin");
        console.log(ball2);

        let droppedCoin = "";
        $(function () {
            $("#floorbox").droppable({
                drop: function (event, ui) {
                    droppedCoin = ui.draggable[0].id;
                    $('#floorbox').attr("data-coin", droppedCoin);
                    console.log("DROPPED: ", droppedCoin)
                },
            });
        });
    }

    setUpTooltips() {
        $(function () {
            $("#answer").tooltip();
            $("#check-answer").tooltip();
            $(".coin").tooltip({
                hide: { effect: "explode", duration: 1000 }
            });
        });
    }

    // This is supposed to trigger every rerender
    componentDidMount() {
        console.log("MOUNT")

        this.setUpCoins();
        this.setUpFloor();
        this.setUpFloorBox();
        this.setUpTooltips();

        
    }

    componentDidUpdate(prevProps, prevState) {
        console.log("UPDATE")
        if (this.state.count !== prevState.count) {
            this.setUpCoins();
            this.setUpFloorBox();
            this.setUpTooltips();
        }
    }

    handleDrop() {
        console.log("big dropper")
    }

    restart() {
        let empty = [];
        this.setState({ 
            coins: empty,
            total: 0,
            count: this.state.count + 1
        });
    }

    handleAnswer() {
        let answer = document.getElementById("answer").value;
        if (parseInt(answer) === this.state.total) {
            console.log("WIN")
        } else {
            console.log("WRONG")
        }
    }

    render() {
        return (
            <div className="game-container">
                <PopupMenu name="Coin Box" onClick={this.props.onClick} restart={this.restart}/>

                <div className="coin-box-container">
                    <div className="buttons-area">Buttons
                    <button onClick={this.restart}>Restart</button>
                        <input id="answer" type="text" placeholder="Put value here" title="That&apos;s what this widget is"></input>
                        <button id="check-answer" title="Lebron James"  onClick={this.handleAnswer}>Check</button>
                        <label className="switch" htmlFor="checkbox">
                            <input type="checkbox" id="checkbox" />
                            <div className="slider round"></div>
                        </label>

                    </div>

                    <div className="from-floor-area">Exchange coins from floor
                        <div id="floorbox" className="a-coin-box" data-coin="" onMouseUp={this.handleDrop}>
                            <p>thing</p>
                        </div>
                    </div>

                    <div className="from-bank-area">Exchange coins from bank
                        <div id="bankbox" className="a-coin-box">
                            thing
                        </div>

                    </div>

                    <div className="bank-account" >Coins from bank
                        <div id="accountbox" className="a-coin-box">
                            thing
                        </div>

                    </div>

                    <div id="floor" className="floor" ref={(div) => { this.floorDiv = div; }}>Floor
                        {this.state.coins.map((coin, index) => {
                            console.log("coin" + coin.toString());
                            return (
                                <div
                                    key={index}
                                    id={"coin" + coin.toString()}
                                    className="coin"
                                    title="This is a coin"
                                    //onClick={$(function() { $(this).css("cursor", "grabbing")})}
                                //style={`top: ${this.state.tops[index+1]} + px; left: ${this.state.lefts[index+1]}  + px;`}
                                >
                                </div>
                            );
                        })}
                    </div>
                </div>
            </div>
        )
    }

}
