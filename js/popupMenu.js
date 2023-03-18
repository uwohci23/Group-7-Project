"use strict"

class PopupMenu extends React.Component {
    constructor(props) {
        super(props)
    }

    handleClosePopup() {
        console.log("click")
    }

    render() {
        return (
          <div id="popup">
            <button id="close-popup" onClick={this.handleClosePopup}>&#215;</button>
            <button id="choice">Restart</button>
            <button id="choice">Exit</button>
          </div>
        )
    }

}
