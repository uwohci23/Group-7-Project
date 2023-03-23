"use strict"

class GroupingAndGrazing extends React.Component {
    constructor(props) {
        super(props)
    }

    render() {

        return (
            <div>
                <PopupMenu name="Grouping and Grazing" onClick={this.props.onClick} />
                <iframe src="../games/GroupingAndGrazing/Build/index.html" style={{ width: "100vw", height: "100vh" }}></iframe>
            </div>
        )
    }

}
