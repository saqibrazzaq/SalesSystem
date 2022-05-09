import { Button, Grid, Typography } from '@mui/material'
import { Box } from '@mui/system'
import React from 'react'
import { Link } from 'react-router-dom'
import BluetoothList from './BluetoothList'

function BluetoothHome() {
  return (
    <>
      <Grid container>
        <Grid item xs={6}>
          <Typography variant='h6'>Bluetooth</Typography>
        </Grid>
        <Grid item xs={6}>
        <Box display="flex" justifyContent="flex-end">
            <Button variant="contained" component={Link} to="/admin/connectivity/bluetooth/edit">
              Add New Bluetooth
            </Button>
          </Box>
        </Grid>
      </Grid>

      <hr />
      <BluetoothList />
    </>
  )
}

export default BluetoothHome