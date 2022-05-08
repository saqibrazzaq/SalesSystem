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
import * as OsService from "../../../../../Services/OsService";
import * as OsVersionService from "../../../../../Services/OsVersionService";

function OsVersionList() {
  const { osId } = useParams();
  const [os, setOs] = useState({ id: "", name: "" });
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
              to={`/admin/platform/os-version/edit/${item.id}?osId=${osId}`}
            >
              <EditIcon />
            </IconButton>
            <IconButton
              component={Link}
              to={`/admin/platform/os-version/delete/${item.id}`}
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

  // Load os info
  useEffect(() => {
    OsService.getOS(osId)
      .then((res) => {
        if (res.status === 200 && res.data.success) {
          setOs(res.data.data);
        } else {
          setError("Error getting OS information");
        }
      })
      .catch((err) => {
        setError("Error getting OS information");
        console.log(err);
      });
  }, [osId]);

  // Load os versions
  useEffect(() => {
    OsVersionService.getAllOSVersions([osId])
      .then((res) => {
        setError('')
        if (res.status === 200 && res.data.success) {
          setItems(res.data.data);
          setLoading(false);
        } else {
          setError("Error loading OS Versions");
          setItems([]);
        }
      })
      .catch((err) => {
        setError("Error loading OS Versions");
        setItems([]);
      });
  }, [osId]);

  return (
    <>
    <Grid container>
      <Grid item xs={6}>
      <Typography variant="h6">{os.name} Versions</Typography>
      </Grid>
      <Grid item xs={6}>
      <Box display="flex" justifyContent="flex-end">
            <Button
              variant="contained"
              component={Link}
              to={`/admin/platform/os-version/edit?osId=${osId}`}
            >
              Add New {os.name} Version
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

export default OsVersionList