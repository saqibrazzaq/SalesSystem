import { Button, ButtonGroup, Typography } from '@mui/material';
import React from 'react'
import { NavLink, Outlet } from 'react-router-dom';

const data = [
  {label: 'OS', url: '/admin/platform/os'},
  {label: 'OS Version', url: '/admin/platform/os-version'},
  {label: 'Chipset', url: '/admin/platform/chipset'}
];

function Platform() {

  let activeStyle = {
    textDecoration: "underline",
  };

  return (
    <>
      <Typography variant='h4'>Platform Settings</Typography>

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
  )
}

export default Platform