import { Alert, Button, TextField, Typography } from "@mui/material";
import React, { useEffect, useState } from "react";
import { useParams, Link, useNavigate } from "react-router-dom";
import * as NetworkBandService from "../../../../../Services/NetworkBandService";
import { Box } from "@mui/system";

function NetworkBandDelete() {
  const { id } = useParams();
  const navigate = useNavigate();
  const [band, setBand] = useState({
    id: "",
    name: "",
    networkId: "",
    networkName: "",
  });
  let mainUrl = "/admin/network/band/list";
  const [error, setError] = useState("");

  // Load band
  useEffect(() => {
    NetworkBandService.getBand(id)
      .then((res) => {
        if (res.status === 200 && res.data.success) {
          // console.log(res.data.data);
          setBand(res.data.data);
        }
      })
      .catch((err) => setError("Cannot find Network"));
  }, []);

  function handleSubmit(e) {
    NetworkBandService.deleteBand(id);
    navigate(mainUrl + "/" + band.networkId);
    navigate(0);
    e.preventDefault();
  }

  return (
    <>
      <Typography variant="h6">Delete {band.networkName} Band</Typography>

      {error && (
        <Alert sx={{ mt: 2, mb: 2 }} severity="error">
          {error}
        </Alert>
      )}

      <form onSubmit={handleSubmit}>
        <Box sx={{ mt: 2 }}>
          <input readOnly hidden id="id" name="id" value={id} />

          <Typography variant="body1">
            Are you sure you want to DELETE the following Band?
          </Typography>

          <Typography variant="h4">{band.name}</Typography>
        </Box>

        <Box sx={{ mt: 2 }}>
          <Button color="error" variant="contained" type="submit">
            YES, I WANT TO DELETE THE BAND
          </Button>
          <Button
            component={Link}
            to={mainUrl + "/" + band.networkId}
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

export default NetworkBandDelete;
