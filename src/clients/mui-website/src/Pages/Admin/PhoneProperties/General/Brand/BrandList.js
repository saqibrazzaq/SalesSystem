import {
  IconButton,
  List,
  ListItem,
  ListItemButton,
  ListItemText,
  Typography,
} from "@mui/material";
import { Box } from "@mui/system";
import React, { useEffect, useState } from "react";
import Api from "../../../../../Api/Api";
import EditIcon from "@mui/icons-material/Edit";
import DeleteIcon from "@mui/icons-material/Delete";
import { Link } from "react-router-dom";
import * as BrandService from '../../../../../Services/BrandService'

function BrandList() {
  // Loading true
  const [loading, setLoading] = useState(true);
  // Empty list
  const [items, setItems] = useState([]);

  // Get items
  useEffect(() => {
    // Loading
    setLoading(true);
    // Get items
    
    BrandService.getAllBrands().then((res) => {
      // Read api response
      if (res && res.status === 200 && res.data.success) {
        // console.log(res.data.data);
        setItems(res.data.data);
        setLoading(false);
      }
    });
  }, []);

  // create list from api response
  const itemList = items.map((item) => {
    return (
      <ListItem
        sx={{ padding: "0" }}
        key={item.id}
        secondaryAction={
          <Box>
            <IconButton
              component={Link}
              to={`/admin/general/brand/edit/${item.id}`}
            >
              <EditIcon />
            </IconButton>
            <IconButton
            component={Link}
            to={`/admin/general/brand/delete/${item.id}`}>
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

  return (
    <>
      {loading && <Typography>Loading...</Typography>}

      <List>{!loading && itemList}</List>
    </>
  );
}

export default BrandList;
