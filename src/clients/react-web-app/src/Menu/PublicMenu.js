import React, { Component } from "react";
import { Link } from "react-router-dom";

export class PublicMenu extends Component {
  render() {
    return (
      <div className="ui blue inverted menu">
        <div className="header item">Cell Store</div>
        <Link to="/home" className="item">Home</Link>
        <Link to="/admin/home" className="item">Admin</Link>
      </div>
    );
  }
}

export default PublicMenu;
