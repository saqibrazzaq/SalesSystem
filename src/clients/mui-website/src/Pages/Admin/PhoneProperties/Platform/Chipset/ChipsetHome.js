import { Button, Grid, Typography } from '@mui/material'
import { Box } from '@mui/system'
import React from 'react'
import { Link } from 'react-router-dom'
import ChipsetList from './ChipsetList'

function ChipsetHome() {
  return (
    <>
      <Grid container>
        <Grid item xs={6}>
          <Typography variant='h6'>Chipset</Typography>
        </Grid>
        <Grid item xs={6}>
        <Box display="flex" justifyContent="flex-end">
            <Button variant="contained" component={Link} to="/admin/platform/chipset/edit">
              Add New Chipset
            </Button>
          </Box>
        </Grid>
      </Grid>

      <hr />
      <ChipsetList />
    </>
  )
}

export default ChipsetHome