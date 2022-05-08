import { Button, Grid, Typography } from "@mui/material";
import { Box } from "@mui/system";
import React from "react";
import { Link } from "react-router-dom";
import FormFactorList from "./FormFactorList";

function FormFactorHome() {
  return (
    <>
      <Grid container>
        <Grid item xs={6}>
          <Typography variant="h6">Form Factor</Typography>
        </Grid>
        <Grid item xs={6}>
          <Box display="flex" justifyContent="flex-end">
            <Button
              variant="contained"
              component={Link}
              to="/admin/body/form-factor/edit"
            >
              Add New Form Factor
            </Button>
          </Box>
        </Grid>
      </Grid>

      <hr />
      <FormFactorList />
    </>
  );
}

export default FormFactorHome;
