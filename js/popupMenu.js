"use strict"

class PopupMenu extends React.Component {
    constructor(props) {
        super(props)
    }

    render() {
        return (
            <button>
                {this.props.name}
            </button>
        )
    }

}
