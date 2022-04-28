import React, { Component } from "react";
import { Link } from "react-router-dom";

export class AdminMenu extends Component {
  render() {
    return (
      <div className="ui fluid grey inverted vertical menu">
        <div className="item">
          <div className="header">Phone Properties</div>
          <div className="menu">
            <Link to="/admin/home/availabilities" className="item">Availability</Link>
            <Link to="/admin/home/back-material" className="item">Back Material</Link>
          </div>
        </div>
        <div className="item">
          <div className="header">CMS Solutions</div>
          <div className="menu">
            <a className="item">Rails</a>
            <a className="item">Python</a>
            <a className="item">PHP</a>
          </div>
        </div>
        <div className="item">
          <div className="header">Hosting</div>
          <div className="menu">
            <a className="item">Shared</a>
            <a className="item">Dedicated</a>
          </div>
        </div>
        <div className="item">
          <div className="header">Support</div>
          <div className="menu">
            <a className="item">E-mail Support</a>
            <a className="item">FAQs</a>
          </div>
        </div>
      </div>
    );
  }
}

export default AdminMenu;
