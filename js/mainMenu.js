"use strict"

class MainMenu extends React.Component {
    constructor(props) {
        super(props)
    }
    // render() {
    //     return (
    //         <div id="menu">
    //             <button className="btn-grid" id="dsd-grid" onClick={() => this.props.onClick(1)}>Deep Sea Duel</button>
    //             <button className="btn-grid" id="gg-grid" onClick={() => this.props.onClick(2)}>Grouping and Grazing</button>
    //             <button className="btn-grid" id="cb-grid" onClick={() => this.props.onClick(3)}>Coin Box</button>
    //             <button className="btn-grid" id="or-grid" onClick={() => this.props.onClick(4)}>Okta's Rescue</button>
    //         </div>
    //     )
    // }
    render() {
        return (
            <div id="menu">
                {/* <div className="btn-grid" id="menuTitle">
                    <h1>Educational Games</h1>
                </div> */}
                <div className="btn-grid" id="dsd-grid">
                    <GameCard
                    onGameNum={this.props.onGameNum}
                    thumbnail=""
                    title={1}
                    /></div>
                <div className="btn-grid" id="gg-grid">
                    <GameCard
                    onGameNum={this.props.onGameNum}
                    thumbnail=""
                    title={2}
                    /></div>
                <div className="btn-grid" id="cb-grid">
                    <GameCard
                    onGameNum={this.props.onGameNum}
                    thumbnail=""
                    title={3}
                    /></div>
                <div className="btn-grid" id="or-grid">
                    <GameCard
                    onGameNum={this.props.onGameNum}
                    thumbnail=""
                    title={4}
                    /></div>
            </div>
        )
    }
}
