"use strict"

class MainMenu extends React.Component {
    constructor(props) {
        super(props)
    }

    render() {
        return (
            <div id="menu">
                <button className="btn-grid" id="dsd-grid" onClick={() => this.props.onClick(1)}>Deep Sea Duel</button>
                <button className="btn-grid" id="gg-grid" onClick={() => this.props.onClick(2)}>Grouping and Grazing</button>
                <button className="btn-grid" id="cb-grid" onClick={() => this.props.onClick(3)}>Coin Box</button>
                <button className="btn-grid" id="or-grid" onClick={() => this.props.onClick(4)}>Okta's Rescue</button>
            </div>
        )
    }

}
