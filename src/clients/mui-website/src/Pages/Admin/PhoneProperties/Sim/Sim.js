import { Button, ButtonGroup, Typography } from '@mui/material';
import React from 'react'
import { NavLink, Outlet } from 'react-router-dom';

const data = [
  {label: 'Size', url: '/admin/sim/size'},
  {label: 'multiple', url: '/admin/sim/multiple'}
];

function Sim() {

  let activeStyle = {
    textDecoration: "underline",
  };

  return (
    <>
      <Typography variant='h4'>Sim Settings</Typography>

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

export default Sim