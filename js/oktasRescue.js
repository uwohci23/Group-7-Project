"use strict"

class OktasRescue extends React.Component {
    constructor(props) {
        super(props)
    }

    render() {
        return (
            <div>
                <PopupMenu name="Okta's Rescue" onClick={this.props.onClick} />
            </div>
        )
    }
}
