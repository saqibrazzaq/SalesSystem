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
import * as BluetoothService from "../../../../../Services/BluetoothService";

function BluetoothList() {
  // Loading state
  const [loading, setLoading] = useState(true);
  // Items
  const [items, setItems] = useState([]);

  // Items list
  const itemList = items.map((item) => {
    return (
      <ListItem
        sx={{ padding: "0" }}
        key={item.id}
        secondaryAction={
          <Box>
            <IconButton
              component={Link}
              to={`/admin/connectivity/bluetooth/edit/${item.id}`}
            >
              <EditIcon />
            </IconButton>
            <IconButton
              component={Link}
              to={`/admin/connectivity/bluetooth/delete/${item.id}`}
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

  // Get items
  useEffect(() => {
    BluetoothService.getAllBluetooths().then((res) => {
      if (res.status === 200 && res.data.success) {
        // console.log(res.data.data)
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
  )
}

export default BluetoothList