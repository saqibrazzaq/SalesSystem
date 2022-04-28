import React, { Component } from "react";

export class AvailabilityList extends Component {
  constructor(props) {
    super(props);

    // Get from props
    this.state = { availabilities: [], isLoading: true };
  }

  componentDidMount() {
    this.setState({ availabilities: this.props.items, isLoading: false });
  }

  deleteAvailability = (a) => {
    console.log("Deleting " + a.name);
  };

  render() {
    // List availabilities
    const availabilities = this.state.availabilities.map((a) => {
      const { id, name, position } = a;
      return (
        <div key={id} className="item">
          <div className="right floated content">
            <button
            className="circular ui mini icon button red"
            onClick={() => this.deleteAvailability(a)}
            >
              <i className="trash icon"></i>
            </button>
          </div>
          <div className="content">{name}</div>
        </div>
      );
    });

    if (this.state.isLoading) return "Loading...";
    else {
      return (
        <div>
          <div className="ui middle aligned divided list">{availabilities}</div>

          
          
        </div>
      );
    }
  }
}

export default AvailabilityList;
