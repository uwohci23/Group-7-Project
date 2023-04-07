"use strict"

class DeepSeaDuel extends React.Component {
    constructor(props) {
        super(props)
    }

    restart() {
        // this is for testing
        // it currently uses grazing iframe but it should use duel iframe
        document.getElementById("Deep Sea Duel").src = "https://uwohci23.github.io/Group-7-Project/games/DeepSeaDuel/Build/index.html";
    }

    //added logical choice between two iframes, one containing the tutorial and on that does not.
    render() {
        let framer
        switch (this.props.isTutorial) {
            case false:
                framer = <iframe id="Deep Sea Duel" src="https://uwohci23.github.io/Group-7-Project/games/DeepSeaDuel/Build/index.html" style={{ width: "100vw", height: "100vh" }}></iframe>
                break;
            case true:
                framer = <iframe id="Deep Sea Duel" src="https://uwohci23.github.io/Group-7-Project/games/DeepSeaDuel/TutorialBuild/index.html" style={{ width: "100vw", height: "100vh" }}></iframe>
                break;
        }
        return (
            <div>
                <PopupMenu name="Deep Sea Duel" onClick={this.props.onClick} restart={this.restart} />
                <div id="frame">
                    {framer}
                </div>
            </div>
        )
    }
}