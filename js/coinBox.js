"use strict"

class CoinBox extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            max: 7,
            min: 3,
            coins: [],
            lefts: [0],
            tops: [0],
            floorboxCoins: [],
        };
    }

    // This is supposed to trigger every rerender
    // Anything that uses lefts and tops does not work
    componentDidMount() {
        // Generate random number of coins
        const numCoins = Math.floor(Math.random() * (this.state.max - this.state.min) + this.state.min);

        // store values in temp
        let temp = [];
        for (let i = 1; i < numCoins; i++) {
            temp.push(i);
        }

        console.log("temp ", temp)

        // set state of coins to temp
        this.setState({
            coins: this.state.coins.concat(temp)
        });


        let floor = this.floorDiv;
        let width = floor.offsetWidth;
        let height = floor.offsetHeight;

        console.log("FLORR: ", floor)

        // this doesnt do anything its just for testing
        var $this = $(ReactDOM.findDOMNode(this));
        console.log($this[0])

        let tempLefts = []
        let tempTops = []

        for (let id of temp) {
            console.log("#" + "coin" + id);

            let randWidth = Math.floor(Math.random() * width);
            let randHeight = Math.floor(Math.random() * height);
            tempLefts.push((width - randWidth));
            tempTops.push((height - randHeight));

            // makes the coin with that id draggable
            $(function () {
                $("#" + "coin" + id).draggable();
            });
        }

        // should copy array but it doesnt, idk
        this.setState({
            lefts: this.state.lefts.concat(tempLefts),
            tops: this.state.tops.concat(tempTops)
        });

        console.log(tempLefts)
        console.log(tempTops)
        console.log(this.state.tops)
        console.log(this.state.lefts)

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
                },
            });
        });

        $(function () {
            $("#answer").tooltip();
            $("#check-answer").tooltip();
            $(".coin").tooltip({
                hide: { effect: "explode", duration: 1000 }
            });
        });
    }

    componentDidUpdate() {
        console.log("UPDATE")
    }

    handleDrop() {
        console.log("big dropper")
    }

    render() {
        return (
            <div>
                <PopupMenu name="Coin Box" onClick={this.props.onClick} />

                <div className="coin-box-container">
                    <div className="buttons-area">Buttons
                        <input id="answer" type="text" placeholder="Put value here" title="That&apos;s what this widget is"></input>
                        <button id="check-answer" title="Lebron James">Check</button>
                        <label class="switch" for="checkbox">
                            <input type="checkbox" id="checkbox" />
                            <div class="slider round"></div>
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
