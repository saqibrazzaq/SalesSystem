import { Grid } from "@mui/material";
import React from "react";
import { Outlet } from "react-router-dom";
import AdminMenu from "../../Components/AdminMenu/AdminMenu";

function Admin() {
  return (
    <Grid container spacing={2}>
      <Grid item xs={6} sm={4} md={3}>
        <AdminMenu />
      </Grid>
      <Grid item xs={6} sm={8} md={9}>
        <Outlet />
      </Grid>
    </Grid>
  );
}

export default Admin;
