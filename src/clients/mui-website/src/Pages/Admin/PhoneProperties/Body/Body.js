import { Button, ButtonGroup, Typography } from "@mui/material";
import React from "react";
import { NavLink, Outlet } from "react-router-dom";

const data = [
  { label: "Back Material", url: "/admin/body/back-material" },
  { label: "Frame Material", url: "/admin/body/frame-material" },
  { label: "Form Factor", url: "/admin/body/form-factor" },
  { label: "IP Certificate", url: "/admin/body/ip-certificate" },
];

function Body() {
  let activeStyle = {
    textDecoration: "underline",
  };

  return (
    <>
      <Typography variant="h4">Body Settings</Typography>

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

export default Body;
