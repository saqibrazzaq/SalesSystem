import { Button, Grid, Typography } from "@mui/material";
import { Box } from "@mui/system";
import React from "react";
import { Link } from "react-router-dom";
import NetworkList from "./NetworkList";

function NetworkHome() {
  return (
    <>
      <Grid container>
        <Grid item xs={6}>
          <Typography variant="h6">Network</Typography>
        </Grid>
        <Grid item xs={6}>
          <Box display="flex" justifyContent="flex-end">
            <Button
              variant="contained"
              component={Link}
              to="/admin/network/network/edit"
            >
              Add New Network
            </Button>
          </Box>
        </Grid>
      </Grid>

      <hr />
      <NetworkList />
    </>
  );
}

export default NetworkHome;
