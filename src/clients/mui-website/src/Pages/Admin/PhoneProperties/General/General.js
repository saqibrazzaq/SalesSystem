import * as React from "react";
import Box from "@mui/material/Box";
import { Link, NavLink, Outlet } from "react-router-dom";
import { Button, ButtonGroup, Typography } from "@mui/material";

const data = [
  { label: "Brand", url: "/admin/general/brand" },
  { label: "Availability", url: "/admin/general/availability" },
];

function General() {
  let activeStyle = {
    textDecoration: "underline",
  };
  return (
    <>
      <Typography variant="h4">General Settings</Typography>
      <ButtonGroup variant="text" aria-label="text button group" sx={{ mb: 2 }}>
        {data.map((item) => (
          <Button
            component={NavLink}
            to={item.url}
            key={item.url}
            style={({ isActive }) => (isActive ? activeStyle : undefined)}
          >
            {item.label}
          </Button>
        ))}
      </ButtonGroup>
      <Outlet />
    </>
  );
}

export default General;
