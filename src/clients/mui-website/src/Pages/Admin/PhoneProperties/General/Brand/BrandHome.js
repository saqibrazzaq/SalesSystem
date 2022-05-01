import { Button, Grid, Typography } from "@mui/material";
import { Box } from "@mui/system";
import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";

import BrandList from "./BrandList";

function BrandHome() {
  return (
    <>
      <Grid container>
        <Grid item xs={6}>
          <Typography variant="h6">Brands</Typography>
        </Grid>
        <Grid item xs={6}>
          <Box display="flex" justifyContent="flex-end">
            <Button
              component={Link}
              to="/admin/general/brand-edit"
              variant="contained"
            >
              Add New Brand
            </Button>
          </Box>
        </Grid>
      </Grid>

      <hr />
      <BrandList />
    </>
  );
}

export default BrandHome;
