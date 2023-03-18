"use strict"

class GroupingAndGrazing extends React.Component {
    constructor(props) {
        super(props)
    }

    render() {
        console.log(this.props.onClick)
        return (
            <div>
                <PopupMenu name="Grouping and Grazing" />
                <button onClick={() => this.props.onClick(0)}>Exit</button>
            </div>
        )
    }

}
