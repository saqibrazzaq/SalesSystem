import { Button, ButtonGroup, Grid, Typography } from "@mui/material";
import { Box } from "@mui/system";
import React, { useEffect, useState } from "react";
import { Link, Outlet } from "react-router-dom";
import * as OsService from "../../../../../Services/OsService";
import OsVersionList from './OsVersionList'

function OsVersionHome() {

  // Items list
  const [items, setItems] = useState([]);

  const itemList = items.map((item) => (
    <Button
      style={{ minWidth: "80px" }}
      component={Link}
      to={"list/" + item.id}
      key={item.id}
    >
      {item.name}
    </Button>
  ));

  useEffect(() => {
    // Get items
    OsService.getAllOSes().then((res) => {
      // Read api response
      if (res.status === 200 && res.data.success) {
        setItems(res.data.data);
      }
    });
  }, []);

  return (
    <>
      <Typography variant="h6">OS Versions</Typography>

      <ButtonGroup variant="text" aria-label="text button group" sx={{ mb: 2 }}>
        {itemList}
      </ButtonGroup>

      <Outlet />
    </>
  )
}

export default OsVersionHome