"use strict"

class GroupingAndGrazing extends React.Component {
    constructor(props) {
        super(props)

        this.restart = this.restart.bind(this);
    }

    restart() {
        document.getElementById("Grouping and Grazing").src = "Group-7-Project//games/GroupingAndGrazing/Build/index.html";
    }

    render() {
        let framer
        console.log(this.props.isTutorial)
        switch (this.props.isTutorial) {
            case false:
                framer = <iframe id="Grouping and Grazing" src="Group-7-Project//games/GroupingAndGrazing/Build/index.html" style={{ width: "100vw", height: "100vh" }}></iframe>
                break;
            case true:
                framer = <iframe id="Grouping and Grazing" src="Group-7-Project//games/GroupingAndGrazing/TutorialBuild/index.html" style={{ width: "100vw", height: "100vh" }}></iframe>
                break;
        }
        return (
            <div>
                <PopupMenu name="Grouping and Grazing" onClick={this.props.onClick} restart={this.restart} />
                <div>
                    {framer}
                </div>
            </div>
        )
    }

}
