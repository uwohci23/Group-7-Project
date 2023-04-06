

class TutorialSlider extends React.Component {
    constructor(props) {
        super(props)
    }

    render() {
        let slider = <label className="switch">
            <input type="checkbox" onChange={() => {this.props.onTutorial()}}/>
            <span className="slider"></span>
            <span className="labels" data-on="Have fun!" data-off="Help?"></span>
            </label>
        return (
            <div>
                {slider}
            </div>
        )
    }
}