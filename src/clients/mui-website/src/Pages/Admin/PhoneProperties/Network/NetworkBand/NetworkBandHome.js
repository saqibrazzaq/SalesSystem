import { Button, ButtonGroup, Grid, Typography } from "@mui/material";
import { Box } from "@mui/system";
import React, { useEffect, useState } from "react";
import { Link, Outlet } from "react-router-dom";
import * as NetworkService from "../../../../../Services/NetworkService";
import NetworkBandList from "./NetworkBandList";

function NetworkBandHome() {
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
    NetworkService.getAllNetworks().then((res) => {
      // Read api response
      if (res.status === 200 && res.data.success) {
        setItems(res.data.data);
      }
    });
  }, []);

  return (
    <>
      <Typography variant="h6">Network Bands</Typography>

      <ButtonGroup variant="text" aria-label="text button group" sx={{ mb: 2 }}>
        {itemList}
      </ButtonGroup>

      <Outlet />
    </>
  );
}

export default NetworkBandHome;
