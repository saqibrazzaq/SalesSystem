import React, { Component } from "react";
import { Link } from "react-router-dom";
import api from "../../../api/api";
import AvailabilityList from "./AvailabilityList";

export class AvailabilitiesHome extends Component {
  constructor(props) {
    super(props);

    // Default values
    this.state = { availabilities: [] };
  }

  componentDidMount() {
    this.loadAvailabilities();
  }

  loadAvailabilities() {
    api
      .get("/availabilities")
      .then((res) => {
        if (res.data && res.data.success === true) {
          this.setState({ availabilities: res.data.data });
          // console.log(res.data.data);
        }
      })
      .catch(() => console.log("Error loading availabilities"));
  }

  render() {
    let items;
    if (this.state.availabilities.length) {
      items = <AvailabilityList items={this.state.availabilities} />;
    } else {
      items = <p>No availabilities found</p>;
    }
    return (
      <div className="">
        <div className="ui two column grid">
          <div className="column py-4">
            <h2>Availability</h2>
          </div>
          <div className="column">
            <button className="ui button right floated">Back</button>
            <Link
              to="/admin/home/availability-edit"
              className="ui primary button right floated"
            >
              Add New
            </Link>
          </div>
        </div>

        <hr />

        {items}
      </div>
    );
  }
}

export default AvailabilitiesHome;
