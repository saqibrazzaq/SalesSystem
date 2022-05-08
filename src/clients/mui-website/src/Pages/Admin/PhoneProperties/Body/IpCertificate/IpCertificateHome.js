import { Button, Grid, Typography } from "@mui/material";
import { Box } from "@mui/system";
import React from "react";
import { Link } from "react-router-dom";
import IpCertificateList from "./IpCertificateList";

function IpCertificateHome() {
  return (
    <>
      <Grid container>
        <Grid item xs={6}>
          <Typography variant="h6">Ip Certificate</Typography>
        </Grid>
        <Grid item xs={6}>
          <Box display="flex" justifyContent="flex-end">
            <Button
              variant="contained"
              component={Link}
              to="/admin/body/ip-certificate/edit"
            >
              Add New Ip Certificate
            </Button>
          </Box>
        </Grid>
      </Grid>

      <hr />
      <IpCertificateList />
    </>
  )
}

export default IpCertificateHome