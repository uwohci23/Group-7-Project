"use strict"

class CoinBox extends React.Component {
    constructor(props) {
        super(props)
    }

    render() {
        return (
            <div>
                <PopupMenu name="Coin Box" onClick={this.props.onClick} />
            </div>
        )
    }

}
