"use strict"

class GroupingAndGrazing extends React.Component {
    constructor(props) {
        super(props)
    }

    render() {
        
        return (
            <div>
                <PopupMenu name="Grouping and Grazing" onClick={this.props.onClick} />
            </div>
        )
    }

}
