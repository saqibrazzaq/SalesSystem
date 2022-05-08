import { Alert, Button, TextField, Typography } from "@mui/material";
import React, { useEffect, useState } from "react";
import { useParams, Link, useNavigate } from "react-router-dom";
import * as OsService from "../../../../../Services/OsService";
import { Box } from "@mui/system";

function OsDelete() {
  const { id } = useParams();
  const navigate = useNavigate();
  const mainUrl = "/admin/platform/os";
  const [os, setOs] = useState({ id: "", name: "" });
  const [error, setError] = useState("");

  // Load os
  useEffect(() => {
    OsService.getOS(id)
      .then((res) => {
        if (res.status === 200 && res.data.success) {
          setOs(res.data.data);
        }
      })
      .catch((err) => setError("Cannot find OS"));
  }, []);

  function handleSubmit(e) {
    OsService.deleteOS(id);
    navigate(mainUrl);
    navigate(0);
    e.preventDefault();
  }

  return (
    <>
      <Typography variant="h6">Delete OS</Typography>

      {error && (
        <Alert sx={{ mt: 2, mb: 2 }} severity="error">
          {error}
        </Alert>
      )}

      <form onSubmit={handleSubmit}>
        <Box sx={{ mt: 2 }}>
          <input readOnly hidden id="id" name="id" value={id} />

          <Typography variant="body1">
            Are you sure you want to DELETE the following OS?
          </Typography>

          <Typography variant="h4">{os.name}</Typography>
        </Box>

        <Box sx={{ mt: 2 }}>
          <Button color="error" variant="contained" type="submit">
            YES, I WANT TO DELETE THE OS
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

export default OsDelete