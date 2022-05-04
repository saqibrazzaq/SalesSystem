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
import * as AvailabilityService from '../../../../../Services/AvailabilityService'

function AvailabilityList() {
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
              to={`/admin/general/availability/edit/${item.id}`}
            >
              <EditIcon />
            </IconButton>
            <IconButton
              component={Link}
              to={`/admin/general/availability/delete/${item.id}`}
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
    AvailabilityService.getAllAvailabilities().then(res => {
      // Read api response
      if (res && res.status === 200 && res.data.data) {
        setItems(res.data.data);
        setLoading(false);
      }
    })
  }, []);

  return (
    <>
      {loading && <Typography>Loading...</Typography>}

      <List>{!loading && itemList}</List>
    </>
  );
}

export default AvailabilityList;
