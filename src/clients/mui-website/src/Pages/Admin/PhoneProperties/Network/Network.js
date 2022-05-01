import { Link, Outlet } from "react-router-dom";
import { Button, ButtonGroup, Typography } from "@mui/material";
import React from 'react'

const data = [
  { label: "2G", url: "/admin/network/2g" },
  { label: "3G", url: "/admin/network/3g" },
  { label: "4G", url: "/admin/network/4g" },
  { label: "5G", url: "/admin/network/5g" },
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