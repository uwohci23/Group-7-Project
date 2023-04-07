"use strict";

class PopupMenu extends React.Component {
    constructor(props) {
        super(props)

        this.handleOpenPopup = this.handleOpenPopup.bind(this);
        this.handleRestart = this.handleRestart.bind(this);
        this.handleClosePopup = this.handleClosePopup.bind(this);
        this.handleClosePopupWithEsc = this.handleClosePopupWithEsc.bind(this);
    }

    // Handle opening the popup via the X in the top right corner
    handleOpenPopup() {
        document.getElementById('popup').style.display = "grid";
        const popup = document.querySelector('#popup');
        popup.showModal();
    }

    confirmRestart() {
        document.getElementById('confirm-restart').style.display = "grid";
        const areYouSure = document.querySelector('#confirm-restart')
        areYouSure.showModal();
    }

    closeConfirmRestart() {
        document.getElementById('confirm-restart').style.display = "none";
        const areYouSure = document.querySelector('#confirm-restart')
        areYouSure.close();
    }

    handleRestart() {
        document.getElementById('confirm-restart').style.display = "none";
        const areYouSure = document.querySelector('#confirm-restart')
        areYouSure.close();

        this.props.restart();

        this.handleClosePopup();
    }

    confirmExit() {
        document.getElementById('confirm-exit').style.display = "grid";
        const areYouSure = document.querySelector('#confirm-exit')
        areYouSure.showModal();
    }

    closeConfirmExit() {
        document.getElementById('confirm-exit').style.display = "none";
        const areYouSure = document.querySelector('#confirm-exit')
        areYouSure.close();
    }

    // Handle closing the popup via the X in the top right corner of the popup
    handleClosePopup() {
        document.getElementById('popup').style.display = "none";
        const popup = document.querySelector('.popup');
        popup.close();
    }

    handleClosePopupWithEsc(e, code) {
        if (e.code === 'Escape') {
            console.log("escape pressed");
            if (code === 1) {
                this.closeConfirmRestart();
                this.handleClosePopup();
            } else if (code === 2) {
                this.closeConfirmExit();
                this.handleClosePopup();
            } else {
                this.handleClosePopup();
            }
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
                    <button id="choice" className="choice" onClick={this.confirmRestart}>Restart</button>
                    <button id="choice" className="choice" onClick={this.confirmExit}>Exit</button>
                </dialog>

                <dialog id="confirm-restart" className="popup" onKeyDown={(e) => {this.handleClosePopupWithEsc(e, 1)}}>
                    <h3>Are you sure you want to restart?</h3>
                    <button onClick={this.handleRestart}>Yes</button>
                    <button onClick={this.closeConfirmRestart}>No</button>
                </dialog>

                <dialog id="confirm-exit" className="popup" onKeyDown={(e) => {this.handleClosePopupWithEsc(e, 2)}}>
                    <h3>Are you sure you want to exit?</h3>
                    <button onClick={() => this.props.onClick(0)}>Yes</button>
                    <button onClick={this.closeConfirmExit}>No</button>
                </dialog>



            </div>
        )
    }

}
