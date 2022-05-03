import {
  IconButton,
  List,
  ListItem,
  ListItemButton,
  ListItemText,
  Typography,
} from "@mui/material";
import { Box } from "@mui/system";
import { Link } from "react-router-dom";
import EditIcon from "@mui/icons-material/Edit";
import DeleteIcon from "@mui/icons-material/Delete";
import React, { useEffect, useState } from "react";
import * as NetworkService from "../../../../../Services/NetworkService";

function NetworkList() {
  // Loading
  const [loading, setLoading] = useState(true);
  // Items list
  const [items, setItems] = useState([]);

  const itemList = items.map((item) => {
    return (
      <ListItem
        sx={{ padding: "0" }}
        key={item.id}
        secondaryAction={
          <Box>
            <IconButton
              component={Link}
              to={`/admin/network/network-edit/${item.id}`}
            >
              <EditIcon />
            </IconButton>
            <IconButton
              component={Link}
              to={`/admin/network/network-delete/${item.id}`}
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

  useEffect(() => {
    // Get items
    NetworkService.getAllNetworks().then((res) => {
      // Read api response
      if (res && res.status === 200 && res.data.success) {
        setItems(res.data.data);
        setLoading(false);
      }
    });
  }, []);

  return (
    <>
      {loading && <Typography>Loading...</Typography>}

      <List>{!loading && itemList}</List>
    </>
  );
}

export default NetworkList;
