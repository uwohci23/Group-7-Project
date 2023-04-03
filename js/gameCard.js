

class GameCard extends React.Component {
    constructor(props) {
        super(props)
        this.title = props.title;
        this.thumbnail = props.thumbnail;
        this.gameNum = props.onGameNum;
    }

    render() {
        let thumbnail = <img src={this.thumbnail}/>
        let tutorialSlider = <TutorialSlider/>
        let name
        let playButton
        switch(this.title) {
            case 1:
                playButton = <button onClick={() => {this.props.onGameNum(1)}} className="btn-play">PLAY</button>
                name = <h1>Deep Sea Duel</h1>
                break;
            case 2:
                playButton = <button onClick={() => {this.props.onGameNum(2)}} className="btn-play">PLAY</button>
                name = <h1>Grouping and Grazing</h1>
                break;
            case 3:
                playButton = <button onClick={() => {this.props.onGameNum(3)}} className="btn-play">PLAY</button>
                name = <h1>Coin Box</h1>
                break;
            case 4:
                playButton = <button onClick={() => {this.props.onGameNum(4)}} className="btn-play">PLAY</button>
                name = <h1>Okta's Rescue</h1> //DO NOT CHANGE THE TEXT, CODE WILL BREAK
                break;
        }
        return (
            <div id="card">
                <div className="card-grid" id="cardName">{name}</div>
                <div className="card-grid" id="cardThumbnail">{thumbnail}</div>
                <div className="card-grid" id="cardPlayButton">{playButton}</div>
                <div className="card-grid" id="cardSlider">{tutorialSlider}</div>
            </div>
        )
    }

}