"use strict"

class CoinBox extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            coins: [1, 2, 3, 4]
        };

        this.handleCoinDragStart = this.handleCoinDragStart.bind(this);
    }

    handleCoinDragStart(e) {
        console.log("Somehting", e.target.id)
        // JQuery has an API for draggable DOM elements
        $(function() {
            $("#" + e.target.id).draggable();
        });
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

                    <div className="floor" >Floor
                        {this.state.coins.map((coin, index) => {
                            console.log("coin" + coin.toString());
                            return (
                                <div key={index} id={"coin" + coin.toString()} className="coin" onMouseDown={this.handleCoinDragStart}></div>
                            );
                        })}
                    </div>
                </div>
            </div>
        )
    }

}
