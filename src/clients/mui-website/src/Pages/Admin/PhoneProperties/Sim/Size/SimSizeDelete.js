import { Alert, Button, TextField, Typography } from "@mui/material";
import React, { useEffect, useState } from "react";
import { useParams, Link, useNavigate } from "react-router-dom";
import * as SimSizeService from "../../../../../Services/SimSizeService";
import { Box } from "@mui/system";

function SimSizeDelete() {
  const { id } = useParams();
  const navigate = useNavigate();
  const mainUrl = "/admin/sim/size";
  const [simSize, setSimSize] = useState({ id: "", name: "" });
  const [error, setError] = useState("");

  // Load sim size
  useEffect(() => {
    SimSizeService.getSimSize(id)
      .then((res) => {
        if (res.status === 200 && res.data.success) {
          setSimSize(res.data.data);
        }
      })
      .catch((err) => setError("Cannot find Sim Size"));
  }, []);

  function handleSubmit(e) {
    SimSizeService.deleteSimSize(id);
    navigate(mainUrl);
    navigate(0);
    e.preventDefault();
  }

  return (
    <>
      <Typography variant="h6">Delete Sim Size</Typography>

      {error && (
        <Alert sx={{ mt: 2, mb: 2 }} severity="error">
          {error}
        </Alert>
      )}

<form onSubmit={handleSubmit}>
        <Box sx={{ mt: 2 }}>
          <input readOnly hidden id="id" name="id" value={id} />

          <Typography variant="body1">
            Are you sure you want to DELETE the following Sim Size?
          </Typography>

          <Typography variant="h4">{simSize.name}</Typography>
        </Box>

        <Box sx={{ mt: 2 }}>
          <Button color="error" variant="contained" type="submit">
            YES, I WANT TO DELETE THE SIM Size
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

export default SimSizeDelete;
