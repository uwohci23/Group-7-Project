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

    /*
    ../art/deepSeaDuel/dsdThumb.png
    ../art/groupingAndGrazing/Cow.png
    ../art/oktasRescue/okatThumb.png
    ../art/coinBox/quarter.png
    */
    render() {
        return (
            <div id="menu">
                {/* <div className="btn-grid" id="menuTitle">
                    <h1>Educational Games</h1>
                </div> */}
                <div className="btn-grid" id="dsd-grid">
                    <GameCard
                        onGameNum={this.props.onGameNum}
                        thumbnail="Group-7-Project/art/deepSeaDuel/dsdThumb.png"
                        title={1}
                    /></div>
                <div className="btn-grid" id="gg-grid">
                    <GameCard
                        onGameNum={this.props.onGameNum}
                        thumbnail="Group-7-Project/art/groupingAndGrazing/Cow2.png"
                        title={2}
                    /></div>
                <div className="btn-grid" id="cb-grid">
                    <GameCard
                        onGameNum={this.props.onGameNum}
                        thumbnail="Group-7-Project/art/coinBox/quarter2.png"
                        title={3}
                    /></div>
                <div className="btn-grid" id="or-grid">
                    <GameCard
                        onGameNum={this.props.onGameNum}
                        thumbnail="Group-7-Project/art/oktasRescue/okatThumb.png"
                        title={4}
                    /></div>
            </div>
        )
    }
}
