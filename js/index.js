"use strict"

class Root extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            /*
            0 = Main Menu
            1 = Deep Sea Duel
            2 = Grouping and Grazing
            3 = Coin Box
            4 = Okta's Rescue
            */
            gameNum: 0,
            /*
            False = No tutorial needed
            True = Tutorial needed
            */
            tutorial: false
        }
        this.changeGameNum = this.changeGameNum.bind(this)
    }

    changeGameNum(gameNum, tutorial = false) {
        this.setState({ gameNum: gameNum, tutorial: tutorial })
    }

    render() {
        let game
        switch (this.state.gameNum) {
            case 0:
                game = <MainMenu
                    onGameNum={this.changeGameNum} />
                break;
            case 1:
                game = <DeepSeaDuel
                    onClick={this.changeGameNum}
                    isTutorial={this.state.tutorial} />
                break;
            case 2:
                game = <GroupingAndGrazing
                    onClick={this.changeGameNum}
                    isTutorial={this.state.tutorial} />
                break;
            case 3:
                game = <CoinBox
                    onClick={this.changeGameNum}
                    isTutorial={this.state.tutorial} />
                break;
            case 4:
                game = <OktasRescue
                    onClick={this.changeGameNum}
                    isTutorial={this.state.tutorial} />
                break;
        }

        return (
            <div>
                {game}
            </div>
        )
    }

}

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(<Root />)
