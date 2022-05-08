import { Button, Grid, Typography } from "@mui/material";
import { Box } from "@mui/system";
import React from "react";
import { Link } from "react-router-dom";
import BackMaterialList from "./BackMaterialList";

function BackMaterialHome() {
  return (
    <>
      <Grid container>
        <Grid item xs={6}>
          <Typography variant="h6">Back Material</Typography>
        </Grid>
        <Grid item xs={6}>
          <Box display="flex" justifyContent="flex-end">
            <Button
              variant="contained"
              component={Link}
              to="/admin/body/back-material/edit"
            >
              Add New Back Material
            </Button>
          </Box>
        </Grid>
      </Grid>

      <hr />
      <BackMaterialList />
    </>
  );
}

export default BackMaterialHome;
