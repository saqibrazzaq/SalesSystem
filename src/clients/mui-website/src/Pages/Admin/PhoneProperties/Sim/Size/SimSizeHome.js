import { Button, Grid, Typography } from '@mui/material'
import { Box } from '@mui/system'
import React from 'react'
import { Link } from 'react-router-dom'
import SimSizeList from './SimSizeList'

function SimSizeHome() {
  return (
    <>
<Grid container>
        <Grid item xs={6}>
          <Typography variant='h6'>Sim Size</Typography>
        </Grid>
        <Grid item xs={6}>
        <Box display="flex" justifyContent="flex-end">
            <Button variant="contained" component={Link} to="/admin/sim/size/edit">
              Add New Sim Size
            </Button>
          </Box>
        </Grid>
      </Grid>

      <hr />
      <SimSizeList />  
    </>
  )
}

export default SimSizeHome