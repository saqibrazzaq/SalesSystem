import { Link, NavLink, Outlet } from "react-router-dom";
import { Button, ButtonGroup, Typography } from "@mui/material";
import React from "react";

const data = [
  { label: "Network", url: "/admin/network/network" },
  { label: "Band", url: "/admin/network/band" },
];

function Network() {
  let activeStyle = {
    textDecoration: "underline",
  };
  return (
    <>
      <Typography variant="h4">Network Settings</Typography>
      <ButtonGroup variant="text" aria-label="text button group" sx={{ mb: 2 }}>
        {data.map((item) => (
          <Button
            sx={{ minWidth: "80px" }}
            component={NavLink}
            to={item.url}
            key={item.url}
            style={({ isActive }) => (isActive ? activeStyle : undefined) }
          >
            {item.label}
          </Button>
        ))}
      </ButtonGroup>
      <Outlet />
    </>
  );
}

export default Network;
