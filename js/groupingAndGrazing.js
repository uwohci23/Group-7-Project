"use strict"

class GroupingAndGrazing extends React.Component {
    constructor(props) {
        super(props)

        this.restart = this.restart.bind(this);
    }

    restart() {
        document.getElementById("Grouping and Grazing").src= "../games/GroupingAndGrazing/Build/index.html";
    }

    render() {

        return (
            <div>
                <PopupMenu name="Grouping and Grazing" onClick={this.props.onClick} restart={this.restart} />
                <iframe id="Grouping and Grazing" src="../games/GroupingAndGrazing/Build/index.html" style={{ width: "100vw", height: "100vh" }}></iframe>
            </div>
        )
    }

}
