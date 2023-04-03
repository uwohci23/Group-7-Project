"use strict"

class OktasRescue extends React.Component {
    constructor(props) {
        super(props)
    }

    restart() {
        // this is for testing
        // it currently uses grazing iframe but it should use Okta iframe
        document.getElementById("Oktas Rescue").src= "../games/GroupingAndGrazing/Build/index.html";
    }

    render() {
        return (
            <div>
                <PopupMenu name="Oktas Rescue" onClick={this.props.onClick} restart={this.restart} />
                <iframe id="Oktas Rescue" src="../games/GroupingAndGrazing/Build/index.html" style={{ width: "100vw", height: "100vh" }}></iframe>
            </div>
        )
    }
}
