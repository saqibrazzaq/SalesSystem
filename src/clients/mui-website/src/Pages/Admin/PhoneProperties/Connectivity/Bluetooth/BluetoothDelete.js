import { Alert, Button, TextField, Typography } from "@mui/material";
import React, { useEffect, useState } from "react";
import { useParams, Link, useNavigate } from "react-router-dom";
import * as BluetoothService from "../../../../../Services/BluetoothService";
import { Box } from "@mui/system";

function BluetoothDelete() {
  const { id } = useParams();
  const navigate = useNavigate();
  const mainUrl = "/admin/connectivity/bluetooth";
  const [bluetooth, setBluetooth] = useState({ id: "", name: "" });
  const [error, setError] = useState("");

  // Load bluetooth
  useEffect(() => {
    BluetoothService.getBluetooth(id)
      .then((res) => {
        if (res.status === 200 && res.data.success) {
          setBluetooth(res.data.data);
        }
      })
      .catch((err) => setError("Cannot find Bluetooth"));
  }, []);

  function handleSubmit(e) {
    BluetoothService.deleteBluetooth(id);
    navigate(mainUrl);
    navigate(0);
    e.preventDefault();
  }

  return (
    <>
      <Typography variant="h6">Delete Bluetooth</Typography>

      {error && (
        <Alert sx={{ mt: 2, mb: 2 }} severity="error">
          {error}
        </Alert>
      )}

      <form onSubmit={handleSubmit}>
        <Box sx={{ mt: 2 }}>
          <input readOnly hidden id="id" name="id" value={id} />

          <Typography variant="body1">
            Are you sure you want to DELETE the following Bluetooth?
          </Typography>

          <Typography variant="h4">{bluetooth.name}</Typography>
        </Box>

        <Box sx={{ mt: 2 }}>
          <Button color="error" variant="contained" type="submit">
            YES, I WANT TO DELETE THE BLUETOOTH
          </Button>
          <Button
            component={Link}
            to={mainUrl}
            sx={{ ml: 1, background: "grey" }}
            variant="contained"
          >
            Back
          </Button>
        </Box>
      </form>
    </>
  );
}

export default BluetoothDelete