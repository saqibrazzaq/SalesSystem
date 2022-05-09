import { Button, Grid, Typography } from '@mui/material'
import { Box } from '@mui/system'
import React from 'react'
import { Link } from 'react-router-dom'
import CameraTypeList from './CameraTypeList'

function CameraTypeHome() {
  return (
    <>
      <Grid container>
        <Grid item xs={6}>
          <Typography variant='h6'>Camera Type</Typography>
        </Grid>
        <Grid item xs={6}>
        <Box display="flex" justifyContent="flex-end">
            <Button variant="contained" component={Link} to="/admin/camera/type/edit">
              Add New Camera Type
            </Button>
          </Box>
        </Grid>
      </Grid>

      <hr />
      <CameraTypeList />
    </>
  )
}

export default CameraTypeHome