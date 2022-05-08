import { Button, Grid, Typography } from "@mui/material";
import { Box } from "@mui/system";
import React from "react";
import { Link } from "react-router-dom";
import FrameMaterialList from "./FrameMaterialList";

function FrameMaterialHome() {
  return (
    <>
      <Grid container>
        <Grid item xs={6}>
          <Typography variant="h6">Frame Material</Typography>
        </Grid>
        <Grid item xs={6}>
          <Box display="flex" justifyContent="flex-end">
            <Button
              variant="contained"
              component={Link}
              to="/admin/body/frame-material/edit"
            >
              Add New Frame Material
            </Button>
          </Box>
        </Grid>
      </Grid>

      <hr />
      <FrameMaterialList />
    </>
  )
}

export default FrameMaterialHome