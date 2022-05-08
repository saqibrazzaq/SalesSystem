import { Button, Grid, Typography } from '@mui/material'
import { Box } from '@mui/system'
import React from 'react'
import { Link } from 'react-router-dom'
import OsList from './OsList'

function OsHome() {
  return (
    <>
      <Grid container>
        <Grid item xs={6}>
          <Typography variant='h6'>OS</Typography>
        </Grid>
        <Grid item xs={6}>
        <Box display="flex" justifyContent="flex-end">
            <Button variant="contained" component={Link} to="/admin/platform/os/edit">
              Add OS
            </Button>
          </Box>
        </Grid>
      </Grid>

      <hr />
      <OsList />
    </>
  )
}

export default OsHome