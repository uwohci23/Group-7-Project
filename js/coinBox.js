"use strict"

class CoinBox extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            coinSelected: false
        };

        this.handleCoinDragStart = this.handleCoinDragStart.bind(this);
        this.handleCoinDragMove = this.handleCoinDragMove.bind(this);
        this.handleCoinDragEnd = this.handleCoinDragEnd.bind(this);
    }

    handleCoinDragStart() {
        console.log("start");
        this.setState({ coinSelected: true });
    }

    handleCoinDragMove(e) {
        if (this.state.coinSelected) {
            const coin = document.querySelector('.coin');
            console.log(e.pageX, e.pageY)
            coin.style.left = e.pageX +'px'; 
            coin.style.top = e.pageY +'px';
        }
    }

    handleCoinDragEnd() {
        console.log("end");
        this.setState({ coinSelected: false });
    }

    componentDidUpdate(props, state) {
        if (this.state.coinSelected && !state.coinSelected) {
            document.addEventListener('mousemove', this.onMouseMove)
            document.addEventListener('mouseup', this.onMouseUp)
        } else if (!this.state.coinSelected && state.coinSelected) {
            document.removeEventListener('mousemove', this.onMouseMove)
            document.removeEventListener('mouseup', this.onMouseUp)
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

                    <div className="floor">Floor
                        <div id ="coin" className="coin" onMouseDown={this.handleCoinDragStart} onMouseMove={this.handleCoinDragMove} onMouseUp={this.handleCoinDragEnd}>

                        </div>
                    
                    </div>
                </div>
            </div>
        )
    }

}
