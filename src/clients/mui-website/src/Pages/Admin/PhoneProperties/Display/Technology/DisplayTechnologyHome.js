import { Button, Grid, Typography } from '@mui/material'
import { Box } from '@mui/system'
import React from 'react'
import { Link } from 'react-router-dom'
import DisplayTechnologyList from './DisplayTechnologyList'

function DisplayTechnologyHome() {
  return (
    <>
      <Grid container>
        <Grid item xs={6}>
          <Typography variant='h6'>Display Technology</Typography>
        </Grid>
        <Grid item xs={6}>
        <Box display="flex" justifyContent="flex-end">
            <Button variant="contained" component={Link} to="/admin/display/technology/edit">
              Add New Display Technology
            </Button>
          </Box>
        </Grid>
      </Grid>

      <hr />
      <DisplayTechnologyList />
    </>
  )
}

export default DisplayTechnologyHome