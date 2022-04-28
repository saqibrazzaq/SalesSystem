import React, { Component } from "react";
import { Outlet } from "react-router-dom";
import AdminMenu from "../../Menu/AdminMenu";

export class AdminHomeIndex extends Component {
  render() {
    return (
      <div className="ui  stackable grid">
        <div className="four wide column ">
          <AdminMenu />
        </div>
        <div className=" twelve wide column ">
          <div className="ui segment stackable">
            <Outlet />
          </div>
        </div>
      </div>
    );
  }
}

export default AdminHomeIndex;
