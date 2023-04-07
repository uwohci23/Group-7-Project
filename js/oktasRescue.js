"use strict"

class OktasRescue extends React.Component {
    constructor(props) {
        super(props)
    }

    restart() {
        // this is for testing
        // it currently uses grazing iframe but it should use Okta iframe
        document.getElementById("Oktas Rescue").src = "https://uwohci23.github.io/Group-7-Project/games/OktaRescue/Build/index.html";
    }

    render() {
        let framer
        switch (this.props.isTutorial) {
            case false:
                framer = <iframe id="Oktas Rescue" src="https://uwohci23.github.io/Group-7-Project/games/OktaRescue/Build/index.html" style={{ width: "100vw", height: "100vh" }}></iframe>
                break;
            case true:
                framer = <iframe id="Oktas Rescue" src="https://uwohci23.github.io/Group-7-Project/games/OktaRescue/TutorialBuild/index.html" style={{ width: "100vw", height: "100vh" }}></iframe>
                break;
        }
        return (
            <div>
                <PopupMenu name="Oktas Rescue" onClick={this.props.onClick} restart={this.restart} />
                <div>
                    {framer}
                </div>
            </div>
        )
    }
}
