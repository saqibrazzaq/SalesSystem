import {
  IconButton,
  List,
  ListItem,
  ListItemButton,
  ListItemText,
  Typography,
  Alert,
  Grid,
  Button,
} from "@mui/material";
import { Link } from "react-router-dom";
import EditIcon from "@mui/icons-material/Edit";
import DeleteIcon from "@mui/icons-material/Delete";
import { Box } from "@mui/system";

import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import * as NetworkService from "../../../../../Services/NetworkService";
import * as NetworkBandService from "../../../../../Services/NetworkBandService";

function NetworkBandList() {
  const { networkId } = useParams();
  const [network, setNetwork] = useState({ id: "", name: "" });
  const [error, setError] = useState("");
  const [items, setItems] = useState([]);
  // Loading
  const [loading, setLoading] = useState(true);

  const itemList = items.map((item) => {
    return (
      <ListItem
        sx={{ padding: "0" }}
        key={item.id}
        secondaryAction={
          <Box>
            <IconButton
              component={Link}
              to={`/admin/network/band/edit/${item.id}?networkId=${networkId}`}
            >
              <EditIcon />
            </IconButton>
            <IconButton
              component={Link}
              to={`/admin/network/band/delete/${item.id}`}
            >
              <DeleteIcon color="error" />
            </IconButton>
          </Box>
        }
      >
        <ListItemButton>
          <ListItemText primary={item.name}></ListItemText>
        </ListItemButton>
      </ListItem>
    );
  });

  // Load network info
  useEffect(() => {
    NetworkService.getNetwork(networkId)
      .then((res) => {
        if (res.status === 200 && res.data.success) {
          setNetwork(res.data.data);
        } else {
          setError("Error getting network information");
        }
      })
      .catch((err) => {
        setError("Error getting network information");
        console.log(err);
      });
  }, [networkId]);

  // Load Network bands
  useEffect(() => {
    NetworkBandService.getAllBands(networkId)
      .then((res) => {
        setError('')
        if (res.status === 200 && res.data.success) {
          setItems(res.data.data);
          setLoading(false);
        } else {
          setError("Error loading network bands");
          setItems([]);
        }
      })
      .catch((err) => {
        setError("Error loading network bands");
        setItems([]);
      });
  }, [networkId]);

  return (
    <>
    <Grid container>
      <Grid item xs={6}>
      <Typography variant="h6">{network.name} Bands</Typography>
      </Grid>
      <Grid item xs={6}>
      <Box display="flex" justifyContent="flex-end">
            <Button
              variant="contained"
              component={Link}
              to={`/admin/network/band/edit?networkId=${networkId}`}
            >
              Add New {network.name} Band
            </Button>
          </Box>
      </Grid>
    </Grid>
      

      {error && (
        <Alert sx={{ mt: 2, mb: 2 }} severity="error">
          {error}
        </Alert>
      )}

      {loading && <Typography>Loading...</Typography>}

      <List>{!loading && itemList}</List>
    </>
  );
}

export default NetworkBandList;
