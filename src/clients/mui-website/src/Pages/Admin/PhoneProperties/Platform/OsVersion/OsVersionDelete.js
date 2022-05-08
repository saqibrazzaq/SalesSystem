import { Alert, Button, TextField, Typography } from "@mui/material";
import React, { useEffect, useState } from "react";
import { useParams, Link, useNavigate } from "react-router-dom";
import * as OsVersionService from "../../../../../Services/OsVersionService";
import { Box } from "@mui/system";

function OsVersionDelete() {
  const { id } = useParams();
  const navigate = useNavigate();
  const [osVersion, setOsVersion] = useState({
    id: "",
    name: "",
    osId: "",
    osName: "",
  });
  let mainUrl = "/admin/platform/os-version/list";
  const [error, setError] = useState("");

  // Load os version
  useEffect(() => {
    OsVersionService.getOSVersion(id)
      .then((res) => {
        if (res.status === 200 && res.data.success) {
          // console.log(res.data.data);
          setOsVersion(res.data.data);
        }
      })
      .catch((err) => setError("Cannot find OS Version"));
  }, []);

  function handleSubmit(e) {
    OsVersionService.deleteOSVersion(id);
    navigate(mainUrl + "/" + osVersion.osId);
    navigate(0);
    e.preventDefault();
  }

  return (
    <>
      <Typography variant="h6">Delete {osVersion.osName} Version</Typography>

      {error && (
        <Alert sx={{ mt: 2, mb: 2 }} severity="error">
          {error}
        </Alert>
      )}

      <form onSubmit={handleSubmit}>
        <Box sx={{ mt: 2 }}>
          <input readOnly hidden id="id" name="id" value={id} />

          <Typography variant="body1">
            Are you sure you want to DELETE the following OS Version?
          </Typography>

          <Typography variant="h4">{osVersion.name}</Typography>
        </Box>

        <Box sx={{ mt: 2 }}>
          <Button color="error" variant="contained" type="submit">
            YES, I WANT TO DELETE THE OS VERSION
          </Button>
          <Button
            component={Link}
            to={mainUrl + "/" + osVersion.osId}
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

export default OsVersionDelete