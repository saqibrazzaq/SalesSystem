import { Button, Grid, Typography } from '@mui/material'
import { Box } from '@mui/system'
import React from 'react'
import { Link } from 'react-router-dom'
import SimMultipleList from './SimMultipleList'

function SimMultipleHome() {
  return (
    <>
      <Grid container>
        <Grid item xs={6}>
          <Typography variant='h6'>Sim Multiples</Typography>
        </Grid>
        <Grid item xs={6}>
        <Box display="flex" justifyContent="flex-end">
            <Button variant="contained" component={Link} to="/admin/sim/multiple/edit">
              Add New Sim Multiple
            </Button>
          </Box>
        </Grid>
      </Grid>

      <hr />
      <SimMultipleList />
    </>
  )
}

export default SimMultipleHome