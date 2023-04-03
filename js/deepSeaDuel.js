"use strict"

class DeepSeaDuel extends React.Component {
    constructor(props) {
        super(props)
    }

    restart() {
        // this is for testing
        // it currently uses grazing iframe but it should use duel iframe
        document.getElementById("Deep Sea Duel").src= "../games/GroupingAndGrazing/Build/index.html";
    }

    render() {
        return (
            <div>
                <PopupMenu name="Deep Sea Duel" onClick={this.props.onClick} restart={this.restart} />
                <iframe id="Deep Sea Duel" src="../games/GroupingAndGrazing/Build/index.html" style={{ width: "100vw", height: "100vh" }}></iframe>
            </div>
        )
    }

}
