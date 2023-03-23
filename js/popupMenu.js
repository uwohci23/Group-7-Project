"use strict";

class PopupMenu extends React.Component {
    constructor(props) {
        super(props)

        this.handleOpenPopup = this.handleOpenPopup.bind(this);
        this.handleClosePopup = this.handleClosePopup.bind(this);
        this.handleClosePopupWithEsc = this.handleClosePopupWithEsc.bind(this);
    }

    // Handle opening the popup via the X in the top right corner
    handleOpenPopup() {
        document.getElementById('popup').style.display = "grid";
        const popup = document.querySelector('.popup');
        popup.showModal();
    }

    // Handle closing the popup via the X in the top right corner of the popup
    handleClosePopup() {
        document.getElementById('popup').style.display = "none";
        const popup = document.querySelector('.popup');
        popup.close();
    }

    handleClosePopupWithEsc(e) {
        if (e.code === 'Escape') {
            console.log("escape pressed");
            this.handleClosePopup();
        }
    }


    render() {
        return (
            <div className="popup-container">
                <div className="open-popup-container">
                    <button className="open-popup" onClick={this.handleOpenPopup}>&#215;</button>
                </div>

                <dialog id="popup" className="popup" onKeyDown={this.handleClosePopupWithEsc}>
                    <button id="close-popup" className="close-popup" onClick={this.handleClosePopup}>&#215;</button>
                    <button id="choice" className="choice">Restart</button>
                    <button id="choice" className="choice" onClick={() => this.props.onClick(0)}>Exit</button>
                </dialog>


            </div>
        )
    }

}
