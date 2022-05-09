import { Button, Grid, Typography } from '@mui/material'
import { Box } from '@mui/system'
import React from 'react'
import { Link } from 'react-router-dom'
import WifiList from './WifiList'

function WifiHome() {
  return (
    <>
      <Grid container>
        <Grid item xs={6}>
          <Typography variant='h6'>Wifi</Typography>
        </Grid>
        <Grid item xs={6}>
        <Box display="flex" justifyContent="flex-end">
            <Button variant="contained" component={Link} to="/admin/connectivity/wifi/edit">
              Add New Wifi
            </Button>
          </Box>
        </Grid>
      </Grid>

      <hr />
      <WifiList />
    </>
  )
}

export default WifiHome