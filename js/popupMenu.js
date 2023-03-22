"use strict"

class PopupMenu extends React.Component {
    constructor(props) {
        super(props)
        console.log("Props: ", props)
    }

    handleClosePopup() {
        console.log(this)
        
    }

    render() {
        return (
          <div id="popup">
            <button id="close-popup" onClick={this.handleClosePopup}>&#215;</button>
            <button id="choice">Restart</button>
            <button id="choice" onClick={() => this.props.onClick(0)}>Exit</button>
          </div>
        )
    }

}
