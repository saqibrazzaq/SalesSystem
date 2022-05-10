import { Button, Grid, Typography } from '@mui/material'
import { Box } from '@mui/system'
import React from 'react'
import { Link } from 'react-router-dom'
import BatteryTypeList from './BatteryTypeList'

function BatteryTypeHome() {
  return (
    <>
      <Grid container>
        <Grid item xs={6}>
          <Typography variant='h6'>Battery Type</Typography>
        </Grid>
        <Grid item xs={6}>
        <Box display="flex" justifyContent="flex-end">
            <Button variant="contained" component={Link} to="/admin/battery/type/edit">
              Add New Battery Type
            </Button>
          </Box>
        </Grid>
      </Grid>

      <hr />
      <BatteryTypeList />
    </>
  )
}

export default BatteryTypeHome