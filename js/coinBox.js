"use strict"

class CoinBox extends React.Component {
    constructor(props) {
        super(props)
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

                    <div className="bank-account">Coins from bank
                    
                    </div>

                    <div className="floor">Floor
                    
                    </div>
                </div>
            </div>
        )
    }

}
