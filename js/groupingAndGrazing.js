"use strict"

class GroupingAndGrazing extends React.Component {
    constructor(props) {
        super(props)
        console.log("Cow props: ", props)
    }

    render() {
        console.log("Function:", this.props.onClick)
        return (
            <div>
                <PopupMenu name="Grouping and Grazing" onClick={this.props.onClick} />
            </div>
        )
    }

}
