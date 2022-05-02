import { Button, Grid, Typography } from '@mui/material'
import { Box } from '@mui/system'
import React from 'react'
import { Link } from "react-router-dom";
import AvailabilityList from './AvailabilityList';

function AvailabilityHome() {
  return (
    <>
      <Grid container>
        <Grid item xs={6}>
          <Typography variant="h6">Availability</Typography>
        </Grid>
        <Grid item xs={6}>
          <Box display="flex" justifyContent="flex-end">
            <Button variant="contained" component={Link} to="/admin/general/availability-edit">
              Add New Availability
            </Button>
          </Box>
        </Grid>
      </Grid>

      <hr />
      <AvailabilityList />
    </>
  )
}

export default AvailabilityHome