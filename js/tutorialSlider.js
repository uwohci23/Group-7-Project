

class TutorialSlider extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            /*
            0: no tutorial
            1: tutorial requested
            */
            isSlid: 0
        }
        this.handleSlide = this.handleSlide.bind(this)
    }

    handleSlide(isSlid) {
        this.setState({ isSlid: isSlid })
    }

    render() {
        let slider = <label className="switch">
            <input type="checkbox" onChange={() => {this.handleSlide}}/>
            <span className="slider"></span>
            </label>
        return (
            <div>
                {slider}
            </div>
        )
    }
}