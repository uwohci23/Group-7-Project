"use strict"

class CoinBox extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            max: 7,
            min: 3,
            coins: []
        };
    }

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


        let floor = document.querySelector('#floor');
        let width = floor.offsetWidth;
        let height = floor.offsetHeight;

        for (let id of temp) {
            console.log("#" + "coin" + id);

            let coin = document.getElementById('coin' + id);
            let randWidth = Math.floor(Math.random() * width);
            let randHeight = Math.floor(Math.random() * height);
            coin.style.left = (width - randWidth) + 'px';
            coin.style.top = (height - randHeight)  + 'px';

            $(function() {
                $("#" + "coin" + id).draggable();
            });
        }

        
    }

    render() {
        return (
            <div>
                <PopupMenu name="Coin Box" onClick={this.props.onClick} />

                <div className="coin-box-container">
                    <div className="buttons-area">Buttons
                    
                    </div>

                    <div className="from-floor-area">Exchange coins from floor
                    
                    </div>

                    <div className="from-bank-area">Exchange coins from bank
                    
                    </div>

                    <div className="bank-account" >Coins from bank
                        
                    </div>

                    <div id="floor" className="floor" >Floor
                        {this.state.coins.map((coin, index) => {
                            console.log("coin" + coin.toString());
                            return (
                                <div key={index} id={"coin" + coin.toString()} className="coin"></div>
                            );
                        })}
                    </div>
                </div>
            </div>
        )
    }

}
