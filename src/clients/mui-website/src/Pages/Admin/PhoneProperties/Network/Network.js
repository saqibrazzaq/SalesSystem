import { Link, Outlet } from "react-router-dom";
import { Button, ButtonGroup, Typography } from "@mui/material";
import React from 'react'

const data = [
  { label: "Network", url: "/admin/network/network" },
  { label: "Band", url: "/admin/network/band" },
];

function Network() {
  return (
    <>
      <Typography variant="h4">Network Settings</Typography>
      <ButtonGroup variant="text" aria-label="text button group" sx={{ mb: 2 }}>
        {data.map((item) => (
          <Button style={{minWidth: '80px'}} component={Link} to={item.url} key={item.url}>
            {item.label}
          </Button>
        ))}
      </ButtonGroup>
      <Outlet />
    </>
  )
}

export default Network