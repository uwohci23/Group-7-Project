

class GameCard extends React.Component {
    constructor(props) {
        super(props)
        this.title = props.title;
        this.thumbnail = props.thumbnail;
        this.gameNum = props.onGameNum;
        this.state = {
            /*
            false: tut not needed
            true: tut needed
            */
            tutorial: false
        }
        this.changeTutorial = this.changeTutorial.bind(this)
    }


    changeTutorial() {
        this.setState({ tutorial: !this.state.tutorial })
    }

    render() {
        let thumbnail = <img src={this.thumbnail} />
        let tutorialSlider = <TutorialSlider onTutorial={this.changeTutorial} />
        let tut
        switch (this.state.tutorial) {
            case false:
                tut = false;
                break;
            case true:
                tut = true;
                break;
        }
        let name
        let playButton
        switch (this.title) {
            case 1:
                playButton = <button onClick={() => { this.props.onGameNum(1, tut) }} className="btn-play">PLAY</button>
                name = <h1 id="title">Deep Sea Duel</h1>
                break;
            case 2:
                playButton = <button onClick={() => { this.props.onGameNum(2, tut) }} className="btn-play">PLAY</button>
                name = <h1 id="title">Grouping and Grazing</h1>
                break;
            case 3:
                playButton = <button onClick={() => { this.props.onGameNum(3, tut) }} className="btn-play">PLAY</button>
                name = <h1 id="title">Coin Box</h1>
                break;
            case 4:
                playButton = <button onClick={() => { this.props.onGameNum(4, tut) }} className="btn-play">PLAY</button>
                name = <h1 id="title">Okta's Rescue</h1> //DO NOT CHANGE THE TEXT, CODE WILL BREAK
                break;
        }
        return (
            <div id="card">
                <div className="card-grid" id="cardName">{name}</div>
                <div className="card-grid" id="cardThumbnail">{thumbnail}</div>
                <div className="card-grid" id="cardSlider">{tutorialSlider}</div>
                <div className="card-grid" id="cardPlayButton">{playButton}</div>
            </div>
        )
    }

}